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

            dgvProfessors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfessors.MultiSelect = false;
            dgvProfessors.ReadOnly = true;
            dgvProfessors.AllowUserToAddRows = false;
            dgvProfessors.CellClick += dgvProfessors_CellClick;

            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;

            btnHome.Click += btnHome_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnManage.Click += btnManage_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;
        }

        // Form load
        private void ManageFormLoad(object sender, EventArgs e)
        {
            InitializeYearSectionCourseCombos();
            LoadProfessors();
            LoadSubjects();
        }

        // Init combos
        private void InitializeYearSectionCourseCombos()
        {
            cmbyearlevel.Items.Clear();
            cmbyearlevel.Items.Add("1st Year");
            cmbyearlevel.Items.Add("2nd Year");
            cmbyearlevel.Items.Add("3rd Year");
            cmbyearlevel.Items.Add("4th Year");

            cmbsection.Items.Clear();
            cmbsection.Items.Add("A");
            cmbsection.Items.Add("B");
            cmbsection.Items.Add("C");

            cmbcourse.Items.Clear();
            cmbcourse.Items.Add("BSIT");
            cmbcourse.Items.Add("BSCS");
            cmbcourse.Items.Add("BMMAM");
            cmbcourse.Items.Add("BSCpE");

            cmbyearlevel.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
        }

        // Reuse form
        private T GetOrCreateForm<T>() where T : Form, new()
        {
            var existing = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (existing == null || existing.IsDisposed)
                existing = new T();
            return existing;
        }

        // Home nav
        private void btnHome_Click(object sender, EventArgs e)
        {
            var home = GetOrCreateForm<AdminForm>();
            home.Show();
            home.BringToFront();
            this.Hide();
        }

        // Prof nav
        private void btnProfessors_Click(object sender, EventArgs e)
        {
            var f = GetOrCreateForm<ProfessorsForm>();
            f.Show();
            f.BringToFront();
            this.Hide();
        }

        // Manage nav
        private void btnManage_Click(object sender, EventArgs e)
        {
            LoadProfessors();
            LoadSubjects();
        }

        // StudReg nav
        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            var f = GetOrCreateForm<StudentRegistration>();
            f.Show();
            f.BringToFront();
            this.Hide();
        }

        // Load teachers
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

        // Load subjects
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
                        S.Course,
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

                if (dgvProfessors.Columns.Contains("SubjectID"))
                    dgvProfessors.Columns["SubjectID"].Visible = false;

                dgvProfessors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Grid click
        private void dgvProfessors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProfessors.Rows[e.RowIndex];

            if (row.Cells["SubjectID"].Value != null)
                selectedSubjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);
        }

        // Validate inputs
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) ||
                string.IsNullOrWhiteSpace(txtSchedule.Text) ||
                string.IsNullOrWhiteSpace(cmbyearlevel.Text) ||
                string.IsNullOrWhiteSpace(cmbcourse.Text) ||
                string.IsNullOrWhiteSpace(cmbsection.Text) ||
                cmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Please complete all fields.");
                return false;
            }

            return true;
        }

        // Check duplicate
        private bool SubjectExists(string subject, string yearLevel, string course, string section)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*) FROM Subjects
                WHERE SubjectName = @name
                  AND YearLevel = @year
                  AND Course = @course
                  AND Section = @section", conn))
            {
                cmd.Parameters.AddWithValue("@name", subject.Trim());
                cmd.Parameters.AddWithValue("@year", yearLevel.Trim());
                cmd.Parameters.AddWithValue("@course", course.Trim());
                cmd.Parameters.AddWithValue("@section", section.Trim());

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Add subject
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (SubjectExists(txtSubjectName.Text, cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text))
            {
                MessageBox.Show("This subject already exists for this year, course, and section.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    INSERT INTO Subjects (SubjectName, Schedule, YearLevel, Course, Section, TeacherID)
                    VALUES (@name, @sched, @year, @course, @section, @teacher)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtSubjectName.Text.Trim());
                cmd.Parameters.AddWithValue("@sched", txtSchedule.Text.Trim());
                cmd.Parameters.AddWithValue("@year", cmbyearlevel.Text.Trim());
                cmd.Parameters.AddWithValue("@course", cmbcourse.Text.Trim());
                cmd.Parameters.AddWithValue("@section", cmbsection.Text.Trim());
                cmd.Parameters.AddWithValue("@teacher", cmbProfessor.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Subject added successfully.");
            LoadSubjects();
            ClearInputs();
        }

        // Delete subject
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectID == 0)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            if (MessageBox.Show("Delete this subject?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Subjects WHERE SubjectID=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedSubjectID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Subject deleted.");
            LoadSubjects();
            selectedSubjectID = 0;
        }

        // Clear fields
        private void ClearInputs()
        {
            txtSubjectName.Clear();
            txtSchedule.Clear();
            cmbyearlevel.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            cmbProfessor.SelectedIndex = -1;
            selectedSubjectID = 0;
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var login = GetOrCreateForm<LoginForm>();
                login.Show();
                Hide();
                login.FormClosed += (s, args) => Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
