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
            avg_transaction = new Button();
            activity_logs = new Label();
            btn_choose_file = new Button();
            choosed_file = new Label();
            SuspendLayout();
            // 
            // avg_transaction
            // 
            avg_transaction.Location = new Point(144, 95);
            avg_transaction.Name = "avg_transaction";
            avg_transaction.Size = new Size(210, 55);
            avg_transaction.TabIndex = 0;
            avg_transaction.Text = "Average Transaction";
            avg_transaction.UseVisualStyleBackColor = true;
            avg_transaction.Click += avg_transaction_Click;
            // 
            // activity_logs
            // 
            activity_logs.BackColor = SystemColors.ActiveCaption;
            activity_logs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activity_logs.ForeColor = SystemColors.ButtonFace;
            activity_logs.Location = new Point(-2, 272);
            activity_logs.Name = "activity_logs";
            activity_logs.Padding = new Padding(10);
            activity_logs.Size = new Size(954, 275);
            activity_logs.TabIndex = 1;
            activity_logs.Text = "Activity Logs";
            // 
            // btn_choose_file
            // 
            btn_choose_file.Location = new Point(799, 24);
            btn_choose_file.Name = "btn_choose_file";
            btn_choose_file.Size = new Size(141, 49);
            btn_choose_file.TabIndex = 2;
            btn_choose_file.Text = "Choose File";
            btn_choose_file.UseVisualStyleBackColor = true;
            btn_choose_file.Click += btn_choose_file_Click;
            // 
            // choosed_file
            // 
            choosed_file.BackColor = SystemColors.ActiveCaption;
            choosed_file.ForeColor = SystemColors.ButtonFace;
            choosed_file.Location = new Point(12, 24);
            choosed_file.Name = "choosed_file";
            choosed_file.Size = new Size(781, 49);
            choosed_file.TabIndex = 3;
            choosed_file.Text = "Please Choose Input File";
            choosed_file.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 543);
            Controls.Add(choosed_file);
            Controls.Add(btn_choose_file);
            Controls.Add(activity_logs);
            Controls.Add(avg_transaction);
            Name = "Form1";
            Text = "Homomorphic Encryption Demo";
            ResumeLayout(false);
        }

        #endregion

        private Button avg_transaction;
        private Label activity_logs;
        private Button btn_choose_file;
        private Label choosed_file;
    }
}
