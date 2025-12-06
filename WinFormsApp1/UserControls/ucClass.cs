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
            string query = @"SELECT DISTINCT s.SectionID, s.SectionName
                     FROM Subjects subj
                     JOIN Sections s ON subj.SectionID = s.SectionID
                     WHERE subj.TeacherID = @TeacherID";

            try
            {
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
                        cmbSections.DisplayMember = "SectionName";
                        cmbSections.ValueMember = "SectionID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sections: " + ex.Message);
            }
        }



        private void LoadYearLevels(int teacherId)
        {
            string query = @"SELECT DISTINCT yl.YearLevelID, yl.YearLevelName
                             FROM Subjects subj
                             JOIN YearLevels yl ON subj.YearLevelID = yl.YearLevelID
                             WHERE subj.TeacherID = @TeacherID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbYearLevel.DataSource = dt;
                cmbYearLevel.DisplayMember = "YearLevelName";
                cmbYearLevel.ValueMember = "YearLevelID";
            }
        }

        private void LoadSubjects(int teacherId, int sectionId, int yearLevelId)
        {
            string query = @"SELECT subj.SubjectID, subj.SubjectName
                             FROM Subjects subj
                             WHERE subj.TeacherID = @TeacherID 
                               AND subj.SectionID = @SectionID 
                               AND subj.YearLevelID = @YearLevelID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                cmd.Parameters.AddWithValue("@SectionID", sectionId);
                cmd.Parameters.AddWithValue("@YearLevelID", yearLevelId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbsubjects.DataSource = dt;
                cmbsubjects.DisplayMember = "SubjectName";
                cmbsubjects.ValueMember = "SubjectID";
            }
        }

        private void LoadStudents(int subjectId, int sectionId)
        {
            string query = @"SELECT sr.StudentID, sr.StudentName
                             FROM StudentRegistered sr
                             WHERE sr.SubjectID = @SubjectID 
                               AND sr.SectionID = @SectionID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                cmd.Parameters.AddWithValue("@SectionID", sectionId);

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
                LoadSubjects(currentTeacherId, Convert.ToInt32(cmbSections.SelectedValue), Convert.ToInt32(cmbYearLevel.SelectedValue));
            }
        }

        private void cmbsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsubjects.SelectedValue != null && cmbSections.SelectedValue != null)
            {
                LoadStudents(Convert.ToInt32(cmbsubjects.SelectedValue), Convert.ToInt32(cmbSections.SelectedValue));
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
