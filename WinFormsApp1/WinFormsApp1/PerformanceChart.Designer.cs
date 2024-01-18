namespace WinFormsApp1
{
    partial class PerformanceChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            performance_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)performance_chart).BeginInit();
            SuspendLayout();
            // 
            // performance_chart
            // 
            performance_chart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            performance_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            performance_chart.Legends.Add(legend1);
            performance_chart.Location = new Point(0, 0);
            performance_chart.Name = "performance_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            performance_chart.Series.Add(series1);
            performance_chart.Size = new Size(801, 455);
            performance_chart.TabIndex = 0;
            performance_chart.Text = "Performance Chart";
            performance_chart.Click += performance_chart_Click;
            // 
            // PerformanceChart
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(performance_chart);
            Name = "PerformanceChart";
            Text = "Performance Graph";
            Load += PerformanceChart_Load;
            ((System.ComponentModel.ISupportInitialize)performance_chart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart performance_chart;
    }
}