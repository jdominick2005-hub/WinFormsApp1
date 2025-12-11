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
            panel4 = new Panel();
            cmbprogram = new ComboBox();
            panel3 = new Panel();
            cmbSections = new ComboBox();
            panel2 = new Panel();
            cmbsubjects = new ComboBox();
            panel1 = new Panel();
            cmbYearLevel = new ComboBox();
            lblprogram = new Label();
            lblsubjects = new Label();
            lblLevel = new Label();
            lblSection = new Label();
            lblSchedule = new Label();
            txtSchedule = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            dgvClass = new DataGridView();
            dtpDate = new DateTimePicker();
            pnlFilters.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClass).BeginInit();
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
            pnlFilters.Location = new Point(64, 50);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(651, 177);
            pnlFilters.TabIndex = 1;
            pnlFilters.Paint += pnlFilters_Paint;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(cmbprogram);
            panel4.Location = new Point(393, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(229, 23);
            panel4.TabIndex = 13;
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
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbSections);
            panel3.Location = new Point(78, 66);
            panel3.Name = "panel3";
            panel3.Size = new Size(229, 23);
            panel3.TabIndex = 13;
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
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cmbsubjects);
            panel2.Location = new Point(78, 115);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 23);
            panel2.TabIndex = 13;
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
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cmbYearLevel);
            panel1.Location = new Point(78, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 23);
            panel1.TabIndex = 12;
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
            // lblprogram
            // 
            lblprogram.AutoSize = true;
            lblprogram.Location = new Point(328, 26);
            lblprogram.Name = "lblprogram";
            lblprogram.Size = new Size(59, 15);
            lblprogram.TabIndex = 11;
            lblprogram.Text = "Program: ";
            // 
            // lblsubjects
            // 
            lblsubjects.AutoSize = true;
            lblsubjects.Location = new Point(14, 121);
            lblsubjects.Name = "lblsubjects";
            lblsubjects.Size = new Size(54, 15);
            lblsubjects.TabIndex = 8;
            lblsubjects.Text = "Subjects:";
            // 
            // lblLevel
            // 
            lblLevel.Location = new Point(14, 25);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(64, 23);
            lblLevel.TabIndex = 0;
            lblLevel.Text = "Year Level:";
            // 
            // lblSection
            // 
            lblSection.Location = new Point(14, 73);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(54, 23);
            lblSection.TabIndex = 2;
            lblSection.Text = "Section:";
            // 
            // lblSchedule
            // 
            lblSchedule.Location = new Point(328, 71);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(59, 23);
            lblSchedule.TabIndex = 4;
            lblSchedule.Text = "Schedule:";
            // 
            // txtSchedule
            // 
            txtSchedule.BorderStyle = BorderStyle.FixedSingle;
            txtSchedule.Location = new Point(393, 65);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(229, 23);
            txtSchedule.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(425, 122);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 23);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total Students:";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Location = new Point(539, 116);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(83, 23);
            txtTotal.TabIndex = 7;
            // 
            // dgvClass
            // 
            dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClass.BackgroundColor = Color.White;
            dgvClass.ColumnHeadersHeight = 29;
            dgvClass.Location = new Point(64, 233);
            dgvClass.Name = "dgvClass";
            dgvClass.RowHeadersVisible = false;
            dgvClass.RowHeadersWidth = 51;
            dgvClass.RowTemplate.Height = 28;
            dgvClass.Size = new Size(651, 304);
            dgvClass.TabIndex = 2;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(510, 16);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(205, 23);
            dtpDate.TabIndex = 12;
            // 
            // ucClass
            // 
            BackColor = Color.White;
            Controls.Add(dtpDate);
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dgvClass);
            Location = new Point(510, 16);
            Name = "ucClass";
            Size = new Size(775, 570);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
    }
}
