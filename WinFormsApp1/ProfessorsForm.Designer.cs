
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
            label2 = new Label();
            label5 = new Label();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            btnLogout = new Button();
            btnStudentRegistration = new Button();
            lblLast = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            lblPrograms = new Label();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtUsername = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            gbProfessorSectionRegistration = new GroupBox();
            panel2 = new Panel();
            cmbprogram = new ComboBox();
            lblFirst = new Label();
            txtFirstName = new TextBox();
            btnUpdate = new Button();
            dgvTeachers = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            gbProfessorSectionRegistration.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(305, 92);
            label2.Name = "label2";
            label2.Size = new Size(297, 60);
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
            btnManage.Location = new Point(15, 123);
            btnManage.Margin = new Padding(3, 4, 3, 4);
            btnManage.Name = "btnManage";
            btnManage.Size = new Size(255, 75);
            btnManage.TabIndex = 5;
            btnManage.Text = "MANAGE";
            btnManage.UseVisualStyleBackColor = false;
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
            btnLogout.TabIndex = 100;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.FlatAppearance.BorderSize = 0;
            btnStudentRegistration.FlatStyle = FlatStyle.Flat;
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(15, 328);
            btnStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(255, 75);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.UseVisualStyleBackColor = true;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLast.Location = new Point(66, 90);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(95, 22);
            lblLast.TabIndex = 84;
            lblLast.Text = "LastName:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(66, 128);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(126, 22);
            lblEmail.TabIndex = 85;
            lblEmail.Text = "Email Address:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(66, 166);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(96, 22);
            lblUsername.TabIndex = 87;
            lblUsername.Text = "Username:";
            // 
            // lblPrograms
            // 
            lblPrograms.AutoSize = true;
            lblPrograms.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrograms.Location = new Point(66, 240);
            lblPrograms.Name = "lblPrograms";
            lblPrograms.Size = new Size(83, 22);
            lblPrograms.TabIndex = 88;
            lblPrograms.Text = "Program:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(226, 123);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(293, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Location = new Point(226, 85);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(293, 27);
            txtLastName.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(226, 161);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(293, 27);
            txtUsername.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Location = new Point(592, 47);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 43);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Location = new Point(592, 109);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 43);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // gbProfessorSectionRegistration
            // 
            gbProfessorSectionRegistration.Controls.Add(panel2);
            gbProfessorSectionRegistration.Controls.Add(lblFirst);
            gbProfessorSectionRegistration.Controls.Add(txtFirstName);
            gbProfessorSectionRegistration.Controls.Add(btnUpdate);
            gbProfessorSectionRegistration.Controls.Add(btnDelete);
            gbProfessorSectionRegistration.Controls.Add(dgvTeachers);
            gbProfessorSectionRegistration.Controls.Add(btnAdd);
            gbProfessorSectionRegistration.Controls.Add(lblPrograms);
            gbProfessorSectionRegistration.Controls.Add(lblUsername);
            gbProfessorSectionRegistration.Controls.Add(txtLastName);
            gbProfessorSectionRegistration.Controls.Add(txtUsername);
            gbProfessorSectionRegistration.Controls.Add(txtEmail);
            gbProfessorSectionRegistration.Controls.Add(lblEmail);
            gbProfessorSectionRegistration.Controls.Add(lblLast);
            gbProfessorSectionRegistration.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbProfessorSectionRegistration.Location = new Point(305, 159);
            gbProfessorSectionRegistration.Margin = new Padding(3, 4, 3, 4);
            gbProfessorSectionRegistration.Name = "gbProfessorSectionRegistration";
            gbProfessorSectionRegistration.Padding = new Padding(3, 4, 3, 4);
            gbProfessorSectionRegistration.Size = new Size(813, 564);
            gbProfessorSectionRegistration.TabIndex = 0;
            gbProfessorSectionRegistration.TabStop = false;
            gbProfessorSectionRegistration.Text = "Professor Section Registration";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbprogram);
            panel2.Location = new Point(226, 235);
            panel2.Name = "panel2";
            panel2.Size = new Size(293, 27);
            panel2.TabIndex = 93;
            // 
            // cmbprogram
            // 
            cmbprogram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbprogram.FormattingEnabled = true;
            cmbprogram.Location = new Point(-1, -1);
            cmbprogram.Margin = new Padding(3, 4, 3, 4);
            cmbprogram.Name = "cmbprogram";
            cmbprogram.Size = new Size(293, 27);
            cmbprogram.TabIndex = 5;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFirst.Location = new Point(66, 52);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(96, 22);
            lblFirst.TabIndex = 92;
            lblFirst.Text = "FirstName:";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Location = new Point(226, 47);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(293, 27);
            txtFirstName.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Location = new Point(592, 172);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 43);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // dgvTeachers
            // 
            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.BorderStyle = BorderStyle.Fixed3D;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Location = new Point(66, 295);
            dgvTeachers.Margin = new Padding(3, 4, 3, 4);
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.RowHeadersWidth = 51;
            dgvTeachers.Size = new Size(674, 211);
            dgvTeachers.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarMonthBackground = Color.White;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.ImeMode = ImeMode.Off;
            dateTimePicker1.Location = new Point(821, 108);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(299, 27);
            dateTimePicker1.TabIndex = 107;
            // 
            // ProfessorsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1152, 859);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(gbProfessorSectionRegistration);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ProfessorsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proffesors";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            gbProfessorSectionRegistration.ResumeLayout(false);
            gbProfessorSectionRegistration.PerformLayout();
            panel2.ResumeLayout(false);
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
        private Label label2;
        private Label label5;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label lblLast;
        private Label lblEmail;
        private Label lblUsername;
        private Label lblPrograms;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtUsername;
        private Button btnAdd;
        private Button btnDelete;
        private GroupBox gbProfessorSectionRegistration;
        private DataGridView dgvTeachers;
        private Button btnStudentRegistration;
        private Button btnUpdate;
        private Label lblFirst;
        private TextBox txtFirstName;
        private Button btnLogout;
        private ComboBox cmbprogram;
        private Panel panel2;
        private DateTimePicker dateTimePicker1;
    }
}