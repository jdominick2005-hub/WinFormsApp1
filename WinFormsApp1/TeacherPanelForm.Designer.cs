namespace WinFormsApp1
{
    partial class TeacherPanelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherPanelForm));
            btnLogout = new Button();
            label2 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            btnReports = new Button();
            btnAttendance = new Button();
            btnClass = new Button();
            btnHome = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblUserName = new Label();
            panelMain = new Panel();
            panelTopDashboard = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTopDashboard.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLogout.Location = new Point(13, 395);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(223, 56);
            btnLogout.TabIndex = 70;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
            label2.Location = new Point(267, 69);
            label2.Name = "label2";
            label2.Size = new Size(239, 47);
            label2.TabIndex = 69;
            label2.Text = "DASHBOARD";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Silver;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(72, 205);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 65;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.Controls.Add(btnLogout);
            panel3.Controls.Add(btnReports);
            panel3.Controls.Add(btnAttendance);
            panel3.Controls.Add(btnClass);
            panel3.Controls.Add(btnHome);
            panel3.Location = new Point(-1, 183);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 460);
            panel3.TabIndex = 1;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.SteelBlue;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnReports.Location = new Point(12, 231);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(223, 56);
            btnReports.TabIndex = 73;
            btnReports.Text = "REPORTS";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnAttendance
            // 
            btnAttendance.BackColor = Color.SteelBlue;
            btnAttendance.FlatAppearance.BorderSize = 0;
            btnAttendance.FlatStyle = FlatStyle.Flat;
            btnAttendance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAttendance.Location = new Point(13, 159);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Size = new Size(223, 56);
            btnAttendance.TabIndex = 5;
            btnAttendance.Text = "ATTENDANCE";
            btnAttendance.UseVisualStyleBackColor = false;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.SteelBlue;
            btnClass.BackgroundImageLayout = ImageLayout.None;
            btnClass.FlatAppearance.BorderSize = 0;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnClass.Location = new Point(12, 87);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(223, 56);
            btnClass.TabIndex = 2;
            btnClass.Text = "CLASS";
            btnClass.UseVisualStyleBackColor = false;
            btnClass.Click += btnClass_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.SteelBlue;
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnHome.Location = new Point(12, 15);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(224, 56);
            btnHome.TabIndex = 0;
            btnHome.Text = "HOME";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(235, 644);
            panel1.TabIndex = 66;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 187);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblUserName.Location = new Point(131, 50);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(78, 21);
            lblUserName.TabIndex = 68;
            lblUserName.Text = "TEACHER";
            // 
            // panelMain
            // 
            panelMain.Location = new Point(235, 136);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(775, 508);
            panelMain.TabIndex = 71;
            // 
            // panelTopDashboard
            // 
            panelTopDashboard.Controls.Add(label3);
            panelTopDashboard.Controls.Add(lblUserName);
            panelTopDashboard.Location = new Point(235, 0);
            panelTopDashboard.Name = "panelTopDashboard";
            panelTopDashboard.Size = new Size(775, 136);
            panelTopDashboard.TabIndex = 72;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(39, 50);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 75;
            label3.Text = "WELCOME: ";
            // 
            // TeacherPanelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 644);
            Controls.Add(label2);
            Controls.Add(panelMain);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(panelTopDashboard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TeacherPanelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TeacherPanelForm";
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTopDashboard.ResumeLayout(false);
            panelTopDashboard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Label label2;
        private Label label5;
        private Panel panel3;
        private Button btnAttendance;
        private Button btnClass;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblUserName;
        private Button btnReports;
        private Panel panelMain;
        private Panel panelTopDashboard;
        private Button btnHome;
        public Label label3;
    }
}