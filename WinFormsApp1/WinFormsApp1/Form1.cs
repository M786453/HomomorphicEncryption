using Microsoft.Research.SEAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static List<double> normal_operations_time = new List<double> { -1,-1,-1};
        public static List<double> homomorphic_operations_time = new List<double> { -1,-1,-1};
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            activity_logs.ReadOnly = true;
        }

        public void scroll_to_end()
        {
            // Scroll to the end
            activity_logs.SelectionStart = activity_logs.Text.Length;
            activity_logs.ScrollToCaret();
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

            public CKKSEncoder encoder;

            public TransactionHistory()
            {

                debitTransactions = new List<int> { };
                creditTransacctions = new List<int> { };
                encryptedCreditTransactions = new List<Ciphertext> { };
                encryptedDebitTransactions = new List<Ciphertext> { };

                EncryptionParameters parms = new EncryptionParameters(SchemeType.CKKS);

                ulong polyModulusDegree = 8192;
                parms.PolyModulusDegree = polyModulusDegree;
                parms.CoeffModulus = CoeffModulus.Create(polyModulusDegree, new int[] { 60, 40, 40, 60 });
                

                context = new SEALContext(parms);


                if (context.ParameterErrorMessage() == "valid")
                {

                    KeyGenerator keygen = new KeyGenerator(context);

                    SecretKey secretKey = keygen.SecretKey;

                    keygen.CreatePublicKey(out PublicKey publicKey);

                    encryptor = new Encryptor(context, publicKey);

                    evaluator = new Evaluator(context);

                    decryptor = new Decryptor(context, secretKey);

                    encoder = new CKKSEncoder(context);

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

                        plainTransaction = new Plaintext();

                        encoder.Encode(credit_trans, Math.Pow(2.0, 40), plainTransaction);

                        encryptor.Encrypt(plainTransaction, encryptedTransaction);

                        encryptedCreditTransactions.Add(encryptedTransaction);

                    }
                    else if (transaction.Debit.HasValue)
                    {
                        int debit_trans = transaction.Debit.Value;

                        // Update Debit Transactions List

                        debitTransactions.Add(debit_trans);


                        // Encrypt Transaction and Update Encrypted Debit Transactions List

                        plainTransaction = new Plaintext();

                        encoder.Encode(debit_trans, Math.Pow(2.0, 40), plainTransaction);

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

            public string decryptResult(Ciphertext encryptedResult)
            {
                
                using Plaintext plainResult = new Plaintext();
                decryptor.Decrypt(encryptedResult, plainResult);

                
                List<double> decryptedResult = new List<double>();
                encoder.Decode(plainResult, decryptedResult);

                string result = (int)Math.Round(decryptedResult[0]) + "";

                return result;
            }

            public string[] transactionsAggregation()
            {
                if (Transactions == null || Transactions.Count == 0)
                {
                    return [];
                }

                int total_credit = creditTransacctions.Sum();
                int total_debit = debitTransactions.Sum();

                return [total_credit.ToString(), total_debit.ToString()];
            }


            public string[] encryptedTransactionsAggregation()
            {
                if (Transactions == null || Transactions.Count == 0)
                {
                    return [];
                }



                Ciphertext encryptedCreditSum = new Ciphertext();
                evaluator.AddMany(encryptedCreditTransactions, encryptedCreditSum);


                Ciphertext encryptedDebitSum = new Ciphertext();
                evaluator.AddMany(encryptedDebitTransactions, encryptedDebitSum);

                string decryptedCreditSum = decryptResult(encryptedCreditSum);

                string decryptedDebitSum = decryptResult(encryptedDebitSum);

                return [decryptedCreditSum, decryptedDebitSum];
            }

            public string account_balance()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return "";
                }


                int total_credit = creditTransacctions.Sum();

                int total_debit = debitTransactions.Sum();

                int balance = total_credit - total_debit;

                return balance.ToString();
            }

            public string encrypted_account_balance_calculation()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return "";

                }


                Ciphertext encryptedCreditSum = new Ciphertext();
                evaluator.AddMany(encryptedCreditTransactions, encryptedCreditSum);
                


                Ciphertext encryptedDebitSum = new Ciphertext();
                evaluator.AddMany(encryptedDebitTransactions, encryptedDebitSum);
                

                evaluator.SubInplace(encryptedCreditSum, encryptedDebitSum);
                
                string decryptedBalance = decryptResult(encryptedCreditSum);

                
                return decryptedBalance;

            }


            public string bank_transaction_charges()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return "";
                }



                int bank_transaction_charges = debitTransactions.Count() * DebitCharges;

                return bank_transaction_charges.ToString();
            }


            public string encrypted_charges_calculation()
            {

                if (Transactions == null || Transactions.Count == 0)
                {
                    return "";

                }

                Ciphertext encryptedDebitCharges = new Ciphertext();

                Plaintext plaintextDebitCharges = new Plaintext();

                encoder.Encode(DebitCharges, Math.Pow(2.0, 40), plaintextDebitCharges);

                encryptor.Encrypt(plaintextDebitCharges, encryptedDebitCharges);

                int total_debit_transactions = encryptedDebitTransactions.Count();

                Ciphertext encrypted_debit_transcations_count = new Ciphertext();

                Plaintext plaintext_debit_transactions_count = new Plaintext();

                encoder.Encode(total_debit_transactions, Math.Pow(2.0, 40), plaintext_debit_transactions_count);

                encryptor.Encrypt(plaintext_debit_transactions_count, encrypted_debit_transcations_count);

                evaluator.MultiplyInplace(encryptedDebitCharges, encrypted_debit_transcations_count);

                string decryptedCharges = decryptResult(encryptedDebitCharges);

                return decryptedCharges;
                

            }

        }

        private void transactions_aggregation_Click(object sender, EventArgs e)
        {


            if (transactions_history_obj != null)
            {
                Stopwatch sw = new Stopwatch();
                

                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Performing Aggration on Plaintext Transactions...";
                activity_logs.Text += Environment.NewLine + "> Aggration Results:";
                sw.Start();
                string[] plaintext_transaction_aggregation = transactions_history_obj.transactionsAggregation();
                sw.Stop();

                normal_operations_time[0] = sw.Elapsed.TotalSeconds;
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
                sw.Restart();
                string[] homomorphic_transaction_aggregation = transactions_history_obj.encryptedTransactionsAggregation();
                sw.Stop();
                homomorphic_operations_time[0] = sw.Elapsed.TotalSeconds;
                if (homomorphic_transaction_aggregation.Length > 0)
                {
                    activity_logs.Text += Environment.NewLine + "Total Credit Transaction Amount: " + homomorphic_transaction_aggregation[0];
                    activity_logs.Text += Environment.NewLine + "Total Debit Transactions Amount: " + homomorphic_transaction_aggregation[1];
                }
                else
                {
                    activity_logs.Text += "There is not transaction found.";
                }

                scroll_to_end();
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

                scroll_to_end();

            }
        }

        private void account_balance_Click(object sender, EventArgs e)
        {

            if (transactions_history_obj != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Account Balance from plaintext transactions...";
                stopwatch.Start();
                activity_logs.Text += Environment.NewLine + "> Account Balance: " + transactions_history_obj.account_balance(); ;
                stopwatch.Stop();

                normal_operations_time[1] = stopwatch.Elapsed.TotalSeconds;


                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Account Balance from encrypted transactions...";
                stopwatch.Restart();
                activity_logs.Text += Environment.NewLine + "> Account Balance: " + transactions_history_obj.encrypted_account_balance_calculation();
                stopwatch.Stop();

                homomorphic_operations_time[1] = stopwatch.Elapsed.TotalSeconds;

                scroll_to_end();
            }

        }

        private void bank_transaction_charges_Click(object sender, EventArgs e)
        {

            if (transactions_history_obj != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Debit Transactions Charges from plaintext transactions...";
                stopwatch.Start();
                activity_logs.Text += Environment.NewLine + "> Debit Transaction Charges: " + transactions_history_obj.bank_transaction_charges(); ;
                stopwatch.Stop();
                normal_operations_time[2] = (stopwatch.Elapsed.TotalSeconds); 
                activity_logs.Text += Environment.NewLine + Environment.NewLine + "> Calculating Debit Transactions Charges from encrypted transactions...";
                stopwatch.Restart();
                activity_logs.Text += Environment.NewLine + "> Debit Transaction Charges: " + transactions_history_obj.encrypted_charges_calculation();
                stopwatch.Stop();
                homomorphic_operations_time[2] = (stopwatch.Elapsed.TotalSeconds);
                scroll_to_end();
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void performance_graph_Click(object sender, EventArgs e)
        {
            using (PerformanceChart chart = new PerformanceChart())
            {
                chart.ShowDialog();
            }

            
        }
    }
}
