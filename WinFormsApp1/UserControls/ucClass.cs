using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucClass : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public int CurrentTeacherID { get; set; } = 1;

        public ucClass()
        {
            InitializeComponent();

            LoadSections();
            LoadYearLevels();
            LoadPrograms();
        }

        // ============================================
        //        LOAD SECTIONS (A, B, C, D ONLY)
        // ============================================
        private void LoadSections()
        {
            string query = @"SELECT DISTINCT RIGHT(Section, 1) AS Sec
                             FROM Subjects 
                             WHERE TeacherID = @TID
                             ORDER BY Sec";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", CurrentTeacherID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbSections.Items.Clear();

                while (dr.Read())
                    cmbSections.Items.Add(dr["Sec"].ToString());
            }
        }

        // ============================================
        //              LOAD YEAR LEVELS
        // ============================================
        private void LoadYearLevels()
        {
            string query = @"SELECT DISTINCT YearLevel 
                             FROM Subjects 
                             WHERE TeacherID = @TID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", CurrentTeacherID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbYearLevel.Items.Clear();

                while (dr.Read())
                    cmbYearLevel.Items.Add(dr["YearLevel"].ToString());
            }
        }

        // ============================================
        //              LOAD SUBJECTS
        // ============================================
        private void LoadSubjects()
        {
            string query = @"SELECT SubjectName
                             FROM Subjects
                             WHERE TeacherID = @TID
                             AND RIGHT(Section, 1) = @Section
                             AND YearLevel = @YearLevel";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", CurrentTeacherID);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbsubjects.Items.Clear();

                while (dr.Read())
                    cmbsubjects.Items.Add(dr["SubjectName"].ToString());
            }
        }

        // ============================================
        //               LOAD PROGRAMS
        // ============================================
        private void LoadPrograms()
        {
            string query = @"SELECT DISTINCT Course 
                             FROM Students 
                             ORDER BY Course";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbprogram.Items.Clear();

                while (dr.Read())
                    cmbprogram.Items.Add(dr["Course"].ToString());
            }
        }

        // ============================================
        //               SHOW SCHEDULE
        // ============================================
        private void ShowSchedule()
        {
            string query = @"SELECT Schedule
                             FROM Subjects
                             WHERE SubjectName = @Subject
                             AND TeacherID = @TID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Subject", cmbsubjects.Text);
                cmd.Parameters.AddWithValue("@TID", CurrentTeacherID);

                con.Open();
                object sched = cmd.ExecuteScalar();

                txtSchedule.Text = sched != null ? sched.ToString() : "No schedule found";
            }
        }

        // ============================================
        //             SHOW TOTAL STUDENT COUNT
        // ============================================
        private void ShowTotalStudents()
        {
            string query = @"SELECT COUNT(*) 
                             FROM Students
                             WHERE RIGHT(Section, 1) = @Section
                             AND YearLevel = @YearLevel
                             AND Course = @Program";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                cmd.Parameters.AddWithValue("@Program", cmbprogram.Text);

                con.Open();
                int total = (int)cmd.ExecuteScalar();
                txtTotal.Text = total.ToString();
            }
        }

        // ============================================
        //        LOAD STUDENTS (Grid)
        // ============================================
        private void LoadStudentsToGrid()
        {
            string query = @"SELECT 
                                FirstName AS [First Name],
                                LastName AS [Last Name],
                                Classification 
                             FROM Students
                             WHERE RIGHT(Section, 1) = @Section
                             AND YearLevel = @YearLevel
                             AND Course = @Program";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@Section", cmbSections.Text);
                da.SelectCommand.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                da.SelectCommand.Parameters.AddWithValue("@Program", cmbprogram.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClass.DataSource = dt;
            }
        }

        // ============================================
        //                EVENTS
        // ============================================
        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
        }

        private void cmbsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSchedule();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
        }

        private void cmbprogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentsToGrid();
            ShowTotalStudents();
        }
    }
}
