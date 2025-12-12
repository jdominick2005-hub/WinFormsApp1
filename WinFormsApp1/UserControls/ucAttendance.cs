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
        private string teacherProgram = "";

        private System.Windows.Forms.Timer autoRefreshTimer;
        private const int autoRefreshIntervalMs = 3000; // 

        public ucAttendance(int teacherId)
        {
            InitializeComponent();
            teacherID = teacherId;

            LoadTeacherProgram();
            LoadSections();
            LoadYearLevels();
            SetupGrid();

            // wire events
            cmbSection.SelectedIndexChanged += cmbSection_SelectedIndexChanged;
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            dvgStudents.CurrentCellDirtyStateChanged += dvgStudents_CurrentCellDirtyStateChanged;
            dvgStudents.CellValueChanged += DvgStudents_CellValueChanged;
            btnMarkAllPresent.Click += BtnMarkAllPresent_Click;

            // start with no subject selected
            cmbSection.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            cmbSubjects.DataSource = null;
            dvgStudents.DataSource = null;

            // ----- ADDED: setup auto-refresh timer -----
            autoRefreshTimer = new System.Windows.Forms.Timer();
            autoRefreshTimer.Interval = autoRefreshIntervalMs;
            autoRefreshTimer.Tick += (s, e) =>
            {
                try
                {
                    ReloadData();
                }
                catch { /* swallow to avoid interrupting UI */ }
            };

            // start timer only if control is visible
            this.VisibleChanged += UcAttendance_VisibleChanged;
            if (this.Visible)
                autoRefreshTimer.Start();
            // ------------------------------------------------
        }

        // ----- ADDED: VisibleChanged handler to start/stop timer -----
        private void UcAttendance_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                    autoRefreshTimer?.Start();
                else
                    autoRefreshTimer?.Stop();
            }
            catch { }
        }
        // --------------------------------------------------------------

        // teacher program
        private void LoadTeacherProgram()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Program FROM Teachers WHERE TeacherID=@TID", conn))
                {
                    cmd.Parameters.AddWithValue("@TID", teacherID);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    teacherProgram = result?.ToString() ?? "";
                }
            }
            catch
            {
                teacherProgram = "";
            }
        }

        // load sections
        private void LoadSections()
        {
            cmbSection.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT Section FROM Subjects WHERE TeacherID=@T ORDER BY Section", conn))
                {
                    cmd.Parameters.AddWithValue("@T", teacherID);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string sec = dr["Section"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(sec))
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

        // load year levels
        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT YearLevel FROM Subjects WHERE TeacherID=@T ORDER BY YearLevel", conn))
                {
                    cmd.Parameters.AddWithValue("@T", teacherID);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string yl = dr["YearLevel"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(yl))
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

        // load subjects for this teacher + filters
        private void LoadSubjects()
        {
            // like student registration: no filters = clear subjects
            bool hasSection = !string.IsNullOrWhiteSpace(cmbSection.Text);
            bool hasYear = !string.IsNullOrWhiteSpace(cmbYearLevel.Text);

            if (!hasSection && !hasYear)
            {
                cmbSubjects.DataSource = null;
                return;
            }

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

                    if (hasSection)
                    {
                        sql += " AND Section = @Section ";
                        cmd.Parameters.AddWithValue("@Section", cmbSection.Text);
                    }

                    if (hasYear)
                    {
                        sql += " AND YearLevel = @YearLevel ";
                        cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(teacherProgram))
                    {
                        sql += " AND Course = @Course ";
                        cmd.Parameters.AddWithValue("@Course", teacherProgram);
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
                else
                    dvgStudents.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadSubjects error:\n" + ex.Message);
            }
        }

        // reload grid + attendance
        private void ReloadData()
        {
            if (cmbSubjects.DataSource == null || cmbSubjects.SelectedValue == null)
            {
                dvgStudents.DataSource = null;
                return;
            }

            if (!int.TryParse(cmbSubjects.SelectedValue.ToString(), out int subjectID))
            {
                dvgStudents.DataSource = null;
                return;
            }

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

                    // optional extra filters, but subject already defines year/section
                    if (!string.IsNullOrWhiteSpace(cmbSection.Text))
                    {
                        sql += " AND s.Section = @Section ";
                        cmd.Parameters.AddWithValue("@Section", cmbSection.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                    {
                        sql += " AND s.YearLevel = @YearLevel ";
                        cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(teacherProgram))
                    {
                        sql += " AND s.Course = @Course ";
                        cmd.Parameters.AddWithValue("@Course", teacherProgram);
                    }

                    sql += " ORDER BY s.LastName, s.FirstName ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.Parameters.AddWithValue("@DateTaken", date);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }

                dvgStudents.DataSource = dt;

                if (dvgStudents.Columns.Contains("StudentID")) dvgStudents.Columns["StudentID"].Visible = false;
                if (dvgStudents.Columns.Contains("AttendanceID")) dvgStudents.Columns["AttendanceID"].Visible = false;
                if (dvgStudents.Columns.Contains("FullName")) dvgStudents.Columns["FullName"].ReadOnly = true;

                ColorRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReloadData error:\n" + ex.Message);
            }
        }

        // section changed
        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            ReloadData();
        }

        // year changed
        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            ReloadData();
        }

        // subject changed
        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        // date changed
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        // grid edit commit
        private void dvgStudents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dvgStudents.IsCurrentCellDirty)
                dvgStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // cell changed
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
                MessageBox.Show("Error saving attendance:\n" + ex.Message);
            }
        }

        // save one row
        private void AutoSaveRow(int rowIndex)
        {
            if (cmbSubjects.DataSource == null || cmbSubjects.SelectedValue == null) return;

            DataGridViewRow row = dvgStudents.Rows[rowIndex];
            if (row.IsNewRow) return;

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
            if (string.IsNullOrWhiteSpace(status)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (attendanceId == 0)
                {
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

        // mark all present
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

        // grid style and status combo
        private void SetupGrid()
        {
            dvgStudents.AutoGenerateColumns = true;
            dvgStudents.AllowUserToAddRows = false;

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

        // row colors
        private void ColorRows()
        {
            try
            {
                foreach (DataGridViewRow row in dvgStudents.Rows)
                {
                    if (row.IsNewRow) continue;

                    string status = row.Cells["Status"].Value?.ToString() ?? "";

                    row.DefaultCellStyle.BackColor = status switch
                    {
                        "Present" => Color.FromArgb(220, 255, 220),
                        "Absent" => Color.FromArgb(255, 220, 220),
                        "Late" => Color.FromArgb(255, 245, 200),
                        _ => Color.White
                    };

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
    }
}
