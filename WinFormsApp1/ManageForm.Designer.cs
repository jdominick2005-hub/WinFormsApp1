


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
            cmbsection = new ComboBox();
            cmbyearlevel = new ComboBox();
            cmbProfessor = new ComboBox();
            lblSubjectName = new Label();
            lblYear = new Label();
            dgvProfessors = new DataGridView();
            lblProfessor = new Label();
            btnDelete = new Button();
            txtSchedule = new TextBox();
            txtSubjectName = new TextBox();
            lblSchedule = new Label();
            btnAdd = new Button();
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
            label2.Location = new Point(267, 50);
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
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.System;
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
            panel1.Size = new Size(235, 562);
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
            // gbProfessorSectionAssignment
            // 
            gbProfessorSectionAssignment.BackColor = SystemColors.Control;
            gbProfessorSectionAssignment.Controls.Add(cmbsection);
            gbProfessorSectionAssignment.Controls.Add(cmbyearlevel);
            gbProfessorSectionAssignment.Controls.Add(cmbProfessor);
            gbProfessorSectionAssignment.Controls.Add(lblSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblYear);
            gbProfessorSectionAssignment.Controls.Add(dgvProfessors);
            gbProfessorSectionAssignment.Controls.Add(lblProfessor);
            gbProfessorSectionAssignment.Controls.Add(btnDelete);
            gbProfessorSectionAssignment.Controls.Add(txtSchedule);
            gbProfessorSectionAssignment.Controls.Add(txtSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblSchedule);
            gbProfessorSectionAssignment.Controls.Add(btnAdd);
            gbProfessorSectionAssignment.Controls.Add(lblSection);
            gbProfessorSectionAssignment.FlatStyle = FlatStyle.Flat;
            gbProfessorSectionAssignment.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbProfessorSectionAssignment.ForeColor = Color.Black;
            gbProfessorSectionAssignment.Location = new Point(267, 109);
            gbProfessorSectionAssignment.Name = "gbProfessorSectionAssignment";
            gbProfessorSectionAssignment.Size = new Size(671, 416);
            gbProfessorSectionAssignment.TabIndex = 96;
            gbProfessorSectionAssignment.TabStop = false;
            gbProfessorSectionAssignment.Text = "Professor Section Assignment";
            gbProfessorSectionAssignment.Enter += gbProfessorSectionAssignment_Enter;
            // 
            // cmbsection
            // 
            cmbsection.FormattingEnabled = true;
            cmbsection.Items.AddRange(new object[] { "A", "B", "C" });
            cmbsection.Location = new Point(189, 194);
            cmbsection.Name = "cmbsection";
            cmbsection.Size = new Size(204, 24);
            cmbsection.TabIndex = 101;
            // 
            // cmbyearlevel
            // 
            cmbyearlevel.FormattingEnabled = true;
            cmbyearlevel.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cmbyearlevel.Location = new Point(189, 165);
            cmbyearlevel.Name = "cmbyearlevel";
            cmbyearlevel.Size = new Size(204, 24);
            cmbyearlevel.TabIndex = 100;
            // 
            // cmbProfessor
            // 
            cmbProfessor.FormattingEnabled = true;
            cmbProfessor.Location = new Point(258, 51);
            cmbProfessor.Name = "cmbProfessor";
            cmbProfessor.Size = new Size(204, 24);
            cmbProfessor.TabIndex = 99;
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubjectName.Location = new Point(96, 110);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(87, 16);
            lblSubjectName.TabIndex = 97;
            lblSubjectName.Text = "SubjectName:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(96, 174);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(67, 16);
            lblYear.TabIndex = 98;
            lblYear.Text = "Year Level:";
            // 
            // dgvProfessors
            // 
            dgvProfessors.BackgroundColor = Color.Gainsboro;
            dgvProfessors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessors.Location = new Point(83, 234);
            dgvProfessors.MultiSelect = false;
            dgvProfessors.Name = "dgvProfessors";
            dgvProfessors.ReadOnly = true;
            dgvProfessors.RowHeadersWidth = 51;
            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.Size = new Size(542, 156);
            dgvProfessors.TabIndex = 94;
            dgvProfessors.CellContentClick += dgvProfessors_CellClick;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfessor.Location = new Point(83, 54);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(169, 16);
            lblProfessor.TabIndex = 79;
            lblProfessor.Text = "Please select a Professor first:";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(539, 193);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 30);
            btnDelete.TabIndex = 90;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(189, 136);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(204, 23);
            txtSchedule.TabIndex = 75;
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(189, 107);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(204, 23);
            txtSubjectName.TabIndex = 74;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSchedule.Location = new Point(96, 143);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(62, 16);
            lblSchedule.TabIndex = 72;
            lblSchedule.Text = "Schedule:";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(458, 193);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 30);
            btnAdd.TabIndex = 81;
            btnAdd.Text = "Add\r\n";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSection.Location = new Point(96, 201);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(52, 16);
            lblSection.TabIndex = 73;
            lblSection.Text = "Section:\r\n";
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 562);
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
        private DataGridView dgvProfessors;
        private Label lblProfessor;
        private Button btnDelete;
        private TextBox txtSchedule;
        private TextBox txtSubjectName;
        private Label lblSchedule;
        private Button btnAdd;
        private Label lblSection;
        private ComboBox cmbsection;
        private ComboBox cmbyearlevel;
    }
}