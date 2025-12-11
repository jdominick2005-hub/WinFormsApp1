namespace WinFormsApp1.UserControls
{
    partial class ucHome
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblTitle = new Label();
            dtpDate = new DateTimePicker();
            chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            SuspendLayout();
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart2.Legends.Add(legend4);
            chart2.Location = new Point(418, 63);
            chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart2.Series.Add(series4);
            chart2.Size = new Size(300, 300);
            chart2.TabIndex = 1;
            chart2.Text = "chart2";
            chart2.Click += chart2_Click;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            chart1.Legends.Add(legend5);
            chart1.Location = new Point(67, 63);
            chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            chart1.Series.Add(series5);
            chart1.Size = new Size(300, 300);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(64, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 47);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "DASHBOARD";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(510, 16);
            dtpDate.Margin = new Padding(3, 2, 3, 2);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(208, 23);
            dtpDate.TabIndex = 9;
            // 
            // chart3
            // 
            chartArea6.Name = "ChartArea1";
            chart3.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            chart3.Legends.Add(legend6);
            chart3.Location = new Point(67, 369);
            chart3.Name = "chart3";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            chart3.Series.Add(series6);
            chart3.Size = new Size(651, 191);
            chart3.TabIndex = 10;
            chart3.Text = "chart3";
            chart3.Click += chart3_Click;
            // 
            // ucHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(chart3);
            Controls.Add(dtpDate);
            Controls.Add(lblTitle);
            Controls.Add(chart1);
            Controls.Add(chart2);
            Name = "ucHome";
            Size = new Size(775, 570);
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Label lblTitle;
        private DateTimePicker dtpDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
    }
}
