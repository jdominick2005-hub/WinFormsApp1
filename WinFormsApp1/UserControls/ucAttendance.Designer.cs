namespace WinFormsApp1
{
    partial class ucAttendance
    {
        private System.ComponentModel.IContainer components = null;

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
            lblTitle = new Label();
            pnlFilters = new Panel();
            lblSelectSection = new Label();
            cmbSection = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblSelectSubject = new Label();
            cmbSubjects = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            dvgStudents = new DataGridView();
            btnSave = new Button();
            btnLoad = new Button();
            btnMarkAll = new Button();
            btnClearAll = new Button();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(256, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Attendance Monitoring";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSelectSection);
            pnlFilters.Controls.Add(cmbSection);
            pnlFilters.Controls.Add(lblDate);
            pnlFilters.Controls.Add(dtpDate);
            pnlFilters.Controls.Add(lblSelectSubject);
            pnlFilters.Controls.Add(cmbSubjects);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Location = new Point(20, 55);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(750, 120);
            pnlFilters.TabIndex = 1;
            // 
            // lblSelectSection
            // 
            lblSelectSection.AutoSize = true;
            lblSelectSection.Location = new Point(20, 18);
            lblSelectSection.Name = "lblSelectSection";
            lblSelectSection.Size = new Size(83, 15);
            lblSelectSection.TabIndex = 0;
            lblSelectSection.Text = "Select Section:";
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Location = new Point(130, 15);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(150, 23);
            cmbSection.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(310, 18);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(34, 15);
            lblDate.TabIndex = 2;
            lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(360, 15);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(220, 23);
            dtpDate.TabIndex = 3;
            // 
            // lblSelectSubject
            // 
            lblSelectSubject.AutoSize = true;
            lblSelectSubject.Location = new Point(20, 55);
            lblSelectSubject.Name = "lblSelectSubject";
            lblSelectSubject.Size = new Size(83, 15);
            lblSelectSubject.TabIndex = 4;
            lblSelectSubject.Text = "Select Subject:";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.Location = new Point(130, 52);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(250, 23);
            cmbSubjects.TabIndex = 5;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new Point(20, 88);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(62, 15);
            lblYearLevel.TabIndex = 6;
            lblYearLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(130, 85);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(150, 23);
            cmbYearLevel.TabIndex = 7;
            // 
            // dvgStudents
            // 
            dvgStudents.BackgroundColor = Color.White;
            dvgStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgStudents.Location = new Point(20, 190);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.RowHeadersVisible = false;
            dvgStudents.RowTemplate.Height = 28;
            dvgStudents.Size = new Size(750, 244);
            dvgStudents.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 120, 215);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 457);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 32);
            btnSave.TabIndex = 3;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.WhiteSmoke;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 10F);
            btnLoad.Location = new Point(136, 457);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(110, 32);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "LOAD";
            btnLoad.UseVisualStyleBackColor = false;
            // 
            // btnMarkAll
            // 
            btnMarkAll.BackColor = Color.LightGreen;
            btnMarkAll.FlatStyle = FlatStyle.Flat;
            btnMarkAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkAll.Location = new Point(416, 458);
            btnMarkAll.Name = "btnMarkAll";
            btnMarkAll.Size = new Size(130, 32);
            btnMarkAll.TabIndex = 5;
            btnMarkAll.Text = "MARK ALL PRESENT";
            btnMarkAll.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.LightCoral;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearAll.Location = new Point(552, 458);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(130, 32);
            btnClearAll.TabIndex = 6;
            btnClearAll.Text = "CLEAR ALL";
            btnClearAll.UseVisualStyleBackColor = false;
            // 
            // ucAttendance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnClearAll);
            Controls.Add(btnMarkAll);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(dvgStudents);
            Controls.Add(pnlFilters);
            Controls.Add(lblTitle);
            Name = "ucAttendance";
            Size = new Size(775, 508);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblSelectSection;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblSelectSubject;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.DataGridView dvgStudents;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnMarkAll;
        private System.Windows.Forms.Button btnClearAll;
    }
}
