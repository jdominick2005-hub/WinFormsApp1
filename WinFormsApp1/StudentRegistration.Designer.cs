
namespace WinFormsApp1
{
    partial class StudentRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentRegistration));
            gbStudentRegistration = new GroupBox();
            lblEnroll = new Label();
            cmbEnrollSubject = new ComboBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblSection = new Label();
            txtSection = new TextBox();
            txtClassification = new TextBox();
            txtUnits = new TextBox();
            txtCourse = new TextBox();
            txtYearLevel = new TextBox();
            txtFirstName = new TextBox();
            txtStudentID = new TextBox();
            lblClassification = new Label();
            lblUnits = new Label();
            lblCourse = new Label();
            lblYearLevel = new Label();
            lblFirstName = new Label();
            lblStudentId = new Label();
            btnEnroll = new Button();
            btnRegister = new Button();
            groupBox2 = new GroupBox();
            btnEdit = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnShow = new Button();
            dgvStudentRegistration = new DataGridView();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            button1 = new Button();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnUsers = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            gbStudentRegistration.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // gbStudentRegistration
            // 
            gbStudentRegistration.AutoSize = true;
            gbStudentRegistration.Controls.Add(lblEnroll);
            gbStudentRegistration.Controls.Add(cmbEnrollSubject);
            gbStudentRegistration.Controls.Add(lblLastName);
            gbStudentRegistration.Controls.Add(txtLastName);
            gbStudentRegistration.Controls.Add(lblSection);
            gbStudentRegistration.Controls.Add(txtSection);
            gbStudentRegistration.Controls.Add(txtClassification);
            gbStudentRegistration.Controls.Add(txtUnits);
            gbStudentRegistration.Controls.Add(txtCourse);
            gbStudentRegistration.Controls.Add(txtYearLevel);
            gbStudentRegistration.Controls.Add(txtFirstName);
            gbStudentRegistration.Controls.Add(txtStudentID);
            gbStudentRegistration.Controls.Add(lblClassification);
            gbStudentRegistration.Controls.Add(lblUnits);
            gbStudentRegistration.Controls.Add(lblCourse);
            gbStudentRegistration.Controls.Add(lblYearLevel);
            gbStudentRegistration.Controls.Add(lblFirstName);
            gbStudentRegistration.Controls.Add(lblStudentId);
            gbStudentRegistration.Location = new Point(242, 124);
            gbStudentRegistration.Name = "gbStudentRegistration";
            gbStudentRegistration.Size = new Size(577, 288);
            gbStudentRegistration.TabIndex = 1;
            gbStudentRegistration.TabStop = false;
            gbStudentRegistration.Text = "Student Registration";
            gbStudentRegistration.Enter += gbStudentRegistration_Enter;
            // 
            // lblEnroll
            // 
            lblEnroll.AutoSize = true;
            lblEnroll.Location = new Point(342, 31);
            lblEnroll.Name = "lblEnroll";
            lblEnroll.Size = new Size(83, 15);
            lblEnroll.TabIndex = 15;
            lblEnroll.Text = "Select Subject:";
            lblEnroll.Click += lblEnroll_Click;
            // 
            // cmbEnrollSubject
            // 
            cmbEnrollSubject.FormattingEnabled = true;
            cmbEnrollSubject.Location = new Point(422, 28);
            cmbEnrollSubject.Name = "cmbEnrollSubject";
            cmbEnrollSubject.Size = new Size(149, 23);
            cmbEnrollSubject.TabIndex = 14;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(58, 96);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "LastName:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(126, 88);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(196, 23);
            txtLastName.TabIndex = 8;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(58, 183);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(49, 15);
            lblSection.TabIndex = 10;
            lblSection.Text = "Section:";
            // 
            // txtSection
            // 
            txtSection.Location = new Point(126, 175);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(195, 23);
            txtSection.TabIndex = 11;
            // 
            // txtClassification
            // 
            txtClassification.Location = new Point(126, 233);
            txtClassification.Name = "txtClassification";
            txtClassification.Size = new Size(196, 23);
            txtClassification.TabIndex = 13;
            // 
            // txtUnits
            // 
            txtUnits.Location = new Point(125, 204);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new Size(196, 23);
            txtUnits.TabIndex = 12;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(125, 146);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(196, 23);
            txtCourse.TabIndex = 10;
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(126, 117);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(196, 23);
            txtYearLevel.TabIndex = 9;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(126, 57);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(196, 23);
            txtFirstName.TabIndex = 7;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(126, 28);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(196, 23);
            txtStudentID.TabIndex = 6;
            // 
            // lblClassification
            // 
            lblClassification.AutoSize = true;
            lblClassification.Location = new Point(40, 236);
            lblClassification.Name = "lblClassification";
            lblClassification.Size = new Size(80, 15);
            lblClassification.TabIndex = 12;
            lblClassification.Text = "Classification:";
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Location = new Point(62, 212);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(37, 15);
            lblUnits.TabIndex = 11;
            lblUnits.Text = "Units:";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(62, 154);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 9;
            lblCourse.Text = "Course:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(62, 125);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(62, 15);
            lblYearLevel.TabIndex = 8;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(58, 65);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "FirstName:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(60, 36);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(61, 15);
            lblStudentId.TabIndex = 5;
            lblStudentId.Text = "StudentId:";
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(65, 189);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(75, 23);
            btnEnroll.TabIndex = 16;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = true;
            btnEnroll.Click += btnEnroll_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(65, 44);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEnroll);
            groupBox2.Controls.Add(btnEdit);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnShow);
            groupBox2.Controls.Add(btnRegister);
            groupBox2.Location = new Point(804, 124);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(192, 288);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(65, 102);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(65, 160);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete All";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(65, 131);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(65, 73);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // dgvStudentRegistration
            // 
            dgvStudentRegistration.BackgroundColor = Color.Gainsboro;
            dgvStudentRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRegistration.Location = new Point(300, 406);
            dgvStudentRegistration.Name = "dgvStudentRegistration";
            dgvStudentRegistration.Size = new Size(642, 170);
            dgvStudentRegistration.TabIndex = 3;
            dgvStudentRegistration.CellClick += dgvStudentRegistration_CellClick;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(951, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 79;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(303, 47);
            label2.Name = "label2";
            label2.Size = new Size(300, 32);
            label2.TabIndex = 81;
            label2.Text = "STUDENT REGISTRATION";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(83, 205);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 77;
            // 
            // button1
            // 
            button1.Location = new Point(939, 85);
            button1.Name = "button1";
            button1.Size = new Size(66, 29);
            button1.TabIndex = 82;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.Location = new Point(13, 311);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(223, 56);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.UseVisualStyleBackColor = true;
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
            btnProfessors.Location = new Point(12, 237);
            btnProfessors.Name = "btnProfessors";
            btnProfessors.Size = new Size(223, 56);
            btnProfessors.TabIndex = 4;
            btnProfessors.Text = "PROFESSORS";
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
            btnUsers.Text = "USERS";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.SteelBlue;
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnHome.Location = new Point(12, 15);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(224, 56);
            btnHome.TabIndex = 0;
            btnHome.Text = "HOME";
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
            panel1.TabIndex = 78;
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
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnUsers);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(871, 56);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 80;
            label1.Text = "ADMIN";
            // 
            // StudentRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(dgvStudentRegistration);
            Controls.Add(gbStudentRegistration);
            Controls.Add(groupBox2);
            MaximizeBox = false;
            Name = "StudentRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentRegistration";
            gbStudentRegistration.ResumeLayout(false);
            gbStudentRegistration.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private GroupBox gbStudentRegistration;
        private Label lblClassification;
        private Label lblUnits;
        private Label lblCourse;
        private Label lblYearLevel;
        private Label lblFirstName;
        private Label lblStudentId;
        private TextBox txtClassification;
        private TextBox txtUnits;
        private TextBox txtCourse;
        private TextBox txtYearLevel;
        private TextBox txtFirstName;
        private TextBox txtStudentID;
        private Button btnRegister;
        private GroupBox groupBox2;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnShow;
        private DataGridView dgvStudentRegistration;
        private Label lblSection;
        private TextBox txtSection;
        private Button btnEdit;
        private TextBox txtLastName;
        private Label lblLastName;
        private Label lblEnroll;
        private ComboBox cmbEnrollSubject;
        private Button btnEnroll;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label5;
        private Button button1;
        private Button btnStudentRegistration;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnUsers;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
    }
}