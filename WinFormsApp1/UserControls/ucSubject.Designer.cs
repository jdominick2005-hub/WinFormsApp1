
namespace WinFormsApp1.UserControls
{
    partial class ucSubject
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
            subjects = new Label();
            dgvsubjects = new DataGridView();
            lblProfessor = new Label();
            txtprofessor = new TextBox();
            lblsection = new Label();
            cmbsection = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvsubjects).BeginInit();
            SuspendLayout();
            // 
            // subjects
            // 
            subjects.BackColor = SystemColors.ActiveCaption;
            subjects.Dock = DockStyle.Top;
            subjects.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            subjects.Location = new Point(0, 0);
            subjects.Name = "subjects";
            subjects.Size = new Size(861, 42);
            subjects.TabIndex = 1;
            subjects.Text = "SUBJECT";
            subjects.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvsubjects
            // 
            dgvsubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvsubjects.BackgroundColor = Color.Gainsboro;
            dgvsubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvsubjects.Location = new Point(56, 194);
            dgvsubjects.Margin = new Padding(3, 2, 3, 2);
            dgvsubjects.Name = "dgvsubjects";
            dgvsubjects.RowHeadersWidth = 51;
            dgvsubjects.Size = new Size(745, 324);
            dgvsubjects.TabIndex = 2;
            dgvsubjects.CellContentClick += dgvsubjects_CellContentClick;
            // 
            // lblProfessor
            // 
            lblProfessor.AutoSize = true;
            lblProfessor.Location = new Point(56, 114);
            lblProfessor.Name = "lblProfessor";
            lblProfessor.Size = new Size(62, 15);
            lblProfessor.TabIndex = 3;
            lblProfessor.Text = "Professor: ";
            // 
            // txtprofessor
            // 
            txtprofessor.Location = new Point(129, 114);
            txtprofessor.Margin = new Padding(3, 2, 3, 2);
            txtprofessor.Name = "txtprofessor";
            txtprofessor.Size = new Size(213, 23);
            txtprofessor.TabIndex = 4;
            txtprofessor.TextChanged += txtprofessor_TextChanged;
            // 
            // lblsection
            // 
            lblsection.AutoSize = true;
            lblsection.Location = new Point(56, 152);
            lblsection.Name = "lblsection";
            lblsection.Size = new Size(48, 15);
            lblsection.TabIndex = 5;
            lblsection.Text = "section:";
            // 
            // cmbsection
            // 
            cmbsection.FormattingEnabled = true;
            cmbsection.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbsection.Location = new Point(129, 152);
            cmbsection.Margin = new Padding(3, 2, 3, 2);
            cmbsection.Name = "cmbsection";
            cmbsection.Size = new Size(197, 23);
            cmbsection.TabIndex = 6;
            // 
            // ucSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbsection);
            Controls.Add(lblsection);
            Controls.Add(txtprofessor);
            Controls.Add(lblProfessor);
            Controls.Add(dgvsubjects);
            Controls.Add(subjects);
            Name = "ucSubject";
            Size = new Size(861, 604);
            ((System.ComponentModel.ISupportInitialize)dgvsubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        private void txtprofessor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvsubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label subjects;
        private DataGridView dgvsubjects;
        private Label lblProfessor;
        private TextBox txtprofessor;
        private Label lblsection;
        private ComboBox cmbsection;
    }
}
