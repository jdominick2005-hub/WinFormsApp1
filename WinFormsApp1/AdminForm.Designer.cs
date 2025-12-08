namespace WinFormsApp1
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblUserName = new Label();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            btnStudentRegistration = new Button();
            btnLogout = new Button();
            label2 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            lblstudnum = new Label();
            lblstudents = new Label();
            panel4 = new Panel();
            lblprofnum = new Label();
            lblprof = new Label();
            panel5 = new Panel();
            lblpresent = new Label();
            lblpresentnum = new Label();
            panel6 = new Panel();
            lblabsentnum = new Label();
            lblabsent = new Label();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(437, 67);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(78, 28);
            lblUserName.TabIndex = 62;
            lblUserName.Text = "ADMIN";
            lblUserName.Click += lblUserName_Click;
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnManage.Location = new Point(15, 123);
            btnManage.Margin = new Padding(3, 4, 3, 4);
            btnManage.Name = "btnManage";
            btnManage.Size = new Size(255, 75);
            btnManage.TabIndex = 5;
            btnManage.Text = "MANAGE";
            btnManage.UseVisualStyleBackColor = false;
            btnManage.Click += btnManage_Click;
            // 
            // btnProfessors
            // 
            btnProfessors.BackColor = Color.SteelBlue;
            btnProfessors.FlatAppearance.BorderSize = 0;
            btnProfessors.FlatStyle = FlatStyle.Flat;
            btnProfessors.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnProfessors.Location = new Point(15, 225);
            btnProfessors.Margin = new Padding(3, 4, 3, 4);
            btnProfessors.Name = "btnProfessors";
            btnProfessors.Size = new Size(255, 75);
            btnProfessors.TabIndex = 4;
            btnProfessors.Text = "PROFESSORS";
            btnProfessors.UseVisualStyleBackColor = false;
            btnProfessors.Click += btnProfessors_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.SteelBlue;
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.System;
            btnHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnHome.Location = new Point(14, 20);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(256, 75);
            btnHome.TabIndex = 0;
            btnHome.Text = "HOME";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(269, 249);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 859);
            panel1.TabIndex = 60;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnHome);
            panel3.Controls.Add(btnLogout);
            panel3.Location = new Point(-1, 245);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(269, 612);
            panel3.TabIndex = 1;
            panel3.Paint += panel3_Paint;
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.FlatAppearance.BorderSize = 0;
            btnStudentRegistration.FlatStyle = FlatStyle.Flat;
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudentRegistration.Location = new Point(15, 328);
            btnStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(255, 75);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLogout.Location = new Point(15, 527);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(255, 75);
            btnLogout.TabIndex = 64;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(305, 92);
            label2.Name = "label2";
            label2.Size = new Size(298, 60);
            label2.TabIndex = 63;
            label2.Text = "DASHBOARD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(65, 273);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 59;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SeaGreen;
            panel2.Controls.Add(lblstudnum);
            panel2.Controls.Add(lblstudents);
            panel2.Location = new Point(930, 195);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 107);
            panel2.TabIndex = 65;
            // 
            // lblstudnum
            // 
            lblstudnum.AutoSize = true;
            lblstudnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblstudnum.ForeColor = Color.White;
            lblstudnum.Location = new Point(63, 52);
            lblstudnum.Name = "lblstudnum";
            lblstudnum.Size = new Size(52, 41);
            lblstudnum.TabIndex = 71;
            lblstudnum.Text = "50";
            lblstudnum.Click += lblstudnum_Click;
            // 
            // lblstudents
            // 
            lblstudents.AutoSize = true;
            lblstudents.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblstudents.ForeColor = Color.White;
            lblstudents.Location = new Point(14, 24);
            lblstudents.Name = "lblstudents";
            lblstudents.Size = new Size(180, 28);
            lblstudents.TabIndex = 70;
            lblstudents.Text = "TOTAL STUDENTS";
            lblstudents.Click += lblstudents_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.MediumPurple;
            panel4.Controls.Add(lblprofnum);
            panel4.Controls.Add(lblprof);
            panel4.Location = new Point(726, 195);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(184, 107);
            panel4.TabIndex = 66;
            // 
            // lblprofnum
            // 
            lblprofnum.AutoSize = true;
            lblprofnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblprofnum.ForeColor = Color.White;
            lblprofnum.Location = new Point(63, 52);
            lblprofnum.Name = "lblprofnum";
            lblprofnum.Size = new Size(52, 41);
            lblprofnum.TabIndex = 72;
            lblprofnum.Text = "50";
            lblprofnum.Click += lblprofnum_Click;
            // 
            // lblprof
            // 
            lblprof.AutoSize = true;
            lblprof.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblprof.ForeColor = Color.White;
            lblprof.Location = new Point(3, 24);
            lblprof.Name = "lblprof";
            lblprof.Size = new Size(200, 28);
            lblprof.TabIndex = 72;
            lblprof.Text = "TOTAL PROFESSORS";
            lblprof.Click += lblprof_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.SteelBlue;
            panel5.Controls.Add(lblpresent);
            panel5.Controls.Add(lblpresentnum);
            panel5.Location = new Point(317, 195);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(184, 107);
            panel5.TabIndex = 67;
            panel5.Paint += panel5_Paint;
            // 
            // lblpresent
            // 
            lblpresent.AutoSize = true;
            lblpresent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpresent.ForeColor = Color.White;
            lblpresent.Location = new Point(14, 24);
            lblpresent.Name = "lblpresent";
            lblpresent.Size = new Size(169, 28);
            lblpresent.TabIndex = 73;
            lblpresent.Text = "PRESENT TODAY";
            lblpresent.TextAlign = ContentAlignment.MiddleCenter;
            lblpresent.Click += lblpresent_Click;
            // 
            // lblpresentnum
            // 
            lblpresentnum.AutoSize = true;
            lblpresentnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpresentnum.ForeColor = Color.White;
            lblpresentnum.Location = new Point(64, 60);
            lblpresentnum.Name = "lblpresentnum";
            lblpresentnum.Size = new Size(52, 41);
            lblpresentnum.TabIndex = 73;
            lblpresentnum.Text = "50";
            lblpresentnum.TextAlign = ContentAlignment.MiddleCenter;
            lblpresentnum.Click += lblpresentnum_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.IndianRed;
            panel6.Controls.Add(lblabsentnum);
            panel6.Controls.Add(lblabsent);
            panel6.Location = new Point(521, 195);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(184, 107);
            panel6.TabIndex = 68;
            // 
            // lblabsentnum
            // 
            lblabsentnum.AutoSize = true;
            lblabsentnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblabsentnum.ForeColor = Color.White;
            lblabsentnum.Location = new Point(67, 52);
            lblabsentnum.Name = "lblabsentnum";
            lblabsentnum.Size = new Size(52, 41);
            lblabsentnum.TabIndex = 74;
            lblabsentnum.Text = "50";
            lblabsentnum.Click += lblabsentnum_Click;
            // 
            // lblabsent
            // 
            lblabsent.AutoSize = true;
            lblabsent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblabsent.ForeColor = Color.White;
            lblabsent.Location = new Point(22, 24);
            lblabsent.Name = "lblabsent";
            lblabsent.Size = new Size(160, 28);
            lblabsent.TabIndex = 74;
            lblabsent.Text = "ABSENT TODAY";
            lblabsent.Click += lblabsent_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(317, 616);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(798, 199);
            dataGridView1.TabIndex = 69;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(313, 152);
            label1.Name = "label1";
            label1.Size = new Size(289, 20);
            label1.TabIndex = 70;
            label1.Text = "WELCOME TO COLLEGE OF INFORMATICS";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarMonthBackground = Color.White;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(860, 111);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(254, 27);
            dateTimePicker1.TabIndex = 72;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // chart1
            // 
            chart1.BackgroundImageLayout = ImageLayout.None;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(317, 313);
            chart1.Margin = new Padding(3, 4, 3, 4);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(797, 292);
            chart1.TabIndex = 73;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(315, 67);
            label3.Name = "label3";
            label3.Size = new Size(116, 28);
            label3.TabIndex = 74;
            label3.Text = "WELCOME: ";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1152, 859);
            Controls.Add(label3);
            Controls.Add(panel5);
            Controls.Add(chart1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(lblUserName);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAttendanceReport;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private Label label5;
        public Label lblUserName;
        private Button btnStudentRegistration;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private DataGridView dataGridView1;
        private Label lblstudnum;
        private Label lblstudents;
        private Label lblprofnum;
        private Label lblprof;
        private Label lblpresent;
        private Label lblpresentnum;
        private Label lblabsentnum;
        private Label lblabsent;
        private Button btnLogout;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public Label label3;
    }
}