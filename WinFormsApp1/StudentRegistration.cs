using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace WinFormsApp1
{
    public partial class StudentRegistration : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;
        public StudentRegistration()
        {
            InitializeComponent();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, YearLevel, Course, Units, Classified) " +
                               "VALUES (@Name, @YearLevel, @Course, @Units, @Classified)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Units", txtUnits.Text);
                cmd.Parameters.AddWithValue("@Classified", txtClassified.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student registered successfully!");

                // Optional: Clear fields
                txtName.Clear();
                txtYearLevel.Clear();
                txtCourse.Clear();
                txtUnits.Clear();
                txtClassified.Clear();
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentID, Name, YearLevel, Course, Units, Classified, DateRegistered FROM Students";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStudentRegistration.DataSource = dt;

                // Hide StudentID after binding data
                if (dgvStudentRegistration.Columns.Contains("StudentID"))
                {
                    dgvStudentRegistration.Columns["StudentID"].Visible = false;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudentRegistration.Rows[e.RowIndex];

                txtStudentId.Text = row.Cells["StudentID"].Value.ToString();

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtYearLevel.Text = row.Cells["YearLevel"].Value.ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                txtUnits.Text = row.Cells["Units"].Value.ToString();
                txtClassified.Text = row.Cells["Classified"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("Please select the specific information to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Students SET
                        Name = @Name,
                        YearLevel = @YearLevel,
                        Course = @Course,
                        Units = @Units,
                        Classified = @Classified
                        WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@StudentID", txtStudentId.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@YearLevel", txtYearLevel.Text);
                cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Units", txtUnits.Text);
                cmd.Parameters.AddWithValue("@Classified", txtClassified.Text);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Student updated successfully!");
                else
                    MessageBox.Show("Update failed. Please try again.");
            }

            btnShow_Click(sender, e); // Refresh grid data 
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

                btnShow_Click(sender, e); // refresh table
            }
        }
    }
}
