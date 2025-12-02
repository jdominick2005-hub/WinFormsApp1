using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucStudents : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;
        public ucStudents()

        {
            InitializeComponent();
        }

        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void cmbyearlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void FilterStudents()
        {
            string section = cmbSections.SelectedItem?.ToString();
            string yearLevel = cmbYearLevel.SelectedItem?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT StudentID, FirstName, LastName, YearLevel, Course, Section, Units, Classification, DateRegistered
                         FROM Students
                         WHERE (@section IS NULL OR Section = @section)
                           AND (@yearLevel IS NULL OR YearLevel = @yearLevel)";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@section", (object)section ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@yearLevel", (object)yearLevel ?? DBNull.Value);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;

                if (dgvStudents.Columns.Contains("StudentID"))
                    dgvStudents.Columns["StudentID"].Visible = false;
            }
        }


        private void btnadd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Text) || string.IsNullOrWhiteSpace(Text))
            {
                MessageBox.Show("Please enter First Name and Last Name.");
                return;
            }

            if (cmbYearLevel.SelectedItem == null || cmbSections.SelectedItem == null)
            {
                MessageBox.Show("Please select Year Level and Section.");
                return;
            }

            int units;
            if (!int.TryParse(Text, out units))
            {
                MessageBox.Show("Please enter a valid number for Units.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                string query = @"INSERT INTO Students 
                         (FirstName, LastName, YearLevel, Course, Section, Units, Classification, DateEnlist)
                         VALUES (@FirstName, @LastName, @YearLevel, @Course, @Section, @Units, @Classification, @DateEnlist)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", Text.Trim());
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Course", Text.Trim());
                cmd.Parameters.AddWithValue("@Section", cmbSections.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Units", units);
                cmd.Parameters.AddWithValue("@Classification", Text.Trim());
                cmd.Parameters.AddWithValue("@DateEnlist", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Student added successfully.");


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this student?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student deleted successfully.");

            }

        }


        private void dgvstudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudents.Rows[e.RowIndex].IsNewRow) return;

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

            int studentID;
            bool isNew = !int.TryParse(Convert.ToString(row.Cells["StudentID"].Value), out studentID);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (isNew)
                {
                    string insertQuery = @"INSERT INTO Students (FirstName, LastName, YearLevel, Course, Section, Units, Classification, DateEnlist)
                                   VALUES (@FirstName, @LastName, @YearLevel, @Course, @Section, @Units, @Classification, @DateEnlist)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(row.Cells["FirstName"].Value));
                    cmd.Parameters.AddWithValue("@LastName", Convert.ToString(row.Cells["LastName"].Value));
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToString(row.Cells["YearLevel"].Value));
                    cmd.Parameters.AddWithValue("@Course", Convert.ToString(row.Cells["Course"].Value));
                    cmd.Parameters.AddWithValue("@Section", Convert.ToString(row.Cells["Section"].Value));
                    cmd.Parameters.AddWithValue("@Units", Convert.ToInt32(row.Cells["Units"].Value));
                    cmd.Parameters.AddWithValue("@Classification", Convert.ToString(row.Cells["Classification"].Value));
                    cmd.Parameters.AddWithValue("@DateEnlist", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string updateQuery = @"UPDATE Students SET FirstName=@FirstName, LastName=@LastName, YearLevel=@YearLevel,
                                   Course=@Course, Section=@Section, Units=@Units, Classification=@Classification
                                   WHERE StudentID=@StudentID";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(row.Cells["FirstName"].Value));
                    cmd.Parameters.AddWithValue("@LastName", Convert.ToString(row.Cells["LastName"].Value));
                    cmd.Parameters.AddWithValue("@YearLevel", Convert.ToString(row.Cells["YearLevel"].Value));
                    cmd.Parameters.AddWithValue("@Course", Convert.ToString(row.Cells["Course"].Value));
                    cmd.Parameters.AddWithValue("@Section", Convert.ToString(row.Cells["Section"].Value));
                    cmd.Parameters.AddWithValue("@Units", Convert.ToInt32(row.Cells["Units"].Value));
                    cmd.Parameters.AddWithValue("@Classification", Convert.ToString(row.Cells["Classification"].Value));
                    cmd.ExecuteNonQuery();

                    if (dgvStudents.Columns.Contains("StudentID"))
                    {
                        dgvStudents.Columns["StudentID"].Visible = false;
                    }
                    dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvStudents.ReadOnly = true;
                    dgvStudents.AllowUserToAddRows = false;
                }
            }

        }

        private void ucStudents_Load(object sender, EventArgs e)
        {

        }

        private void lblYearLevel_Click(object sender, EventArgs e)
        {

        }
    }
}
