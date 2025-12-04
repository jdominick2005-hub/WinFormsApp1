using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ManageForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public ManageForm()
        {
            InitializeComponent();
        }

        private void ManageFormLoad(object sender, EventArgs e)
        {
            LoadProfessors();
            LoadSubjects();
        }

        //  LOAD PROFESSORS INTO COMBOBOX
        private void LoadProfessors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"
                SELECT 
                    T.TeacherID,
                    CONCAT(L.FirstName, ' ', L.LastName) AS FullName
                FROM Teachers T
                JOIN Logins L ON T.UserID = L.UserID";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbProfessor.DataSource = dt;
                    cmbProfessor.DisplayMember = "FullName";
                    cmbProfessor.ValueMember = "TeacherID";
                    cmbProfessor.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load professors: {ex.Message}");
            }
        }


        //  LOAD SUBJECTS GRID

        private void LoadSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"
SELECT 
    S.SubjectID,
    S.SubjectName,
    S.Schedule,
    S.YearLevel,
    S.Section,
    CONCAT(L.FirstName, ' ', L.LastName) AS Professor
FROM Subjects S
LEFT JOIN Teachers T ON S.TeacherID = T.TeacherID
LEFT JOIN Logins L ON T.UserID = L.UserID";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvProfessors.DataSource = dt;
                    dgvProfessors.Columns["SubjectID"].Visible = false;

                    dgvProfessors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvProfessors.ReadOnly = true;
                    dgvProfessors.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}");
            }
        }

        //  ADD SUBJECT
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a professor.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
INSERT INTO Subjects (SubjectName, Schedule, YearLevel, Section, TeacherID)
VALUES (@name, @sched, @year, @section, @teacher)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtSubjectName.Text.Trim());
                cmd.Parameters.AddWithValue("@sched", txtSchedule.Text.Trim());
                cmd.Parameters.AddWithValue("@year", txtYearLevel.Text.Trim());
                cmd.Parameters.AddWithValue("@section", txtSection.Text.Trim());
                cmd.Parameters.AddWithValue("@teacher", cmbProfessor.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Subject added successfully.");
                LoadSubjects();
                ClearFields();
            }
        }


        //  DELETE SUBJECT
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProfessors.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a subject to delete.");
                return;
            }

            int subjectId = Convert.ToInt32(dgvProfessors.SelectedRows[0].Cells["SubjectID"].Value);

            DialogResult confirm = MessageBox.Show(
                "Are you sure?",
                "Delete Subject",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Subjects WHERE SubjectID=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", subjectId);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Subject deleted.");
                LoadSubjects();
                ClearFields();
            }
        }


        //  WHEN USER CLICKS A ROW
        private void dgvProfessors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtSubjectName.Text = dgvProfessors.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString();
            txtSchedule.Text = dgvProfessors.Rows[e.RowIndex].Cells["Schedule"].Value.ToString();
            txtYearLevel.Text = dgvProfessors.Rows[e.RowIndex].Cells["YearLevel"].Value.ToString();
            txtSection.Text = dgvProfessors.Rows[e.RowIndex].Cells["Section"].Value.ToString();

            cmbProfessor.Text = dgvProfessors.Rows[e.RowIndex].Cells["Professor"].Value.ToString();
        }


        //  CLEAR FIELDS

        private void ClearFields()
        {
            txtSubjectName.Clear();
            txtSchedule.Clear();
            txtYearLevel.Clear();
            txtSection.Clear();
            cmbProfessor.SelectedIndex = -1;
        }


        //  SIDE NAVIGATION BUTTONS (UNCHANGED)
        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm home = new AdminForm();
            home.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm form = new ProfessorsForm();
            form.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm form = new ManageForm();
            form.Show();
            this.Hide();
        }

        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration form = new StudentRegistration();
            form.Show();
            this.Hide();
        }
    }
}
