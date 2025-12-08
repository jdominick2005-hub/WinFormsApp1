
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
            lblEnroll = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
            lblLastName = new Label();
            dgvStudentRegistration = new DataGridView();
            btnUpdate = new Button();
            txtLastName = new TextBox();
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
            gbStudentRegistration.Controls.Add(lblEnroll);
            gbStudentRegistration.Controls.Add(btnEdit);
            gbStudentRegistration.Controls.Add(btnDelete);
            gbStudentRegistration.Controls.Add(lblLastName);
            gbStudentRegistration.Controls.Add(dgvStudentRegistration);
            gbStudentRegistration.Controls.Add(btnUpdate);
            gbStudentRegistration.Controls.Add(txtLastName);
            gbStudentRegistration.Controls.Add(btnRegister);
            gbStudentRegistration.Controls.Add(lblSection);
            gbStudentRegistration.Controls.Add(txtFirstName);
            gbStudentRegistration.Controls.Add(txtStudentID);
            gbStudentRegistration.Controls.Add(lblCourse);
            gbStudentRegistration.Controls.Add(lblYearLevel);
            gbStudentRegistration.Controls.Add(lblFirstName);
            gbStudentRegistration.Controls.Add(lblStudentId);
            gbStudentRegistration.Location = new Point(305, 128);
            gbStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            gbStudentRegistration.Name = "gbStudentRegistration";
            gbStudentRegistration.Padding = new Padding(3, 4, 3, 4);
            gbStudentRegistration.Size = new Size(813, 715);
            gbStudentRegistration.TabIndex = 1;
            gbStudentRegistration.TabStop = false;
            gbStudentRegistration.Text = "Student Registration";
            // 
            // clbSubjects
            // 
            clbSubjects.BorderStyle = BorderStyle.None;
            clbSubjects.FormattingEnabled = true;
            clbSubjects.Location = new Point(194, 289);
            clbSubjects.Margin = new Padding(3, 4, 3, 4);
            clbSubjects.Name = "clbSubjects";
            clbSubjects.Size = new Size(283, 66);
            clbSubjects.TabIndex = 12;
            // 
            // cmbsection
            // 
            cmbsection.FormattingEnabled = true;
            cmbsection.Location = new Point(194, 251);
            cmbsection.Margin = new Padding(3, 4, 3, 4);
            cmbsection.Name = "cmbsection";
            cmbsection.Size = new Size(245, 28);
            cmbsection.TabIndex = 11;
            cmbsection.SelectedIndexChanged += cmbsection_SelectedIndexChanged;
            // 
            // cmbcourse
            // 
            cmbcourse.FormattingEnabled = true;
            cmbcourse.Location = new Point(194, 212);
            cmbcourse.Margin = new Padding(3, 4, 3, 4);
            cmbcourse.Name = "cmbcourse";
            cmbcourse.Size = new Size(245, 28);
            cmbcourse.TabIndex = 10;
            cmbcourse.SelectedIndexChanged += cmbcourse_SelectedIndexChanged;
            // 
            // cmbyearlevel
            // 
            cmbyearlevel.FormattingEnabled = true;
            cmbyearlevel.Location = new Point(194, 173);
            cmbyearlevel.Margin = new Padding(3, 4, 3, 4);
            cmbyearlevel.Name = "cmbyearlevel";
            cmbyearlevel.Size = new Size(223, 28);
            cmbyearlevel.TabIndex = 9;
            cmbyearlevel.SelectedIndexChanged += cmbyearlevel_SelectedIndexChanged;
            // 
            // lblEnroll
            // 
            lblEnroll.AutoSize = true;
            lblEnroll.Location = new Point(95, 292);
            lblEnroll.Name = "lblEnroll";
            lblEnroll.Size = new Size(105, 20);
            lblEnroll.TabIndex = 15;
            lblEnroll.Text = "Select Subject:";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(638, 112);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 37);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(638, 216);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 37);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(95, 139);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(78, 20);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "LastName:";
            // 
            // dgvStudentRegistration
            // 
            dgvStudentRegistration.BackgroundColor = Color.Gainsboro;
            dgvStudentRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRegistration.Location = new Point(95, 377);
            dgvStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            dgvStudentRegistration.Name = "dgvStudentRegistration";
            dgvStudentRegistration.RowHeadersWidth = 51;
            dgvStudentRegistration.Size = new Size(629, 308);
            dgvStudentRegistration.TabIndex = 17;
            dgvStudentRegistration.CellClick += dgvStudentRegistration_CellClick;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(638, 167);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 37);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(194, 128);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(224, 27);
            txtLastName.TabIndex = 8;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.SteelBlue;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(638, 61);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(86, 37);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(95, 255);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(61, 20);
            lblSection.TabIndex = 10;
            lblSection.Text = "Section:";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(194, 89);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(224, 27);
            txtFirstName.TabIndex = 7;
            // 
            // txtStudentID
            // 
            txtStudentID.BorderStyle = BorderStyle.FixedSingle;
            txtStudentID.Location = new Point(194, 51);
            txtStudentID.Margin = new Padding(3, 4, 3, 4);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(224, 27);
            txtStudentID.TabIndex = 6;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(95, 216);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(57, 20);
            lblCourse.TabIndex = 9;
            lblCourse.Text = "Course:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(95, 177);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(78, 20);
            lblYearLevel.TabIndex = 8;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(95, 100);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(79, 20);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "FirstName:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStudentId.Location = new Point(95, 61);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(76, 20);
            lblStudentId.TabIndex = 5;
            lblStudentId.Text = "StudentId:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(305, 67);
            label2.Name = "label2";
            label2.Size = new Size(549, 60);
            label2.TabIndex = 81;
            label2.Text = "STUDENT REGISTRATION";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(95, 273);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 77;
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(15, 328);
            btnStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(255, 75);
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
            btnHome.FlatStyle = FlatStyle.Flat;
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
            panel1.TabIndex = 78;
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
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 244);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(269, 613);
            panel3.TabIndex = 1;
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
            btnLogout.TabIndex = 101;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // StudentRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 859);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(gbStudentRegistration);
            Margin = new Padding(3, 4, 3, 4);
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
        private DataGridView dgvStudentRegistration;
        private Label lblSection;
        private TextBox txtLastName;
        private Label lblLastName;
        private Label lblEnroll;
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
        private Button btnEdit;
    }
}