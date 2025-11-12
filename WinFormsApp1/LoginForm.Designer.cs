namespace WinFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            chkbxremember = new CheckBox();
            lblpassword = new Label();
            lblusername = new Label();
            btnlogin = new Button();
            txtpassword = new TextBox();
            txtusername = new TextBox();
            SuspendLayout();
            // 
            // chkbxremember
            // 
            chkbxremember.AutoSize = true;
            chkbxremember.BackColor = Color.Transparent;
            chkbxremember.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkbxremember.Location = new Point(368, 347);
            chkbxremember.Name = "chkbxremember";
            chkbxremember.Size = new Size(98, 17);
            chkbxremember.TabIndex = 12;
            chkbxremember.Text = "Remember me";
            chkbxremember.UseVisualStyleBackColor = false;
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.BackColor = Color.Transparent;
            lblpassword.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblpassword.ForeColor = Color.Black;
            lblpassword.Location = new Point(369, 288);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(66, 17);
            lblpassword.TabIndex = 11;
            lblpassword.Text = "Password";
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.BackColor = Color.Transparent;
            lblusername.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblusername.ForeColor = Color.Black;
            lblusername.Location = new Point(369, 222);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(69, 17);
            lblusername.TabIndex = 10;
            lblusername.Text = "Username";
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.DodgerBlue;
            btnlogin.BackgroundImageLayout = ImageLayout.None;
            btnlogin.FlatStyle = FlatStyle.Popup;
            btnlogin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(434, 429);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(95, 29);
            btnlogin.TabIndex = 9;
            btnlogin.Text = "LOGIN";
            btnlogin.UseVisualStyleBackColor = false;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.White;
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Location = new Point(369, 306);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(229, 35);
            txtpassword.TabIndex = 8;
            // 
            // txtusername
            // 
            txtusername.BackColor = Color.White;
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Location = new Point(369, 240);
            txtusername.Multiline = true;
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(229, 35);
            txtusername.TabIndex = 7;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(964, 611);
            Controls.Add(chkbxremember);
            Controls.Add(lblpassword);
            Controls.Add(lblusername);
            Controls.Add(btnlogin);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkbxremember;
        private Label lblpassword;
        private Label lblusername;
        private Button btnlogin;
        private TextBox txtpassword;
        private TextBox txtusername;
    }
}
