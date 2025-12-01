namespace WinFormsApp1
{
    partial class TeacherPanelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherPanelForm));
            btnLogout = new Button();
            label2 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            btnStudent = new Button();
            btnReports = new Button();
            lblSubject = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            lblClass = new Label();
            lblAttendance = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            btnAttendance = new Button();
            btnSubject = new Button();
            btnClass = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblUserName = new Label();
            panelMain = new Panel();
            panelTopDashboard = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(928, 85);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(66, 29);
            btnLogout.TabIndex = 70;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(292, 47);
            label2.Name = "label2";
            label2.Size = new Size(164, 32);
            label2.TabIndex = 69;
            label2.Text = "DASHBOARD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(72, 205);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 65;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnStudent);
            panel3.Controls.Add(btnReports);
            panel3.Controls.Add(lblSubject);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(lblClass);
            panel3.Controls.Add(lblAttendance);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(btnAttendance);
            panel3.Controls.Add(btnSubject);
            panel3.Controls.Add(btnClass);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // btnStudent
            // 
            btnStudent.BackColor = Color.SteelBlue;
            btnStudent.FlatAppearance.BorderSize = 0;
            btnStudent.FlatStyle = FlatStyle.Flat;
            btnStudent.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudent.Location = new Point(8, 303);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(223, 56);
            btnStudent.TabIndex = 74;
            btnStudent.Text = "STUDENTS";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.SteelBlue;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnReports.Location = new Point(13, 375);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(223, 56);
            btnReports.TabIndex = 73;
            btnReports.Text = "REPORTS";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.BackColor = Color.Transparent;
            lblSubject.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSubject.Location = new Point(95, 255);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(61, 17);
            lblSubject.TabIndex = 72;
            lblSubject.Text = "SUBJECT";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(51, 172);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(32, 33);
            pictureBox6.TabIndex = 71;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(51, 248);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(33, 29);
            pictureBox5.TabIndex = 70;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(52, 100);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 29);
            pictureBox4.TabIndex = 69;
            pictureBox4.TabStop = false;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.BackColor = Color.Transparent;
            lblClass.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblClass.Location = new Point(95, 182);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(70, 17);
            lblClass.TabIndex = 67;
            lblClass.Text = "MY CLASS";
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.BackColor = Color.Transparent;
            lblAttendance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttendance.ForeColor = Color.Black;
            lblAttendance.Location = new Point(95, 109);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(93, 17);
            lblAttendance.TabIndex = 66;
            lblAttendance.Text = "ATTENDANCE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(95, 36);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 65;
            label3.Text = "HOME";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(55, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 20);
            pictureBox3.TabIndex = 65;
            pictureBox3.TabStop = false;
            // 
            // btnAttendance
            // 
            btnAttendance.BackColor = Color.SteelBlue;
            btnAttendance.FlatAppearance.BorderSize = 0;
            btnAttendance.FlatStyle = FlatStyle.Flat;
            btnAttendance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAttendance.Location = new Point(12, 87);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Size = new Size(223, 56);
            btnAttendance.TabIndex = 5;
            btnAttendance.UseVisualStyleBackColor = false;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnSubject
            // 
            btnSubject.BackColor = Color.SteelBlue;
            btnSubject.FlatAppearance.BorderSize = 0;
            btnSubject.FlatStyle = FlatStyle.Flat;
            btnSubject.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSubject.Location = new Point(12, 231);
            btnSubject.Name = "btnSubject";
            btnSubject.Size = new Size(223, 56);
            btnSubject.TabIndex = 4;
            btnSubject.UseVisualStyleBackColor = false;
            btnSubject.Click += btnSubject_Click;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.SteelBlue;
            btnClass.BackgroundImageLayout = ImageLayout.None;
            btnClass.FlatAppearance.BorderSize = 0;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClass.Location = new Point(12, 159);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(223, 56);
            btnClass.TabIndex = 2;
            btnClass.UseVisualStyleBackColor = false;
            btnClass.Click += btnClass_Click;
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
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
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
            panel1.TabIndex = 66;
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
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(940, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 67;
            pictureBox2.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(810, 53);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(95, 25);
            lblUserName.TabIndex = 68;
            lblUserName.Text = "TEACHER";
            // 
            // panelMain
            // 
            panelMain.Location = new Point(235, 136);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(775, 508);
            panelMain.TabIndex = 71;
            // 
            // panelTopDashboard
            // 
            panelTopDashboard.Location = new Point(235, 0);
            panelTopDashboard.Name = "panelTopDashboard";
            panelTopDashboard.Size = new Size(775, 140);
            panelTopDashboard.TabIndex = 72;
            // 
            // TeacherPanelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(btnLogout);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(lblUserName);
            Controls.Add(panelMain);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(panelTopDashboard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TeacherPanelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeacherPanelForm";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Label label2;
        private Label label5;
        private Panel panel3;
        private Label lblSubject;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Label lblClass;
        private Label lblAttendance;
        private Label label3;
        private PictureBox pictureBox3;
        private Button btnAttendance;
        private Button btnSubject;
        private Button btnClass;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblUserName;
        private Button btnStudent;
        private Button btnReports;
        private Panel panelMain;
        private Panel panelTopDashboard;
    }
}