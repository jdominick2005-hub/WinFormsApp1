using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class StudentRegistration : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public StudentRegistration()
        {
            InitializeComponent();
            this.Load += StudentRegistration_Load;
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadSubjects();
        }
        private void LoadSubjects()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT SubjectID, SubjectName + ' (' + Section + ')' AS FullName FROM Subjects", conn))
            {
                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cmbEnrollSubject.DataSource = dt;
                cmbEnrollSubject.DisplayMember = "FullName";
                cmbEnrollSubject.ValueMember = "SubjectID";
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        StudentID,
                        FirstName,
                        LastName,
                        YearLevel,
                        Course,
                        Section,
                        Units,
                        Classification,
                        DateRegistered
                    FROM Students";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStudentRegistration.AutoGenerateColumns = true;
                dgvStudentRegistration.DataSource = dt;

                if (dgvStudentRegistration.Columns.Contains("DateRegistered"))
                    dgvStudentRegistration.Columns["DateRegistered"].Visible = false;
            }
        }

        private void dgvStudentRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudentRegistration.Rows[e.RowIndex];

                txtStudentID.Text = row.Cells["StudentID"].Value?.ToString() ?? "";
                txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
                txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";
                txtYearLevel.Text = row.Cells["YearLevel"].Value?.ToString() ?? "";
                txtCourse.Text = row.Cells["Course"].Value?.ToString() ?? "";
                txtUnits.Text = row.Cells["Units"].Value?.ToString() ?? "";
                txtClassification.Text = row.Cells["Classification"].Value?.ToString() ?? "";
                txtSection.Text = row.Cells["Section"].Value?.ToString() ?? "";

            }
        }

        private void ToggleTextboxes(bool enabled)
        {
            txtFirstName.Enabled = enabled;
            txtLastName.Enabled = enabled;
            txtYearLevel.Enabled = enabled;
            txtCourse.Enabled = enabled;
            txtUnits.Enabled = enabled;
            txtClassification.Enabled = enabled;
            txtSection.Enabled = enabled;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Please select a student first.");
                return;
            }

            ToggleTextboxes(true);
            MessageBox.Show("Fields enabled — click UPDATE to save.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("No student selected.");
                return;
            }

            int studentId;
            if (!int.TryParse(txtStudentID.Text, out studentId))
            {
                MessageBox.Show("Invalid Student ID.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = @"
            UPDATE Students SET
                FirstName = @FirstName,
                LastName = @LastName,
                YearLevel = @YearLevel,
                Course = @Course,
                Section = @Section,
                Units = @Units,
                Classification = @Classification
            WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);

                int units;
                int.TryParse(txtUnits.Text, out units);
                cmd.Parameters.AddWithValue("@Units", units);

                cmd.Parameters.AddWithValue("@Classification", txtClassification.Text);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Student updated successfully!");
                else
                    MessageBox.Show("Update failed. Student not found.");
            }

            LoadStudents();
            ToggleTextboxes(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudentRegistration.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student to delete.");
                return;
            }

            int id = Convert.ToInt32(dgvStudentRegistration.SelectedRows[0].Cells["StudentID"].Value);

            if (MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student deleted.");
                LoadStudents();
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("First Name and Last Name are required.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO Students (FirstName, LastName, YearLevel, Course, Section, Units, Classification)
            VALUES (@FirstName, @LastName, @YearLevel, @Course, @Section, @Units, @Classification)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Section", txtSection.Text);

                // convert Units safely
                int units = 0;
                int.TryParse(txtUnits.Text, out units);
                cmd.Parameters.AddWithValue("@Units", units);

                cmd.Parameters.AddWithValue("@Classification", txtClassification.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student registered successfully!");

            LoadStudents();
            ClearFields();
        }
        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtYearLevel.Text = "";
            txtCourse.Text = "";
            txtUnits.Text = "";
            txtClassification.Text = "";
            txtSection.Text = "";
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Select or Register a student first.");
                return;
            }

            int studentID = int.Parse(txtStudentID.Text);
            int subjectID = (int)cmbEnrollSubject.SelectedValue;

            if (IsStudentAlreadyEnrolled(studentID, subjectID))
            {
                MessageBox.Show("Student is already enrolled in this subject.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        INSERT INTO Enrollments (StudentID, SubjectID)
        VALUES (@StudentID, @SubjectID)", conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student successfully enrolled in the subject.");
        }
        private bool IsStudentAlreadyEnrolled(int studentID, int subjectID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT COUNT(*)
        FROM Enrollments
        WHERE StudentID = @StudentID AND SubjectID = @SubjectID", conn))
            {
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void gbStudentRegistration_Enter(object sender, EventArgs e)
        {

        }

        private void lblEnroll_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm home = new AdminForm();
            home.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm manage = new ManageForm();
            manage.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm users = new UsersForm();
            users.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm prof = new ProfessorsForm();
            prof.Show();
            this.Hide();
        }
    }
}
