namespace WinFormsApp1.UserControls
{
    partial class ucStudents
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStudents = new Label();
            dgvstudents = new DataGridView();
            lblsection = new Label();
            cmbSections = new ComboBox();
            lblyearlevel = new Label();
            cmbyearlevel = new ComboBox();
            btnadd = new Button();
            btndelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvstudents).BeginInit();
            SuspendLayout();
            // 
            // lblStudents
            // 
            lblStudents.BackColor = SystemColors.ActiveCaption;
            lblStudents.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudents.Location = new Point(56, 24);
            lblStudents.Name = "lblStudents";
            lblStudents.Size = new Size(977, 47);
            lblStudents.TabIndex = 1;
            lblStudents.Text = "Students";
            lblStudents.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvstudents
            // 
            dgvstudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvstudents.Location = new Point(56, 243);
            dgvstudents.Name = "dgvstudents";
            dgvstudents.RowHeadersWidth = 51;
            dgvstudents.Size = new Size(802, 451);
            dgvstudents.TabIndex = 2;
            dgvstudents.CellContentClick += dgvstudents_CellContentClick;
            // 
            // lblsection
            // 
            lblsection.AutoSize = true;
            lblsection.Location = new Point(56, 142);
            lblsection.Name = "lblsection";
            lblsection.Size = new Size(61, 20);
            lblsection.TabIndex = 3;
            lblsection.Text = "Section:";
            // 
            // cmbSections
            // 
            cmbSections.FormattingEnabled = true;
            cmbSections.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbSections.Location = new Point(123, 142);
            cmbSections.Name = "cmbSections";
            cmbSections.Size = new Size(151, 28);
            cmbSections.TabIndex = 4;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            // 
            // lblyearlevel
            // 
            lblyearlevel.AutoSize = true;
            lblyearlevel.Location = new Point(56, 189);
            lblyearlevel.Name = "lblyearlevel";
            lblyearlevel.Size = new Size(82, 20);
            lblyearlevel.TabIndex = 5;
            lblyearlevel.Text = "Year Level: ";
            // 
            // cmbyearlevel
            // 
            cmbyearlevel.FormattingEnabled = true;
            cmbyearlevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year" });
            cmbyearlevel.Location = new Point(144, 189);
            cmbyearlevel.Name = "cmbyearlevel";
            cmbyearlevel.Size = new Size(151, 28);
            cmbyearlevel.TabIndex = 6;
            cmbyearlevel.SelectedIndexChanged += cmbyearlevel_SelectedIndexChanged;
            // 
            // btnadd
            // 
            btnadd.Location = new Point(604, 192);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(115, 29);
            btnadd.TabIndex = 7;
            btnadd.Text = "Add Student";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // btndelete
            // 
            btndelete.Location = new Point(743, 192);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(115, 29);
            btndelete.TabIndex = 8;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // ucStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btndelete);
            Controls.Add(btnadd);
            Controls.Add(cmbyearlevel);
            Controls.Add(lblyearlevel);
            Controls.Add(cmbSections);
            Controls.Add(lblsection);
            Controls.Add(dgvstudents);
            Controls.Add(lblStudents);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucStudents";
            Size = new Size(1095, 763);
            ((System.ComponentModel.ISupportInitialize)dgvstudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudents;
        private DataGridView dgvstudents;
        private Label lblsection;
        private ComboBox cmbSections;
        private Label lblyearlevel;
        private ComboBox cmbyearlevel;
        private Button btnadd;
        private Button btndelete;
    }
}
