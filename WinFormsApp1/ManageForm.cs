using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;            
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ManageForm : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        private int selectedSubjectID = 0;

        public ManageForm()
        {
            InitializeComponent();
            this.Load += ManageFormLoad;

            // Table selection
            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.MultiSelect = false;

            dgvProfessors.CellClick += dgvProfessors_CellClick;

            // Buttons
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;

            // Navigation buttons
            btnHome.Click += btnHome_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnManage.Click += btnManage_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
        }

        private void ManageFormLoad(object sender, EventArgs e)
        {
            LoadProfessors();
            LoadSubjects();
        }

        //
        // SMALL HELPER TO AVOID DUPLICATE FORMS
        //
        private T GetOrCreateForm<T>() where T : Form, new()
        {
            // Look for an already open form of this type
            var existing = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existing == null || existing.IsDisposed)
            {
                existing = new T();
            }

            return existing;
        }

        //
        // NAVIGATION BUTTONS
        // 

        private void btnHome_Click(object sender, EventArgs e)
        {
            var home = GetOrCreateForm<AdminForm>();
            home.Show();
            home.BringToFront();
            this.Hide();   // or this.Close(); if you prefer
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            var f = GetOrCreateForm<ProfessorsForm>();
            f.Show();
            f.BringToFront();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            // You are already in Manage, so maybe just refresh
            LoadSubjects();
            // No need to open another ManageForm
        }

        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            var f = GetOrCreateForm<StudentRegistration>();
            f.Show();
            f.BringToFront();
            this.Hide();
        }

        //
        // DATA LOADING
        // 

        private void LoadProfessors()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                SELECT 
                    T.TeacherID,
                    CONCAT(L.FirstName, ' ', L.LastName, ' - ', T.Program) AS DisplayName
                FROM Teachers T
                JOIN Logins L ON T.UserID = L.UserID
                ORDER BY L.LastName";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProfessor.DataSource = dt;
                cmbProfessor.DisplayMember = "DisplayName";
                cmbProfessor.ValueMember = "TeacherID";

                cmbProfessor.SelectedIndex = -1;
            }
        }

        private void LoadSubjects()
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
                    T.Program,
                    CONCAT(L.FirstName, ' ', L.LastName) AS ProfessorName
                FROM Subjects S
                LEFT JOIN Teachers T ON S.TeacherID = T.TeacherID
                LEFT JOIN Logins L ON T.UserID = L.UserID
                ORDER BY S.SubjectName";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProfessors.DataSource = dt;

                dgvProfessors.Columns["SubjectID"].Visible = false;

                dgvProfessors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProfessors.ReadOnly = true;
                dgvProfessors.AllowUserToAddRows = false;
            }
        }

        //
        // SUBJECT SELECTION
        // 

        private void dgvProfessors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProfessors.Rows[e.RowIndex];
            selectedSubjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);
        }

        //
        // ADD SUBJECT
        //

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (SubjectExists(txtSubjectName.Text, cmbsection.Text))
            {
                MessageBox.Show("This subject already exists for this section.",
                                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmd.Parameters.AddWithValue("@year", cmbyearlevel.Text.Trim());
                cmd.Parameters.AddWithValue("@section", cmbsection.Text.Trim());
                cmd.Parameters.AddWithValue("@teacher", cmbProfessor.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Subject added successfully!");
            LoadSubjects();
            ClearInputs();
        }

        //
        // DELETE SUBJECT
        //

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectID == 0)
            {
                MessageBox.Show("Please select a subject to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this subject?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Subjects WHERE SubjectID=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedSubjectID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Subject deleted successfully.");
            LoadSubjects();
            selectedSubjectID = 0;
        }

        //
        // HELPER FUNCTIONS
        //

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) ||
                string.IsNullOrWhiteSpace(txtSchedule.Text) ||
                string.IsNullOrWhiteSpace(cmbyearlevel.Text) ||
                string.IsNullOrWhiteSpace(cmbsection.Text) ||
                cmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all fields before saving.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool SubjectExists(string subject, string section)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*) FROM Subjects
                WHERE SubjectName=@name AND Section=@section", conn))
            {
                cmd.Parameters.AddWithValue("@name", subject.Trim());
                cmd.Parameters.AddWithValue("@section", section.Trim());

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void ClearInputs()
        {
            txtSubjectName.Clear();
            txtSchedule.Clear();
            cmbyearlevel.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;
            cmbProfessor.SelectedIndex = -1;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Open the login form
                LoginForm login = new LoginForm();   // <-- use your actual login form class name
                login.Show();

                // When login form is closed, exit this form too (or the whole app)
                login.FormClosed += (s, args) =>
                {
                    // Close the current ProfessorsForm
                    this.Close();
                    // If you want to exit the whole app instead:
                    // Application.Exit();
                };

                // Hide current form
                this.Hide();
            }
        }
    }
}
