using System;
using System.Windows.Forms;
using WinFormsApp1.UserControls;

namespace WinFormsApp1
{
    public partial class TeacherPanelForm : Form
    {
        private string teacherName;
        private int teacherID;


        public TeacherPanelForm(string name, int id)
        {
            InitializeComponent();
            teacherName = name;
            teacherID = id;
            lblUserName.Text = teacherName;

            LoadControl(new UserControls.ucHome());


        }
        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            LoadControl(new ucAttendance(teacherID));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // If user selects No, stop the logout process
            if (result == DialogResult.No)
                return;

            // Hide TeacherPanelForm
            this.Hide();

            // Show login form
            LoginForm login = new LoginForm();
            login.Show();

            // Close TeacherPanelForm when login closes (optional)
            login.FormClosed += (s, args) => this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new ucHome());
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            LoadControl(new ucClass());
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            LoadControl(new ucSubject(teacherName, teacherID));
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadControl(new ucStudents());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadControl(new ucReports());
        }
    }
}
