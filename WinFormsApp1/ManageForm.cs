using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class ManageForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;


        public ManageForm()
        {
            InitializeComponent();
        }

        // 🔍 Helper method to get TeacherID from professor name
        private int? GetTeacherIdByName(string professorName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.TeacherID
                         FROM Teachers t
                         INNER JOIN Logins l ON t.UserID = l.UserID
                         WHERE l.Name = @Name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", professorName);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                return result != null ? Convert.ToInt32(result) : (int?)null;
            }

        }
        private int GetNextSubjectId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(SubjectID), 0) + 1 FROM Subjects";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int nextId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return nextId;
            }
        }


        // Add subject
        private void btnAdd_Click(object sender, EventArgs e)
        {

            int? teacherId = GetTeacherIdByName(txtProffesors.Text);
            if (teacherId == null)
            {
                MessageBox.Show("Professor not found. Please check the name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Subjects (SubjectName, Section, Schedule, TeacherID) " +
                               "VALUES (@SubjectName, @Section, @Schedule, @TeacherID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                cmd.Parameters.AddWithValue("@Schedule", txtSchedule.Text);
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Subject added successfully.");
                LoadSubjects(); // optional: refresh your grid
            }


        }

        // Update subject
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProffesors.SelectedRows.Count > 0)
            {

                int? teacherId = GetTeacherIdByName(txtProffesors.Text);
                if (teacherId == null) ;
                {
                    MessageBox.Show("Professor not found.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Subjects SET SubjectName=@SubjectName, Section=@Section, Schedule=@Schedule, TeacherID=@TeacherID WHERE SubjectID=@SubjectID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                    cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                    cmd.Parameters.AddWithValue("@Schedule", txtSchedule.Text);
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Subject updated successfully.");
                    LoadSubjects();
                }
            }
        }

        // Delete subject
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvProffesors.SelectedRows.Count > 0)
            {
                int subjectId = Convert.ToInt32(dgvProffesors.SelectedRows[0].Cells["SubjectID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Subjects WHERE SubjectID=@SubjectID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Subject deleted successfully.");
                    LoadSubjects();
                }
            }
        }

        // Load subjects into DataGridView
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.SubjectID, s.SubjectName, s.Section, s.Schedule,
                             l.Name AS ProfessorName
                             FROM Subjects s
                             LEFT JOIN Teachers t ON s.TeacherID = t.TeacherID
                             LEFT JOIN Logins l ON t.UserID = l.UserID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProffesors.DataSource = dt;
            }
        }

        // Populate textboxes when selecting a row
        private void dgvProffesors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProffesors.Rows[e.RowIndex];
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
                txtSection.Text = row.Cells["Section"].Value.ToString();
                txtSchedule.Text = row.Cells["Schedule"].Value.ToString();

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {

        }
    }
}