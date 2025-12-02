using System;
using System.Windows.Forms;
using WinFormsApp1.UserControls;

namespace WinFormsApp1
{
    public partial class TeacherPanelForm : Form
    {
        private readonly string teacherName;
        private readonly int teacherID;

        public TeacherPanelForm(string name, int id)
        {
            InitializeComponent();

            teacherName = name;
            teacherID = id;

            lblUserName.Text = teacherName;

            // Debug check – confirm TeacherID passed correctly
            MessageBox.Show($"TeacherPanelForm started with TeacherID={teacherID}, Name={teacherName}");

            // Automatically load the Subject user control on form load
            LoadControl(new ucSubject(teacherName, teacherID));
        }

        // Generic method to load UserControls into the main panel
        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        // Button click handlers to load different user controls
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadControl(new ucHome());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            LoadControl(new ucAttendance(teacherID));
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            this.Hide();

            var loginForm = new LoginForm();
            loginForm.Show();

            // Close this form when login form closes
            loginForm.FormClosed += (s, args) => this.Close();
        }
    }
}

