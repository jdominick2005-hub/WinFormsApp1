namespace WinFormsApp1
{
    partial class Attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendance));
            label2 = new Label();
            btnLogout = new Button();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            lblUserName = new Label();
            panel3 = new Panel();
            lblSubject = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            lblClass = new Label();
            lblAttendance = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            btnAttendanceForm = new Button();
            btnSubject = new Button();
            btnClass = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            cmbSubjects = new ComboBox();
            dvgStudents = new DataGridView();
            btnSave = new Button();
            btnLoad = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(299, 47);
            label2.Name = "label2";
            label2.Size = new Size(0, 32);
            label2.TabIndex = 75;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(935, 85);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(66, 29);
            btnLogout.TabIndex = 76;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(79, 205);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 71;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(947, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 73;
            pictureBox2.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(817, 53);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(95, 25);
            lblUserName.TabIndex = 74;
            lblUserName.Text = "TEACHER";
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(lblSubject);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(lblClass);
            panel3.Controls.Add(lblAttendance);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(btnAttendanceForm);
            panel3.Controls.Add(btnSubject);
            panel3.Controls.Add(btnClass);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
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
            // btnAttendanceForm
            // 
            btnAttendanceForm.BackColor = Color.SteelBlue;
            btnAttendanceForm.FlatAppearance.BorderSize = 0;
            btnAttendanceForm.FlatStyle = FlatStyle.Flat;
            btnAttendanceForm.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAttendanceForm.Location = new Point(12, 89);
            btnAttendanceForm.Name = "btnAttendanceForm";
            btnAttendanceForm.Size = new Size(223, 56);
            btnAttendanceForm.TabIndex = 5;
            btnAttendanceForm.UseVisualStyleBackColor = false;
            // 
            // btnSubject
            // 
            btnSubject.BackColor = Color.SteelBlue;
            btnSubject.FlatAppearance.BorderSize = 0;
            btnSubject.FlatStyle = FlatStyle.Flat;
            btnSubject.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSubject.Location = new Point(12, 237);
            btnSubject.Name = "btnSubject";
            btnSubject.Size = new Size(223, 56);
            btnSubject.TabIndex = 4;
            btnSubject.UseVisualStyleBackColor = false;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.SteelBlue;
            btnClass.BackgroundImageLayout = ImageLayout.None;
            btnClass.FlatAppearance.BorderSize = 0;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClass.Location = new Point(12, 163);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(223, 56);
            btnClass.TabIndex = 2;
            btnClass.UseVisualStyleBackColor = false;
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
            panel1.TabIndex = 72;
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
            // cmbSubjects
            // 
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(379, 89);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(121, 23);
            cmbSubjects.TabIndex = 77;
            // 
            // dvgStudents
            // 
            dvgStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgStudents.Location = new Point(278, 138);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.Size = new Size(615, 296);
            dvgStudents.TabIndex = 78;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(319, 474);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 79;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(409, 474);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 80;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(290, 92);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 81;
            label1.Text = "Select Subject:";
            // 
            // Attendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(label1);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(dvgStudents);
            Controls.Add(cmbSubjects);
            Controls.Add(lblUserName);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label5);
            Controls.Add(btnLogout);
            Controls.Add(label2);
            Name = "Attendance";
            Text = "Attendance";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnLogout;
        private Label label5;
        private PictureBox pictureBox2;
        private Label lblUserName;
        private Panel panel3;
        private Label lblSubject;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Label lblClass;
        private Label lblAttendance;
        private Label label3;
        private PictureBox pictureBox3;
        private Button btnAttendanceForm;
        private Button btnSubject;
        private Button btnClass;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private ComboBox cmbSubjects;
        private DataGridView dvgStudents;
        private Button btnSave;
        private Button btnLoad;
        private Label label1;
    }
}