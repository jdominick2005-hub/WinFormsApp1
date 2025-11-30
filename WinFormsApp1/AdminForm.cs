using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        private readonly string connectionString = @"Data Source=GERALD\SQLEXPRESS;Initial Catalog=AttendanceDB_v2;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
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
            if (Controls.ContainsKey("dateTimePicker1"))
            {
                var dtp = Controls["dateTimePicker1"] as DateTimePicker;
                if (dtp != null) dtp.Value = currentDate;
            }

            LoadDate(currentDate);

            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 15000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            ApplyKpiLabelLayout();
            MakeRoundedPanelSafe(panel5, 30);
            MakeRoundedPanelSafe(panel6, 30);
            MakeRoundedPanelSafe(panel4, 30);
            MakeRoundedPanelSafe(panel2, 30);
            Resize -= AdminForm_Resize;
            Resize += AdminForm_Resize;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadKpis(currentDate);
        }

        private void lblstudents_Click(object sender, EventArgs e)
        {
            ShowAllStudentsInGrid();
        }

        private void lblabsent_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Absent");
        }

        private void lblpresent_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Present");
        }

        private void lblprof_Click(object sender, EventArgs e)
        {
            ShowAllTeachersInGrid();
        }

        private void lblstudnum_Click(object sender, EventArgs e)
        {
            ShowAllStudentsInGrid();
        }

        private void lblprofnum_Click(object sender, EventArgs e)
        {
            ShowAllTeachersInGrid();
        }

        private void lblpresentnum_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Present");
        }

        private void lblabsentnum_Click(object sender, EventArgs e)
        {
            FilterGridByStatus("Absent");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            if (dtp == null) return;
            currentDate = dtp.Value.Date;
            LoadDate(currentDate);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chart clicked. You can implement drilldown here.", "Chart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                int totalStudents = ExecuteScalarInt("SELECT COUNT(*) FROM Students");
                if (lblstudnum != null) lblstudnum.Text = totalStudents.ToString();
                if (lblstudents != null) lblstudents.Text = "Total Students";

                int totalTeachers = ExecuteScalarInt("SELECT COUNT(*) FROM Teachers");
                if (lblprofnum != null) lblprofnum.Text = totalTeachers.ToString();
                if (lblprof != null) lblprof.Text = "Total Professors";

                int present = ExecuteScalarInt(
                    "SELECT COUNT(*) FROM Attendance WHERE DateTaken = @date AND Status = 'Present'",
                    new Dictionary<string, object> { { "@date", date } });
                if (lblpresentnum != null) lblpresentnum.Text = present.ToString();
                if (lblpresent != null) lblpresent.Text = "Present Today";

                int absent = ExecuteScalarInt(
                    "SELECT COUNT(*) FROM Attendance WHERE DateTaken = @date AND Status = 'Absent'",
                    new Dictionary<string, object> { { "@date", date } });
                if (lblabsentnum != null) lblabsentnum.Text = absent.ToString();
                if (lblabsent != null) lblabsent.Text = "Absent Today";
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

                var counts = new Dictionary<string, int> { { "Present", 0 }, { "Absent", 0 }, { "Late", 0 } };
                foreach (DataRow r in dt.Rows)
                {
                    string status = r["Status"].ToString();
                    int total = Convert.ToInt32(r["Total"]);
                    if (counts.ContainsKey(status)) counts[status] = total;
                    else counts[status] = total;
                }

                int totalAll = counts.Values.Sum();
                if (totalAll == 0) totalAll = 1;

                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                ChartArea area = new ChartArea("Main");
                area.AxisX.Enabled = AxisEnabled.False;
                area.AxisY.Enabled = AxisEnabled.False;
                chart1.ChartAreas.Add(area);

                Series series = new Series("Attendance")
                {
                    ChartType = SeriesChartType.Doughnut,
                    IsValueShownAsLabel = true,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                series["DoughnutRadius"] = "60";
                series["PieLabelStyle"] = "Outside";
                series.BorderWidth = 2;
                series.BorderColor = Color.White;

                foreach (var kvp in counts)
                {
                    int idx = series.Points.AddY(kvp.Value);
                    var pt = series.Points[idx];
                    int value = kvp.Value;
                    double percent = (double)value / totalAll * 100.0;
                    pt.AxisLabel = kvp.Key;
                    pt.Label = $"{value} ({Math.Round(percent)}%)";
                    pt.LegendText = kvp.Key;
                    pt.ToolTip = $"{kvp.Key}: {value} ({percent:F1}%)";
                }

                var colors = new[] { Color.FromArgb(72, 133, 199), Color.FromArgb(237, 125, 49), Color.FromArgb(165, 196, 61) };
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].Color = colors[i % colors.Length];
                }

                chart1.Series.Add(series);

                var legend = new Legend("Legend");
                legend.Docking = Docking.Bottom;
                legend.Alignment = StringAlignment.Center;
                chart1.Legends.Add(legend);

                chart1.ChartAreas[0].Position = new ElementPosition(10, 5, 80, 85);
                chart1.ChartAreas[0].InnerPlotPosition = new ElementPosition(15, 10, 70, 70);

                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating chart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                if (dataGridView1.DataSource is DataTable dt)
                {
                    DataView dv = new DataView(dt) { RowFilter = $"Status = '{status.Replace("'", "''")}'" };
                    dataGridView1.DataSource = dv;
                }
                else
                {
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

        private void MakeRoundedPanelSafe(Panel panel, int radius)
        {
            if (panel == null) return;
            panel.SuspendLayout();
            if (panel.Width == 0 || panel.Height == 0)
            {
                panel.ResumeLayout();
                panel.HandleCreated += (s, e) => MakeRoundedPanel(panel, radius);
            }
            else
            {
                MakeRoundedPanel(panel, radius);
                panel.ResumeLayout();
            }
        }

        private void MakeRoundedPanel(Panel panel, int radius)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        private void ApplyKpiLabelLayout()
        {
            try
            {
                LayoutKpiPanel(panel5, lblstudents, lblstudnum);
                LayoutKpiPanel(panel6, lblprof, lblprofnum);
                LayoutKpiPanel(panel4, lblpresent, lblpresentnum);
                LayoutKpiPanel(panel2, lblabsent, lblabsentnum);
            }
            catch { }
        }

        private void LayoutKpiPanel(Panel panel, Label titleLabel, Label numberLabel, int titleHeight = 28)
        {
            if (panel == null || titleLabel == null || numberLabel == null) return;
            if (titleLabel.Parent != panel) panel.Controls.Add(titleLabel);
            if (numberLabel.Parent != panel) panel.Controls.Add(numberLabel);
            titleLabel.AutoSize = false;
            numberLabel.AutoSize = false;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = titleHeight;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            numberLabel.Dock = DockStyle.Fill;
            numberLabel.TextAlign = ContentAlignment.MiddleCenter;
            numberLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            panel.Padding = new Padding(8);
        }

        private void AdminForm_Resize(object sender, EventArgs e)
        {
            ApplyKpiLabelLayout();
            MakeRoundedPanelSafe(panel5, 30);
            MakeRoundedPanelSafe(panel6, 30);
            MakeRoundedPanelSafe(panel4, 30);
            MakeRoundedPanelSafe(panel2, 30);
        }

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
            ManageForm manage = new ManageForm();
            manage.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm form = new UsersForm();
            form.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var login = new LoginForm();
                login.Show();
                Hide();
                login.FormClosed += (s, args) => Close();
            }
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm form = new ProfessorsForm();
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
