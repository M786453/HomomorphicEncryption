using Microsoft.Research.SEAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public TransactionHistory transactions_history_obj;
        public class Transaction
            {
                public int? Credit { get; set; }
                public int? Debit { get; set; }
            }


        public class TransactionHistory
        {
            public int DebitCharges { get; set; }
            public List<Transaction> Transactions { get; set; }

            public List<int> debitTransactions;

            public List<int> creditTransacctions;

            public List<Ciphertext> encryptedDebitTransactions;

            public List<Ciphertext> encryptedCreditTransactions;

            public Encryptor encryptor;

            public Evaluator evaluator;
            
            public Decryptor decryptor;
            
            public SEALContext context;

            public TransactionHistory() {

                debitTransactions = new List<int> { };
                creditTransacctions = new List<int> { };
                encryptedCreditTransactions = new List<Ciphertext> { };
                encryptedDebitTransactions = new List<Ciphertext> { };

                EncryptionParameters parms = new EncryptionParameters(SchemeType.BFV);

                ulong polyModulusDegree = 4096;
                parms.PolyModulusDegree = polyModulusDegree;
                parms.CoeffModulus = CoeffModulus.BFVDefault(polyModulusDegree);
                parms.PlainModulus = new Modulus(1024);

                context = new SEALContext(parms);


                if (context.ParameterErrorMessage() == "valid")
                {

                    KeyGenerator keygen = new KeyGenerator(context);

                    SecretKey secretKey = keygen.SecretKey;

                    keygen.CreatePublicKey(out PublicKey publicKey);

                    encryptor = new Encryptor(context, publicKey);

                    evaluator = new Evaluator(context);

                    decryptor = new Decryptor(context, secretKey);

                }
                else
                {
                    Console.WriteLine("Invalid Encryption Params");
                }

            }


            public string encryptTransactions()
            {
                if(context.ParameterErrorMessage() != "valid")
                {
                    return context.ParameterErrorMessage();
                }


                foreach (var transaction in Transactions)
                {
                    Ciphertext encryptedTransaction = new Ciphertext();

                    Plaintext plainTransaction;

                    if (transaction.Credit.HasValue)
                    {

                        int credit_trans = transaction.Credit.Value;

                        // Update Credit Transactions List

                        creditTransacctions.Add(credit_trans);


                        // Encrypt Transaction and Update Encrypted Credit Transactions List

                        plainTransaction = new Plaintext($"{credit_trans}");

                        encryptor.Encrypt(plainTransaction, encryptedTransaction);

                        encryptedCreditTransactions.Add(encryptedTransaction);

                    }
                    else if (transaction.Debit.HasValue)
                    {
                        int debit_trans = transaction.Debit.Value;

                        // Update Debit Transactions List

                        debitTransactions.Add(debit_trans);


                        // Encrypt Transaction and Update Encrypted Debit Transactions List

                        plainTransaction = new Plaintext($"{debit_trans}");

                        encryptor.Encrypt(plainTransaction, encryptedTransaction);

                        encryptedDebitTransactions.Add(encryptedTransaction);


                    }   

                }

                string output = "\nPlaintext Credit Transactions:\n";
                output += string.Join(", ", creditTransacctions);
                output += "\nPlaintext Debit Transactions:\n";
                output += string.Join(", ", debitTransactions);

                return output;
            }

            public int[] transactionsAggregation()
            {
                if (Transactions == null || Transactions.Count == 0)
                {
                    return [];
                }

                int total_credit = creditTransacctions.Sum();
                int total_debit = debitTransactions.Sum();
                

                return [total_credit, total_debit];
            }


            public int[] encryptedTransactionsAggregation()
            {
                if (Transactions == null || Transactions.Count == 0)
                {
                    return [];
                }


                // Homomorphic addition of encrypted credit transactions
                Ciphertext encryptedCreditSum = new Ciphertext();
                evaluator.AddMany(encryptedCreditTransactions, encryptedCreditSum);

                // Homomorphic addition of encrypted debit transactions
                Ciphertext encryptedDebitSum = new Ciphertext();
                evaluator.AddMany(encryptedDebitTransactions, encryptedDebitSum);


                // Decrypting  credit sum
                Plaintext decryptedCreditSum = new Plaintext();
                decryptor.Decrypt(encryptedCreditSum, decryptedCreditSum);

                // Decrypting  debit sum
                Plaintext decryptedDebitSum = new Plaintext();
                decryptor.Decrypt(encryptedDebitSum, decryptedDebitSum);

                // Convert the results back to int
                int decryptedCreditResult = int.Parse(decryptedCreditSum.ToString());
                int decryptedDebitResult = int.Parse(decryptedDebitSum.ToString());

                return [decryptedCreditResult,decryptedDebitResult];
            }

        }

    private void transactions_aggregation_Click(object sender, EventArgs e)
        {
            

            if(transactions_history_obj != null)
            {
                activity_logs.Text = "> Performing Aggration on Plaintext Transactions:";
                int[] plaintext_transaction_aggregation = transactions_history_obj.transactionsAggregation();

                if (plaintext_transaction_aggregation.Length > 0) { 
                activity_logs.Text += "\nTotal Credit Transaction Amount: " + plaintext_transaction_aggregation[0];
                activity_logs.Text += "\nTotal Debit Transactions Amount: " + plaintext_transaction_aggregation[1];
                }
                else
                {
                    activity_logs.Text = "There is not transaction found.";
                }

                
                activity_logs.Text += "\n\n> Performing Aggration on Encrypted Transactions:";

                int[] homomorphic_transaction_aggregation = transactions_history_obj.encryptedTransactionsAggregation();

                if (plaintext_transaction_aggregation.Length > 0)
                {
                    activity_logs.Text += "\nTotal Credit Transaction Amount: " + homomorphic_transaction_aggregation[0];
                    activity_logs.Text += "\nTotal Debit Transactions Amount: " + homomorphic_transaction_aggregation[1];
                }
                else
                {
                    activity_logs.Text = "There is not transaction found.";
                }
            }

        }

        private void btn_choose_file_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "Json File (*.json)|*.json";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string selectedFileName = openFileDialog.FileName;
                
                choosed_file.Text = selectedFileName;

                string transaction_details_json = File.ReadAllText(selectedFileName);

                activity_logs.Text += "Reading file: " + selectedFileName + "\n";

                activity_logs.Text = transaction_details_json;

                transactions_history_obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TransactionHistory>(transaction_details_json);

                activity_logs.Text = transactions_history_obj.encryptTransactions();
                /*activity_logs.Text += $"Debit Charges: {jsonObject.DebitCharges}";


                foreach (var transaction in jsonObject.Transactions)
                {
                    if (transaction.Credit.HasValue)
                    {
                        activity_logs.Text += $"\nTransaction Type: Credit, Amount: {transaction.Credit.Value}";
                    }
                    else if (transaction.Debit.HasValue)
                    {
                        activity_logs.Text += $"\nTransaction Type: Debit, Amount: {transaction.Debit.Value}";
                    }
                }*/
            }
        }
    }
}
