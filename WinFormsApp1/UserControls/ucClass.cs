using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucClass : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;
        private int loggedInTeacherID = 1; // TEMP: Replace with actual value from login

        public ucClass()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Load Sections
                SqlDataAdapter daSection = new SqlDataAdapter("SELECT DISTINCT Section FROM Subjects WHERE TeacherID = @TeacherID", con);
                daSection.SelectCommand.Parameters.AddWithValue("@TeacherID", loggedInTeacherID);
                DataTable dtSection = new DataTable();
                daSection.Fill(dtSection);
                cmbSections.DataSource = dtSection;
                cmbSections.DisplayMember = "Section";

                // Load Year Levels
                SqlDataAdapter daYear = new SqlDataAdapter("SELECT DISTINCT YearLevel FROM Subjects WHERE TeacherID = @TeacherID", con);
                daYear.SelectCommand.Parameters.AddWithValue("@TeacherID", loggedInTeacherID);
                DataTable dtYear = new DataTable();
                daYear.Fill(dtYear);
                cmbYearLevel.DataSource = dtYear;
                cmbYearLevel.DisplayMember = "YearLevel";
            }
        }

        private void cmbsections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSections.Text) && !string.IsNullOrEmpty(cmbYearLevel.Text))
            {
                LoadSchedule();
                LoadTotalStudents();
                LoadStudents();
            }
        }

        private void cmbYearlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSections.Text) && !string.IsNullOrEmpty(cmbYearLevel.Text))
            {
                LoadSchedule();
                LoadTotalStudents();
                LoadStudents();
            }
        }

        private void LoadSchedule()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Schedule FROM Subjects WHERE Section = @Section AND YearLevel = @YearLevel AND TeacherID = @TeacherID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                cmd.Parameters.AddWithValue("@TeacherID", loggedInTeacherID);

                con.Open();
                object result = cmd.ExecuteScalar();
                txtSchedule.Text = result != null ? result.ToString() : "No schedule found";
            }
        }

        private void LoadTotalStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Students WHERE Section = @Section AND YearLevel = @YearLevel";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@YearLevel",   cmbYearLevel.Text);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                txtTotal.Text = count.ToString();
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT StudentID, FirstName + ' ' + LastName AS FullName,
                                Course, Section, YearLevel, Classification, DateRegistered
                                FROM Students
                                WHERE Section = @Section AND YearLevel = @YearLevel";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClass.DataSource = dt;
                dgvClass.Columns["StudentID"].Visible = false;
                dgvClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

    }
}