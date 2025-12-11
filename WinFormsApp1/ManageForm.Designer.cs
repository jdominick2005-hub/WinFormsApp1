


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
            btnLogout = new Button();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblSection = new Label();
            btnAdd = new Button();
            lblSchedule = new Label();
            txtSubjectName = new TextBox();
            txtSchedule = new TextBox();
            btnDelete = new Button();
            lblProfessor = new Label();
            lblYear = new Label();
            lblSubjectName = new Label();
            cmbProfessor = new ComboBox();
            cmbyearlevel = new ComboBox();
            cmbsection = new ComboBox();
            gbProfessorSectionAssignment = new GroupBox();
            btnupdate = new Button();
            dgvProfessors = new DataGridView();
            panel5 = new Panel();
            cmbcourse = new ComboBox();
            panel6 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbProfessorSectionAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(305, 92);
            label2.Name = "label2";
            label2.Size = new Size(218, 60);
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
            btnLogout.TabIndex = 97;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
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
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // btnManage
            // 
            btnManage.BackColor = Color.SteelBlue;
            btnManage.FlatAppearance.BorderSize = 0;
            btnManage.FlatStyle = FlatStyle.System;
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
            // lblSection
            // 
            lblSection.AutoSize = true;
            lblSection.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSection.Location = new Point(112, 242);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(63, 19);
            lblSection.TabIndex = 73;
            lblSection.Text = "Section:\r\n";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SteelBlue;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Location = new Point(617, 120);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 43);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add\r\n";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSchedule.Location = new Point(112, 166);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(76, 19);
            lblSchedule.TabIndex = 72;
            lblSchedule.Text = "Schedule:";
            // 
            // txtSubjectName
            // 
            txtSubjectName.BackColor = Color.White;
            txtSubjectName.BorderStyle = BorderStyle.FixedSingle;
            txtSubjectName.Location = new Point(237, 120);
            txtSubjectName.Margin = new Padding(3, 4, 3, 4);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(265, 27);
            txtSubjectName.TabIndex = 1;
            // 
            // txtSchedule
            // 
            txtSchedule.BackColor = Color.White;
            txtSchedule.BorderStyle = BorderStyle.FixedSingle;
            txtSchedule.Location = new Point(237, 158);
            txtSchedule.Margin = new Padding(3, 4, 3, 4);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(265, 27);
            txtSchedule.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Location = new Point(617, 181);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 43);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProfessor.Location = new Point(57, 60);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(212, 19);
            lblProfessor.TabIndex = 79;
            lblProfessor.Text = "Please select a Professor first:";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblYear.Location = new Point(112, 204);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(83, 19);
            lblYear.TabIndex = 98;
            lblYear.Text = "Year Level:";
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubjectName.Location = new Point(112, 128);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(105, 19);
            lblSubjectName.TabIndex = 97;
            lblSubjectName.Text = "SubjectName:";
            // 
            // cmbProfessor
            // 
            cmbProfessor.BackColor = Color.White;
            cmbProfessor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfessor.FormattingEnabled = true;
            cmbProfessor.Location = new Point(-1, -1);
            cmbProfessor.Margin = new Padding(3, 4, 3, 4);
            cmbProfessor.Name = "cmbProfessor";
            cmbProfessor.Size = new Size(265, 27);
            cmbProfessor.TabIndex = 0;
            // 
            // cmbyearlevel
            // 
            cmbyearlevel.BackColor = Color.White;
            cmbyearlevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbyearlevel.FormattingEnabled = true;
            cmbyearlevel.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cmbyearlevel.Location = new Point(-1, -1);
            cmbyearlevel.Margin = new Padding(3, 4, 3, 4);
            cmbyearlevel.Name = "cmbyearlevel";
            cmbyearlevel.Size = new Size(265, 27);
            cmbyearlevel.TabIndex = 3;
            // 
            // cmbsection
            // 
            cmbsection.BackColor = Color.White;
            cmbsection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbsection.FormattingEnabled = true;
            cmbsection.Items.AddRange(new object[] { "A", "B", "C" });
            cmbsection.Location = new Point(-1, -1);
            cmbsection.Margin = new Padding(3, 4, 3, 4);
            cmbsection.Name = "cmbsection";
            cmbsection.Size = new Size(265, 27);
            cmbsection.TabIndex = 4;
            // 
            // gbProfessorSectionAssignment
            // 
            gbProfessorSectionAssignment.BackColor = Color.White;
            gbProfessorSectionAssignment.Controls.Add(btnupdate);
            gbProfessorSectionAssignment.Controls.Add(dgvProfessors);
            gbProfessorSectionAssignment.Controls.Add(panel5);
            gbProfessorSectionAssignment.Controls.Add(panel6);
            gbProfessorSectionAssignment.Controls.Add(panel4);
            gbProfessorSectionAssignment.Controls.Add(panel2);
            gbProfessorSectionAssignment.Controls.Add(label1);
            gbProfessorSectionAssignment.Controls.Add(lblSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblYear);
            gbProfessorSectionAssignment.Controls.Add(lblProfessor);
            gbProfessorSectionAssignment.Controls.Add(btnDelete);
            gbProfessorSectionAssignment.Controls.Add(txtSchedule);
            gbProfessorSectionAssignment.Controls.Add(txtSubjectName);
            gbProfessorSectionAssignment.Controls.Add(lblSchedule);
            gbProfessorSectionAssignment.Controls.Add(btnAdd);
            gbProfessorSectionAssignment.Controls.Add(lblSection);
            gbProfessorSectionAssignment.FlatStyle = FlatStyle.System;
            gbProfessorSectionAssignment.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbProfessorSectionAssignment.ForeColor = Color.Black;
            gbProfessorSectionAssignment.Location = new Point(305, 156);
            gbProfessorSectionAssignment.Margin = new Padding(3, 4, 3, 4);
            gbProfessorSectionAssignment.Name = "gbProfessorSectionAssignment";
            gbProfessorSectionAssignment.Padding = new Padding(3, 4, 3, 4);
            gbProfessorSectionAssignment.Size = new Size(815, 696);
            gbProfessorSectionAssignment.TabIndex = 96;
            gbProfessorSectionAssignment.TabStop = false;
            gbProfessorSectionAssignment.Text = "Professor Section Assignment";
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.SteelBlue;
            btnupdate.FlatAppearance.BorderSize = 0;
            btnupdate.FlatStyle = FlatStyle.Popup;
            btnupdate.Location = new Point(617, 242);
            btnupdate.Margin = new Padding(3, 4, 3, 4);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(96, 43);
            btnupdate.TabIndex = 106;
            btnupdate.Text = "Update";
            btnupdate.UseVisualStyleBackColor = false;
            btnupdate.Click += btnupdate_Click;
            // 
            // dgvProfessors
            // 
            dgvProfessors.BackgroundColor = Color.White;
            dgvProfessors.BorderStyle = BorderStyle.Fixed3D;
            dgvProfessors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfessors.Location = new Point(0, 342);
            dgvProfessors.Margin = new Padding(3, 4, 3, 4);
            dgvProfessors.MultiSelect = false;
            dgvProfessors.Name = "dgvProfessors";
            dgvProfessors.ReadOnly = true;
            dgvProfessors.RowHeadersWidth = 51;
            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.Size = new Size(815, 348);
            dgvProfessors.TabIndex = 8;
            dgvProfessors.CellContentClick += dgvProfessors_CellClick;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(cmbcourse);
            panel5.Location = new Point(237, 272);
            panel5.Name = "panel5";
            panel5.Size = new Size(265, 27);
            panel5.TabIndex = 105;
            // 
            // cmbcourse
            // 
            cmbcourse.BackColor = Color.White;
            cmbcourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbcourse.FormattingEnabled = true;
            cmbcourse.Items.AddRange(new object[] { "A", "B", "C" });
            cmbcourse.Location = new Point(-1, -1);
            cmbcourse.Margin = new Padding(3, 4, 3, 4);
            cmbcourse.Name = "cmbcourse";
            cmbcourse.Size = new Size(265, 27);
            cmbcourse.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(cmbyearlevel);
            panel6.Location = new Point(237, 196);
            panel6.Name = "panel6";
            panel6.Size = new Size(265, 27);
            panel6.TabIndex = 105;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(cmbsection);
            panel4.Location = new Point(237, 234);
            panel4.Name = "panel4";
            panel4.Size = new Size(265, 27);
            panel4.TabIndex = 104;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbProfessor);
            panel2.Location = new Point(293, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(265, 27);
            panel2.TabIndex = 103;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 280);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 102;
            label1.Text = "Program:\r\n";
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
            dateTimePicker1.TabIndex = 106;
            // 
            // ManageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1152, 859);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
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
            gbProfessorSectionAssignment.ResumeLayout(false);
            gbProfessorSectionAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfessors).EndInit();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
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
        private Button btnStudentRegistration;
         private Button btnLogout;
        private Label lblSection;
        private Button btnAdd;
        private Label lblSchedule;
        private TextBox txtSubjectName;
        private TextBox txtSchedule;
        private Button btnDelete;
        private Label lblProfessor;
        private Label lblYear;
        private Label lblSubjectName;
        private ComboBox cmbProfessor;
        private ComboBox cmbyearlevel;
        private ComboBox cmbsection;
        private GroupBox gbProfessorSectionAssignment;
        private Label label1;
        private ComboBox cmbcourse;
        private Panel panel5;
        private Panel panel6;
        private Panel panel4;
        private Panel panel2;
        private DataGridView dgvProfessors;
        private DateTimePicker dateTimePicker1;
        private Button btnupdate;
    }
}