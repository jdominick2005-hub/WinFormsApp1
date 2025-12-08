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
            lblSection = new Label();
            cmbSection = new ComboBox();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            lblCourse = new Label();
            cmbCourse = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            pictureBox1 = new PictureBox();
            dvgSummary = new DataGridView();
            lblTotals = new Label();
            btnExportPDF = new Button();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dvgSummary).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(110, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(364, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Attendance Reports & Summary";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(cmbSection);
            pnlFilters.Controls.Add(lblSubject);
            pnlFilters.Controls.Add(cmbSubject);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(lblCourse);
            pnlFilters.Controls.Add(cmbCourse);
            pnlFilters.Controls.Add(lblDate);
            pnlFilters.Controls.Add(dtpDate);
            pnlFilters.Location = new Point(25, 75);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(745, 110);
            pnlFilters.TabIndex = 2;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(15, 15);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(71, 23);
            lblSection.TabIndex = 0;
            lblSection.Text = "Section:";
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Location = new Point(92, 12);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(150, 28);
            cmbSection.TabIndex = 1;
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged_1;
            // 
            // lblSubject
            // 
            lblSubject.Location = new Point(260, 15);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(54, 23);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Subject:";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Location = new Point(320, 12);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(180, 28);
            cmbSubject.TabIndex = 3;
            cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged_1;
            // 
            // lblYearLevel
            // 
            lblYearLevel.Location = new Point(15, 55);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(71, 23);
            lblYearLevel.TabIndex = 4;
            lblYearLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(92, 52);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(150, 28);
            cmbYearLevel.TabIndex = 5;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            // 
            // lblCourse
            // 
            lblCourse.Location = new Point(260, 55);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(54, 23);
            lblCourse.TabIndex = 6;
            lblCourse.Text = "Course:";
            // 
            // cmbCourse
            // 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.Location = new Point(320, 52);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(180, 28);
            cmbCourse.TabIndex = 7;
            // 
            // lblDate
            // 
            lblDate.Location = new Point(515, 15);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(39, 23);
            lblDate.TabIndex = 8;
            lblDate.Text = "Date:";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(560, 12);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(170, 27);
            dtpDate.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.SchoolLogo;
            pictureBox1.Location = new Point(25, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(70, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // dvgSummary
            // 
            dvgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgSummary.BackgroundColor = Color.White;
            dvgSummary.ColumnHeadersHeight = 29;
            dvgSummary.GridColor = Color.Silver;
            dvgSummary.Location = new Point(25, 200);
            dvgSummary.Name = "dvgSummary";
            dvgSummary.RowHeadersVisible = false;
            dvgSummary.RowHeadersWidth = 51;
            dvgSummary.RowTemplate.Height = 28;
            dvgSummary.Size = new Size(745, 260);
            dvgSummary.TabIndex = 3;
            dvgSummary.CellContentClick += dvgSummary_CellContentClick;
            // 
            // lblTotals
            // 
            lblTotals.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotals.Location = new Point(25, 470);
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
            btnExportPDF.Location = new Point(610, 465);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(160, 32);
            btnExportPDF.TabIndex = 5;
            btnExportPDF.Text = "Export to PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            // 
            // ucReports
            // 
            Controls.Add(lblTitle);
            Controls.Add(pictureBox1);
            Controls.Add(pnlFilters);
            Controls.Add(dvgSummary);
            Controls.Add(lblTotals);
            Controls.Add(btnExportPDF);
            Name = "ucReports";
            Size = new Size(775, 508);
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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

        private Label lblDate;
        private DateTimePicker dtpDate;

        private Label lblYearLevel;
        private ComboBox cmbYearLevel;

        private Label lblCourse;
        private ComboBox cmbCourse;
        private PictureBox pictureBox1;

        private DataGridView dvgSummary;
        private Label lblTotals;
        private Button btnExportPDF;
    }
}
