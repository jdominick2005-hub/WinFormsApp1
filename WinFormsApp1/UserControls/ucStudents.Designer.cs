namespace WinFormsApp1.UserControls
{
    partial class ucStudents
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
            cmbSections = new ComboBox();
            lblYearLevel = new Label();
            cmbYearLevel = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            dgvStudents = new DataGridView();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(206, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Management";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = BorderStyle.FixedSingle;
            pnlFilters.Controls.Add(lblSection);
            pnlFilters.Controls.Add(cmbSections);
            pnlFilters.Controls.Add(lblYearLevel);
            pnlFilters.Controls.Add(cmbYearLevel);
            pnlFilters.Controls.Add(btnAdd);
            pnlFilters.Controls.Add(btnDelete);
            pnlFilters.Location = new Point(20, 50);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(740, 95);
            pnlFilters.TabIndex = 1;
            // 
            // lblSection
            // 
            lblSection.Location = new Point(20, 15);
            lblSection.Name = "lblSection";
            lblSection.Size = new Size(71, 23);
            lblSection.TabIndex = 0;
            lblSection.Text = "Section:";
            // 
            // cmbSections
            // 
            cmbSections.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSections.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbSections.Location = new Point(97, 12);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(160, 23);
            cmbSections.TabIndex = 1;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            // 
            // lblYearLevel
            // 
            lblYearLevel.Location = new Point(20, 50);
            lblYearLevel.Name = "lblYearLevel";
            lblYearLevel.Size = new Size(71, 23);
            lblYearLevel.TabIndex = 2;
            lblYearLevel.Text = "Year Level:";
            lblYearLevel.Click += lblYearLevel_Click;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearLevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year" });
            cmbYearLevel.Location = new Point(97, 47);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(160, 23);
            cmbYearLevel.TabIndex = 3;
            cmbYearLevel.SelectedIndexChanged += cmbyearlevel_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 120, 215);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(350, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnadd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Firebrick;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(490, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btndelete_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.Location = new Point(20, 160);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowTemplate.Height = 28;
            dgvStudents.Size = new Size(740, 320);
            dgvStudents.TabIndex = 2;
            dgvStudents.CellContentClick += dgvstudents_CellContentClick;
            // 
            // ucStudents
            // 
            BackColor = Color.White;
            Controls.Add(lblTitle);
            Controls.Add(pnlFilters);
            Controls.Add(dgvStudents);
            Name = "ucStudents";
            Size = new Size(800, 510);
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlFilters;

        private Label lblSection;
        private ComboBox cmbSections;

        private Label lblYearLevel;
        private ComboBox cmbYearLevel;

        private Button btnAdd;
        private Button btnDelete;

        private DataGridView dgvStudents;
    }
}
