﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class PerformanceChart : Form
    {
        public PerformanceChart()
        {
            InitializeComponent();
            PopulateChart();
        }

        private void performance_chart_Click(object sender, EventArgs e)
        {

        }

        private void PerformanceChart_Load(object sender, EventArgs e)
        {

        }

        private void PopulateChart()
        {
            
            double[] normal_operations = { 10, 20, 15};
            double[] homomorphic_operations = { 5, 15, 10};

            string[] keywords_strings = { "Transaction Aggregation", "Account Balance", "Debit Transaction Charges"};
            
            performance_chart.Series.Clear();
            performance_chart.ChartAreas.Clear();

            
            Series series1 = new Series("Homomorphic Operations");
            series1.ChartType = SeriesChartType.Bar;
            series1.Color = System.Drawing.Color.Blue; 
            for (int i = 0; i < normal_operations.Length; i++)
            {

                DataPoint dataPoint = new DataPoint(i + 1, normal_operations[i]);
                dataPoint.AxisLabel = keywords_strings[i];
                series1.Points.Add(dataPoint);
                
                
            }

            
            Series series2 = new Series("Normal Operations");
            series2.ChartType = SeriesChartType.Bar;
            series2.Color = System.Drawing.Color.Red; 
            for (int i = 0; i < homomorphic_operations.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(i + 1, homomorphic_operations[i]);
                dataPoint.AxisLabel = keywords_strings[i];
                series2.Points.Add(dataPoint);
            }

            
            performance_chart.Series.Add(series1);
            performance_chart.Series.Add(series2);

            
            performance_chart.ChartAreas.Add("PerformanceGraph");
            performance_chart.ChartAreas["PerformanceGraph"].AxisX.Title = "Operations";
            performance_chart.ChartAreas["PerformanceGraph"].AxisY.Title = "Execution Time (in seconds)";

        }
    }
}
