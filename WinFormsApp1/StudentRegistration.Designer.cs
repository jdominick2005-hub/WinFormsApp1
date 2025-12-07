
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
            clbSubjects = new CheckedListBox();
            cmbsection = new ComboBox();
            cmbcourse = new ComboBox();
            cmbyearlevel = new ComboBox();
            btnEnroll = new Button();
            lblEnroll = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
            lblLastName = new Label();
            dgvStudentRegistration = new DataGridView();
            btnUpdate = new Button();
            txtLastName = new TextBox();
            btnShow = new Button();
            btnRegister = new Button();
            lblSection = new Label();
            txtFirstName = new TextBox();
            txtStudentID = new TextBox();
            lblCourse = new Label();
            lblYearLevel = new Label();
            lblFirstName = new Label();
            lblStudentId = new Label();
            label2 = new Label();
            label5 = new Label();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            btnLogout = new Button();
            gbStudentRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // gbStudentRegistration
            // 
            gbStudentRegistration.AutoSize = true;
            gbStudentRegistration.Controls.Add(clbSubjects);
            gbStudentRegistration.Controls.Add(cmbsection);
            gbStudentRegistration.Controls.Add(cmbcourse);
            gbStudentRegistration.Controls.Add(cmbyearlevel);
            gbStudentRegistration.Controls.Add(btnEnroll);
            gbStudentRegistration.Controls.Add(lblEnroll);
            gbStudentRegistration.Controls.Add(btnEdit);
            gbStudentRegistration.Controls.Add(btnDelete);
            gbStudentRegistration.Controls.Add(lblLastName);
            gbStudentRegistration.Controls.Add(dgvStudentRegistration);
            gbStudentRegistration.Controls.Add(btnUpdate);
            gbStudentRegistration.Controls.Add(txtLastName);
            gbStudentRegistration.Controls.Add(btnShow);
            gbStudentRegistration.Controls.Add(btnRegister);
            gbStudentRegistration.Controls.Add(lblSection);
            gbStudentRegistration.Controls.Add(txtFirstName);
            gbStudentRegistration.Controls.Add(txtStudentID);
            gbStudentRegistration.Controls.Add(lblCourse);
            gbStudentRegistration.Controls.Add(lblYearLevel);
            gbStudentRegistration.Controls.Add(lblFirstName);
            gbStudentRegistration.Controls.Add(lblStudentId);
            gbStudentRegistration.Location = new Point(258, 118);
            gbStudentRegistration.Name = "gbStudentRegistration";
            gbStudentRegistration.Size = new Size(711, 526);
            gbStudentRegistration.TabIndex = 1;
            gbStudentRegistration.TabStop = false;
            gbStudentRegistration.Text = "Student Registration";
            // 
            // clbSubjects
            // 
            clbSubjects.FormattingEnabled = true;
            clbSubjects.Location = new Point(83, 237);
            clbSubjects.Name = "clbSubjects";
            clbSubjects.Size = new Size(248, 58);
            clbSubjects.TabIndex = 20;
            // 
            // cmbsection
            // 
            cmbsection.FormattingEnabled = true;
            cmbsection.Location = new Point(170, 188);
            cmbsection.Name = "cmbsection";
            cmbsection.Size = new Size(215, 23);
            cmbsection.TabIndex = 19;
            // 
            // cmbcourse
            // 
            cmbcourse.FormattingEnabled = true;
            cmbcourse.Location = new Point(170, 159);
            cmbcourse.Name = "cmbcourse";
            cmbcourse.Size = new Size(215, 23);
            cmbcourse.TabIndex = 18;
            cmbcourse.SelectedIndexChanged += cmbsection_SelectedIndexChanged;
            // 
            // cmbyearlevel
            // 
            cmbyearlevel.FormattingEnabled = true;
            cmbyearlevel.Location = new Point(170, 130);
            cmbyearlevel.Name = "cmbyearlevel";
            cmbyearlevel.Size = new Size(196, 23);
            cmbyearlevel.TabIndex = 17;
            // 
            // btnEnroll
            // 
            btnEnroll.BackColor = Color.SteelBlue;
            btnEnroll.FlatStyle = FlatStyle.Flat;
            btnEnroll.Location = new Point(558, 246);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(75, 28);
            btnEnroll.TabIndex = 16;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = false;
            btnEnroll.Click += btnEnroll_Click;
            // 
            // lblEnroll
            // 
            lblEnroll.AutoSize = true;
            lblEnroll.Location = new Point(83, 219);
            lblEnroll.Name = "lblEnroll";
            lblEnroll.Size = new Size(83, 15);
            lblEnroll.TabIndex = 15;
            lblEnroll.Text = "Select Subject:";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(558, 126);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 28);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(558, 206);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 28);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete All";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(83, 104);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "LastName:";
            // 
            // dgvStudentRegistration
            // 
            dgvStudentRegistration.BackgroundColor = Color.Gainsboro;
            dgvStudentRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRegistration.Location = new Point(83, 328);
            dgvStudentRegistration.Name = "dgvStudentRegistration";
            dgvStudentRegistration.RowHeadersWidth = 51;
            dgvStudentRegistration.Size = new Size(550, 170);
            dgvStudentRegistration.TabIndex = 3;
            dgvStudentRegistration.CellClick += dgvStudentRegistration_CellClick;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(558, 166);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 28);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(170, 96);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(196, 23);
            txtLastName.TabIndex = 8;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.SteelBlue;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Location = new Point(558, 86);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 28);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.SteelBlue;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(558, 46);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 28);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(83, 191);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(49, 15);
            lblSection.TabIndex = 10;
            lblSection.Text = "Section:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(170, 67);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(196, 23);
            txtFirstName.TabIndex = 7;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(170, 38);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(196, 23);
            txtStudentID.TabIndex = 6;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(83, 162);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 9;
            lblCourse.Text = "Course:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(83, 133);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(62, 15);
            lblYearLevel.TabIndex = 8;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(83, 75);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "FirstName:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(83, 46);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(61, 15);
            lblStudentId.TabIndex = 5;
            lblStudentId.Text = "StudentId:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(267, 50);
            label2.Name = "label2";
            label2.Size = new Size(442, 47);
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
            // btnStudentRegistration
            // 
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(13, 246);
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
            btnManage.Location = new Point(13, 92);
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
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLogout.Location = new Point(13, 395);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(223, 56);
            btnLogout.TabIndex = 101;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // StudentRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(gbStudentRegistration);
            MaximizeBox = false;
            Name = "StudentRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentRegistration";
            gbStudentRegistration.ResumeLayout(false);
            gbStudentRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private GroupBox gbStudentRegistration;
        private Label lblCourse;
        private Label lblYearLevel;
        private Label lblFirstName;
        private Label lblStudentId;
        private TextBox txtFirstName;
        private TextBox txtStudentID;
        private Button btnRegister;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnShow;
        private DataGridView dgvStudentRegistration;
        private Label lblSection;
        private Button btnEdit;
        private TextBox txtLastName;
        private Label lblLastName;
        private Label lblEnroll;
        private Button btnEnroll;
        private Label label2;
        private Label label5;
        private Button btnStudentRegistration;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Button btnLogout;
        private ComboBox cmbcourse;
        private ComboBox cmbyearlevel;
        private ComboBox cmbsection;
        private CheckedListBox clbSubjects;
    }
}