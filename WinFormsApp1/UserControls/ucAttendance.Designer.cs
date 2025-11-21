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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

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
            cmbYearLevel = new ComboBox();
            lblYearLevel = new Label();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            SuspendLayout();
            // 
            // lblSelectSubject
            // 
            lblSelectSubject.AutoSize = true;
            lblSelectSubject.Location = new Point(14, 75);
            lblSelectSubject.Name = "lblSelectSubject";
            lblSelectSubject.Size = new Size(83, 15);
            lblSelectSubject.TabIndex = 3;
            lblSelectSubject.Text = "Select Subject:";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(171, 449);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 9;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(74, 449);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // dvgStudents
            // 
            dvgStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgStudents.Location = new Point(74, 131);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.Size = new Size(416, 296);
            dvgStudents.TabIndex = 7;
            // 
            // cmbSubjects
            // 
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(116, 72);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(300, 23);
            cmbSubjects.TabIndex = 4;
            // 
            // cmbSection
            // 
            cmbSection.FormattingEnabled = true;
            cmbSection.Location = new Point(116, 40);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(121, 23);
            cmbSection.TabIndex = 1;
            // 
            // lblSelectSection
            // 
            lblSelectSection.AutoSize = true;
            lblSelectSection.Location = new Point(14, 43);
            lblSelectSection.Name = "lblSelectSection";
            lblSelectSection.Size = new Size(83, 15);
            lblSelectSection.TabIndex = 0;
            lblSelectSection.Text = "Select Section:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(259, 40);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(231, 23);
            dtpDate.TabIndex = 2;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(116, 102);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(121, 23);
            cmbYearLevel.TabIndex = 6;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(14, 105);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(96, 15);
            lblYearLevel.TabIndex = 5;
            lblYearLevel.Text = "Select Year Level:";
            // 
            // ucAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(dvgStudents);
            Controls.Add(cmbYearLevel);
            Controls.Add(lblYearLevel);
            Controls.Add(cmbSubjects);
            Controls.Add(lblSelectSubject);
            Controls.Add(dtpDate);
            Controls.Add(lblSelectSection);
            Controls.Add(cmbSection);
            Name = "ucAttendance";
            Size = new Size(760, 500);
            ((System.ComponentModel.ISupportInitialize)dvgStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectSubject;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dvgStudents;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblSelectSection;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.Label lblYearLevel;
    }
}
