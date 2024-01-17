using Microsoft.Research.SEAL;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void avg_transaction_Click(object sender, EventArgs e)
        {
            using EncryptionParameters parms = new EncryptionParameters(SchemeType.BFV);

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

            using Decryptor decryptor = new Decryptor(context, secretKey);

            activity_logs.Text += "\nEncryptor, Evaluator and Decryptor Done.";

        }

        private void btn_choose_file_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                string selectedFileName = openFileDialog.FileName;
                
                choosed_file.Text = selectedFileName;
            }
        }
    }
}
