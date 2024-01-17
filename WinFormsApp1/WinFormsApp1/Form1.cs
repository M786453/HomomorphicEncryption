using Microsoft.Research.SEAL;
using System.Collections.Generic;

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

                public int[] CalculateAverageTransaction()
                {
                    if (Transactions == null || Transactions.Count == 0)
                    {
                        return [];
                    }

                    int total_credit = 0;
                    int total_debit = 0;
                    int credit_count = 0;
                    int debit_count = 0;
                    

                    foreach (var transaction in Transactions)
                    {
                        if (transaction.Credit.HasValue)
                        {
                            total_credit += transaction.Credit.Value;
                            credit_count++;
                        }
                        else if (transaction.Debit.HasValue)
                        {
                            total_debit += transaction.Debit.Value;
                            debit_count++;
                        }
                    }

                    int[] averages = new int[2];

                    averages[0] = credit_count > 0 ? total_credit / credit_count : 0;

                    averages[1] = debit_count > 0 ? total_debit / debit_count : 0;

                return averages;
                }
            }

    private void avg_transaction_Click(object sender, EventArgs e)
        {
            /*using EncryptionParameters parms = new EncryptionParameters(SchemeType.BFV);

            ulong polyModulusDegree = 4096;
            parms.PolyModulusDegree = polyModulusDegree;
            parms.CoeffModulus = CoeffModulus.BFVDefault(polyModulusDegree);
            parms.PlainModulus = new Modulus(1024);
            using SEALContext context = new SEALContext(parms);

            activity_logs.Text = context.ParameterErrorMessage();

            using KeyGenerator keygen = new KeyGenerator(context);
            using SecretKey secretKey = keygen.SecretKey;
            keygen.CreatePublicKey(out PublicKey publicKey);

            activity_logs.Text += "\nKey Generation Done.";

            using Encryptor encryptor = new Encryptor(context, publicKey);

            using Evaluator evaluator = new Evaluator(context);

            using Decryptor decryptor = new Decryptor(context, secretKey);*/



            activity_logs.Text += "\nEncryptor, Evaluator and Decryptor Done.";

            if(transactions_history_obj != null)
            {
                int[] averages = transactions_history_obj.CalculateAverageTransaction();
                if (averages.Length > 0) { 
                activity_logs.Text = "Average Credit Transaction: " + averages[0];
                activity_logs.Text += "\nAverage Debit Transaction: " + averages[1];
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
