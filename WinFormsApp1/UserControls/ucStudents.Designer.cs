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
            SuspendLayout();
            // 
            // label1
            // 
            lblStudents.AutoSize = true;
            lblStudents.Location = new Point(342, 243);
            lblStudents.Name = "label1";
            lblStudents.Size = new Size(53, 15);
            lblStudents.TabIndex = 1;
            lblStudents.Text = "Students";
            // 
            // ucStudents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStudents);
            Name = "ucStudents";
            Size = new Size(752, 501);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudents;
    }
}
