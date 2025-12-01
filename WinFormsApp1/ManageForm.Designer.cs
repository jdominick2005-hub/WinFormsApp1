


using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    partial class ManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            button1 = new Button();
            label2 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnUsers = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            lblSchedule = new Label();
            lblSection = new Label();
            txtSubjectName = new TextBox();
            txtSchedule = new TextBox();
            txtSection = new TextBox();
            lblProfessor = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            dgvProfessors = new DataGridView();
            gbProfessorSectionAssignment = new GroupBox();
            cmbProfessor = new ComboBox();
            lblSubjectName = new Label();
            lblYear = new Label();
            txtYearLevel = new TextBox();
            btnView = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).BeginInit();
            gbProfessorSectionAssignment.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(928, 85);
            button1.Name = "button1";
            button1.Size = new Size(66, 29);
            button1.TabIndex = 70;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(292, 47);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 69;
            label2.Text = "MANAGE";
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
            // btnStudentRegistration
            // 
            btnStudentRegistration.FlatAppearance.BorderSize = 0;
            btnStudentRegistration.FlatStyle = FlatStyle.Flat;
            btnStudentRegistration.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnStudentRegistration.Location = new Point(12, 311);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(223, 56);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.Text = "REGISTER";
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.System;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(860, 56);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 68;
            label1.Text = "ADMIN";
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Location = new Point(103, 135);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(58, 15);
            lblSchedule.TabIndex = 72;
            lblSchedule.Text = "Schedule:";
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(103, 194);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(49, 15);
            lblSection.TabIndex = 73;
            lblSection.Text = "Section:\r\n";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(190, 99);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(204, 23);
            txtSubjectName.TabIndex = 74;
            txtSubjectName.TextChanged += txtSubjectName_TextChanged;
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(190, 128);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(204, 23);
            txtSchedule.TabIndex = 75;
            // 
            // txtSection
            // 
            txtSection.Location = new Point(190, 186);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(204, 23);
            txtSection.TabIndex = 77;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Location = new Point(30, 42);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(160, 15);
            lblProfessor.TabIndex = 79;
            lblProfessor.Text = "Please select a Professor first:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(340, 417);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 27);
            btnAdd.TabIndex = 81;
            btnAdd.Text = "Add\r\n";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(589, 419);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(74, 27);
            btnDelete.TabIndex = 90;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(497, 419);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(76, 25);
            btnUpdate.TabIndex = 91;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // dgvProfessors
            // 
            dgvProfessors.BackgroundColor = Color.Gainsboro;
            dgvProfessors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessors.Location = new Point(34, 229);
            dgvProfessors.MultiSelect = false;
            dgvProfessors.Name = "dgvProfessors";
            dgvProfessors.ReadOnly = true;
            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.Size = new Size(643, 156);
            dgvProfessors.TabIndex = 94;
            dgvProfessors.CellContentClick += dgvProfessors_CellClick;
            // 
            // gbProfessorSectionAssignment
            // 
            gbProfessorSectionAssignment.BackColor = SystemColors.Control;
            gbProfessorSectionAssignment.Controls.Add(cmbProfessor);
            gbProfessorSectionAssignment.Controls.Add(lblSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblYear);
            gbProfessorSectionAssignment.Controls.Add(txtYearLevel);
            gbProfessorSectionAssignment.Controls.Add(btnView);
            gbProfessorSectionAssignment.Controls.Add(dgvProfessors);
            gbProfessorSectionAssignment.Controls.Add(lblProfessor);
            gbProfessorSectionAssignment.Controls.Add(btnDelete);
            gbProfessorSectionAssignment.Controls.Add(btnUpdate);
            gbProfessorSectionAssignment.Controls.Add(txtSchedule);
            gbProfessorSectionAssignment.Controls.Add(txtSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblSchedule);
            gbProfessorSectionAssignment.Controls.Add(btnAdd);
            gbProfessorSectionAssignment.Controls.Add(txtSection);
            gbProfessorSectionAssignment.Controls.Add(lblSection);
            gbProfessorSectionAssignment.FlatStyle = FlatStyle.Flat;
            gbProfessorSectionAssignment.ForeColor = Color.Black;
            gbProfessorSectionAssignment.Location = new Point(271, 138);
            gbProfessorSectionAssignment.Name = "gbProfessorSectionAssignment";
            gbProfessorSectionAssignment.Size = new Size(709, 457);
            gbProfessorSectionAssignment.TabIndex = 96;
            gbProfessorSectionAssignment.TabStop = false;
            gbProfessorSectionAssignment.Text = "Professor Section Assignment";
            // 
            // cmbProfessor
            // 
            cmbProfessor.FormattingEnabled = true;
            cmbProfessor.Location = new Point(190, 39);
            cmbProfessor.Name = "cmbProfessor";
            cmbProfessor.Size = new Size(204, 23);
            cmbProfessor.TabIndex = 99;
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Location = new Point(103, 107);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(81, 15);
            lblSubjectName.TabIndex = 97;
            lblSubjectName.Text = "SubjectName:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(103, 165);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(62, 15);
            lblYear.TabIndex = 98;
            lblYear.Text = "Year Level:";
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(190, 157);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(204, 23);
            txtYearLevel.TabIndex = 97;
            // 
            // btnView
            // 
            btnView.Location = new Point(424, 420);
            btnView.Name = "btnView";
            btnView.Size = new Size(67, 23);
            btnView.TabIndex = 95;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnAdd_Click;
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(gbProfessorSectionAssignment);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ManageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage";
            Load += ManageFormLoad;
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).EndInit();
            gbProfessorSectionAssignment.ResumeLayout(false);
            gbProfessorSectionAssignment.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }








        #endregion

        private Button button1;
        private Label label2;
        private Label label5;
        private Panel panel3;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnUsers;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label lblSchedule;
        private Label lblSection;
        private TextBox txtSubjectName;
        private TextBox txtSchedule;
        private TextBox txtSection;
        private Label lblProfessor;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private DataGridView dgvProfessors;
        private GroupBox gbProfessorSectionAssignment;
        private Button btnView;
        private Button btnStudentRegistration;
        private TextBox txtYearLevel;
        private Label lblYear;
        private ComboBox cmbProfessor;
        private Label lblSubjectName;
    }
}