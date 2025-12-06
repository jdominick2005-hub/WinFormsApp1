


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
            label2 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            gbProfessorSectionAssignment = new GroupBox();
            cmbProfessor = new ComboBox();
            lblSubjectName = new Label();
            lblYear = new Label();
            txtYearLevel = new TextBox();
            dgvProfessors = new DataGridView();
            lblProfessor = new Label();
            btnDelete = new Button();
            txtSchedule = new TextBox();
            txtSubjectName = new TextBox();
            lblSchedule = new Label();
            btnAdd = new Button();
            txtSection = new TextBox();
            lblSection = new Label();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            gbProfessorSectionAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(305, 67);
            label2.Name = "label2";
            label2.Size = new Size(150, 41);
            label2.TabIndex = 69;
            label2.Text = "MANAGE";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(82, 273);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 65;
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
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.System;
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
            panel1.TabIndex = 66;
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
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1074, 65);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 53);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 67;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(983, 75);
            label1.Name = "label1";
            label1.Size = new Size(99, 32);
            label1.TabIndex = 68;
            label1.Text = "ADMIN";
            // 
            // gbProfessorSectionAssignment
            // 
            gbProfessorSectionAssignment.BackColor = SystemColors.Control;
            gbProfessorSectionAssignment.Controls.Add(cmbProfessor);
            gbProfessorSectionAssignment.Controls.Add(lblSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblYear);
            gbProfessorSectionAssignment.Controls.Add(txtYearLevel);
            gbProfessorSectionAssignment.Controls.Add(dgvProfessors);
            gbProfessorSectionAssignment.Controls.Add(lblProfessor);
            gbProfessorSectionAssignment.Controls.Add(btnDelete);
            gbProfessorSectionAssignment.Controls.Add(txtSchedule);
            gbProfessorSectionAssignment.Controls.Add(txtSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblSchedule);
            gbProfessorSectionAssignment.Controls.Add(btnAdd);
            gbProfessorSectionAssignment.Controls.Add(txtSection);
            gbProfessorSectionAssignment.Controls.Add(lblSection);
            gbProfessorSectionAssignment.FlatStyle = FlatStyle.Flat;
            gbProfessorSectionAssignment.ForeColor = Color.Black;
            gbProfessorSectionAssignment.Location = new Point(305, 189);
            gbProfessorSectionAssignment.Margin = new Padding(3, 4, 3, 4);
            gbProfessorSectionAssignment.Name = "gbProfessorSectionAssignment";
            gbProfessorSectionAssignment.Padding = new Padding(3, 4, 3, 4);
            gbProfessorSectionAssignment.Size = new Size(767, 588);
            gbProfessorSectionAssignment.TabIndex = 96;
            gbProfessorSectionAssignment.TabStop = false;
            gbProfessorSectionAssignment.Text = "Professor Section Assignment";
            gbProfessorSectionAssignment.Enter += gbProfessorSectionAssignment_Enter;
            // 
            // cmbProfessor
            // 
            cmbProfessor.FormattingEnabled = true;
            cmbProfessor.Location = new Point(295, 72);
            cmbProfessor.Margin = new Padding(3, 4, 3, 4);
            cmbProfessor.Name = "cmbProfessor";
            cmbProfessor.Size = new Size(233, 28);
            cmbProfessor.TabIndex = 99;
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Location = new Point(117, 153);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(101, 20);
            lblSubjectName.TabIndex = 97;
            lblSubjectName.Text = "SubjectName:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(117, 231);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(78, 20);
            lblYear.TabIndex = 98;
            lblYear.Text = "Year Level:";
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(216, 220);
            txtYearLevel.Margin = new Padding(3, 4, 3, 4);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(233, 27);
            txtYearLevel.TabIndex = 97;
            // 
            // dgvProfessors
            // 
            dgvProfessors.BackgroundColor = Color.Gainsboro;
            dgvProfessors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessors.Location = new Point(117, 312);
            dgvProfessors.Margin = new Padding(3, 4, 3, 4);
            dgvProfessors.MultiSelect = false;
            dgvProfessors.Name = "dgvProfessors";
            dgvProfessors.ReadOnly = true;
            dgvProfessors.RowHeadersWidth = 51;
            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.Size = new Size(598, 208);
            dgvProfessors.TabIndex = 94;
            dgvProfessors.CellContentClick += dgvProfessors_CellClick;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Location = new Point(105, 76);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(202, 20);
            lblProfessor.TabIndex = 79;
            lblProfessor.Text = "Please select a Professor first:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(617, 215);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 40);
            btnDelete.TabIndex = 90;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(216, 181);
            txtSchedule.Margin = new Padding(3, 4, 3, 4);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(233, 27);
            txtSchedule.TabIndex = 75;
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(216, 143);
            txtSubjectName.Margin = new Padding(3, 4, 3, 4);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(233, 27);
            txtSubjectName.TabIndex = 74;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Location = new Point(117, 192);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(72, 20);
            lblSchedule.TabIndex = 72;
            lblSchedule.Text = "Schedule:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(525, 213);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 40);
            btnAdd.TabIndex = 81;
            btnAdd.Text = "Add\r\n";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSection
            // 
            txtSection.Location = new Point(216, 259);
            txtSection.Margin = new Padding(3, 4, 3, 4);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(233, 27);
            txtSection.TabIndex = 77;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Location = new Point(117, 269);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(61, 20);
            lblSection.TabIndex = 73;
            lblSection.Text = "Section:\r\n";
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 859);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(gbProfessorSectionAssignment);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ManageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage";
            Load += ManageFormLoad;
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            gbProfessorSectionAssignment.ResumeLayout(false);
            gbProfessorSectionAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void gbProfessorSectionAssignment_Enter(object sender, EventArgs e)
        {
            
        }

        #endregion
        private Label label2;
        private Label label5;
        private Panel panel3;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Button btnStudentRegistration;
        private GroupBox gbProfessorSectionAssignment;
        private ComboBox cmbProfessor;
        private Label lblSubjectName;
        private Label lblYear;
        private TextBox txtYearLevel;
        private DataGridView dgvProfessors;
        private Label lblProfessor;
        private Button btnDelete;
        private TextBox txtSchedule;
        private TextBox txtSubjectName;
        private Label lblSchedule;
        private Button btnAdd;
        private TextBox txtSection;
        private Label lblSection;
    }
}