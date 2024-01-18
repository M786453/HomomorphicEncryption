namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            transactions_aggregation = new Button();
            btn_choose_file = new Button();
            choosed_file = new Label();
            activity_logs = new TextBox();
            label1 = new Label();
            account_balance = new Button();
            bank_transaction_charges = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // transactions_aggregation
            // 
            transactions_aggregation.Location = new Point(222, 257);
            transactions_aggregation.Name = "transactions_aggregation";
            transactions_aggregation.Size = new Size(256, 55);
            transactions_aggregation.TabIndex = 0;
            transactions_aggregation.Text = "Transactions Aggregation";
            transactions_aggregation.UseVisualStyleBackColor = true;
            transactions_aggregation.Click += transactions_aggregation_Click;
            // 
            // btn_choose_file
            // 
            btn_choose_file.Location = new Point(1132, 174);
            btn_choose_file.Name = "btn_choose_file";
            btn_choose_file.Size = new Size(141, 48);
            btn_choose_file.TabIndex = 2;
            btn_choose_file.Text = "Choose File";
            btn_choose_file.UseVisualStyleBackColor = true;
            btn_choose_file.Click += btn_choose_file_Click;
            // 
            // choosed_file
            // 
            choosed_file.BackColor = SystemColors.ActiveCaption;
            choosed_file.ForeColor = SystemColors.ButtonFace;
            choosed_file.Location = new Point(12, 174);
            choosed_file.Name = "choosed_file";
            choosed_file.Size = new Size(1114, 48);
            choosed_file.TabIndex = 3;
            choosed_file.Text = "Please Choose Input File";
            choosed_file.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // activity_logs
            // 
            activity_logs.BackColor = SystemColors.ActiveCaption;
            activity_logs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activity_logs.ForeColor = SystemColors.ButtonHighlight;
            activity_logs.Location = new Point(-3, 395);
            activity_logs.Multiline = true;
            activity_logs.Name = "activity_logs";
            activity_logs.ScrollBars = ScrollBars.Vertical;
            activity_logs.Size = new Size(1287, 310);
            activity_logs.TabIndex = 4;
            activity_logs.Text = "Activity Logs";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(-3, 345);
            label1.Name = "label1";
            label1.Padding = new Padding(3, 10, 0, 0);
            label1.Size = new Size(1287, 47);
            label1.TabIndex = 5;
            label1.Text = "Activity Logs";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // account_balance
            // 
            account_balance.Location = new Point(542, 257);
            account_balance.Name = "account_balance";
            account_balance.Size = new Size(219, 55);
            account_balance.TabIndex = 6;
            account_balance.Text = "Account Balance";
            account_balance.UseVisualStyleBackColor = true;
            account_balance.Click += account_balance_Click;
            // 
            // bank_transaction_charges
            // 
            bank_transaction_charges.Location = new Point(825, 257);
            bank_transaction_charges.Name = "bank_transaction_charges";
            bank_transaction_charges.Size = new Size(236, 55);
            bank_transaction_charges.TabIndex = 7;
            bank_transaction_charges.Text = "Bank Transaction Charges";
            bank_transaction_charges.UseVisualStyleBackColor = true;
            bank_transaction_charges.Click += bank_transaction_charges_Click;
            // 
            // label2
            // 
            label2.Location = new Point(108, 70);
            label2.Name = "label2";
            label2.Size = new Size(916, 82);
            label2.TabIndex = 8;
            label2.Text = resources.GetString("label2.Text");
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(474, 19);
            label3.Name = "label3";
            label3.Size = new Size(287, 32);
            label3.TabIndex = 9;
            label3.Text = "Bank Finance Calculator";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 702);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(bank_transaction_charges);
            Controls.Add(account_balance);
            Controls.Add(label1);
            Controls.Add(activity_logs);
            Controls.Add(choosed_file);
            Controls.Add(btn_choose_file);
            Controls.Add(transactions_aggregation);
            Name = "Form1";
            Text = "Homomorphic Encryption Demo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button transactions_aggregation;
        private Button btn_choose_file;
        private Label choosed_file;
        private TextBox activity_logs;
        private Label label1;
        private Button account_balance;
        private Button bank_transaction_charges;
        private Label label2;
        private Label label3;
    }
}
