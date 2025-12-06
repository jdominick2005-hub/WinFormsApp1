
namespace WinFormsApp1
{
    partial class ProfessorsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorsForm));
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            btnStudentRegistration = new Button();
            label1 = new Label();
            lblLast = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            lblUsername = new Label();
            lblPrograms = new Label();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            gbProfessorSectionRegistration = new GroupBox();
            txtprogram = new TextBox();
            lblFirst = new Label();
            txtFirstName = new TextBox();
            btnUpdate = new Button();
            btnEdit = new Button();
            dgvTeachers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            gbProfessorSectionRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1087, 65);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 53);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 79;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(305, 67);
            label2.Name = "label2";
            label2.Size = new Size(205, 41);
            label2.TabIndex = 81;
            label2.Text = "PROFESSORS";
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
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.Flat;
            btnManage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnManage.Location = new Point(14, 123);
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
            btnProfessors.FlatStyle = FlatStyle.System;
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
            // btnStudentRegistration
            // 
            btnStudentRegistration.FlatAppearance.BorderSize = 0;
            btnStudentRegistration.FlatStyle = FlatStyle.Flat;
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(16, 328);
            btnStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(255, 75);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(973, 76);
            label1.Name = "label1";
            label1.Size = new Size(99, 32);
            label1.TabIndex = 80;
            label1.Text = "ADMIN";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(66, 101);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(78, 20);
            lblLast.TabIndex = 84;
            lblLast.Text = "LastName:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(66, 147);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 20);
            lblEmail.TabIndex = 85;
            lblEmail.Text = "Email Address:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(67, 224);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 86;
            lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(67, 185);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 87;
            lblUsername.Text = "Username:";
            // 
            // lblPrograms
            // 
            lblPrograms.AutoSize = true;
            lblPrograms.Location = new Point(67, 256);
            lblPrograms.Name = "lblPrograms";
            lblPrograms.Size = new Size(75, 20);
            lblPrograms.TabIndex = 88;
            lblPrograms.Text = "Programs:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(194, 136);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(218, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(194, 97);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(218, 27);
            txtLastName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(194, 213);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(218, 27);
            txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(194, 175);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(218, 27);
            txtUsername.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(406, 567);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 39);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "  Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(683, 567);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 39);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // gbProfessorSectionRegistration
            // 
            gbProfessorSectionRegistration.Controls.Add(txtprogram);
            gbProfessorSectionRegistration.Controls.Add(lblFirst);
            gbProfessorSectionRegistration.Controls.Add(txtFirstName);
            gbProfessorSectionRegistration.Controls.Add(btnUpdate);
            gbProfessorSectionRegistration.Controls.Add(btnEdit);
            gbProfessorSectionRegistration.Controls.Add(dgvTeachers);
            gbProfessorSectionRegistration.Controls.Add(btnAdd);
            gbProfessorSectionRegistration.Controls.Add(btnDelete);
            gbProfessorSectionRegistration.Controls.Add(lblPrograms);
            gbProfessorSectionRegistration.Controls.Add(lblPassword);
            gbProfessorSectionRegistration.Controls.Add(lblUsername);
            gbProfessorSectionRegistration.Controls.Add(txtLastName);
            gbProfessorSectionRegistration.Controls.Add(txtUsername);
            gbProfessorSectionRegistration.Controls.Add(txtEmail);
            gbProfessorSectionRegistration.Controls.Add(lblEmail);
            gbProfessorSectionRegistration.Controls.Add(txtPassword);
            gbProfessorSectionRegistration.Controls.Add(lblLast);
            gbProfessorSectionRegistration.Location = new Point(305, 183);
            gbProfessorSectionRegistration.Margin = new Padding(3, 4, 3, 4);
            gbProfessorSectionRegistration.Name = "gbProfessorSectionRegistration";
            gbProfessorSectionRegistration.Padding = new Padding(3, 4, 3, 4);
            gbProfessorSectionRegistration.Size = new Size(813, 631);
            gbProfessorSectionRegistration.TabIndex = 99;
            gbProfessorSectionRegistration.TabStop = false;
            gbProfessorSectionRegistration.Text = "Professor Section Registration";
            // 
            // txtprogram
            // 
            txtprogram.Location = new Point(194, 252);
            txtprogram.Name = "txtprogram";
            txtprogram.Size = new Size(218, 27);
            txtprogram.TabIndex = 93;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(66, 63);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(79, 20);
            lblFirst.TabIndex = 92;
            lblFirst.Text = "FirstName:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(194, 59);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(218, 27);
            txtFirstName.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(591, 567);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 39);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(498, 567);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 39);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvTeachers
            // 
            dgvTeachers.BackgroundColor = Color.Gainsboro;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Location = new Point(66, 303);
            dgvTeachers.Margin = new Padding(3, 4, 3, 4);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.RowHeadersWidth = 51;
            dgvTeachers.Size = new Size(703, 239);
            dgvTeachers.TabIndex = 13;
            // 
            // ProfessorsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 859);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(gbProfessorSectionRegistration);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ProfessorsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proffesors";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            gbProfessorSectionRegistration.ResumeLayout(false);
            gbProfessorSectionRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label2;
        private Label label5;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
        private Label lblLast;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblPrograms;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnAdd;
        private Button btnDelete;
        private GroupBox gbProfessorSectionRegistration;
        private DataGridView dgvTeachers;
        private Button btnStudentRegistration;
        private Button btnUpdate;
        private Button btnEdit;
        private Label lblFirst;
        private TextBox txtFirstName;
        private TextBox txtprogram;
    }
}