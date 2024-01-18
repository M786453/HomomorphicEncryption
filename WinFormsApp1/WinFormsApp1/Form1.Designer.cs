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
            transactions_aggregation = new Button();
            activity_logs = new Label();
            btn_choose_file = new Button();
            choosed_file = new Label();
            SuspendLayout();
            // 
            // transactions_aggregation
            // 
            transactions_aggregation.Location = new Point(377, 85);
            transactions_aggregation.Name = "transactions_aggregation";
            transactions_aggregation.Size = new Size(256, 55);
            transactions_aggregation.TabIndex = 0;
            transactions_aggregation.Text = "Transactions Aggregation";
            transactions_aggregation.UseVisualStyleBackColor = true;
            transactions_aggregation.Click += transactions_aggregation_Click;
            // 
            // activity_logs
            // 
            activity_logs.BackColor = SystemColors.ActiveCaption;
            activity_logs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activity_logs.ForeColor = SystemColors.ButtonFace;
            activity_logs.Location = new Point(-2, 246);
            activity_logs.Name = "activity_logs";
            activity_logs.Padding = new Padding(10);
            activity_logs.Size = new Size(1286, 457);
            activity_logs.TabIndex = 1;
            activity_logs.Text = "Activity Logs";
            // 
            // btn_choose_file
            // 
            btn_choose_file.Location = new Point(1131, 23);
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
            choosed_file.Location = new Point(11, 23);
            choosed_file.Name = "choosed_file";
            choosed_file.Size = new Size(1114, 48);
            choosed_file.TabIndex = 3;
            choosed_file.Text = "Please Choose Input File";
            choosed_file.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 702);
            Controls.Add(choosed_file);
            Controls.Add(btn_choose_file);
            Controls.Add(activity_logs);
            Controls.Add(transactions_aggregation);
            Name = "Form1";
            Text = "Homomorphic Encryption Demo";
            ResumeLayout(false);
        }

        #endregion

        private Button transactions_aggregation;
        private Label activity_logs;
        private Button btn_choose_file;
        private Label choosed_file;
    }
}
