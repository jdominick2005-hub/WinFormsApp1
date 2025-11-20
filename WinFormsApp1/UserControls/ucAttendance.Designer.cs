namespace WinFormsApp1
{


    partial class ucAttendance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSelectSubject = new Label();
            btnLoad = new Button();
            btnSave = new Button();
            dvgStudents = new DataGridView();
            cmbSubjects = new ComboBox();
            cmbSection = new ComboBox();
            lblSelectSection = new Label();
            dtpDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            SuspendLayout();
            // 
            // lblSelectSubject
            // 
            lblSelectSubject.AutoSize = true;
            lblSelectSubject.Location = new Point(27, 75);
            lblSelectSubject.Name = "lblSelectSubject";
            lblSelectSubject.Size = new Size(83, 15);
            lblSelectSubject.TabIndex = 87;
            lblSelectSubject.Text = "Select Subject:";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(146, 433);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 86;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(56, 433);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 85;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // dvgStudents
            // 
            dvgStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgStudents.Location = new Point(27, 101);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.Size = new Size(615, 296);
            dvgStudents.TabIndex = 84;
            // 
            // cmbSubjects
            // 
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(116, 72);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(121, 23);
            cmbSubjects.TabIndex = 83;
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(116, 43);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(121, 23);
            cmbSection.TabIndex = 88;
            // 
            // lblSelectSection
            // 
            lblSelectSection.AutoSize = true;
            lblSelectSection.Location = new Point(27, 46);
            lblSelectSection.Name = "lblSelectSection";
            lblSelectSection.Size = new Size(83, 15);
            lblSelectSection.TabIndex = 89;
            lblSelectSection.Text = "Select Section:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(259, 46);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(231, 23);
            dtpDate.TabIndex = 90;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // ucAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dtpDate);
            Controls.Add(lblSelectSection);
            Controls.Add(cmbSection);
            Controls.Add(lblSelectSubject);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(dvgStudents);
            Controls.Add(cmbSubjects);
            Name = "ucAttendance";
            Size = new Size(752, 501);
            ((System.ComponentModel.ISupportInitialize)dvgStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSelectSubject;
        private Button btnLoad;
        private Button btnSave;
        private DataGridView dvgStudents;
        private ComboBox cmbSubjects;
        private ComboBox cmbSection;
        private Label lblSelectSection;
        private DateTimePicker dtpDate;
    }
}
