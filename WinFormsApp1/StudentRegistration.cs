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
        private string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public StudentRegistration()
        {
            InitializeComponent();
            this.Load += StudentRegistration_Load;

            // Optional quality-of-life settings for the grid
            dgvStudentRegistration.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentRegistration.MultiSelect = false;
            dgvStudentRegistration.ReadOnly = true;
            dgvStudentRegistration.AllowUserToAddRows = false;
            dgvStudentRegistration.AllowUserToDeleteRows = false;
        }

        // Form load
        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            InitializeYearCourseSectionCombos();
            LoadStudents();
            LoadSubjects(null, null, null);   // no subjects at start
        }

        // Init combos
        private void InitializeYearCourseSectionCombos()
        {
            cmbyearlevel.Items.Clear();
            cmbyearlevel.Items.Add("1st Year");
            cmbyearlevel.Items.Add("2nd Year");
            cmbyearlevel.Items.Add("3rd Year");
            cmbyearlevel.Items.Add("4th Year");

            cmbcourse.Items.Clear();
            cmbcourse.Items.Add("BSIT");
            cmbcourse.Items.Add("BSCS");
            cmbcourse.Items.Add("BMMAM");
            cmbcourse.Items.Add("BSCpE");

            cmbsection.Items.Clear();
            cmbsection.Items.Add("A");
            cmbsection.Items.Add("B");
            cmbsection.Items.Add("C");

            cmbyearlevel.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;
        }

        // Load subjects (filter)
        private void LoadSubjects(string yearFilter, string courseFilter, string sectionFilter)
        {
            bool hasYear = !string.IsNullOrWhiteSpace(yearFilter);
            bool hasCourse = !string.IsNullOrWhiteSpace(courseFilter);
            bool hasSection = !string.IsNullOrWhiteSpace(sectionFilter);

            // nothing chosen → no subjects
            if (!hasYear && !hasCourse && !hasSection)
            {
                clbSubjects.DataSource = null;
                clbSubjects.Items.Clear();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT SubjectID,
                           SubjectName + ' (' + Section + ')' AS FullName
                    FROM Subjects";

                List<string> conditions = new List<string>();

                if (hasYear)
                    conditions.Add("YearLevel = @Year");
                if (hasCourse)
                    conditions.Add("Course = @Course");
                if (hasSection)
                    conditions.Add("Section = @Sec");

                if (conditions.Count > 0)
                    sql += " WHERE " + string.Join(" AND ", conditions);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (hasYear)
                        cmd.Parameters.AddWithValue("@Year", yearFilter);
                    if (hasCourse)
                        cmd.Parameters.AddWithValue("@Course", courseFilter);
                    if (hasSection)
                        cmd.Parameters.AddWithValue("@Sec", sectionFilter);

                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    clbSubjects.DataSource = dt;
                    clbSubjects.DisplayMember = "FullName";
                    clbSubjects.ValueMember = "SubjectID";
                }
            }
        }

        // Load students
        private void LoadStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT StudentID,
                           FirstName,
                           LastName,
                           YearLevel,
                           Course,
                           Section,
                           Classification
                    FROM Students";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStudentRegistration.AutoGenerateColumns = true;
                dgvStudentRegistration.DataSource = dt;
                dgvStudentRegistration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // HIDE StudentID column from the grid
                if (dgvStudentRegistration.Columns.Contains("StudentID"))
                {
                    dgvStudentRegistration.Columns["StudentID"].Visible = false;
                }
            }
        }

        // Grid click
        private void dgvStudentRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStudentRegistration.Rows[e.RowIndex];

            // StudentID is hidden in the grid but still accessible in code
            txtStudentID.Text = row.Cells["StudentID"].Value?.ToString() ?? "";
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
            txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";

            cmbyearlevel.Text = row.Cells["YearLevel"].Value?.ToString() ?? "";
            cmbcourse.Text = row.Cells["Course"].Value?.ToString() ?? "";
            cmbsection.Text = row.Cells["Section"].Value?.ToString() ?? "";

            // correct order: year, course, section
            LoadSubjects(cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text);
        }

        // Enable edit
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            cmbyearlevel.Enabled = true;
            cmbcourse.Enabled = true;
            cmbsection.Enabled = true;
        }

        // Update student
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("No student selected.");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    UPDATE Students SET
                        FirstName = @FN,
                        LastName = @LN,
                        YearLevel = @YL,
                        Course = @C,
                        Section = @S
                    WHERE StudentID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FN", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLastName.Text);
                cmd.Parameters.AddWithValue("@YL", cmbyearlevel.Text);
                cmd.Parameters.AddWithValue("@C", cmbcourse.Text);
                cmd.Parameters.AddWithValue("@S", cmbsection.Text);
                cmd.Parameters.AddWithValue("@ID", studentId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            UpdateClassification(studentId);
            LoadStudents();
            MessageBox.Show("Student updated.");
        }

        // Delete student
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID.");
                return;
            }

            if (MessageBox.Show("Delete this student?", "Confirm",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE StudentID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", studentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadStudents();
            ClearFields();
            MessageBox.Show("Student deleted.");
        }

        // Register student
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                cmbyearlevel.SelectedIndex < 0 ||
                cmbcourse.SelectedIndex < 0 ||
                cmbsection.SelectedIndex < 0)
            {
                MessageBox.Show("Complete all fields.");
                return;
            }

            int newStudentId;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    INSERT INTO Students (FirstName, LastName, YearLevel, Course, Section, Classification)
                    VALUES (@FN, @LN, @YL, @C, @S, 'Irregular');
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FN", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LN", txtLastName.Text);
                cmd.Parameters.AddWithValue("@YL", cmbyearlevel.Text);
                cmd.Parameters.AddWithValue("@C", cmbcourse.Text);
                cmd.Parameters.AddWithValue("@S", cmbsection.Text);

                conn.Open();
                newStudentId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            AutoEnroll(newStudentId, cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text);
            UpdateClassification(newStudentId);
            LoadStudents();
            ClearFields();

            MessageBox.Show("Student registered and auto-enrolled.");
        }

        // Auto enroll
        private void AutoEnroll(int studentId, string yearLevel, string course, string section)
        {
            if (string.IsNullOrWhiteSpace(yearLevel) ||
                string.IsNullOrWhiteSpace(course) ||
                string.IsNullOrWhiteSpace(section))
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT SubjectID FROM Subjects
                    WHERE YearLevel = @YL AND Course = @C AND Section = @S";

                SqlCommand getSubjects = new SqlCommand(sql, conn);
                getSubjects.Parameters.AddWithValue("@YL", yearLevel);
                getSubjects.Parameters.AddWithValue("@C", course);
                getSubjects.Parameters.AddWithValue("@S", section);

                DataTable dt = new DataTable();
                dt.Load(getSubjects.ExecuteReader());

                foreach (DataRow r in dt.Rows)
                {
                    SqlCommand enroll = new SqlCommand(
                        "INSERT INTO Enrollments (StudentID, SubjectID) VALUES (@ST, @SB)", conn);
                    enroll.Parameters.AddWithValue("@ST", studentId);
                    enroll.Parameters.AddWithValue("@SB", r["SubjectID"]);
                    enroll.ExecuteNonQuery();
                }
            }
        }

        // Manual enroll
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            if (!int.TryParse(txtStudentID.Text, out int studentId))
            {
                MessageBox.Show("Invalid Student ID.");
                return;
            }

            if (clbSubjects.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select at least one subject.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (object item in clbSubjects.CheckedItems)
                {
                    DataRowView row = item as DataRowView;
                    int subjectId = Convert.ToInt32(row["SubjectID"]);

                    SqlCommand cmd = new SqlCommand(@"
                        IF NOT EXISTS (
                            SELECT 1 FROM Enrollments
                            WHERE StudentID = @S AND SubjectID = @SB
                        )
                        INSERT INTO Enrollments (StudentID, SubjectID)
                        VALUES (@S, @SB);", conn);

                    cmd.Parameters.AddWithValue("@S", studentId);
                    cmd.Parameters.AddWithValue("@SB", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }

            UpdateClassification(studentId);
            MessageBox.Show("Enrollment updated.");
        }

        // Update class (Regular/Irregular)
        private void UpdateClassification(int studentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string yearLevel = "";
                string course = "";
                string section = "";

                using (SqlCommand cmdInfo = new SqlCommand(
                    "SELECT YearLevel, Course, Section FROM Students WHERE StudentID = @ID", conn))
                {
                    cmdInfo.Parameters.AddWithValue("@ID", studentId);
                    using (SqlDataReader r = cmdInfo.ExecuteReader())
                    {
                        if (!r.Read()) return;
                        yearLevel = r["YearLevel"].ToString();
                        course = r["Course"].ToString();
                        section = r["Section"].ToString();
                    }
                }

                int totalSubjects;
                using (SqlCommand cmdTotal = new SqlCommand(
                    "SELECT COUNT(*) FROM Subjects WHERE YearLevel = @YL AND Course = @C AND Section = @S", conn))
                {
                    cmdTotal.Parameters.AddWithValue("@YL", yearLevel);
                    cmdTotal.Parameters.AddWithValue("@C", course);
                    cmdTotal.Parameters.AddWithValue("@S", section);
                    totalSubjects = (int)cmdTotal.ExecuteScalar();
                }

                int enrolledSame;
                using (SqlCommand cmdEnrolled = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Enrollments E
                    JOIN Subjects S ON E.SubjectID = S.SubjectID
                    WHERE E.StudentID = @ID
                      AND S.YearLevel = @YL
                      AND S.Course = @C
                      AND S.Section = @S", conn))
                {
                    cmdEnrolled.Parameters.AddWithValue("@ID", studentId);
                    cmdEnrolled.Parameters.AddWithValue("@YL", yearLevel);
                    cmdEnrolled.Parameters.AddWithValue("@C", course);
                    cmdEnrolled.Parameters.AddWithValue("@S", section);
                    enrolledSame = (int)cmdEnrolled.ExecuteScalar();
                }

                string classification =
                    (totalSubjects > 0 && enrolledSame == totalSubjects) ? "Regular" : "Irregular";

                using (SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE Students SET Classification = @C WHERE StudentID = @ID", conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@C", classification);
                    cmdUpdate.Parameters.AddWithValue("@ID", studentId);
                    cmdUpdate.ExecuteNonQuery();
                }
            }

            LoadStudents();
        }

        // Clear inputs
        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cmbyearlevel.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;

            clbSubjects.DataSource = null;
            clbSubjects.Items.Clear();
        }

        // Show students
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        // Section change
        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects(cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text);
        }

        // Course change
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects(cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text);
        }

        // Year change
        private void cmbyearlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects(cmbyearlevel.Text, cmbcourse.Text, cmbsection.Text);
        }

        // Home nav
        private void btnHome_Click(object sender, EventArgs e)
        {
            new AdminForm().Show();
            this.Hide();
        }

        // Manage nav
        private void btnManage_Click(object sender, EventArgs e)
        {
            new ManageForm().Show();
            this.Hide();
        }

        // Professors nav
        private void btnProfessors_Click(object sender, EventArgs e)
        {
            new ProfessorsForm().Show();
            this.Hide();
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                login.FormClosed += (s, args) => this.Close();
                this.Hide();
            }
        }

        // Group enter
        private void gbStudentRegistration_Enter(object sender, EventArgs e) { }

        // Label click
        private void lblEnroll_Click(object sender, EventArgs e) { }
    }
}
