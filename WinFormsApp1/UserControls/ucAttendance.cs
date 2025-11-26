using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ucAttendance : UserControl
    {
        private int teacherID;
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public ucAttendance(int teacherId)
        {
            InitializeComponent();
            teacherID = teacherId;

            // Wire events (safe if already wired in designer)
            cmbSection.SelectedIndexChanged += CmbSection_SelectedIndexChanged;
            cmbSubjects.SelectedIndexChanged += CmbSubjects_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnLoad.Click += BtnLoad_Click;
            dtpDate.ValueChanged += DtpDate_ValueChanged;

            // initial load
            LoadSections();
            LoadYearLevels();
            LoadSubjects(); // load all subjects for teacher (will filter when section selected)
            SetupDataGridAfterBind();
        }

        // Load distinct sections for this teacher (from Subjects)
        private void LoadSections()
        {
            cmbSection.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ISNULL(Section,'') AS Section FROM Subjects WHERE TeacherID = @TeacherID ORDER BY Section", conn))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var sec = dr["Section"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(sec))
                            cmbSection.Items.Add(sec);
                    }
                }
            }

            if (cmbSection.Items.Count > 0)
                cmbSection.SelectedIndex = 0;
        }

        // Load distinct year levels (optional source: Subjects)
        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ISNULL(YearLevel,'') AS YearLevel FROM Subjects WHERE TeacherID = @TeacherID ORDER BY YearLevel", conn))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var yl = dr["YearLevel"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(yl))
                            cmbYearLevel.Items.Add(yl);
                    }
                }
            }

            if (cmbYearLevel.Items.Count > 0)
                cmbYearLevel.SelectedIndex = 0;
        }

        // Load subjects for teacher, optional section filter
        private void LoadSubjects(string section = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT SubjectID, SubjectName + ' (' + ISNULL(Section,'') + ')' AS SubjectDisplay
                FROM Subjects
                WHERE TeacherID = @TeacherID
                " + (string.IsNullOrEmpty(section) ? "" : "AND Section = @Section") + @"
                ORDER BY SubjectName", conn))
            {
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                if (!string.IsNullOrEmpty(section))
                    cmd.Parameters.AddWithValue("@Section", section);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbSubjects.DisplayMember = "SubjectDisplay";
            cmbSubjects.ValueMember = "SubjectID";
            cmbSubjects.DataSource = dt;
            if (cmbSubjects.Items.Count > 0) cmbSubjects.SelectedIndex = 0;
        }

        // Load students and existing attendance for selected subject/date
        private void LoadStudentsForSelection()
        {
            if (cmbSubjects.SelectedValue == null) return;

            int subjectID = Convert.ToInt32(cmbSubjects.SelectedValue);
            string section = cmbSection.Text ?? "";
            string yearLevel = cmbYearLevel.Text ?? "";
            DateTime date = dtpDate.Value.Date;

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    s.StudentID,
                    (s.FirstName + ' ' + s.LastName) AS FullName,
                    ISNULL(a.Status, 'Not Recorded') AS Status,
                    ISNULL(a.AttendanceID, 0) AS AttendanceID,
                    ISNULL(a.Remarks, '') AS Remarks
                FROM Students s
                INNER JOIN Enrollments e ON s.StudentID = e.StudentID
                LEFT JOIN Attendance a ON a.StudentID = s.StudentID 
                    AND a.SubjectID = @SubjectID 
                    AND CAST(a.DateTaken AS DATE) = @DateTaken
                WHERE e.SubjectID = @SubjectID
                  " + (string.IsNullOrEmpty(section) ? "" : " AND s.Section = @Section ") + @"
                  " + (string.IsNullOrEmpty(yearLevel) ? "" : " AND s.YearLevel = @YearLevel ") + @"
                ORDER BY s.LastName, s.FirstName", conn))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.Parameters.AddWithValue("@DateTaken", date);
                if (!string.IsNullOrEmpty(section))
                    cmd.Parameters.AddWithValue("@Section", section);
                if (!string.IsNullOrEmpty(yearLevel))
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dvgStudents.DataSource = dt;

            // hide internal columns
            if (dvgStudents.Columns.Contains("AttendanceID"))
                dvgStudents.Columns["AttendanceID"].Visible = false;
            if (dvgStudents.Columns.Contains("StudentID"))
                dvgStudents.Columns["StudentID"].Visible = false;
            if (dvgStudents.Columns.Contains("FullName"))
                dvgStudents.Columns["FullName"].ReadOnly = true;
        }

        private bool ValidateInputs()
        {
            if (cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dvgStudents.Rows.Count == 0)
            {
                MessageBox.Show("There are no students to save attendance for.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if at least one status is selected (or all rows have a valid status)
            foreach (DataGridViewRow row in dvgStudents.Rows)
            {
                if (row.IsNewRow) continue;

                string status = row.Cells["Status"].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(status) || status == "Not Recorded")
                {
                    MessageBox.Show("Some students do not have a status selected.\nPlease update all rows before saving.",
                        "Status Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool AttendanceAlreadyExists(int subjectID, DateTime date)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT COUNT(*) 
                FROM Attendance
                WHERE SubjectID = @SubjectID
                  AND CAST(DateTaken AS DATE) = @DateTaken", conn))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.Parameters.AddWithValue("@DateTaken", date);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        private void SaveAttendance()
        {
            // Validate dropdowns, students, and statuses
            if (!ValidateInputs())
                return;

            int subjectID = Convert.ToInt32(cmbSubjects.SelectedValue);
            DateTime date = dtpDate.Value.Date;

            // Prevent duplicate saving for same date
            if (AttendanceAlreadyExists(subjectID, date))
            {
                DialogResult result = MessageBox.Show(
                    "Attendance for this subject and date already exists.\n\n" +
                    "Do you want to overwrite it?",
                    "Duplicate Attendance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dvgStudents.Rows)
                {
                    if (row.IsNewRow) continue;

                    int studentID = Convert.ToInt32(row.Cells["StudentID"].Value);
                    string status = row.Cells["Status"].Value?.ToString() ?? "Not Recorded";
                    string remarks = row.Cells["Remarks"]?.Value?.ToString() ?? "";
                    int attendanceId = Convert.ToInt32(row.Cells["AttendanceID"].Value);

                    if (attendanceId > 0)
                    {
                        // update
                        using (SqlCommand update = new SqlCommand(@"
                            UPDATE Attendance
                            SET Status = @Status,
                                Remarks = @Remarks,
                                DateTaken = @DateTaken
                            WHERE AttendanceID = @AttendanceID", conn))
                        {
                            update.Parameters.AddWithValue("@Status", status);
                            update.Parameters.AddWithValue("@Remarks", remarks);
                            update.Parameters.AddWithValue("@DateTaken", date);
                            update.Parameters.AddWithValue("@AttendanceID", attendanceId);
                            update.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // insert
                        using (SqlCommand insert = new SqlCommand(@"
                            INSERT INTO Attendance (StudentID, SubjectID, DateTaken, Status, Remarks)
                            VALUES (@StudentID, @SubjectID, @DateTaken, @Status, @Remarks)", conn))
                        {
                            insert.Parameters.AddWithValue("@StudentID", studentID);
                            insert.Parameters.AddWithValue("@SubjectID", subjectID);
                            insert.Parameters.AddWithValue("@DateTaken", date);
                            insert.Parameters.AddWithValue("@Status", status);
                            insert.Parameters.AddWithValue("@Remarks", remarks);
                            insert.ExecuteNonQuery();
                        }
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Attendance saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadStudentsForSelection();
        }

        // Event handlers
        private void BtnSave_Click(object sender, EventArgs e) => SaveAttendance();
        private void BtnLoad_Click(object sender, EventArgs e) => LoadStudentsForSelection();
        private void DtpDate_ValueChanged(object sender, EventArgs e) => LoadStudentsForSelection();
        private void CmbSubjects_SelectedIndexChanged(object sender, EventArgs e) => LoadStudentsForSelection();
        private void CmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When section changes, reload subjects for that section and then students
            LoadSubjects(cmbSection.Text);
            LoadStudentsForSelection();
        }

        // Ensure grid Status column is a combobox and Remarks column exists
        private void SetupDataGridAfterBind()
        {
            dvgStudents.AutoGenerateColumns = true;
            dvgStudents.AllowUserToAddRows = false;
            dvgStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dvgStudents.DataBindingComplete += (s, e) =>
            {
                // Replace Status column with ComboBox column if needed
                if (dvgStudents.Columns.Contains("Status"))
                {
                    var col = dvgStudents.Columns["Status"];
                    if (!(col is DataGridViewComboBoxColumn))
                    {
                        int idx = col.Index;
                        DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn
                        {
                            Name = "Status",
                            HeaderText = "Status",
                            DataPropertyName = "Status"
                        };
                        cb.Items.AddRange("Present", "Absent", "Late", "Not Recorded");

                        dvgStudents.Columns.Remove(col);
                        dvgStudents.Columns.Insert(idx, cb);
                    }
                }

                if (!dvgStudents.Columns.Contains("Remarks"))
                {
                    DataGridViewTextBoxColumn remarks = new DataGridViewTextBoxColumn
                    {
                        Name = "Remarks",
                        HeaderText = "Remarks",
                        DataPropertyName = "Remarks"
                    };
                    dvgStudents.Columns.Add(remarks);
                }

                // Make FullName column read-only
                if (dvgStudents.Columns.Contains("FullName"))
                    dvgStudents.Columns["FullName"].ReadOnly = true;

                // Hide internal IDs
                if (dvgStudents.Columns.Contains("AttendanceID"))
                    dvgStudents.Columns["AttendanceID"].Visible = false;
                if (dvgStudents.Columns.Contains("StudentID"))
                    dvgStudents.Columns["StudentID"].Visible = false;
            };
        }

        // legacy stub events (if wired from designer)
        private void dtpDate_ValueChanged(object sender, EventArgs e) { /* handled above */ }
        private void lblYearLevel_Click(object sender, EventArgs e) { /* nothing */ }
    }
}
