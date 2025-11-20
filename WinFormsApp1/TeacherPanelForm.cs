using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TeacherPanelForm : Form
    {
        private string teacherName;
        private int teacherID;
        private Attendance attendanceForm; // Single instance

        public TeacherPanelForm(string name, int id)
        {
            InitializeComponent();
            teacherName = name;
            teacherID = id;

         
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            this.Hide(); // hide TeacherPanelForm

            // Only create Attendance form if it doesn't exist or was disposed
            if (attendanceForm == null || attendanceForm.IsDisposed)
            {
                attendanceForm = new Attendance(this, teacherName, teacherID);
            }

            attendanceForm.Show();
            // Make Attendance form appear in the same place as TeacherPanelForm
            attendanceForm.StartPosition = FormStartPosition.Manual; // required to set Location manually
            attendanceForm.Location = this.Location;                // same top-left corner
            attendanceForm.Size = this.Size;                        // same size
            attendanceForm.Show();
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
    }
}
