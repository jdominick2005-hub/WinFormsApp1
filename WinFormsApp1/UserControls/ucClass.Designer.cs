namespace WinFormsApp1.UserControls
{
    partial class ucClass
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
            lblclass = new Label();
            dgvclass = new DataGridView();
            lblSections = new Label();
            cmbsections = new ComboBox();
            lbllevel = new Label();
            cmbYearlevel = new ComboBox();
            lbltotal = new Label();
            txttotal = new TextBox();
            lblschedule = new Label();
            txtschedule = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvclass).BeginInit();
            SuspendLayout();
            // 
            // lblclass
            // 
            lblclass.BackColor = SystemColors.ActiveCaption;
            lblclass.Font = new Font("Century", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblclass.Location = new Point(0, 0);
            lblclass.Name = "lblclass";
            lblclass.Size = new Size(1095, 47);
            lblclass.TabIndex = 1;
            lblclass.Text = "CLASS";
            lblclass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvclass
            // 
            dgvclass.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvclass.Location = new Point(27, 326);
            dgvclass.Name = "dgvclass";
            dgvclass.RowHeadersWidth = 51;
            dgvclass.Size = new Size(1031, 412);
            dgvclass.TabIndex = 2;
            // 
            // lblSections
            // 
            lblSections.AutoSize = true;
            lblSections.Location = new Point(355, 240);
            lblSections.Name = "lblSections";
            lblSections.Size = new Size(67, 20);
            lblSections.TabIndex = 3;
            lblSections.Text = "Sections:";
            // 
            // cmbsections
            // 
            cmbsections.FormattingEnabled = true;
            cmbsections.Items.AddRange(new object[] { "BSIT-1A", "BSCS-2A", "BSIS-3B" });
            cmbsections.Location = new Point(428, 237);
            cmbsections.Name = "cmbsections";
            cmbsections.Size = new Size(191, 28);
            cmbsections.TabIndex = 4;
            cmbsections.SelectedIndexChanged += cmbsections_SelectedIndexChanged;
            // 
            // lbllevel
            // 
            lbllevel.AutoSize = true;
            lbllevel.Location = new Point(30, 237);
            lbllevel.Name = "lbllevel";
            lbllevel.Size = new Size(78, 20);
            lbllevel.TabIndex = 5;
            lbllevel.Text = "Year Level:";
            // 
            // cmbYearlevel
            // 
            cmbYearlevel.FormattingEnabled = true;
            cmbYearlevel.Items.AddRange(new object[] { "1st Year", "2nd Year", "3rd Year" });
            cmbYearlevel.Location = new Point(114, 237);
            cmbYearlevel.Name = "cmbYearlevel";
            cmbYearlevel.Size = new Size(214, 28);
            cmbYearlevel.TabIndex = 6;
            cmbYearlevel.SelectedIndexChanged += cmbYearlevel_SelectedIndexChanged;
            // 
            // lbltotal
            // 
            lbltotal.AutoSize = true;
            lbltotal.Location = new Point(387, 291);
            lbltotal.Name = "lbltotal";
            lbltotal.Size = new Size(106, 20);
            lbltotal.TabIndex = 7;
            lbltotal.Text = "Total Students:";
            // 
            // txttotal
            // 
            txttotal.Location = new Point(499, 288);
            txttotal.Name = "txttotal";
            txttotal.Size = new Size(89, 27);
            txttotal.TabIndex = 8;
            // 
            // lblschedule
            // 
            lblschedule.AutoSize = true;
            lblschedule.Location = new Point(32, 291);
            lblschedule.Name = "lblschedule";
            lblschedule.Size = new Size(76, 20);
            lblschedule.TabIndex = 9;
            lblschedule.Text = "Schedule: ";
            // 
            // txtschedule
            // 
            txtschedule.AllowDrop = true;
            txtschedule.Location = new Point(114, 288);
            txtschedule.Name = "txtschedule";
            txtschedule.Size = new Size(254, 27);
            txtschedule.TabIndex = 10;
            // 
            // ucClass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtschedule);
            Controls.Add(lblschedule);
            Controls.Add(txttotal);
            Controls.Add(lbltotal);
            Controls.Add(cmbYearlevel);
            Controls.Add(lbllevel);
            Controls.Add(cmbsections);
            Controls.Add(lblSections);
            Controls.Add(dgvclass);
            Controls.Add(lblclass);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucClass";
            Size = new Size(1095, 763);
            ((System.ComponentModel.ISupportInitialize)dgvclass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblclass;
        private DataGridView dgvclass;
        private Label lblSections;
        private ComboBox cmbsections;
        private Label lbllevel;
        private ComboBox cmbYearlevel;
        private Label lbltotal;
        private TextBox txttotal;
        private Label lblschedule;
        private TextBox txtschedule;
    }
}
