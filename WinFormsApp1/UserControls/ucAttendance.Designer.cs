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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            pnlFilters = new Panel();
            lblSelectSection = new Label();
            cmbSection = new ComboBox();
            dtpDate = new DateTimePicker();
            lblSelectSubject = new Label();
            cmbSubjects = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            dvgStudents = new DataGridView();
            btnMarkAllPresent = new Button();
            btnClearAll = new Button();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(16, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(311, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ATTENDANCE";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSelectSection);
            pnlFilters.Controls.Add(cmbSection);
            pnlFilters.Controls.Add(lblSelectSubject);
            pnlFilters.Controls.Add(cmbSubjects);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Location = new Point(71, 113);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(740, 110);
            pnlFilters.TabIndex = 1;
            // 
            // lblSelectSection
            // 
            lblSelectSection.AutoSize = true;
            lblSelectSection.Font = new Font("Segoe UI", 9F);
            lblSelectSection.Location = new Point(15, 15);
            lblSelectSection.Name = "lblSelectSection";
            lblSelectSection.Size = new Size(61, 20);
            lblSelectSection.TabIndex = 0;
            lblSelectSection.Text = "Section:";
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.FlatStyle = FlatStyle.Flat;
            cmbSection.Font = new Font("Segoe UI", 9F);
            cmbSection.Location = new Point(90, 12);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(140, 28);
            cmbSection.TabIndex = 1;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 9F);
            dtpDate.Location = new Point(577, 39);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(271, 27);
            dtpDate.TabIndex = 3;
            // 
            // lblSelectSubject
            // 
            lblSelectSubject.AutoSize = true;
            lblSelectSubject.Font = new Font("Segoe UI", 9F);
            lblSelectSubject.Location = new Point(15, 55);
            lblSelectSubject.Name = "lblSelectSubject";
            lblSelectSubject.Size = new Size(61, 20);
            lblSelectSubject.TabIndex = 4;
            lblSelectSubject.Text = "Subject:";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.FlatStyle = FlatStyle.Flat;
            cmbSubjects.Font = new Font("Segoe UI", 9F);
            cmbSubjects.Location = new Point(90, 52);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(240, 28);
            cmbSubjects.TabIndex = 5;
            cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 9F);
            lblYearLevel.Location = new Point(360, 55);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(78, 20);
            lblYearLevel.TabIndex = 6;
            lblYearLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.FlatStyle = FlatStyle.Flat;
            cmbYearLevel.Font = new Font("Segoe UI", 9F);
            cmbYearLevel.Location = new Point(440, 52);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(120, 28);
            cmbYearLevel.TabIndex = 7;
            // 
            // dvgStudents
            // 
            dvgStudents.AllowUserToResizeRows = false;
            dvgStudents.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dvgStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dvgStudents.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dvgStudents.DefaultCellStyle = dataGridViewCellStyle2;
            dvgStudents.EnableHeadersVisualStyles = false;
            dvgStudents.GridColor = Color.Gainsboro;
            dvgStudents.Location = new Point(71, 242);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.RowHeadersVisible = false;
            dvgStudents.RowHeadersWidth = 51;
            dvgStudents.Size = new Size(740, 446);
            dvgStudents.TabIndex = 2;
            // 
            // btnMarkAllPresent
            // 
            btnMarkAllPresent.BackColor = Color.FromArgb(180, 240, 180);
            btnMarkAllPresent.FlatAppearance.BorderSize = 0;
            btnMarkAllPresent.FlatStyle = FlatStyle.Flat;
            btnMarkAllPresent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkAllPresent.Location = new Point(501, 694);
            btnMarkAllPresent.Name = "btnMarkAllPresent";
            btnMarkAllPresent.Size = new Size(150, 35);
            btnMarkAllPresent.TabIndex = 3;
            btnMarkAllPresent.Text = "MARK ALL PRESENT";
            btnMarkAllPresent.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.FromArgb(255, 180, 180);
            btnClearAll.FlatAppearance.BorderSize = 0;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearAll.Location = new Point(661, 694);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(150, 35);
            btnClearAll.TabIndex = 4;
            btnClearAll.Text = "CLEAR ALL";
            btnClearAll.UseVisualStyleBackColor = false;
            // 
            // ucAttendance
            // 
            BackColor = Color.White;
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dvgStudents);
            Controls.Add(dtpDate);
            Controls.Add(btnMarkAllPresent);
            Controls.Add(btnClearAll);
            Name = "ucAttendance";
            Size = new Size(886, 759);
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
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblSelectSubject;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label lblYearLevel;
        private System.Windows.Forms.ComboBox cmbYearLevel;
        private System.Windows.Forms.DataGridView dvgStudents;
        private System.Windows.Forms.Button btnMarkAllPresent;
        private System.Windows.Forms.Button btnClearAll;
    }
}
