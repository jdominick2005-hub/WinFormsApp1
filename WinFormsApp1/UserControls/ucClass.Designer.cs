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
            lblSection = new Label();
            cmbYearLevel = new ComboBox();
            cmbSections = new ComboBox();
            lblSchedule = new Label();
            txtSchedule = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            dgvClass = new DataGridView();
            dtpDate = new DateTimePicker();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClass).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            lblTitle.Location = new Point(64, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(331, 47);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Class Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(panel4);
            pnlFilters.Controls.Add(panel3);
            pnlFilters.Controls.Add(panel2);
            pnlFilters.Controls.Add(panel1);
            pnlFilters.Controls.Add(lblprogram);
            pnlFilters.Controls.Add(lblsubjects);
            pnlFilters.Controls.Add(lblLevel);
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(lblSchedule);
            pnlFilters.Controls.Add(txtSchedule);
            pnlFilters.Controls.Add(lblTotal);
            pnlFilters.Controls.Add(txtTotal);
            pnlFilters.Location = new Point(64, 106);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(761, 161);
            pnlFilters.TabIndex = 1;
            pnlFilters.Paint += pnlFilters_Paint;
            // 
            // lblprogram
            // 
            lblprogram.AutoSize = true;
            lblprogram.Location = new Point(399, 22);
            lblprogram.Name = "lblprogram";
            lblprogram.Size = new Size(59, 15);
            lblprogram.TabIndex = 11;
            lblprogram.Text = "Program: ";
            // 
            // cmbprogram
            // 
            cmbprogram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbprogram.FormattingEnabled = true;
            cmbprogram.Location = new Point(-1, -1);
            cmbprogram.Name = "cmbprogram";
            cmbprogram.Size = new Size(229, 23);
            cmbprogram.TabIndex = 10;
            cmbprogram.SelectedIndexChanged += cmbprogram_SelectedIndexChanged;
            // 
            // cmbsubjects
            // 
            cmbsubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbsubjects.FormattingEnabled = true;
            cmbsubjects.Location = new Point(-1, -2);
            cmbsubjects.Name = "cmbsubjects";
            cmbsubjects.Size = new Size(229, 23);
            cmbsubjects.TabIndex = 9;
            cmbsubjects.SelectedIndexChanged += cmbsubjects_SelectedIndexChanged;
            // 
            // lblsubjects
            // 
            lblsubjects.AutoSize = true;
            lblsubjects.Location = new Point(37, 119);
            lblsubjects.Name = "lblsubjects";
            lblsubjects.Size = new Size(54, 15);
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
            // lblSection
            // 
            lblSection.Location = new Point(37, 71);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(64, 23);
            lblSection.TabIndex = 2;
            lblSection.Text = "Section:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Location = new Point(-1, -1);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(229, 23);
            cmbYearLevel.TabIndex = 1;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            // 
            // cmbSections
            // 
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Location = new Point(-1, -1);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(229, 23);
            cmbSections.TabIndex = 3;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            // 
            // lblSchedule
            // 
            lblSchedule.Location = new Point(399, 67);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(75, 23);
            lblSchedule.TabIndex = 4;
            lblSchedule.Text = "Schedule:";
            // 
            // txtSchedule
            // 
            txtSchedule.BorderStyle = BorderStyle.FixedSingle;
            txtSchedule.Location = new Point(489, 61);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(229, 23);
            txtSchedule.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(514, 115);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 23);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total Students:";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Location = new Point(628, 109);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(83, 23);
            txtTotal.TabIndex = 7;
            // 
            // dgvClass
            // 
            dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClass.BackgroundColor = Color.White;
            dgvClass.ColumnHeadersHeight = 29;
            dgvClass.Location = new Point(64, 294);
            dgvClass.Name = "dgvClass";
            dgvClass.RowHeadersVisible = false;
            dgvClass.RowHeadersWidth = 51;
            dgvClass.RowTemplate.Height = 28;
            dgvClass.Size = new Size(761, 426);
            dgvClass.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(602, 13);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(271, 23);
            dtpDate.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cmbYearLevel);
            panel1.Location = new Point(123, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 23);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbsubjects);
            panel2.Location = new Point(123, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 23);
            panel2.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbSections);
            panel3.Location = new Point(123, 64);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 23);
            panel3.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(cmbprogram);
            panel4.Location = new Point(489, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(229, 23);
            panel4.TabIndex = 13;
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
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
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
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
    }
}
