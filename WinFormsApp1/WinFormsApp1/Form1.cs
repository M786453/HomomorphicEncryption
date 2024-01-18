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

            public TransactionHistory()
            {

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
                if (context.ParameterErrorMessage() != "valid")
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

                string output = "> Reading json data:";
                output += Environment.NewLine + "Plaintext Credit Transactions:";
                output += Environment.NewLine + string.Join(", ", creditTransacctions);
                output += Environment.NewLine + "Plaintext Debit Transactions:";
                output += Environment.NewLine + string.Join(", ", debitTransactions);
                output += Environment.NewLine + Environment.NewLine + "> Performing encryption on Transactions:";
                output += Environment.NewLine + "Encrypted Credit Transactions:";
                output += Environment.NewLine + string.Join(", ", encryptedCreditTransactions);
                output += Environment.NewLine + "Encrypted Debit Transactions:";
                output += Environment.NewLine + string.Join(", ", encryptedDebitTransactions);


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



                Ciphertext encryptedCreditSum = new Ciphertext();
                evaluator.AddMany(encryptedCreditTransactions, encryptedCreditSum);


                Ciphertext encryptedDebitSum = new Ciphertext();
                evaluator.AddMany(encryptedDebitTransactions, encryptedDebitSum);



                Plaintext decryptedCreditSum = new Plaintext();
                decryptor.Decrypt(encryptedCreditSum, decryptedCreditSum);


                Plaintext decryptedDebitSum = new Plaintext();
                decryptor.Decrypt(encryptedDebitSum, decryptedDebitSum);


                int decryptedCreditResult = int.Parse(decryptedCreditSum.ToString());
                int decryptedDebitResult = int.Parse(decryptedDebitSum.ToString());

                return [decryptedCreditResult, decryptedDebitResult];
            }

            public int account_balance()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return -1;
                }


                int total_credit = creditTransacctions.Sum();

                int total_debit = debitTransactions.Sum();

                int balance = total_credit - total_debit;

                return balance;
            }

            public int encrypted_account_balance_calculation()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return -1;

                }


                Ciphertext encryptedCreditSum = new Ciphertext();
                evaluator.AddMany(encryptedCreditTransactions, encryptedCreditSum);


                Ciphertext encryptedDebitSum = new Ciphertext();
                evaluator.AddMany(encryptedDebitTransactions, encryptedDebitSum);

                evaluator.SubInplace(encryptedCreditSum, encryptedDebitSum);

                Plaintext decryptedBalance = new Plaintext();

                decryptor.Decrypt(encryptedCreditSum, decryptedBalance);

                int balance = int.Parse(decryptedBalance.ToString());

                return balance;

            }


            public int bank_transaction_charges()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return -1;
                }



                int bank_transaction_charges = debitTransactions.Count() * DebitCharges;

                return bank_transaction_charges;
            }

            
            public int encrypted_charges_calculation()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return -1;

                }

                Ciphertext encryptedDebitCharges = new Ciphertext();

                Plaintext plaintextDebitCharges = new Plaintext($"{DebitCharges}");

                encryptor.Encrypt(plaintextDebitCharges, encryptedDebitCharges);
                
                int total_debit_transactions = encryptedDebitTransactions.Count();

                Ciphertext encrypted_debit_transcations_count = new Ciphertext();

                Plaintext plaintext_debit_transactions_count = new Plaintext($"{total_debit_transactions}");

                encryptor.Encrypt(plaintext_debit_transactions_count, encrypted_debit_transcations_count);

                evaluator.MultiplyInplace(encryptedDebitCharges,encrypted_debit_transcations_count);

                Plaintext decryptedCharges = new Plaintext();

                decryptor.Decrypt(encryptedDebitCharges, decryptedCharges);

                int charges = int.Parse(decryptedCharges.ToString());

                return charges;

            }

        }

        private void transactions_aggregation_Click(object sender, EventArgs e)
        {


            if (transactions_history_obj != null)
            {
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Performing Aggration on Plaintext Transactions...";
                activity_logs.Text += Environment.NewLine + "> Aggration Results:";
                int[] plaintext_transaction_aggregation = transactions_history_obj.transactionsAggregation();

                if (plaintext_transaction_aggregation.Length > 0)
                {
                    activity_logs.Text += Environment.NewLine + "Total Credit Transaction Amount: " + plaintext_transaction_aggregation[0];
                    activity_logs.Text += Environment.NewLine + "Total Debit Transactions Amount: " + plaintext_transaction_aggregation[1];
                }
                else
                {
                    activity_logs.Text += Environment.NewLine + "There is not transaction found.";
                }


                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Performing Aggration on Encrypted Transactions...";
                activity_logs.Text += Environment.NewLine + "> Aggration Results:";
                int[] homomorphic_transaction_aggregation = transactions_history_obj.encryptedTransactionsAggregation();

                if (homomorphic_transaction_aggregation.Length > 0)
                {
                    activity_logs.Text += Environment.NewLine + "Total Credit Transaction Amount: " + homomorphic_transaction_aggregation[0];
                    activity_logs.Text += Environment.NewLine + "Total Debit Transactions Amount: " + homomorphic_transaction_aggregation[1];
                }
                else
                {
                    activity_logs.Text += "There is not transaction found.";
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

            }
        }

        private void account_balance_Click(object sender, EventArgs e)
        {

            if (transactions_history_obj != null)
            {
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Account Balance from plaintext transactions...";
                activity_logs.Text += Environment.NewLine + "> Account Balance: " + transactions_history_obj.account_balance(); ;

                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Account Balance from encrypted transactions...";
                activity_logs.Text += Environment.NewLine + "> Account Balance: " + transactions_history_obj.encrypted_account_balance_calculation();


            }

        }

        private void bank_transaction_charges_Click(object sender, EventArgs e)
        {

            if (transactions_history_obj != null)
            {
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Debit Transactions Charges from plaintext transactions...";
                activity_logs.Text += Environment.NewLine + "> Debit Transaction Charges: " + transactions_history_obj.bank_transaction_charges(); ;

                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Debit Transactions Charges from encrypted transactions...";
                activity_logs.Text += Environment.NewLine + "> Debit Transaction Charges: " + transactions_history_obj.encrypted_charges_calculation();


            }

        }
    }
}
