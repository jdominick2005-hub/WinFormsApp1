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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblTitle = new Label();
            pnlFilters = new Panel();
            lblSelectSection = new Label();
            cmbSection = new ComboBox();
            lblSelectSubject = new Label();
            cmbSubjects = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            dtpDate = new DateTimePicker();
            dvgStudents = new DataGridView();
            btnMarkAllPresent = new Button();
            btnClearAll = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgStudents).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(64, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(252, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ATTENDANCE";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(panel4);
            pnlFilters.Controls.Add(panel2);
            pnlFilters.Controls.Add(panel1);
            pnlFilters.Controls.Add(lblSelectSection);
            pnlFilters.Controls.Add(lblSelectSubject);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Location = new Point(71, 80);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(10);
            pnlFilters.Size = new Size(740, 110);
            pnlFilters.TabIndex = 1;
            // 
            // lblSelectSection
            // 
            lblSelectSection.AutoSize = true;
            lblSelectSection.Font = new Font("Segoe UI", 9F);
            lblSelectSection.Location = new Point(48, 26);
            lblSelectSection.Name = "lblSelectSection";
            lblSelectSection.Size = new Size(49, 15);
            lblSelectSection.TabIndex = 0;
            lblSelectSection.Text = "Section:";
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.FlatStyle = FlatStyle.System;
            cmbSection.Font = new Font("Segoe UI", 9F);
            cmbSection.Location = new Point(-1, -1);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(225, 23);
            cmbSection.TabIndex = 1;
            // 
            // lblSelectSubject
            // 
            lblSelectSubject.AutoSize = true;
            lblSelectSubject.Font = new Font("Segoe UI", 9F);
            lblSelectSubject.Location = new Point(48, 66);
            lblSelectSubject.Name = "lblSelectSubject";
            lblSelectSubject.Size = new Size(49, 15);
            lblSelectSubject.TabIndex = 4;
            lblSelectSubject.Text = "Subject:";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.FlatStyle = FlatStyle.Flat;
            cmbSubjects.Font = new Font("Segoe UI", 9F);
            cmbSubjects.Location = new Point(-1, -1);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(225, 23);
            cmbSubjects.TabIndex = 5;
            cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
            // 
            // lblYearLevel
            // 
            lblYearLevel.AutoSize = true;
            lblYearLevel.Font = new Font("Segoe UI", 9F);
            lblYearLevel.Location = new Point(388, 26);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(62, 15);
            lblYearLevel.TabIndex = 6;
            lblYearLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.FlatStyle = FlatStyle.Flat;
            cmbYearLevel.Font = new Font("Segoe UI", 9F);
            cmbYearLevel.Location = new Point(-1, -1);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(225, 23);
            cmbYearLevel.TabIndex = 7;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 9F);
            dtpDate.Location = new Point(602, 13);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(271, 23);
            dtpDate.TabIndex = 3;
            // 
            // dvgStudents
            // 
            dvgStudents.AllowUserToResizeRows = false;
            dvgStudents.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dvgStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dvgStudents.ColumnHeadersHeight = 29;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dvgStudents.DefaultCellStyle = dataGridViewCellStyle4;
            dvgStudents.EnableHeadersVisualStyles = false;
            dvgStudents.GridColor = Color.Gainsboro;
            dvgStudents.Location = new Point(71, 216);
            dvgStudents.Name = "dvgStudents";
            dvgStudents.RowHeadersVisible = false;
            dvgStudents.RowHeadersWidth = 51;
            dvgStudents.Size = new Size(740, 439);
            dvgStudents.TabIndex = 2;
            // 
            // btnMarkAllPresent
            // 
            btnMarkAllPresent.BackColor = Color.MediumSeaGreen;
            btnMarkAllPresent.FlatAppearance.BorderSize = 0;
            btnMarkAllPresent.FlatStyle = FlatStyle.Flat;
            btnMarkAllPresent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkAllPresent.Location = new Point(501, 675);
            btnMarkAllPresent.Name = "btnMarkAllPresent";
            btnMarkAllPresent.Size = new Size(150, 35);
            btnMarkAllPresent.TabIndex = 3;
            btnMarkAllPresent.Text = "MARK ALL PRESENT";
            btnMarkAllPresent.UseVisualStyleBackColor = false;
            // 
            // btnClearAll
            // 
            btnClearAll.BackColor = Color.IndianRed;
            btnClearAll.FlatAppearance.BorderSize = 0;
            btnClearAll.FlatStyle = FlatStyle.Flat;
            btnClearAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearAll.Location = new Point(661, 675);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(150, 35);
            btnClearAll.TabIndex = 4;
            btnClearAll.Text = "CLEAR ALL";
            btnClearAll.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cmbSubjects);
            panel1.Location = new Point(103, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(225, 23);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbSection);
            panel2.Location = new Point(103, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(225, 23);
            panel2.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(cmbYearLevel);
            panel4.Location = new Point(456, 18);
            panel4.Name = "panel4";
            panel4.Size = new Size(225, 23);
            panel4.TabIndex = 10;
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
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
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
        private Panel panel4;
        private Panel panel2;
        private Panel panel1;
    }
}
