namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        private string loggedInName;
        public AdminForm(String name)
        {
            InitializeComponent();
            loggedInName = name;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = loggedInName.ToUpper();
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
            // Hide the current panel/form
            this.Hide();

            // Show the login form again
            LoginForm login = new LoginForm();
            login.Show();

            // Optional: If you want to fully close this form when Login closes:
            login.FormClosed += (s, args) => Close();
        }
    }
}
