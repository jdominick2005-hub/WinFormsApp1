


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
            lblStudentRegistration = new Label();
            btnStudentRegistration = new Button();
            label8 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            btnManage = new Button();
            btnProfessors = new Button();
            btnUsers = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            txtSubjectName = new TextBox();
            txtSchedule = new TextBox();
            txtSection = new TextBox();
            label12 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            dgvProffesors = new DataGridView();
            gbProfessorSectionAssignment = new GroupBox();
            label11 = new Label();
            txtYearLevel = new TextBox();
            txtProfessor = new TextBox();
            btnView = new Button();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProffesors).BeginInit();
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
            panel3.Controls.Add(lblStudentRegistration);
            panel3.Controls.Add(btnStudentRegistration);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(pictureBox6);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(btnManage);
            panel3.Controls.Add(btnProfessors);
            panel3.Controls.Add(btnUsers);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // lblStudentRegistration
            // 
            lblStudentRegistration.AutoSize = true;
            lblStudentRegistration.BackColor = Color.White;
            lblStudentRegistration.Location = new Point(51, 328);
            lblStudentRegistration.Name = "lblStudentRegistration";
            lblStudentRegistration.Size = new Size(140, 15);
            lblStudentRegistration.TabIndex = 74;
            lblStudentRegistration.Text = "STUDENT REGISTRATION\r\n";
            // 
            // btnStudentRegistration
            // 
            btnStudentRegistration.Location = new Point(15, 313);
            btnStudentRegistration.Name = "btnStudentRegistration";
            btnStudentRegistration.Size = new Size(204, 44);
            btnStudentRegistration.TabIndex = 73;
            btnStudentRegistration.UseVisualStyleBackColor = true;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label8.Location = new Point(95, 255);
            label8.Name = "label8";
            label8.Size = new Size(87, 17);
            label8.TabIndex = 72;
            label8.Text = "PROFESSORS";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(51, 172);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(32, 33);
            pictureBox6.TabIndex = 71;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(51, 248);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(33, 29);
            pictureBox5.TabIndex = 70;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(52, 100);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 29);
            pictureBox4.TabIndex = 69;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(95, 182);
            label6.Name = "label6";
            label6.Size = new Size(46, 17);
            label6.TabIndex = 67;
            label6.Text = "USERS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(95, 109);
            label4.Name = "label4";
            label4.Size = new Size(64, 17);
            label4.TabIndex = 66;
            label4.Text = "MANAGE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(95, 36);
            label3.Name = "label3";
            label3.Size = new Size(47, 17);
            label3.TabIndex = 65;
            label3.Text = "HOME";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(55, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 20);
            pictureBox3.TabIndex = 65;
            pictureBox3.TabStop = false;
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(103, 69);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 71;
            label7.Text = "SubjectName:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(122, 98);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 72;
            label9.Text = "Schedule:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(122, 162);
            label10.Name = "label10";
            label10.Size = new Size(49, 15);
            label10.TabIndex = 73;
            label10.Text = "Section:\r\n";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(190, 61);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(204, 23);
            txtSubjectName.TabIndex = 74;
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(190, 90);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(204, 23);
            txtSchedule.TabIndex = 75;
            // 
            // txtSection
            // 
            txtSection.Location = new Point(190, 154);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(204, 23);
            txtSection.TabIndex = 77;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(122, 191);
            label12.Name = "label12";
            label12.Size = new Size(59, 15);
            label12.TabIndex = 79;
            label12.Text = "Professor:";
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
            btnDelete.Click += btnDelete_Click_1;
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
            // dgvProffesors
            // 
            dgvProffesors.BackgroundColor = Color.Gainsboro;
            dgvProffesors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProffesors.Location = new Point(34, 229);
            dgvProffesors.MultiSelect = false;
            dgvProffesors.Name = "dgvProffesors";
            dgvProffesors.ReadOnly = true;
            dgvProffesors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProffesors.Size = new Size(643, 156);
            dgvProffesors.TabIndex = 94;
            dgvProffesors.CellContentClick += dgvProffesors_CellContentClick;
            // 
            // gbProfessorSectionAssignment
            // 
            gbProfessorSectionAssignment.BackColor = SystemColors.Control;
            gbProfessorSectionAssignment.Controls.Add(label11);
            gbProfessorSectionAssignment.Controls.Add(txtYearLevel);
            gbProfessorSectionAssignment.Controls.Add(txtProfessor);
            gbProfessorSectionAssignment.Controls.Add(btnView);
            gbProfessorSectionAssignment.Controls.Add(dgvProffesors);
            gbProfessorSectionAssignment.Controls.Add(label12);
            gbProfessorSectionAssignment.Controls.Add(btnDelete);
            gbProfessorSectionAssignment.Controls.Add(btnUpdate);
            gbProfessorSectionAssignment.Controls.Add(txtSchedule);
            gbProfessorSectionAssignment.Controls.Add(txtSubjectName);
            gbProfessorSectionAssignment.Controls.Add(label9);
            gbProfessorSectionAssignment.Controls.Add(label7);
            gbProfessorSectionAssignment.Controls.Add(btnAdd);
            gbProfessorSectionAssignment.Controls.Add(txtSection);
            gbProfessorSectionAssignment.Controls.Add(label10);
            gbProfessorSectionAssignment.FlatStyle = FlatStyle.Flat;
            gbProfessorSectionAssignment.ForeColor = Color.Black;
            gbProfessorSectionAssignment.Location = new Point(271, 138);
            gbProfessorSectionAssignment.Name = "gbProfessorSectionAssignment";
            gbProfessorSectionAssignment.Size = new Size(709, 457);
            gbProfessorSectionAssignment.TabIndex = 96;
            gbProfessorSectionAssignment.TabStop = false;
            gbProfessorSectionAssignment.Text = "Professor Section Assignment";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(122, 127);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 98;
            label11.Text = "Year Level:";
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(190, 119);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(204, 23);
            txtYearLevel.TabIndex = 97;
            // 
            // txtProfessor
            // 
            txtProfessor.Location = new Point(190, 183);
            txtProfessor.Name = "txtProfessor";
            txtProfessor.Size = new Size(204, 23);
            txtProfessor.TabIndex = 96;
            // 
            // btnView
            // 
            btnView.Location = new Point(424, 420);
            btnView.Name = "btnView";
            btnView.Size = new Size(67, 23);
            btnView.TabIndex = 95;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
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
            Load += ManageForm_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProffesors).EndInit();
            gbProfessorSectionAssignment.ResumeLayout(false);
            gbProfessorSectionAssignment.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
          
        }

        private void Initialization()
        {
            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.cmbAssignProf);
        }

       

        #endregion

        private Button button1;
        private Label label2;
        private Label label5;
        private Panel panel3;
        private Label label8;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Label label6;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox3;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnUsers;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBox txtSubjectName;
        private TextBox txtSchedule;
        private TextBox txtSection;
        private Label label12;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private DataGridView dgvProffesors;
        private GroupBox gbProfessorSectionAssignment;
        private Button btnView;
       

        public ManageForm(ComboBox cmbYearLevels) => this.cmbYearLevel = cmbYearLevels;
        private ComboBox cmbYearLevel;
        private object cmbAssignProf;
        private TextBox txtProfessor;
        private Label lblStudentRegistration;
        private Button btnStudentRegistration;
        private TextBox txtYearLevel;
        private Label label11;
    }
}