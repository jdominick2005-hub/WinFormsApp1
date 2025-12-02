namespace WinFormsApp1.UserControls
{
    partial class ucSubject
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
            cmbYearLevel = new ComboBox();
            lblProfessor = new Label();
            txtProfessor = new TextBox();
            lblSection = new Label();
            cmbSection = new ComboBox();
            dgvSubjects = new DataGridView();
            lblYearLevel = new Label();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Subject Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(lblProfessor);
            pnlFilters.Controls.Add(txtProfessor);
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(cmbSection);
            pnlFilters.Location = new Point(20, 50);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(740, 110);
            pnlFilters.TabIndex = 1;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.Location = new Point(96, 81);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(139, 23);
            cmbYearLevel.TabIndex = 4;
            // 
            // lblProfessor
            // 
            lblProfessor.Location = new Point(20, 20);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(70, 23);
            lblProfessor.TabIndex = 0;
            lblProfessor.Text = "Professor:";
            lblProfessor.Click += lblProfessor_Click;
            // 
            // txtProfessor
            // 
            txtProfessor.Location = new Point(96, 17);
            txtProfessor.Name = "txtProfessor";
            txtProfessor.Size = new Size(254, 23);
            txtProfessor.TabIndex = 1;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(20, 55);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(70, 23);
            lblSection.TabIndex = 2;
            lblSection.Text = "Section:";
            lblSection.Click += lblSection_Click;
            // 
            // cmbSection
            // 
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbSection.Location = new Point(96, 52);
            cmbSection.Name = "cmbSection";
            cmbSection.Size = new Size(174, 23);
            cmbSection.TabIndex = 3;
            // 
            // dgvSubjects
            // 
            dgvSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubjects.BackgroundColor = Color.White;
            dgvSubjects.Location = new Point(20, 180);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.RowHeadersVisible = false;
            dgvSubjects.RowTemplate.Height = 28;
            dgvSubjects.Size = new Size(740, 300);
            dgvSubjects.TabIndex = 2;
            // 
            // lblYearLevel
            // 
            lblYearLevel.Location = new Point(20, 86);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(70, 23);
            lblYearLevel.TabIndex = 5;
            lblYearLevel.Text = "YearLevel:";
            // 
            // ucSubject
            // 
            BackColor = Color.White;
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dgvSubjects);
            Name = "ucSubject";
            Size = new Size(800, 510);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlFilters;

        private Label lblProfessor;
        private TextBox txtProfessor;

        private Label lblSection;
        private ComboBox cmbSection;

        private DataGridView dgvSubjects;
        private ComboBox cmbYearLevel;
        private Label lblYearLevel;
    }
}
