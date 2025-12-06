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
        private SqlConnection con;
        private int loggedInTeacherID = 1; 
        private int currentTeacherId;

        public ucClass()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
            currentTeacherId = loggedInTeacherID;

            LoadSections(currentTeacherId);
            LoadYearLevels(currentTeacherId);
        }
        private void LoadSections(int teacherId)
        {
            string query = @"SELECT DISTINCT Section
                     FROM Subjects
                     WHERE TeacherID = @TeacherID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbSections.DataSource = dt;
                    cmbSections.DisplayMember = "Section";
                    cmbSections.ValueMember = "Section";
                }
            }
        }




        private void LoadYearLevels(int teacherId)
        {
            string query = @"SELECT DISTINCT YearLevel
                     FROM Subjects
                     WHERE TeacherID = @TeacherID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbYearLevel.DataSource = dt;
                    cmbYearLevel.DisplayMember = "YearLevel";
                    cmbYearLevel.ValueMember = "YearLevel";
                }
            }
        }


        private void LoadSubjects(int teacherId, string section, string yearLevel)
        {
            string query = @"SELECT SubjectID, SubjectName
                     FROM Subjects
                     WHERE TeacherID = @TeacherID
                       AND Section = @Section
                       AND YearLevel = @YearLevel";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                cmd.Parameters.AddWithValue("@Section", section);
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbsubjects.DataSource = dt;
                cmbsubjects.DisplayMember = "SubjectName";
                cmbsubjects.ValueMember = "SubjectID";
            }
        }


        private void LoadStudents(int subjectId)
        {
            string query = @"SELECT s.StudentID, s.FirstName + ' ' + s.LastName AS StudentName
                     FROM Enrollments e
                     JOIN Students s ON e.StudentID = s.StudentID
                     WHERE e.SubjectID = @SubjectID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClass.DataSource = dt;
            }
        }


        private void LoadStudentsByYearLevel(string yearLevel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT FirstName, LastName, Classification 
                                 FROM Students 
                                 WHERE YearLevel = @YearLevel";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvClass.DataSource = dt;
                    txtTotal.Text = dt.Rows.Count.ToString();
                }
            }
        }

        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSections.SelectedValue != null && cmbYearLevel.SelectedValue != null)
            {
                LoadSubjects(currentTeacherId,
                             cmbSections.SelectedValue.ToString(),
                             cmbYearLevel.SelectedValue.ToString());
            }
        }


        private void cmbsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsubjects.SelectedValue != null)
            {
                LoadStudents(Convert.ToInt32(cmbsubjects.SelectedValue));
            }
        }


        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYearLevel.SelectedValue != null)
            {
                LoadStudentsByYearLevel(cmbYearLevel.SelectedValue.ToString());
            }
        }

    }
}
