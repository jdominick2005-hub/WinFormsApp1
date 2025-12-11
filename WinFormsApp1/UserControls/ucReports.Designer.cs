namespace WinFormsApp1.UserControls
{
    partial class ucReports
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlFilters = new Panel();
            panel4 = new Panel();
            cmbSection = new ComboBox();
            panel2 = new Panel();
            cmbCourse = new ComboBox();
            panel3 = new Panel();
            cmbYearLevel = new ComboBox();
            panel1 = new Panel();
            cmbSubject = new ComboBox();
            lblSection = new Label();
            lblSubject = new Label();
            lblYearLevel = new Label();
            lblCourse = new Label();
            dtpDate = new DateTimePicker();
            dvgSummary = new DataGridView();
            lblTotals = new Label();
            btnExportPDF = new Button();
            pnlFilters.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgSummary).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.Location = new Point(64, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(154, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REPORT";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(panel4);
            pnlFilters.Controls.Add(panel2);
            pnlFilters.Controls.Add(panel3);
            pnlFilters.Controls.Add(panel1);
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(lblSubject);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(lblCourse);
            pnlFilters.Location = new Point(64, 50);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(649, 106);
            pnlFilters.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(cmbSection);
            panel4.Location = new Point(395, 55);
            panel4.Name = "panel4";
            panel4.Size = new Size(223, 23);
            panel4.TabIndex = 9;
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Location = new Point(-1, -1);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(238, 23);
            cmbSection.TabIndex = 1;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged_1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbCourse);
            panel2.Location = new Point(90, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(221, 23);
            panel2.TabIndex = 9;
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Location = new Point(-1, -1);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(238, 23);
            cmbCourse.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbYearLevel);
            panel3.Location = new Point(90, 55);
            panel3.Name = "panel3";
            panel3.Size = new Size(221, 23);
            panel3.TabIndex = 9;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(-1, -1);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(238, 23);
            cmbYearLevel.TabIndex = 5;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cmbSubject);
            panel1.Location = new Point(395, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 23);
            panel1.TabIndex = 8;
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Location = new Point(-1, -1);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(238, 23);
            cmbSubject.TabIndex = 3;
            cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged_1;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(334, 60);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(71, 23);
            lblSection.TabIndex = 0;
            lblSection.Text = "Section:";
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(334, 24);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(66, 23);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
            // 
            // lblYearLevel
            // 
            lblYearLevel.Location = new Point(21, 60);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(80, 23);
            lblYearLevel.TabIndex = 4;
            lblYearLevel.Text = "Year Level:";
            // 
            // lblCourse
            // 
            lblCourse.Location = new Point(21, 24);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(63, 23);
            lblCourse.TabIndex = 6;
            lblCourse.Text = "Course:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(510, 16);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(203, 23);
            dtpDate.TabIndex = 8;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // dvgSummary
            // 
            dvgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgSummary.BackgroundColor = Color.White;
            dvgSummary.ColumnHeadersHeight = 29;
            dvgSummary.GridColor = Color.Silver;
            dvgSummary.Location = new Point(64, 162);
            dvgSummary.Name = "dvgSummary";
            dvgSummary.RowHeadersVisible = false;
            dvgSummary.RowHeadersWidth = 51;
            dvgSummary.RowTemplate.Height = 28;
            dvgSummary.Size = new Size(649, 323);
            dvgSummary.TabIndex = 3;
            dvgSummary.CellContentClick += dvgSummary_CellContentClick;
            // 
            // lblTotals
            // 
            lblTotals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotals.Location = new Point(58, 499);
            lblTotals.Name = "lblTotals";
            lblTotals.Size = new Size(489, 23);
            lblTotals.TabIndex = 4;
            lblTotals.Text = "Summary:";
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.MediumSeaGreen;
            btnExportPDF.FlatAppearance.BorderSize = 0;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportPDF.ForeColor = Color.White;
            btnExportPDF.Location = new Point(553, 490);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(160, 32);
            btnExportPDF.TabIndex = 5;
            btnExportPDF.Text = "Export to PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            // 
            // ucReports
            // 
            BackColor = Color.White;
            Controls.Add(dtpDate);
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dvgSummary);
            Controls.Add(lblTotals);
            Controls.Add(btnExportPDF);
            Name = "ucReports";
            Size = new Size(775, 570);
            pnlFilters.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgSummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlFilters;

        private Label lblSection;
        private ComboBox cmbSection;

        private Label lblSubject;
        private ComboBox cmbSubject;

        private Label lblYearLevel;
        private ComboBox cmbYearLevel;

        private Label lblCourse;
        private ComboBox cmbCourse;

        private DataGridView dvgSummary;
        private Label lblTotals;
        private Button btnExportPDF;
        private DateTimePicker dtpDate;
        private Panel panel4;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
    }
}
