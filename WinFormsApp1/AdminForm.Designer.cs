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
            btnLogout = new Button();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(864, 58);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(64, 21);
            lblUserName.TabIndex = 62;
            lblUserName.Text = "ADMIN";
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnManage.Location = new Point(12, 92);
            btnManage.Name = "btnManage";
            btnManage.Size = new Size(223, 56);
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
            btnProfessors.Location = new Point(13, 169);
            btnProfessors.Name = "btnProfessors";
            btnProfessors.Size = new Size(223, 56);
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
            btnHome.Location = new Point(12, 15);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(224, 56);
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
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 187);
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
            panel1.Name = "panel1";
            panel1.Size = new Size(235, 644);
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
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.FlatAppearance.BorderSize = 0;
            btnStudentRegistration.FlatStyle = FlatStyle.Flat;
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStudentRegistration.Location = new Point(14, 246);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(223, 56);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(267, 50);
            label2.Name = "label2";
            label2.Size = new Size(192, 40);
            label2.TabIndex = 63;
            label2.Text = "DASHBOARD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(57, 205);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 59;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.Controls.Add(lblstudnum);
            panel2.Controls.Add(lblstudents);
            panel2.Location = new Point(814, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(161, 80);
            panel2.TabIndex = 65;
            // 
            // lblstudnum
            // 
            lblstudnum.AutoSize = true;
            lblstudnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblstudnum.Location = new Point(55, 39);
            lblstudnum.Name = "lblstudnum";
            lblstudnum.Size = new Size(42, 32);
            lblstudnum.TabIndex = 71;
            lblstudnum.Text = "50";
            lblstudnum.Click += lblstudnum_Click;
            // 
            // lblstudents
            // 
            lblstudents.AutoSize = true;
            lblstudents.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblstudents.Location = new Point(12, 18);
            lblstudents.Name = "lblstudents";
            lblstudents.Size = new Size(142, 21);
            lblstudents.TabIndex = 70;
            lblstudents.Text = "TOTAL STUDENTS";
            lblstudents.Click += lblstudents_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Controls.Add(lblprofnum);
            panel4.Controls.Add(lblprof);
            panel4.Location = new Point(635, 142);
            panel4.Name = "panel4";
            panel4.Size = new Size(161, 80);
            panel4.TabIndex = 66;
            // 
            // lblprofnum
            // 
            lblprofnum.AutoSize = true;
            lblprofnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblprofnum.Location = new Point(55, 39);
            lblprofnum.Name = "lblprofnum";
            lblprofnum.Size = new Size(42, 32);
            lblprofnum.TabIndex = 72;
            lblprofnum.Text = "50";
            lblprofnum.Click += lblprofnum_Click;
            // 
            // lblprof
            // 
            lblprof.AutoSize = true;
            lblprof.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblprof.Location = new Point(3, 18);
            lblprof.Name = "lblprof";
            lblprof.Size = new Size(158, 21);
            lblprof.TabIndex = 72;
            lblprof.Text = "TOTAL PROFESSORS";
            lblprof.Click += lblprof_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.SteelBlue;
            panel5.Controls.Add(lblpresent);
            panel5.Controls.Add(lblpresentnum);
            panel5.Location = new Point(277, 142);
            panel5.Name = "panel5";
            panel5.Size = new Size(161, 80);
            panel5.TabIndex = 67;
            // 
            // lblpresent
            // 
            lblpresent.AutoSize = true;
            lblpresent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpresent.ForeColor = Color.Black;
            lblpresent.Location = new Point(12, 18);
            lblpresent.Name = "lblpresent";
            lblpresent.Size = new Size(135, 21);
            lblpresent.TabIndex = 73;
            lblpresent.Text = "PRESENT TODAY";
            lblpresent.TextAlign = ContentAlignment.MiddleCenter;
            lblpresent.Click += lblpresent_Click;
            // 
            // lblpresentnum
            // 
            lblpresentnum.AutoSize = true;
            lblpresentnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblpresentnum.ForeColor = Color.Black;
            lblpresentnum.Location = new Point(56, 45);
            lblpresentnum.Name = "lblpresentnum";
            lblpresentnum.Size = new Size(42, 32);
            lblpresentnum.TabIndex = 73;
            lblpresentnum.Text = "50";
            lblpresentnum.TextAlign = ContentAlignment.MiddleCenter;
            lblpresentnum.Click += lblpresentnum_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.SteelBlue;
            panel6.Controls.Add(lblabsentnum);
            panel6.Controls.Add(lblabsent);
            panel6.Location = new Point(456, 142);
            panel6.Name = "panel6";
            panel6.Size = new Size(161, 80);
            panel6.TabIndex = 68;
            // 
            // lblabsentnum
            // 
            lblabsentnum.AutoSize = true;
            lblabsentnum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblabsentnum.Location = new Point(59, 39);
            lblabsentnum.Name = "lblabsentnum";
            lblabsentnum.Size = new Size(42, 32);
            lblabsentnum.TabIndex = 74;
            lblabsentnum.Text = "50";
            lblabsentnum.Click += lblabsentnum_Click;
            // 
            // lblabsent
            // 
            lblabsent.AutoSize = true;
            lblabsent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblabsent.Location = new Point(19, 18);
            lblabsent.Name = "lblabsent";
            lblabsent.Size = new Size(127, 21);
            lblabsent.TabIndex = 74;
            lblabsent.Text = "ABSENT TODAY";
            lblabsent.Click += lblabsent_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(594, 237);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(334, 99);
            dataGridView1.TabIndex = 69;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 128);
            btnLogout.FlatAppearance.BorderSize = 8;
            btnLogout.Location = new Point(920, 82);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(66, 29);
            btnLogout.TabIndex = 64;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(934, 50);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 61;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(273, 90);
            label1.Name = "label1";
            label1.Size = new Size(215, 13);
            label1.TabIndex = 70;
            label1.Text = "WELCOME TO COLLEGE OF INFORMATICS";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(672, 57);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(173, 23);
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
            chart1.Location = new Point(277, 237);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(300, 303);
            chart1.TabIndex = 73;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(panel5);
            Controls.Add(chart1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(btnLogout);
            Controls.Add(pictureBox2);
            Controls.Add(lblUserName);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox pictureBox2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}