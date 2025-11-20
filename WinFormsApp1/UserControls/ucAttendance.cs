using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ucAttendance : UserControl
    {
        private int teacherID;
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

        public ucAttendance(int teacherId)
        {
            InitializeComponent();
            teacherID = teacherId;

            LoadSubjects(); // load subjects on UC load
        }

        // =========================
        // Load subjects for teacher
        // =========================
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT SubjectID, SubjectName + ' (' + Section + ')' AS SubjectDisplay
                                 FROM Subjects
                                 WHERE TeacherID = @TeacherID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbSubjects.DisplayMember = "SubjectDisplay";
                cmbSubjects.ValueMember = "SubjectID";
                cmbSubjects.DataSource = dt;
            }
        }

        // =========================
        // Load students for selected subject
        // =========================
        private void LoadStudents(int subjectID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.StudentID, s.Name, ISNULL(a.Status, 'Not Recorded') AS Status
                                 FROM Students s
                                 INNER JOIN Enrollments e ON s.StudentID = e.StudentID
                                 LEFT JOIN Attendance a 
                                     ON s.StudentID = a.StudentID 
                                     AND a.SubjectID = @SubjectID
                                 WHERE e.SubjectID = @SubjectID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dvgStudents.DataSource = dt;
            }
        }

        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedValue != null)
            {
                int subjectID = Convert.ToInt32(cmbSubjects.SelectedValue);
                LoadStudents(subjectID);
            }
        }

        // =========================
        // Record attendance
        // =========================
        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }

            int subjectID = Convert.ToInt32(cmbSubjects.SelectedValue);

            foreach (DataGridViewRow row in dvgStudents.Rows)
            {
                int studentID = Convert.ToInt32(row.Cells["StudentID"].Value);
                string status = row.Cells["Status"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string checkQuery = @"SELECT COUNT(*) FROM Attendance 
                                          WHERE StudentID=@StudentID AND SubjectID=@SubjectID";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@StudentID", studentID);
                    checkCmd.Parameters.AddWithValue("@SubjectID", subjectID);

                    conn.Open();
                    int count = (int)checkCmd.ExecuteScalar();
                    conn.Close();

                    if (count == 0)
                    {
                        string insertQuery = @"INSERT INTO Attendance (StudentID, SubjectID, Status)
                                               VALUES (@StudentID, @SubjectID, @Status)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@StudentID", studentID);
                        insertCmd.Parameters.AddWithValue("@SubjectID", subjectID);
                        insertCmd.Parameters.AddWithValue("@Status", status);

                        conn.Open();
                        insertCmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            MessageBox.Show("Attendance recorded successfully!");
            LoadStudents(subjectID);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
