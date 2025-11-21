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
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

        public StudentRegistration()
        {
            InitializeComponent();
            this.Load += StudentRegistration_Load;
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentID, Name, YearLevel, Course, Units, Classified, Section, DateRegistered FROM Students";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStudentRegistration.AutoGenerateColumns = true;
                dgvStudentRegistration.DataSource = dt;

                if (dgvStudentRegistration.Columns.Contains("DateRegistered"))
                    dgvStudentRegistration.Columns["DateRegistered"].Visible = false;
            }
        }

        // Cell click just selects row, does not enable editing
        private void dgvStudentRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudentRegistration.Rows[e.RowIndex];

                txtStudentId.Text = row.Cells["StudentID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtYearLevel.Text = row.Cells["YearLevel"].Value?.ToString() ?? "";
                txtCourse.Text = row.Cells["Course"].Value?.ToString() ?? "";
                txtUnits.Text = row.Cells["Units"].Value?.ToString() ?? "";
                txtClassified.Text = row.Cells["Classified"].Value?.ToString() ?? "";
                txtSection.Text = row.Cells["Section"].Value?.ToString() ?? "";

                // Disable textboxes until Edit button is clicked
                txtName.Enabled = false;
                txtYearLevel.Enabled = false;
                txtCourse.Enabled = false;
                txtUnits.Enabled = false;
                txtClassified.Enabled = false;
                txtSection.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please select a studentID first before editing. ");
                return;
            }

            // Enable only the textboxes for editing
            txtName.Enabled = true;
            txtYearLevel.Enabled = true;
            txtCourse.Enabled = true;
            txtUnits.Enabled = true;
            txtClassified.Enabled = true;
            txtSection.Enabled = true;

            MessageBox.Show("You can now edit the fields. Click UPDATE to save changes.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please select a student record to update.");
                return;
            }

            int studentId = Convert.ToInt32(txtStudentId.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                List<string> updates = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    updates.Add("Name=@Name");
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtYearLevel.Text))
                {
                    updates.Add("YearLevel=@YearLevel");
                    cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtCourse.Text))
                {
                    updates.Add("Course=@Course");
                    cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtUnits.Text))
                {
                    updates.Add("Units=@Units");
                    cmd.Parameters.AddWithValue("@Units", txtUnits.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtClassified.Text))
                {
                    updates.Add("Classified=@Classified");
                    cmd.Parameters.AddWithValue("@Classified", txtClassified.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtSection.Text))
                {
                    updates.Add("Section=@Section");
                    cmd.Parameters.AddWithValue("@Section", txtSection.Text);
                }

                if (updates.Count > 0)
                {
                    string updateQuery = $"UPDATE Students SET {string.Join(", ", updates)} WHERE StudentID=@StudentID";
                    cmd.CommandText = updateQuery;
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student updated successfully!");
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("No changes detected to update.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudentRegistration.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            int id = Convert.ToInt32(dgvStudentRegistration.SelectedRows[0].Cells["StudentID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student deleted successfully!");
                LoadStudents();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
    }
}
