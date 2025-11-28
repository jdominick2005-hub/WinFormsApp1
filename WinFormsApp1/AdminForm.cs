using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        private readonly string connectionString = @"Server=.\SQLEXPRESS;Database=AttendanceDB_v2;Trusted_Connection=True;";

        private DateTime currentDate = DateTime.Today;
        private System.Windows.Forms.Timer refreshTimer;
        public AdminForm(string name)
        {
            InitializeComponent();
            lblUserName.Text = name?.ToUpper();
        }

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // initialize current date from the date picker if present
            if (this.Controls.ContainsKey("dateTimePicker1"))
            {
                var dtp = this.Controls["dateTimePicker1"] as DateTimePicker;
                if (dtp != null)
                {
                    dtp.Value = currentDate;
                }
            }

            // initial load
            LoadDate(currentDate);

            // start refresh timer (fallback)
            refreshTimer = new System.Windows.Forms.Timer(); refreshTimer.Interval = 15000; // 15s
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // lightweight refresh of counts for current date
            LoadKpis(currentDate);
        }

        // ---------------------------
        // Event handlers you requested
        // ---------------------------

        // label for total students (title) - optional click behavior
        private void lblstudents_Click(object sender, EventArgs e)
        {
            // show students list in the grid
            ShowAllStudentsInGrid();
        }

        // label for total absent (title)
        private void lblabsent_Click(object sender, EventArgs e)
        {
            // filter grid to absent for current date
            FilterGridByStatus("Absent");
        }

        // label for total present (title)
        private void lblpresent_Click(object sender, EventArgs e)
        {
            // filter grid to present for current date
            FilterGridByStatus("Present");
        }

        // label for professor (title)
        private void lblprof_Click(object sender, EventArgs e)
        {
            // show teachers/professors list in grid
            ShowAllTeachersInGrid();
        }

        // label for the number of students (number label)
        private void lblstudnum_Click(object sender, EventArgs e)
        {
            // drilldown: open students list
            ShowAllStudentsInGrid();
        }

        // label for the number of prof (number label)
        private void lblprofnum_Click(object sender, EventArgs e)
        {
            ShowAllTeachersInGrid();
        }

        // label for number of present (number label)
        private void lblpresentnum_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Present");
        }

        // label for number of absent (number label)
        private void lblabsentnum_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Absent");
        }

        // label for the data grid view - cell content click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // optional: handle actions like edit or view details if you add buttons to the grid
        }

        // panel for the date - DateTimePicker value changed
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dtp = sender as DateTimePicker;
                if (dtp == null) return;
                currentDate = dtp.Value.Date;
                LoadDate(currentDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Date change error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // panel for the chart click
        private void chart1_Click(object sender, EventArgs e)
        {
            // optional: you could change chart type or show details
            MessageBox.Show("Chart clicked. You can implement drilldown here.", "Chart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------------------------
        // Main loading functions
        // ---------------------------
        private void LoadDate(DateTime date)
        {
            currentDate = date;
            LoadKpis(date);
            LoadAttendanceGrid(date);
            UpdateAttendanceChart(date);
        }

        private void LoadKpis(DateTime date)
        {
            try
            {
                // Total students
                int totalStudents = ExecuteScalarInt("SELECT COUNT(*) FROM Students");
                lblstudnum.Text = totalStudents.ToString();
                // set title text if needed
                if (lblstudents != null) lblstudents.Text = "Total Students";

                // Total professors (Teachers table)
                int totalTeachers = ExecuteScalarInt("SELECT COUNT(*) FROM Teachers");
                lblprofnum.Text = totalTeachers.ToString();
                if (lblprof != null) lblprof.Text = "Total Professors";

                // Present for the date
                int present = ExecuteScalarInt(
                    "SELECT COUNT(*) FROM Attendance WHERE DateTaken = @date AND Status = 'Present'",
                    new Dictionary<string, object> { { "@date", date } });
                lblpresentnum.Text = present.ToString();
                if (lblpresent != null) lblpresent.Text = "Today's  Present";

                // Absent for the date
                int absent = ExecuteScalarInt(
                    "SELECT COUNT(*) FROM Attendance WHERE DateTaken = @date AND Status = 'Absent'",
                    new Dictionary<string, object> { { "@date", date } });
                lblabsentnum.Text = absent.ToString();
                if (lblabsent != null) lblabsent.Text = "Today's    Absent";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPIs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAttendanceGrid(DateTime date)
        {
            try
            {
                string sql = @"
                    SELECT a.AttendanceID, s.StudentID, s.FirstName, s.LastName, sub.SubjectName, a.Status, a.Remarks
                    FROM Attendance a
                    JOIN Students s ON a.StudentID = s.StudentID
                    JOIN Subjects sub ON a.SubjectID = sub.SubjectID
                    WHERE a.DateTaken = @date
                    ORDER BY sub.SubjectName, s.LastName, s.FirstName";
                DataTable dt = GetDataTable(sql, new Dictionary<string, object> { { "@date", date } });

                dataGridView1.DataSource = dt;

                // polish columns
                if (dataGridView1.Columns.Contains("AttendanceID")) dataGridView1.Columns["AttendanceID"].Visible = false;
                if (dataGridView1.Columns.Contains("StudentID")) dataGridView1.Columns["StudentID"].HeaderText = "ID";
                if (dataGridView1.Columns.Contains("FirstName")) dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                if (dataGridView1.Columns.Contains("LastName")) dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                if (dataGridView1.Columns.Contains("SubjectName")) dataGridView1.Columns["SubjectName"].HeaderText = "Subject";
                if (dataGridView1.Columns.Contains("Status")) dataGridView1.Columns["Status"].HeaderText = "Status";

                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance grid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAttendanceChart(DateTime date)
        {
            try
            {
                string sql = @"
                    SELECT Status, COUNT(*) AS Total
                    FROM Attendance
                    WHERE DateTaken = @date
                    GROUP BY Status";
                DataTable dt = GetDataTable(sql, new Dictionary<string, object> { { "@date", date } });

                // prepare counts (ensure zeros if missing)
                var counts = new Dictionary<string, int> { { "Present", 0 }, { "Absent", 0 }, { "Late", 0 } };
                foreach (DataRow r in dt.Rows)
                {
                    string status = r["Status"].ToString();
                    int total = Convert.ToInt32(r["Total"]);
                    counts[status] = total;
                }

                // clear and build chart
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                ChartArea area = new ChartArea("Main");
                chart1.ChartAreas.Add(area);
                area.AxisX.Interval = 1;
                area.AxisX.Title = "Status";
                area.AxisY.Title = "Count";

                Series series = new Series("Counts");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;

                series.Points.AddXY("Present", counts["Present"]);
                series.Points.AddXY("Absent", counts["Absent"]);
                series.Points.AddXY("Late", counts["Late"]);

                chart1.Series.Add(series);

                chart1.Legends.Clear();
                chart1.Legends.Add(new Legend("Legend") { Docking = Docking.Bottom });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating chart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------
        // Small helper actions
        // ---------------------------
        private void ShowAllStudentsInGrid()
        {
            try
            {
                string sql = "SELECT StudentID, FirstName, LastName, YearLevel, Course, Section FROM Students ORDER BY LastName, FirstName";
                DataTable dt = GetDataTable(sql, null);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowAllTeachersInGrid()
        {
            try
            {
                string sql = @"
                    SELECT t.TeacherID, l.Username, l.FirstName, l.LastName, t.Department, t.Email
                    FROM Teachers t
                    JOIN Logins l ON t.UserID = l.UserID
                    ORDER BY l.LastName, l.FirstName";
                DataTable dt = GetDataTable(sql, null);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterGridByStatus(string status)
        {
            try
            {
                // if grid is showing attendance results, apply DataView filter
                if (dataGridView1.DataSource is DataTable dt)
                {
                    DataView dv = new DataView(dt) { RowFilter = $"Status = '{status.Replace("'", "''")}'" };
                    dataGridView1.DataSource = dv;
                }
                else
                {
                    // fallback: reload attendance for current date filtered by status
                    string sql = @"
                        SELECT a.AttendanceID, s.StudentID, s.FirstName, s.LastName, sub.SubjectName, a.Status, a.Remarks
                        FROM Attendance a
                        JOIN Students s ON a.StudentID = s.StudentID
                        JOIN Subjects sub ON a.SubjectID = sub.SubjectID
                        WHERE a.DateTaken = @date AND a.Status = @status
                        ORDER BY sub.SubjectName, s.LastName, s.FirstName";
                    DataTable dt2 = GetDataTable(sql, new Dictionary<string, object> { { "@date", currentDate }, { "@status", status } });
                    dataGridView1.DataSource = dt2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering grid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------
        // Inline ADO.NET helpers
        // ---------------------------
        private int ExecuteScalarInt(string sql, Dictionary<string, object> parameters = null)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
            }
        }

        private DataTable GetDataTable(string sql, Dictionary<string, object> parameters = null)
        {
            var dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // ---------------------------
        // Cleanup
        // ---------------------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            try
            {
                if (refreshTimer != null)
                {
                    refreshTimer.Stop();
                    refreshTimer.Tick -= RefreshTimer_Tick;
                    refreshTimer.Dispose();
                    refreshTimer = null;
                }
            }
            catch { }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
