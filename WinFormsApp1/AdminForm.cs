namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        private string loggedInName;

        public AdminForm(string name)
        {
            InitializeComponent();
            loggedInName = name;
        }

        // This empty constructor is NOT needed anymore,
        // but if you want to keep it, make sure it also initializes the UI.
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(loggedInName))
            {
                lblUserName.Text = loggedInName.ToUpper();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm ProfessorsForm = new ProfessorsForm();
            ProfessorsForm.Show();
            this.Hide();
        }

        private void lblManage_Click(object sender, EventArgs e)
        {
            ManageForm ManageForm = new ManageForm();
            ManageForm.Show();
            this.Hide();
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            UsersForm UsersForm = new UsersForm();
            UsersForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Hide();

                LoginForm login = new LoginForm();
                login.Show();

                login.FormClosed += (s, args) => this.Close();
            }

        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm ManageForm = new ManageForm();
            ManageForm.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm ProfessorsForm = new ProfessorsForm();
            ProfessorsForm.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm UsersForm = new UsersForm();
            UsersForm.Show();
            this.Hide();
        }

    }
}
