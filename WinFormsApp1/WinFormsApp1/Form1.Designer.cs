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
            btn_choose_file = new Button();
            choosed_file = new Label();
            activity_logs = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // transactions_aggregation
            // 
            transactions_aggregation.Location = new Point(127, 113);
            transactions_aggregation.Name = "transactions_aggregation";
            transactions_aggregation.Size = new Size(256, 55);
            transactions_aggregation.TabIndex = 0;
            transactions_aggregation.Text = "Transactions Aggregation";
            transactions_aggregation.UseVisualStyleBackColor = true;
            transactions_aggregation.Click += transactions_aggregation_Click;
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
            // activity_logs
            // 
            activity_logs.BackColor = SystemColors.ActiveCaption;
            activity_logs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            activity_logs.ForeColor = SystemColors.ButtonHighlight;
            activity_logs.Location = new Point(-3, 251);
            activity_logs.Multiline = true;
            activity_logs.Name = "activity_logs";
            activity_logs.ScrollBars = ScrollBars.Vertical;
            activity_logs.Size = new Size(1287, 454);
            activity_logs.TabIndex = 4;
            activity_logs.Text = "Activity Logs";
            //activity_logs.TextChanged += activity_logs_TextChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(-3, 201);
            label1.Name = "label1";
            label1.Padding = new Padding(3, 10, 0, 0);
            label1.Size = new Size(1287, 47);
            label1.TabIndex = 5;
            label1.Text = "Activity Logs";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 702);
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
    }
}
