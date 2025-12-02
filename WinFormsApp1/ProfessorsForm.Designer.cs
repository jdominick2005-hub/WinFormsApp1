
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
            button1 = new Button();
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
            lblDepartment = new Label();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnAdd = new Button();
            btnSendEmail = new Button();
            btnDelete = new Button();
            btnShow = new Button();
            txtDepartment = new TextBox();
            gbProfessorSectionRegistration = new GroupBox();
            btnClear = new Button();
            lblFirst = new Label();
            txtFirstName = new TextBox();
            btnUpdate = new Button();
            btnEdit = new Button();
            dgvTeachers = new DataGridView();
            txtTeacherID = new TextBox();
            txtUserID = new TextBox();
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
            label2.Location = new Point(267, 50);
            label2.Name = "label2";
            label2.Size = new Size(161, 32);
            label2.TabIndex = 81;
            label2.Text = "PROFESSORS";
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
            btnProfessors.FlatStyle = FlatStyle.System;
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
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(14, 246);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(223, 56);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(851, 57);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 80;
            label1.Text = "ADMIN";
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Location = new Point(58, 116);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(63, 15);
            lblLast.TabIndex = 84;
            lblLast.Text = "LastName:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(58, 145);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(84, 15);
            lblEmail.TabIndex = 85;
            lblEmail.Text = "Email Address:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(58, 203);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 86;
            lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(58, 174);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 87;
            lblUsername.Text = "Username:";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(58, 232);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(73, 15);
            lblDepartment.TabIndex = 88;
            lblDepartment.Text = "Department:\r\n";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(170, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(191, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(170, 108);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(191, 23);
            txtLastName.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(170, 195);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(191, 23);
            txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(170, 166);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(191, 23);
            txtUsername.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(445, 100);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "  Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSendEmail
            // 
            btnSendEmail.BackColor = Color.SteelBlue;
            btnSendEmail.FlatAppearance.BorderSize = 0;
            btnSendEmail.FlatStyle = FlatStyle.Flat;
            btnSendEmail.Location = new Point(489, 192);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(75, 23);
            btnSendEmail.TabIndex = 7;
            btnSendEmail.Text = "Send Email";
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(445, 129);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.SteelBlue;
            btnShow.FlatAppearance.BorderSize = 0;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Location = new Point(536, 160);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 12;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(170, 224);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(191, 23);
            txtDepartment.TabIndex = 6;
            // 
            // gbProfessorSectionRegistration
            // 
            gbProfessorSectionRegistration.Controls.Add(btnClear);
            gbProfessorSectionRegistration.Controls.Add(lblFirst);
            gbProfessorSectionRegistration.Controls.Add(txtFirstName);
            gbProfessorSectionRegistration.Controls.Add(btnUpdate);
            gbProfessorSectionRegistration.Controls.Add(btnEdit);
            gbProfessorSectionRegistration.Controls.Add(dgvTeachers);
            gbProfessorSectionRegistration.Controls.Add(btnAdd);
            gbProfessorSectionRegistration.Controls.Add(btnSendEmail);
            gbProfessorSectionRegistration.Controls.Add(btnDelete);
            gbProfessorSectionRegistration.Controls.Add(btnShow);
            gbProfessorSectionRegistration.Controls.Add(txtDepartment);
            gbProfessorSectionRegistration.Controls.Add(lblDepartment);
            gbProfessorSectionRegistration.Controls.Add(lblPassword);
            gbProfessorSectionRegistration.Controls.Add(lblUsername);
            gbProfessorSectionRegistration.Controls.Add(txtLastName);
            gbProfessorSectionRegistration.Controls.Add(txtUsername);
            gbProfessorSectionRegistration.Controls.Add(txtEmail);
            gbProfessorSectionRegistration.Controls.Add(lblEmail);
            gbProfessorSectionRegistration.Controls.Add(txtPassword);
            gbProfessorSectionRegistration.Controls.Add(lblLast);
            gbProfessorSectionRegistration.Location = new Point(267, 85);
            gbProfessorSectionRegistration.Name = "gbProfessorSectionRegistration";
            gbProfessorSectionRegistration.Size = new Size(711, 497);
            gbProfessorSectionRegistration.TabIndex = 99;
            gbProfessorSectionRegistration.TabStop = false;
            gbProfessorSectionRegistration.Text = "Professor Section Registration";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SteelBlue;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(445, 160);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 93;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Location = new Point(58, 87);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(61, 15);
            lblFirst.TabIndex = 92;
            lblFirst.Text = "FirstName";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(170, 79);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(191, 23);
            txtFirstName.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(536, 129);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
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
            btnEdit.Location = new Point(536, 100);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvTeachers
            // 
            dgvTeachers.BackgroundColor = Color.Gainsboro;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Location = new Point(58, 268);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.Size = new Size(590, 179);
            dgvTeachers.TabIndex = 13;
            // 
            // txtTeacherID
            // 
            txtTeacherID.Enabled = false;
            txtTeacherID.Location = new Point(536, 12);
            txtTeacherID.Name = "txtTeacherID";
            txtTeacherID.Size = new Size(191, 23);
            txtTeacherID.TabIndex = 100;
            txtTeacherID.Visible = false;
            // 
            // txtUserID
            // 
            txtUserID.Enabled = false;
            txtUserID.Location = new Point(536, 50);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(191, 23);
            txtUserID.TabIndex = 101;
            txtUserID.Visible = false;
            // 
            // ProfessorsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(txtUserID);
            Controls.Add(txtTeacherID);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(gbProfessorSectionRegistration);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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



        private void BtnAdd_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label2;
        private Label label5;
        private Button button1;
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
        private Label lblDepartment;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnAdd;
        private Button btnSendEmail;
        private Button btnDelete;
        private Button btnShow;
        private TextBox txtDepartment;
        private GroupBox gbProfessorSectionRegistration;
        private DataGridView dgvTeachers;
        private Button btnStudentRegistration;
        private Button btnUpdate;
        private Button btnEdit;
        private Label lblFirst;
        private TextBox txtFirstName;
        private TextBox txtTeacherID;
        private TextBox txtUserID;
        private Button btnClear;
    }
}