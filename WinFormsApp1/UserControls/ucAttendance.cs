using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ucAttendance : UserControl
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        private int teacherID;

        public ucAttendance(int teacherId)
        {
            InitializeComponent();
            teacherID = teacherId;

            // Wire UI events
            cmbSection.SelectedIndexChanged += (s, e) => OnSectionOrYearChanged();
            cmbYearLevel.SelectedIndexChanged += (s, e) => OnSectionOrYearChanged();
            cmbSubjects.SelectedIndexChanged += (s, e) => ReloadData();
            dtpDate.ValueChanged += (s, e) => ReloadData();

            // Ensure combobox commit triggers CellValueChanged for DataGridView
            dvgStudents.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dvgStudents.IsCurrentCellDirty)
                    dvgStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            dvgStudents.CellValueChanged += DvgStudents_CellValueChanged;

            // mark-all-present button (already in designer)
            btnMarkAllPresent.Click += BtnMarkAllPresent_Click;

            // initial load
            LoadSections();
            LoadYearLevels();
            // choose defaults if available
            if (cmbSection.Items.Count > 0) cmbSection.SelectedIndex = 0;
            if (cmbYearLevel.Items.Count > 0) cmbYearLevel.SelectedIndex = 0;

            LoadSubjects(cmbSection.Text, cmbYearLevel.Text);
            SetupGrid();
            ReloadData();
        }

        // When section or year changes, reload subjects (filtered) then students
        private void OnSectionOrYearChanged()
        {
            LoadSubjects(cmbSection.Text, cmbYearLevel.Text);
            ReloadData();
        }

        // ------------------------------------------------------------
        // LOAD SECTIONS (text only)
        // ------------------------------------------------------------
        private void LoadSections()
        {
            cmbSection.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT ISNULL(Section,'') AS Section FROM Subjects WHERE TeacherID=@T ORDER BY Section", conn))
                {
                    cmd.Parameters.AddWithValue("@T", teacherID);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string sec = dr["Section"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(sec) && !cmbSection.Items.Contains(sec))
                                cmbSection.Items.Add(sec);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSections error:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // LOAD YEAR LEVELS
        // ------------------------------------------------------------
        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT ISNULL(YearLevel,'') AS YearLevel FROM Subjects WHERE TeacherID=@T ORDER BY YearLevel", conn))
                {
                    cmd.Parameters.AddWithValue("@T", teacherID);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string yl = dr["YearLevel"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(yl) && !cmbYearLevel.Items.Contains(yl))
                                cmbYearLevel.Items.Add(yl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadYearLevels error:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // LOAD SUBJECTS (filtered by section + year if provided)
        // SubjectName displayed WITHOUT section suffix.
        // ------------------------------------------------------------
        private void LoadSubjects(string section = null, string yearLevel = null)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    string sql = @"
                        SELECT SubjectID, SubjectName
                        FROM Subjects
                        WHERE TeacherID = @TeacherID
                    ";

                    if (!string.IsNullOrWhiteSpace(section))
                    {
                        sql += " AND Section = @Section ";
                        cmd.Parameters.AddWithValue("@Section", section);
                    }

                    if (!string.IsNullOrWhiteSpace(yearLevel))
                    {
                        sql += " AND YearLevel = @YearLevel ";
                        cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                    }

                    sql += " ORDER BY SubjectName ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }

                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectID";
                cmbSubjects.DataSource = dt;

                if (cmbSubjects.Items.Count > 0)
                    cmbSubjects.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSubjects error:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // RELOAD STUDENTS & EXISTING ATTENDANCE
        // ------------------------------------------------------------
        private void ReloadData()
        {
            // if no subject selected, nothing to load
            if (cmbSubjects.DataSource == null || cmbSubjects.SelectedValue == null) return;

            int subjectID;
            if (!int.TryParse(cmbSubjects.SelectedValue.ToString(), out subjectID)) return;

            string section = cmbSection.Text?.Trim();
            string year = cmbYearLevel.Text?.Trim();
            DateTime date = dtpDate.Value.Date;

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    string sql = @"
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
                    ";

                    if (!string.IsNullOrWhiteSpace(section))
                    {
                        sql += " AND s.Section = @Section ";
                        cmd.Parameters.AddWithValue("@Section", section);
                    }

                    if (!string.IsNullOrWhiteSpace(year))
                    {
                        sql += " AND s.YearLevel = @YearLevel ";
                        cmd.Parameters.AddWithValue("@YearLevel", year);
                    }

                    sql += " ORDER BY s.LastName, s.FirstName ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.Parameters.AddWithValue("@DateTaken", date);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }

                dvgStudents.DataSource = dt;

                // hide internal columns safely (if they exist)
                if (dvgStudents.Columns.Contains("StudentID")) dvgStudents.Columns["StudentID"].Visible = false;
                if (dvgStudents.Columns.Contains("AttendanceID")) dvgStudents.Columns["AttendanceID"].Visible = false;

                // read-only name
                if (dvgStudents.Columns.Contains("FullName")) dvgStudents.Columns["FullName"].ReadOnly = true;

                ColorRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReloadData error:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // AUTO-SAVE when DataGridView cell changes
        // ------------------------------------------------------------
        private void DvgStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                AutoSaveRow(e.RowIndex);
                ColorRows();
            }
            catch (Exception ex)
            {
                // avoid crashing UI loop - notify user for debugging
                MessageBox.Show("Error saving attendance:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // Auto-save a single row (insert or update)
        // ------------------------------------------------------------
        private void AutoSaveRow(int rowIndex)
        {
            if (cmbSubjects.DataSource == null || cmbSubjects.SelectedValue == null) return;

            DataGridViewRow row = dvgStudents.Rows[rowIndex];

            // skip if accidental/new-row
            if (row.IsNewRow) return;

            // basic validation: student id must be present
            if (!dvgStudents.Columns.Contains("StudentID")) return;
            object sidObj = row.Cells["StudentID"].Value;
            if (sidObj == null || sidObj == DBNull.Value) return;

            int studentID = Convert.ToInt32(sidObj);

            int subjectID = Convert.ToInt32(cmbSubjects.SelectedValue);
            string status = row.Cells["Status"].Value?.ToString() ?? "Not Recorded";
            string remarks = row.Cells["Remarks"].Value?.ToString() ?? "";

            int attendanceId = 0;
            if (dvgStudents.Columns.Contains("AttendanceID"))
            {
                var aObj = row.Cells["AttendanceID"].Value;
                attendanceId = (aObj == null || aObj == DBNull.Value) ? 0 : Convert.ToInt32(aObj);
            }

            DateTime date = dtpDate.Value.Date;

            // Do not attempt to save if status is null/empty (but we allow Not Recorded if user left it)
            if (string.IsNullOrWhiteSpace(status)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (attendanceId == 0)
                {
                    // insert
                    using (SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO Attendance (StudentID, SubjectID, DateTaken, Status, Remarks)
                        VALUES (@S, @Sub, @D, @St, @R);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);", conn))
                    {
                        cmd.Parameters.AddWithValue("@S", studentID);
                        cmd.Parameters.AddWithValue("@Sub", subjectID);
                        cmd.Parameters.AddWithValue("@D", date);
                        cmd.Parameters.AddWithValue("@St", status);
                        cmd.Parameters.AddWithValue("@R", remarks);

                        object newId = cmd.ExecuteScalar();
                        if (newId != null && newId != DBNull.Value)
                        {
                            int id = Convert.ToInt32(newId);
                            if (dvgStudents.Columns.Contains("AttendanceID"))
                                row.Cells["AttendanceID"].Value = id;
                        }
                    }
                }
                else
                {
                    // update
                    using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE Attendance
                        SET Status = @St,
                            Remarks = @R,
                            DateTaken = @D
                        WHERE AttendanceID = @AID", conn))
                    {
                        cmd.Parameters.AddWithValue("@St", status);
                        cmd.Parameters.AddWithValue("@R", remarks);
                        cmd.Parameters.AddWithValue("@D", date);
                        cmd.Parameters.AddWithValue("@AID", attendanceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // ------------------------------------------------------------
        // MARK ALL PRESENT (changes cells which triggers auto-save)
        // ------------------------------------------------------------
        private void BtnMarkAllPresent_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dvgStudents.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (dvgStudents.Columns.Contains("Status"))
                        row.Cells["Status"].Value = "Present";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mark all present error:\n" + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // SETUP GRID: ensure Status is combo and Remarks exists
        // ------------------------------------------------------------
        private void SetupGrid()
        {
            dvgStudents.AutoGenerateColumns = true;
            dvgStudents.AllowUserToAddRows = false;

            // ✅ ADD THIS BLOCK HERE
            dvgStudents.BorderStyle = BorderStyle.None;
            dvgStudents.BackgroundColor = Color.White;
            dvgStudents.GridColor = Color.Gainsboro;

            dvgStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dvgStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dvgStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dvgStudents.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dvgStudents.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dvgStudents.DefaultCellStyle.SelectionForeColor = Color.Black;

            dvgStudents.RowTemplate.Height = 28;
            dvgStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // ✅ END OF STYLING


            // Keep your existing DataBindingComplete logic
            dvgStudents.DataBindingComplete += (s, e) =>
            {
                if (dvgStudents.Columns.Contains("Status") &&
                    !(dvgStudents.Columns["Status"] is DataGridViewComboBoxColumn))
                {
                    int idx = dvgStudents.Columns["Status"].Index;

                    dvgStudents.Columns.Remove("Status");

                    DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn
                    {
                        Name = "Status",
                        HeaderText = "Status",
                        DataPropertyName = "Status",
                        Items = { "Present", "Absent", "Late", "Not Recorded" }
                    };

                    dvgStudents.Columns.Insert(idx, cb);
                }

                if (!dvgStudents.Columns.Contains("Remarks"))
                {
                    dvgStudents.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "Remarks",
                        HeaderText = "Remarks",
                        DataPropertyName = "Remarks"
                    });
                }

                if (dvgStudents.Columns.Contains("FullName"))
                    dvgStudents.Columns["FullName"].ReadOnly = true;

                if (dvgStudents.Columns.Contains("AttendanceID"))
                    dvgStudents.Columns["AttendanceID"].Visible = false;

                if (dvgStudents.Columns.Contains("StudentID"))
                    dvgStudents.Columns["StudentID"].Visible = false;

                ColorRows();
            };
        }


        // 
        // COLOR ROWS BASED ON STATUS
        // 
        private void ColorRows()
        {
            try
            {
                foreach (DataGridViewRow row in dvgStudents.Rows)
                {
                    if (row.IsNewRow) continue;

                    string status = row.Cells["Status"].Value?.ToString() ?? "";

                    // Soft background color based on attendance
                    row.DefaultCellStyle.BackColor = status switch
                    {
                        "Present" => Color.FromArgb(220, 255, 220),
                        "Absent" => Color.FromArgb(255, 220, 220),
                        "Late" => Color.FromArgb(255, 245, 200),
                        _ => Color.White
                    };

                    // NICE ALTERNATING STYLE  
                    if (status == "Not Recorded")
                    {
                        if (row.Index % 2 == 0)
                            row.DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                        else
                            row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch { }
        }



        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
