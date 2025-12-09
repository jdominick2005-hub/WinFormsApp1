namespace WinFormsApp1.UserControls
{
    partial class ucClass
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
            lblprogram = new Label();
            cmbprogram = new ComboBox();
            cmbsubjects = new ComboBox();
            lblsubjects = new Label();
            lblLevel = new Label();
            cmbYearLevel = new ComboBox();
            lblSection = new Label();
            cmbSections = new ComboBox();
            lblSchedule = new Label();
            txtSchedule = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            dgvClass = new DataGridView();
            dtpDate = new DateTimePicker();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClass).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(415, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Class Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblprogram);
            pnlFilters.Controls.Add(cmbprogram);
            pnlFilters.Controls.Add(cmbsubjects);
            pnlFilters.Controls.Add(lblsubjects);
            pnlFilters.Controls.Add(lblLevel);
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(cmbSections);
            pnlFilters.Controls.Add(lblSchedule);
            pnlFilters.Controls.Add(txtSchedule);
            pnlFilters.Controls.Add(lblTotal);
            pnlFilters.Controls.Add(txtTotal);
            pnlFilters.Location = new Point(42, 106);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(806, 161);
            pnlFilters.TabIndex = 1;
            // 
            // lblprogram
            // 
            lblprogram.AutoSize = true;
            lblprogram.Location = new Point(444, 26);
            lblprogram.Name = "lblprogram";
            lblprogram.Size = new Size(73, 20);
            lblprogram.TabIndex = 11;
            lblprogram.Text = "Program: ";
            // 
            // cmbprogram
            // 
            cmbprogram.FormattingEnabled = true;
            cmbprogram.Location = new Point(534, 18);
            cmbprogram.Name = "cmbprogram";
            cmbprogram.Size = new Size(222, 28);
            cmbprogram.TabIndex = 10;
            cmbprogram.SelectedIndexChanged += cmbprogram_SelectedIndexChanged;
            // 
            // cmbsubjects
            // 
            cmbsubjects.FormattingEnabled = true;
            cmbsubjects.Location = new Point(146, 111);
            cmbsubjects.Name = "cmbsubjects";
            cmbsubjects.Size = new Size(229, 28);
            cmbsubjects.TabIndex = 9;
            cmbsubjects.SelectedIndexChanged += cmbsubjects_SelectedIndexChanged;
            // 
            // lblsubjects
            // 
            lblsubjects.AutoSize = true;
            lblsubjects.Location = new Point(37, 119);
            lblsubjects.Name = "lblsubjects";
            lblsubjects.Size = new Size(67, 20);
            lblsubjects.TabIndex = 8;
            lblsubjects.Text = "Subjects:";
            // 
            // lblLevel
            // 
            lblLevel.Location = new Point(37, 23);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(78, 23);
            lblLevel.TabIndex = 0;
            lblLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(146, 18);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(229, 28);
            cmbYearLevel.TabIndex = 1;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(37, 71);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(64, 23);
            lblSection.TabIndex = 2;
            lblSection.Text = "Section:";
            // 
            // cmbSections
            // 
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Location = new Point(146, 66);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(229, 28);
            cmbSections.TabIndex = 3;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            // 
            // lblSchedule
            // 
            lblSchedule.Location = new Point(444, 71);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(75, 23);
            lblSchedule.TabIndex = 4;
            lblSchedule.Text = "Schedule:";
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(534, 67);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(222, 27);
            txtSchedule.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(560, 117);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 23);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total Students:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(688, 113);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(68, 27);
            txtTotal.TabIndex = 7;
            // 
            // dgvClass
            // 
            dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClass.BackgroundColor = Color.White;
            dgvClass.ColumnHeadersHeight = 29;
            dgvClass.Location = new Point(42, 292);
            dgvClass.Name = "dgvClass";
            dgvClass.RowHeadersVisible = false;
            dgvClass.RowHeadersWidth = 51;
            dgvClass.RowTemplate.Height = 28;
            dgvClass.Size = new Size(806, 426);
            dgvClass.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(577, 39);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(271, 27);
            dtpDate.TabIndex = 12;
            // 
            // ucClass
            // 
            BackColor = Color.White;
            Controls.Add(dtpDate);
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dgvClass);
            Name = "ucClass";
            Size = new Size(886, 759);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlFilters;

        private Label lblLevel;
        private ComboBox cmbYearLevel;

        private Label lblSection;
        private ComboBox cmbSections;

        private Label lblSchedule;
        private TextBox txtSchedule;

        private Label lblTotal;
        private TextBox txtTotal;

        private DataGridView dgvClass;
        private ComboBox cmbsubjects;
        private Label lblsubjects;
        private Label lblprogram;
        private ComboBox cmbprogram;
        private DateTimePicker dtpDate;
    }
}
