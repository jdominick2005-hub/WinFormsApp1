using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class AdminForm : Form
    {
        private readonly string connectionString = @"Data Source=GEMINI;Initial Catalog=AttendanceDB_v2;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;";
        private DateTime currentDate = DateTime.Today;
        private System.Windows.Forms.Timer refreshTimer;

        // ====== Win32 imports to remove DateTimePicker border ======
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;

        private void RemoveDatePickerBorder(DateTimePicker dtp)
        {
            if (dtp == null || dtp.IsHandleCreated == false) return;

            int style = GetWindowLong(dtp.Handle, GWL_EXSTYLE);
            style &= ~WS_EX_CLIENTEDGE;            // remove 3D client edge
            SetWindowLong(dtp.Handle, GWL_EXSTYLE, style);
            dtp.Refresh();
        }

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
            // set date picker if present
            if (Controls.ContainsKey("dateTimePicker1"))
            {
                var dtp = Controls["dateTimePicker1"] as DateTimePicker;
                if (dtp != null)
                {
                    dtp.Value = currentDate;
                    dtp.BackColor = Color.White;
                    dtp.CalendarMonthBackground = Color.White;
                    dtp.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

                    // remove border/outline
                    dtp.HandleCreated += (s, ev) => RemoveDatePickerBorder(dtp);
                    if (dtp.IsHandleCreated) RemoveDatePickerBorder(dtp);
                }
            }

            // initial load
            LoadDate(currentDate);

            // start refresh timer
            refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 15000
            };
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            // UI adjustments
            ApplyKpiLabelLayout();
            MakeRoundedPanelSafe(panel5, 30);
            MakeRoundedPanelSafe(panel6, 30);
            MakeRoundedPanelSafe(panel4, 30);
            MakeRoundedPanelSafe(panel2, 30);

            // keep layout responsive
            Resize -= AdminForm_Resize;
            Resize += AdminForm_Resize;

            // apply grid style once (also re-applied after every data bind)
            StyleDataGrid();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e) => LoadKpis(currentDate);

        // ---------------------------
        // KPI click handlers (drilldowns)
        // ---------------------------
        private void lblstudents_Click(object sender, EventArgs e) => ShowAllStudentsInGrid();
        private void lblstudnum_Click(object sender, EventArgs e) => ShowAllStudentsInGrid();

        private void lblprof_Click(object sender, EventArgs e) => ShowAllTeachersInGrid();
        private void lblprofnum_Click(object sender, EventArgs e) => ShowAllTeachersInGrid();

        private void lblpresent_Click(object sender, EventArgs e) => ShowEnrollmentsInGrid();
        private void lblpresentnum_Click(object sender, EventArgs e) => ShowEnrollmentsInGrid();

        private void lblabsent_Click(object sender, EventArgs e) => ShowStaffAccountsInGrid();
        private void lblabsentnum_Click(object sender, EventArgs e) => ShowStaffAccountsInGrid();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

        // ---------------------------
        // Main load functions
        // ---------------------------
        private void LoadDate(DateTime date)
        {
            currentDate = date;
            LoadKpis(date);
            LoadAttendanceGrid(date);
            UpdateAttendanceChart(date);
        }

        // KPIs: Total Students, Total Professors, Total Enrollments, Staff Accounts
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

                int totalEnrollments = ExecuteScalarInt("SELECT COUNT(*) FROM Enrollments");
                if (lblpresentnum != null) lblpresentnum.Text = totalEnrollments.ToString();
                if (lblpresent != null) lblpresent.Text = "Total Enrollments";

                int staffAccounts = ExecuteScalarInt("SELECT COUNT(*) FROM Logins WHERE Role IN ('Admin','Teacher')");
                if (lblabsentnum != null) lblabsentnum.Text = staffAccounts.ToString();
                if (lblabsent != null) lblabsent.Text = "Staff Accounts";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPIs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Attendance grid: entries for selected date
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
                if (dataGridView1.Columns.Contains("StudentID")) dataGridView1.Columns["StudentID"].Visible = false;
                if (dataGridView1.Columns.Contains("FirstName")) dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                if (dataGridView1.Columns.Contains("LastName")) dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                if (dataGridView1.Columns.Contains("SubjectName")) dataGridView1.Columns["SubjectName"].HeaderText = "Subject";
                if (dataGridView1.Columns.Contains("Status")) dataGridView1.Columns["Status"].HeaderText = "Status";

                dataGridView1.AutoResizeColumns();
                StyleDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance grid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Line chart: 12 months on X, Y fixed 0..100, values normalized to the max month
        private void UpdateAttendanceChart(DateTime date)
        {
            try
            {
                string sql = @"
            SELECT MONTH(DateRegistered) AS Month, COUNT(*) AS Total
            FROM Students
            GROUP BY MONTH(DateRegistered)
            ORDER BY MONTH(DateRegistered)";

                DataTable dt = GetDataTable(sql);

                int[] monthlyCounts = new int[12];

                foreach (DataRow row in dt.Rows)
                {
                    int month = Convert.ToInt32(row["Month"]);
                    int total = Convert.ToInt32(row["Total"]);
                    monthlyCounts[month - 1] = total;
                }

                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                ChartArea area = new ChartArea("MainArea");
                chart1.ChartAreas.Add(area);

                // X-axis: Jan to Dec
                string[] months =
                {
                    "Jan","Feb","Mar","Apr","May","Jun",
                    "Jul","Aug","Sep","Oct","Nov","Dec"
                };

                area.AxisX.Interval = 1;
                area.AxisX.CustomLabels.Clear();

                for (int i = 1; i <= 12; i++)
                    area.AxisX.CustomLabels.Add(i - 0.5, i + 0.5, months[i - 1]);

                // Remove "Months" title
                area.AxisX.Title = "";

                // Y-axis fixed 0–100
                area.AxisY.Minimum = 0;
                area.AxisY.Maximum = 100;
                area.AxisY.Interval = 10;
                area.AxisY.Title = "Registered Students";

                // Disable clicking
                try { chart1.Click -= chart1_Click; } catch { }

                // LINE SERIES
                Series series = new Series("Monthly Average")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 3,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 7,
                    Color = Color.RoyalBlue,
                    IsValueShownAsLabel = true
                };

                // Add RAW counts (NOT percentage)
                for (int i = 0; i < 12; i++)
                {
                    int value = monthlyCounts[i];
                    series.Points.AddXY(i + 1, value);
                }

                chart1.Series.Add(series);

                // LEGEND: ONLY show "Monthly Average"
                Legend legend = new Legend("Legend");
                legend.Docking = Docking.Bottom;
                legend.Alignment = StringAlignment.Center;
                legend.IsTextAutoFit = true;

                chart1.Legends.Add(legend);

                chart1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating chart: " + ex.Message);
            }
        }

        // ---------------------------
        // Grid drilldowns
        // ---------------------------
        private void ShowAllStudentsInGrid()
        {
            try
            {
                string sql = @"
            SELECT StudentID,
                   FirstName AS [First Name],
                   LastName AS [Last Name],
                   YearLevel AS [Year Level],
                   Course,
                   Section,
                   DateRegistered AS [Registered]
            FROM Students ORDER BY LastName, FirstName";

                dataGridView1.DataSource = GetDataTable(sql);

                // HIDE ID
                if (dataGridView1.Columns.Contains("StudentID"))
                    dataGridView1.Columns["StudentID"].Visible = false;

                StyleDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        // ======================= TEACHERS ===========================
        private void ShowAllTeachersInGrid()
        {
            try
            {
                string sql = @"
            SELECT t.TeacherID,
                   l.Username AS [Username],
                   l.FirstName AS [First Name],
                   l.LastName AS [Last Name],
                   t.Program,
                   t.Email
            FROM Teachers t
            JOIN Logins l ON t.UserID = l.UserID
            ORDER BY l.LastName, l.FirstName";

                dataGridView1.DataSource = GetDataTable(sql);

                // HIDE ID
                if (dataGridView1.Columns.Contains("TeacherID"))
                    dataGridView1.Columns["TeacherID"].Visible = false;

                StyleDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers: " + ex.Message);
            }
        }

        // ======================= ENROLLMENTS ===========================
        private void ShowEnrollmentsInGrid()
        {
            try
            {
                string sql = @"
            SELECT e.EnrollmentID,
                   s.StudentID,
                   (s.LastName + ', ' + s.FirstName) AS [Student Name],
                   sub.SubjectID,
                   sub.SubjectName AS [Subject],
                   CAST(e.DateEnrolled AS DATE) AS [Date Enrolled]
            FROM Enrollments e
            JOIN Students s ON e.StudentID = s.StudentID
            JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            ORDER BY e.DateEnrolled DESC";

                dataGridView1.DataSource = GetDataTable(sql);

                // HIDE IDS
                if (dataGridView1.Columns.Contains("EnrollmentID")) dataGridView1.Columns["EnrollmentID"].Visible = false;
                if (dataGridView1.Columns.Contains("StudentID")) dataGridView1.Columns["StudentID"].Visible = false;
                if (dataGridView1.Columns.Contains("SubjectID")) dataGridView1.Columns["SubjectID"].Visible = false;

                StyleDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading enrollments: " + ex.Message);
            }
        }

        // ======================= STAFF ACCOUNTS ===========================
        private void ShowStaffAccountsInGrid()
        {
            try
            {
                string sql = @"
            SELECT UserID,
                   Username AS [Username],
                   FirstName AS [First Name],
                   LastName AS [Last Name],
                   Role,
                   DateCreated AS [Created]
            FROM Logins
            WHERE Role = 'Teacher'
            ORDER BY LastName, FirstName";

                dataGridView1.DataSource = GetDataTable(sql);

                // HIDE ID
                if (dataGridView1.Columns.Contains("UserID"))
                    dataGridView1.Columns["UserID"].Visible = false;

                StyleDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff accounts: " + ex.Message);
            }
        }


        // ---------------------------
        // ADO.NET helpers
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
        // GRID STYLE (SteelBlue header, white titles, fill width)
        // ---------------------------
        private void StyleDataGrid()
        {
            if (dataGridView1 == null) return;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            // make columns fill the grid width
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 120, 180);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 242, 250);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
        }

        // ---------------------------
        // Rounded panels & KPI layout
        // ---------------------------
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

            // Ensure labels are children of the panel
            if (titleLabel.Parent != panel) panel.Controls.Add(titleLabel);
            if (numberLabel.Parent != panel) panel.Controls.Add(numberLabel);

            // Disable designer auto sizing/anchoring that might override runtime layout
            titleLabel.AutoSize = false;
            numberLabel.AutoSize = false;

            titleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numberLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Title at the top
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = titleHeight;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            titleLabel.Margin = new Padding(0);

            // Number fills remaining space BUT we add top padding so it sits LOWER
            numberLabel.Dock = DockStyle.Fill;
            numberLabel.TextAlign = ContentAlignment.MiddleCenter;
            numberLabel.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            numberLabel.Padding = new Padding(0, 18, 0, 0);

            panel.Padding = new Padding(6);

            panel.PerformLayout();
            numberLabel.Refresh();
            titleLabel.Refresh();
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

        // ---------------------------
        // Navigation button handlers
        // ---------------------------
        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm manage = new ManageForm();
            manage.Show();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            // optional home click behavior
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
