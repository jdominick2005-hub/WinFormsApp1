
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
            btnEnroll = new Button();
            lblEnroll = new Label();
            btnEdit = new Button();
            cmbEnrollSubject = new ComboBox();
            btnDelete = new Button();
            lblLastName = new Label();
            dgvStudentRegistration = new DataGridView();
            btnUpdate = new Button();
            txtLastName = new TextBox();
            btnShow = new Button();
            btnRegister = new Button();
            lblSection = new Label();
            txtSection = new TextBox();
            txtClassification = new TextBox();
            txtUnits = new TextBox();
            txtCourse = new TextBox();
            txtYearLevel = new TextBox();
            txtFirstName = new TextBox();
            txtStudentID = new TextBox();
            lblClassification = new Label();
            lblUnits = new Label();
            lblCourse = new Label();
            lblYearLevel = new Label();
            lblFirstName = new Label();
            lblStudentId = new Label();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            label5 = new Label();
            btnStudentRegistration = new Button();
            btnManage = new Button();
            btnProfessors = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            gbStudentRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // gbStudentRegistration
            // 
            gbStudentRegistration.AutoSize = true;
            gbStudentRegistration.Controls.Add(btnEnroll);
            gbStudentRegistration.Controls.Add(lblEnroll);
            gbStudentRegistration.Controls.Add(btnEdit);
            gbStudentRegistration.Controls.Add(cmbEnrollSubject);
            gbStudentRegistration.Controls.Add(btnDelete);
            gbStudentRegistration.Controls.Add(lblLastName);
            gbStudentRegistration.Controls.Add(dgvStudentRegistration);
            gbStudentRegistration.Controls.Add(btnUpdate);
            gbStudentRegistration.Controls.Add(txtLastName);
            gbStudentRegistration.Controls.Add(btnShow);
            gbStudentRegistration.Controls.Add(btnRegister);
            gbStudentRegistration.Controls.Add(lblSection);
            gbStudentRegistration.Controls.Add(txtSection);
            gbStudentRegistration.Controls.Add(txtClassification);
            gbStudentRegistration.Controls.Add(txtUnits);
            gbStudentRegistration.Controls.Add(txtCourse);
            gbStudentRegistration.Controls.Add(txtYearLevel);
            gbStudentRegistration.Controls.Add(txtFirstName);
            gbStudentRegistration.Controls.Add(txtStudentID);
            gbStudentRegistration.Controls.Add(lblClassification);
            gbStudentRegistration.Controls.Add(lblUnits);
            gbStudentRegistration.Controls.Add(lblCourse);
            gbStudentRegistration.Controls.Add(lblYearLevel);
            gbStudentRegistration.Controls.Add(lblFirstName);
            gbStudentRegistration.Controls.Add(lblStudentId);
            gbStudentRegistration.Location = new Point(305, 113);
            gbStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            gbStudentRegistration.Name = "gbStudentRegistration";
            gbStudentRegistration.Padding = new Padding(3, 4, 3, 4);
            gbStudentRegistration.Size = new Size(813, 701);
            gbStudentRegistration.TabIndex = 1;
            gbStudentRegistration.TabStop = false;
            gbStudentRegistration.Text = "Student Registration";
            gbStudentRegistration.Enter += gbStudentRegistration_Enter;
            // 
            // btnEnroll
            // 
            btnEnroll.BackColor = Color.SteelBlue;
            btnEnroll.FlatStyle = FlatStyle.Flat;
            btnEnroll.Location = new Point(638, 328);
            btnEnroll.Margin = new Padding(3, 4, 3, 4);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(86, 37);
            btnEnroll.TabIndex = 16;
            btnEnroll.Text = "Enroll";
            btnEnroll.UseVisualStyleBackColor = false;
            btnEnroll.Click += btnEnroll_Click;
            // 
            // lblEnroll
            // 
            lblEnroll.AutoSize = true;
            lblEnroll.Location = new Point(95, 371);
            lblEnroll.Name = "lblEnroll";
            lblEnroll.Size = new Size(105, 20);
            lblEnroll.TabIndex = 15;
            lblEnroll.Text = "Select Subject:";
            lblEnroll.Click += lblEnroll_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(638, 168);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 37);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // cmbEnrollSubject
            // 
            cmbEnrollSubject.FormattingEnabled = true;
            cmbEnrollSubject.Location = new Point(95, 399);
            cmbEnrollSubject.Margin = new Padding(3, 4, 3, 4);
            cmbEnrollSubject.Name = "cmbEnrollSubject";
            cmbEnrollSubject.Size = new Size(202, 28);
            cmbEnrollSubject.TabIndex = 14;
            cmbEnrollSubject.SelectedIndexChanged += cmbEnrollSubject_SelectedIndexChanged;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.SteelBlue;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(638, 275);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 37);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete All";
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
            dgvStudentRegistration.Location = new Point(95, 445);
            dgvStudentRegistration.Margin = new Padding(3, 4, 3, 4);
            dgvStudentRegistration.Name = "dgvStudentRegistration";
            dgvStudentRegistration.RowHeadersWidth = 51;
            dgvStudentRegistration.Size = new Size(629, 227);
            dgvStudentRegistration.TabIndex = 3;
            dgvStudentRegistration.CellClick += dgvStudentRegistration_CellClick;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(638, 221);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(86, 37);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(194, 128);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(223, 27);
            txtLastName.TabIndex = 8;
            // 
            // btnShow
            // 
            btnShow.BackColor = Color.SteelBlue;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Location = new Point(638, 115);
            btnShow.Margin = new Padding(3, 4, 3, 4);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(86, 37);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.SteelBlue;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(638, 61);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(86, 37);
            btnRegister.TabIndex = 0;
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
            // txtSection
            // 
            txtSection.Location = new Point(195, 244);
            txtSection.Margin = new Padding(3, 4, 3, 4);
            txtSection.Name = "txtSection";
            txtSection.Size = new Size(222, 27);
            txtSection.TabIndex = 11;
            // 
            // txtClassification
            // 
            txtClassification.Location = new Point(194, 321);
            txtClassification.Margin = new Padding(3, 4, 3, 4);
            txtClassification.Name = "txtClassification";
            txtClassification.Size = new Size(223, 27);
            txtClassification.TabIndex = 13;
            // 
            // txtUnits
            // 
            txtUnits.Location = new Point(194, 283);
            txtUnits.Margin = new Padding(3, 4, 3, 4);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new Size(223, 27);
            txtUnits.TabIndex = 12;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(194, 205);
            txtCourse.Margin = new Padding(3, 4, 3, 4);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(223, 27);
            txtCourse.TabIndex = 10;
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(194, 167);
            txtYearLevel.Margin = new Padding(3, 4, 3, 4);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(223, 27);
            txtYearLevel.TabIndex = 9;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(194, 89);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(223, 27);
            txtFirstName.TabIndex = 7;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(194, 51);
            txtStudentID.Margin = new Padding(3, 4, 3, 4);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(223, 27);
            txtStudentID.TabIndex = 6;
            // 
            // lblClassification
            // 
            lblClassification.AutoSize = true;
            lblClassification.Location = new Point(95, 332);
            lblClassification.Name = "lblClassification";
            lblClassification.Size = new Size(99, 20);
            lblClassification.TabIndex = 12;
            lblClassification.Text = "Classification:";
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Location = new Point(95, 293);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(45, 20);
            lblUnits.TabIndex = 11;
            lblUnits.Text = "Units:";
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
            lblStudentId.Location = new Point(95, 61);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(76, 20);
            lblStudentId.TabIndex = 5;
            lblStudentId.Text = "StudentId:";
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
            label2.Size = new Size(379, 41);
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
            btnStudentRegistration.Location = new Point(16, 328);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(995, 75);
            label1.Name = "label1";
            label1.Size = new Size(99, 32);
            label1.TabIndex = 80;
            label1.Text = "ADMIN";
            // 
            // StudentRegistration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 859);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(gbStudentRegistration);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "StudentRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentRegistration";
            gbStudentRegistration.ResumeLayout(false);
            gbStudentRegistration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private GroupBox gbStudentRegistration;
        private Label lblClassification;
        private Label lblUnits;
        private Label lblCourse;
        private Label lblYearLevel;
        private Label lblFirstName;
        private Label lblStudentId;
        private TextBox txtClassification;
        private TextBox txtUnits;
        private TextBox txtCourse;
        private TextBox txtYearLevel;
        private TextBox txtFirstName;
        private TextBox txtStudentID;
        private Button btnRegister;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnShow;
        private DataGridView dgvStudentRegistration;
        private Label lblSection;
        private TextBox txtSection;
        private Button btnEdit;
        private TextBox txtLastName;
        private Label lblLastName;
        private Label lblEnroll;
        private ComboBox cmbEnrollSubject;
        private Button btnEnroll;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label5;
        private Button btnStudentRegistration;
        private Button btnManage;
        private Button btnProfessors;
        private Button btnHome;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label1;
    }
}