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
            lblLevel = new Label();
            cmbYearLevel = new ComboBox();
            lblSection = new Label();
            cmbSections = new ComboBox();
            lblSchedule = new Label();
            txtSchedule = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            dgvClass = new DataGridView();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClass).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Class Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(cmbSections);
            pnlFilters.Controls.Add(lblSchedule);
            pnlFilters.Controls.Add(txtSchedule);
            pnlFilters.Controls.Add(lblTotal);
            pnlFilters.Controls.Add(txtTotal);
            pnlFilters.Location = new Point(20, 50);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(740, 120);
            pnlFilters.TabIndex = 1;
            // 
            // lblLevel
            // 
            lblLevel.Location = new Point(20, 20);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(84, 23);
            lblLevel.TabIndex = 0;
            lblLevel.Text = "Year Level:";
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year" });
            cmbYearLevel.Location = new Point(110, 17);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(170, 23);
            cmbYearLevel.TabIndex = 1;
            cmbYearLevel.SelectedIndexChanged += cmbYearlevel_SelectedIndexChanged;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(310, 20);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(64, 23);
            lblSection.TabIndex = 2;
            lblSection.Text = "Section:";
            // 
            // cmbSections
            // 
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbSections.Location = new Point(380, 17);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(170, 23);
            cmbSections.TabIndex = 3;
            cmbSections.SelectedIndexChanged += cmbsections_SelectedIndexChanged;
            // 
            // lblSchedule
            // 
            lblSchedule.Location = new Point(20, 60);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(75, 23);
            lblSchedule.TabIndex = 4;
            lblSchedule.Text = "Schedule:";
            // 
            // txtSchedule
            // 
            txtSchedule.Location = new Point(110, 57);
            txtSchedule.Name = "txtSchedule";
            txtSchedule.Size = new Size(200, 23);
            txtSchedule.TabIndex = 5;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(330, 60);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(96, 23);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total Students:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(432, 57);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(68, 23);
            txtTotal.TabIndex = 7;
            // 
            // dgvClass
            // 
            dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClass.BackgroundColor = Color.White;
            dgvClass.Location = new Point(20, 180);
            dgvClass.Name = "dgvClass";
            dgvClass.RowHeadersVisible = false;
            dgvClass.RowTemplate.Height = 28;
            dgvClass.Size = new Size(740, 300);
            dgvClass.TabIndex = 2;
            // 
            // ucClass
            // 
            BackColor = Color.White;
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dgvClass);
            Name = "ucClass";
            Size = new Size(800, 510);
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
    }
}
