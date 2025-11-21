using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            int? teacherId = GetTeacherIdByName(txtProfessor.Text);
            if (teacherId == null)
            {
                MessageBox.Show("Professor not found. Please check the name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Subjects (SubjectName, Section, Schedule, YearLevel, TeacherID) 
                                 VALUES (@SubjectName, @Section, @Schedule, @YearLevel, @TeacherID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                cmd.Parameters.AddWithValue("@Schedule", txtSchedule.Text);
                cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Added successfully.");
                LoadSubjects();
            }
        }

        // Update subject
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProffesors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select you want to update.");
                return;
            }

            int subjectId = Convert.ToInt32(dgvProffesors.SelectedRows[0].Cells["SubjectID"].Value);

            // Get TeacherID by professor name
            int? teacherId = GetTeacherIdByName(txtProfessor.Text);
            if (teacherId == null)
            {
                MessageBox.Show("Professor not found.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                List<string> updates = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Add only fields that are edited
                if (!string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    updates.Add("SubjectName=@SubjectName");
                    cmd.Parameters.AddWithValue("@SubjectName", txtSubjectName.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtSection.Text))
                {
                    updates.Add("Section=@Section");
                    cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtSchedule.Text))
                {
                    updates.Add("Schedule=@Schedule");
                    cmd.Parameters.AddWithValue("@Schedule", txtSchedule.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtYearLevel.Text))
                {
                    updates.Add("YearLevel=@YearLevel");
                    cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                }

                // Always update TeacherID if professor changed
                updates.Add("TeacherID=@TeacherID");
                cmd.Parameters.AddWithValue("@TeacherID", teacherId);

                if (updates.Count > 0)
                {
                    string updateQuery = $"UPDATE Subjects SET {string.Join(", ", updates)} WHERE SubjectID=@SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Updated successfully!");
                    LoadSubjects();
                }
                else
                {
                    MessageBox.Show("No changes detected to update.");
                }
            }
        }

        // Delete subject
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvProffesors.SelectedRows.Count > 0)
            {
                int subjectId = Convert.ToInt32(dgvProffesors.SelectedRows[0].Cells["SubjectID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this subject?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Subjects WHERE SubjectID=@SubjectID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Deleted successfully.");
                    LoadSubjects();
                }
            }
            else
            {
                MessageBox.Show("Please select first before proceeding to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Load subjects into DataGridView
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT s.SubjectID, s.SubjectName, s.Section, s.Schedule, s.YearLevel,
                                 l.Name AS ProfessorName
                                 FROM Subjects s
                                 LEFT JOIN Teachers t ON s.TeacherID = t.TeacherID
                                 LEFT JOIN Logins l ON t.UserID = l.UserID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProffesors.DataSource = dt;

                if (dgvProffesors.Columns.Contains("SubjectID"))
                    dgvProffesors.Columns["SubjectID"].Visible = false;

                dgvProffesors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProffesors.ReadOnly = true;
                dgvProffesors.AllowUserToAddRows = false;
                dgvProffesors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProffesors.MultiSelect = false;
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
                txtYearLevel.Text = row.Cells["YearLevel"].Value.ToString(); // NEW
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm AdminForm = new AdminForm();
            AdminForm.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm Users = new UsersForm();
            Users.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm profForm = new ProfessorsForm();
            profForm.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm manage = new ManageForm();
            manage.Show();
            this.Hide();
        }

        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration StudentRegister = new StudentRegistration();
            StudentRegister.Show();
            this.Hide();
        }
    }
}
