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
            lblUserName = new Label();
            pictureBox2 = new PictureBox();
            btnManage = new Button();
            btnProfessors = new Button();
            btnUsers = new Button();
            btnHome = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            panel3 = new Panel();
            lblStudentRegistration = new Label();
            btnStudentRegistration = new Button();
            lblProfessors = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            lblUsers = new Label();
            lblManage = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            btnLogout = new Button();
            label2 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(746, 49);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(78, 25);
            lblUserName.TabIndex = 62;
            lblUserName.Text = "ADMIN";
            lblUserName.Click += lblUserName_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(925, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 61;
            pictureBox2.TabStop = false;
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnManage.Location = new Point(12, 89);
            btnManage.Name = "btnManage";
            btnManage.Size = new Size(223, 56);
            btnManage.TabIndex = 5;
            btnManage.UseVisualStyleBackColor = false;
            btnManage.Click += btnManage_Click;
            // 
            // btnProfessors
            // 
            btnProfessors.BackColor = Color.SteelBlue;
            btnProfessors.FlatAppearance.BorderSize = 0;
            btnProfessors.FlatStyle = FlatStyle.Flat;
            btnProfessors.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnProfessors.Location = new Point(12, 237);
            btnProfessors.Name = "btnProfessors";
            btnProfessors.Size = new Size(223, 56);
            btnProfessors.TabIndex = 4;
            btnProfessors.UseVisualStyleBackColor = false;
            btnProfessors.Click += btnProfessors_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.SteelBlue;
            btnUsers.BackgroundImageLayout = ImageLayout.None;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUsers.Location = new Point(12, 163);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(223, 56);
            btnUsers.TabIndex = 2;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
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
            panel3.Controls.Add(lblStudentRegistration);
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(lblProfessors);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(lblUsers);
            panel3.Controls.Add(lblManage);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnUsers);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // lblStudentRegistration
            // 
            lblStudentRegistration.AutoSize = true;
            lblStudentRegistration.BackColor = Color.White;
            lblStudentRegistration.Location = new Point(42, 329);
            lblStudentRegistration.Name = "lblStudentRegistration";
            lblStudentRegistration.Size = new Size(140, 15);
            lblStudentRegistration.TabIndex = 74;
            lblStudentRegistration.Text = "STUDENT REGISTRATION";
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.Location = new Point(18, 317);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(188, 38);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.TextImageRelation = TextImageRelation.ImageAboveText;
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // lblProfessors
            // 
            lblProfessors.AutoSize = true;
            lblProfessors.BackColor = Color.Transparent;
            lblProfessors.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblProfessors.Location = new Point(95, 255);
            lblProfessors.Name = "lblProfessors";
            lblProfessors.Size = new Size(87, 17);
            lblProfessors.TabIndex = 72;
            lblProfessors.Text = "PROFESSORS";
            lblProfessors.Click += lblProfessors_Click;
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
            // lblUsers
            // 
            lblUsers.AutoSize = true;
            lblUsers.BackColor = Color.Transparent;
            lblUsers.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUsers.Location = new Point(95, 182);
            lblUsers.Name = "lblUsers";
            lblUsers.Size = new Size(46, 17);
            lblUsers.TabIndex = 67;
            lblUsers.Text = "USERS";
            lblUsers.Click += lblUsers_Click;
            // 
            // lblManage
            // 
            lblManage.AutoSize = true;
            lblManage.BackColor = Color.Transparent;
            lblManage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManage.ForeColor = Color.Black;
            lblManage.Location = new Point(95, 109);
            lblManage.Name = "lblManage";
            lblManage.Size = new Size(64, 17);
            lblManage.TabIndex = 66;
            lblManage.Text = "MANAGE";
            lblManage.Click += lblManage_Click;
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
            pictureBox3.Click += pictureBox3_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(913, 85);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(66, 29);
            btnLogout.TabIndex = 64;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(277, 47);
            label2.Name = "label2";
            label2.Size = new Size(164, 32);
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
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(lblUserName);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(label2);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox2;
        private Button btnAttendanceReport;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnUsers;
        private Button btnHome;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel3;
        private Button btnLogout;
        private Label label2;
        private Label label5;
        private PictureBox pictureBox3;
        private Label label3;
        private Label lblUsers;
        private Label lblManage;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Label lblProfessors;
        public Label lblUserName;
        private Button btnStudentRegistration;
        private Label lblStudentRegistration;
    }
}