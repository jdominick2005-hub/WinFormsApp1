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
            btnShow = new Button();
            btnHide = new Button();
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
            btnlogin.Click += btnlogin_Click;
            // 
            // txtpassword
            // 
            txtpassword.BackColor = Color.White;
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Location = new Point(369, 306);
            txtpassword.Multiline = true;
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
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
            // btnShow
            // 
            btnShow.BackColor = Color.White;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.ForeColor = Color.White;
            btnShow.Image = (Image)resources.GetObject("btnShow.Image");
            btnShow.Location = new Point(558, 306);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(40, 35);
            btnShow.TabIndex = 13;
            btnShow.UseVisualStyleBackColor = false;
            btnShow.Click += btnShow_Click;
            // 
            // btnHide
            // 
            btnHide.BackColor = Color.White;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.ForeColor = Color.White;
            btnHide.Image = (Image)resources.GetObject("btnHide.Image");
            btnHide.Location = new Point(557, 306);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(40, 35);
            btnHide.TabIndex = 14;
            btnHide.UseVisualStyleBackColor = false;
            btnHide.Click += btnHide_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(964, 611);
            Controls.Add(btnShow);
            Controls.Add(chkbxremember);
            Controls.Add(lblpassword);
            Controls.Add(lblusername);
            Controls.Add(btnlogin);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(btnHide);
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
        private Button btnShow;
        private Button btnHide;
    }
}
