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
            dtpDate = new DateTimePicker();
            lblSection = new Label();
            cmbSection = new ComboBox();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            dvgSummary = new DataGridView();
            lblTotals = new Label();
            btnExportPDF = new Button();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgSummary).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(191, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REPORT";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(lblSubject);
            pnlFilters.Controls.Add(cmbSection);
            pnlFilters.Controls.Add(cmbSubject);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(lblCourse);
            pnlFilters.Controls.Add(cmbCourse);
            pnlFilters.Location = new Point(16, 83);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(856, 110);
            pnlFilters.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(577, 39);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(271, 27);
            dtpDate.TabIndex = 8;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(451, 59);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(71, 23);
            lblSection.TabIndex = 0;
            lblSection.Text = "Section:";
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Location = new Point(548, 54);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(288, 28);
            cmbSection.TabIndex = 1;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged_1;
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(451, 23);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(66, 23);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Location = new Point(548, 20);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(288, 28);
            cmbSubject.TabIndex = 3;
            cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged_1;
            // 
            // lblYearLevel
            // 
            lblYearLevel.Location = new Point(18, 59);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(80, 23);
            lblYearLevel.TabIndex = 4;
            lblYearLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(115, 54);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(288, 28);
            cmbYearLevel.TabIndex = 5;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.Location = new Point(18, 25);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(63, 23);
            lblCourse.TabIndex = 6;
            lblCourse.Text = "Course:";
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Location = new Point(115, 20);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(288, 28);
            cmbCourse.TabIndex = 7;
            // 
            // dvgSummary
            // 
            dvgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgSummary.BackgroundColor = Color.White;
            dvgSummary.ColumnHeadersHeight = 29;
            dvgSummary.GridColor = Color.Silver;
            dvgSummary.Location = new Point(16, 199);
            dvgSummary.Name = "dvgSummary";
            dvgSummary.RowHeadersVisible = false;
            dvgSummary.RowHeadersWidth = 51;
            dvgSummary.RowTemplate.Height = 28;
            dvgSummary.Size = new Size(856, 467);
            dvgSummary.TabIndex = 3;
            dvgSummary.CellContentClick += dvgSummary_CellContentClick;
            // 
            // lblTotals
            // 
            lblTotals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotals.Location = new Point(17, 672);
            lblTotals.Name = "lblTotals";
            lblTotals.Size = new Size(500, 23);
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
            btnExportPDF.Location = new Point(712, 672);
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
            Size = new Size(886, 759);
            pnlFilters.ResumeLayout(false);
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
    }
}
