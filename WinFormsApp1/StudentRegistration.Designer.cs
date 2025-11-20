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
            gbStudentRegistration = new GroupBox();
            txtClassified = new TextBox();
            txtUnits = new TextBox();
            txtCourse = new TextBox();
            txtYearLevel = new TextBox();
            txtName = new TextBox();
            txtStudentId = new TextBox();
            lblClassified = new Label();
            lblUnits = new Label();
            lblCourse = new Label();
            lblYearLevel = new Label();
            lblName = new Label();
            lblStudentId = new Label();
            btnRegister = new Button();
            groupBox2 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnShow = new Button();
            dgvStudentRegistration = new DataGridView();
            gbStudentRegistration.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).BeginInit();
            SuspendLayout();
            // 
            // gbStudentRegistration
            // 
            gbStudentRegistration.AutoSize = true;
            gbStudentRegistration.Controls.Add(txtClassified);
            gbStudentRegistration.Controls.Add(txtUnits);
            gbStudentRegistration.Controls.Add(txtCourse);
            gbStudentRegistration.Controls.Add(txtYearLevel);
            gbStudentRegistration.Controls.Add(txtName);
            gbStudentRegistration.Controls.Add(txtStudentId);
            gbStudentRegistration.Controls.Add(lblClassified);
            gbStudentRegistration.Controls.Add(lblUnits);
            gbStudentRegistration.Controls.Add(lblCourse);
            gbStudentRegistration.Controls.Add(lblYearLevel);
            gbStudentRegistration.Controls.Add(lblName);
            gbStudentRegistration.Controls.Add(lblStudentId);
            gbStudentRegistration.Location = new Point(105, 61);
            gbStudentRegistration.Name = "gbStudentRegistration";
            gbStudentRegistration.Size = new Size(529, 251);
            gbStudentRegistration.TabIndex = 0;
            gbStudentRegistration.TabStop = false;
            gbStudentRegistration.Text = "Student Registration";
            // 
            // txtClassified
            // 
            txtClassified.Location = new Point(201, 192);
            txtClassified.Name = "txtClassified";
            txtClassified.Size = new Size(196, 23);
            txtClassified.TabIndex = 11;
            // 
            // txtUnits
            // 
            txtUnits.Location = new Point(201, 163);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new Size(196, 23);
            txtUnits.TabIndex = 10;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(201, 134);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(196, 23);
            txtCourse.TabIndex = 9;
            // 
            // txtYearLevel
            // 
            txtYearLevel.Location = new Point(201, 105);
            txtYearLevel.Name = "txtYearLevel";
            txtYearLevel.Size = new Size(196, 23);
            txtYearLevel.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(201, 76);
            txtName.Name = "txtName";
            txtName.Size = new Size(196, 23);
            txtName.TabIndex = 7;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(201, 45);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(196, 23);
            txtStudentId.TabIndex = 6;
            // 
            // lblClassified
            // 
            lblClassified.AutoSize = true;
            lblClassified.Location = new Point(135, 200);
            lblClassified.Name = "lblClassified";
            lblClassified.Size = new Size(60, 15);
            lblClassified.TabIndex = 5;
            lblClassified.Text = "Classified:";
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Location = new Point(141, 171);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(37, 15);
            lblUnits.TabIndex = 4;
            lblUnits.Text = "Units:";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(141, 142);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(47, 15);
            lblCourse.TabIndex = 3;
            lblCourse.Text = "Course:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(136, 113);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(62, 15);
            lblYearLevel.TabIndex = 2;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(141, 84);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(134, 53);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(61, 15);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "StudentId:";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(65, 44);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnUpdate);
            groupBox2.Controls.Add(btnShow);
            groupBox2.Controls.Add(btnRegister);
            groupBox2.Location = new Point(662, 61);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 251);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(65, 131);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete All";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(65, 102);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(65, 73);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 2;
            btnShow.Text = "Show";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // dgvStudentRegistration
            // 
            dgvStudentRegistration.BackgroundColor = Color.Gainsboro;
            dgvStudentRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentRegistration.Location = new Point(160, 335);
            dgvStudentRegistration.Name = "dgvStudentRegistration";
            dgvStudentRegistration.Size = new Size(642, 150);
            dgvStudentRegistration.TabIndex = 3;
            // 
            // StudentRegistration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 517);
            Controls.Add(dgvStudentRegistration);
            Controls.Add(gbStudentRegistration);
            Controls.Add(groupBox2);
            Name = "StudentRegistration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentRegistration";
            gbStudentRegistration.ResumeLayout(false);
            gbStudentRegistration.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudentRegistration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbStudentRegistration;
        private Label lblClassified;
        private Label lblUnits;
        private Label lblCourse;
        private Label lblYearLevel;
        private Label lblName;
        private Label lblStudentId;
        private TextBox txtClassified;
        private TextBox txtUnits;
        private TextBox txtCourse;
        private TextBox txtYearLevel;
        private TextBox txtName;
        private TextBox txtStudentId;
        private Button btnRegister;
        private GroupBox groupBox2;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnShow;
        private DataGridView dgvStudentRegistration;
    }
}