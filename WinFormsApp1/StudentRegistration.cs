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
        }

        private void StudentRegistration_Load(object sender, EventArgs e)
        {
            InitializeYearCourseSectionCombos();
            LoadStudents();
            LoadSubjects();
        }

        // ====================== COMBO PRESET VALUES ======================

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

        // ====================== LOAD SUBJECTS (uses clbSubjects) ======================

        private void LoadSubjects(string sectionFilter = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT SubjectID,
                           SubjectName + ' (' + Section + ')' AS FullName
                    FROM Subjects";

                if (!string.IsNullOrEmpty(sectionFilter))
                {
                    sql += " WHERE Section = @Sec";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(sectionFilter))
                        cmd.Parameters.AddWithValue("@Sec", sectionFilter);

                    conn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    clbSubjects.DataSource = dt;
                    clbSubjects.DisplayMember = "FullName";  // <-- alias fixed
                    clbSubjects.ValueMember = "SubjectID";
                }
            }
        }

        // ====================== LOAD STUDENTS GRID ======================

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
            }
        }

        // ====================== GRID CLICK ======================

        private void dgvStudentRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvStudentRegistration.Rows[e.RowIndex];

            txtStudentID.Text = row.Cells["StudentID"].Value?.ToString() ?? "";
            txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
            txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";

            cmbyearlevel.Text = row.Cells["YearLevel"].Value?.ToString() ?? "";
            cmbcourse.Text = row.Cells["Course"].Value?.ToString() ?? "";
            cmbsection.Text = row.Cells["Section"].Value?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(cmbsection.Text))
                LoadSubjects(cmbsection.Text);
            else
                LoadSubjects();
        }

        // ====================== EDIT / UPDATE ======================

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

        // ====================== DELETE ======================

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

        // ====================== REGISTER + AUTO-ENROLL ======================

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

            AutoEnroll(newStudentId, cmbsection.Text);
            UpdateClassification(newStudentId);
            LoadStudents();
            ClearFields();

            MessageBox.Show("Student registered and auto-enrolled.");
        }

        private void AutoEnroll(int studentId, string section)
        {
            if (string.IsNullOrWhiteSpace(section)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // get all subjects in that section
                SqlCommand getSubjects = new SqlCommand(
                    "SELECT SubjectID FROM Subjects WHERE Section = @S", conn);
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

        // ====================== MANUAL ENROLL (clbSubjects) ======================

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

        // ====================== CLASSIFICATION LOGIC ======================

        private void UpdateClassification(int studentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // get student's year + section
                string yearLevel = "";
                string section = "";

                using (SqlCommand cmdInfo = new SqlCommand(
                    "SELECT YearLevel, Section FROM Students WHERE StudentID = @ID", conn))
                {
                    cmdInfo.Parameters.AddWithValue("@ID", studentId);
                    using (SqlDataReader r = cmdInfo.ExecuteReader())
                    {
                        if (!r.Read()) return;
                        yearLevel = r["YearLevel"].ToString();
                        section = r["Section"].ToString();
                    }
                }

                // total subjects for that year+section
                int totalSubjects;
                using (SqlCommand cmdTotal = new SqlCommand(
                    "SELECT COUNT(*) FROM Subjects WHERE YearLevel = @YL AND Section = @S", conn))
                {
                    cmdTotal.Parameters.AddWithValue("@YL", yearLevel);
                    cmdTotal.Parameters.AddWithValue("@S", section);
                    totalSubjects = (int)cmdTotal.ExecuteScalar();
                }

                // how many of those the student is enrolled in
                int enrolledSame;
                using (SqlCommand cmdEnrolled = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM Enrollments E
                    JOIN Subjects S ON E.SubjectID = S.SubjectID
                    WHERE E.StudentID = @ID
                      AND S.YearLevel = @YL
                      AND S.Section = @S", conn))
                {
                    cmdEnrolled.Parameters.AddWithValue("@ID", studentId);
                    cmdEnrolled.Parameters.AddWithValue("@YL", yearLevel);
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

        // ====================== HELPERS & NAV ======================

        private void ClearFields()
        {
            txtStudentID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            cmbyearlevel.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;

            clbSubjects.ClearSelected();
            for (int i = 0; i < clbSubjects.Items.Count; i++)
                clbSubjects.SetItemChecked(i, false);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbsection.Text))
                LoadSubjects(cmbsection.Text);
            else
                LoadSubjects();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            new AdminForm().Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            new ManageForm().Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            new ProfessorsForm().Show();
            this.Hide();
        }

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

        // Dummy handlers if wired in designer
        private void gbStudentRegistration_Enter(object sender, EventArgs e) { }
        private void lblEnroll_Click(object sender, EventArgs e) { }
        private void cmbcourse_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbyearlevel_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
