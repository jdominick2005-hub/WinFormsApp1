using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucClass : UserControl
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        private int teacherID;
        private string teacherProgram = ""; // default program (used as initial selection only)

        // --- AUTO REFRESH (3 seconds) ---
        private System.Windows.Forms.Timer autoRefreshTimer;
        private const int autoRefreshIntervalMs = 3000; // 3 seconds
        // --------------------------------

        public ucClass(int currentTeacherId)
        {
            InitializeComponent();

            teacherID = currentTeacherId;

            LoadTeacherProgram();   // get default Program from Teachers table (if any)
            LoadPrograms();         // fill cmbprogram with available programs for this teacher
            LoadYearLevels();       // from Subjects of this teacher (will use cmbprogram selection)

            // wire events
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            cmbsubjects.SelectedIndexChanged += cmbsubjects_SelectedIndexChanged;
            cmbprogram.SelectedIndexChanged += cmbprogram_SelectedIndexChanged;

            // initial selections
            if (cmbprogram.Items.Count > 0)
            {
                // set default selection to teacherProgram if it exists, otherwise first program
                if (!string.IsNullOrWhiteSpace(teacherProgram) && cmbprogram.Items.Contains(teacherProgram))
                    cmbprogram.SelectedItem = teacherProgram;
                else
                    cmbprogram.SelectedIndex = 0;
            }

            if (cmbYearLevel.Items.Count > 0)
                cmbYearLevel.SelectedIndex = 0;

            // Setup auto-refresh, but start only when visible
            autoRefreshTimer = new System.Windows.Forms.Timer();
            autoRefreshTimer.Interval = autoRefreshIntervalMs;
            autoRefreshTimer.Tick += (s, e) =>
            {
                try
                {
                    // Refresh all visible data
                    LoadSubjects();
                    LoadStudentsToGrid();
                    ShowTotalStudents();
                    ShowSchedule();
                }
                catch
                {
                    // swallow exceptions to avoid crashing UI on tick errors
                }
            };

            this.VisibleChanged += UcClass_VisibleChanged;
            if (this.Visible)
                autoRefreshTimer.Start();
        }

        // get teacher program (BSIT, BSCS, etc.) as a default hint (do NOT lock)
        private void LoadTeacherProgram()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Program FROM Teachers WHERE TeacherID = @TID", con))
                {
                    cmd.Parameters.AddWithValue("@TID", teacherID);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    teacherProgram = result?.ToString() ?? "";
                }
            }
            catch
            {
                teacherProgram = "";
            }
        }

        // load distinct programs (Course) available for this teacher from Subjects table
        private void LoadPrograms()
        {
            try
            {
                string query = @"
                    SELECT DISTINCT Course
                    FROM Subjects
                    WHERE TeacherID = @TID
                    ORDER BY Course";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TID", teacherID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    cmbprogram.Items.Clear();
                    while (dr.Read())
                    {
                        var course = dr["Course"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(course) && !cmbprogram.Items.Contains(course))
                            cmbprogram.Items.Add(course);
                    }
                }

                // If no programs were found from Subjects, fall back to teacherProgram (if any)
                if (cmbprogram.Items.Count == 0 && !string.IsNullOrWhiteSpace(teacherProgram))
                {
                    cmbprogram.Items.Add(teacherProgram);
                }

                // If still empty, you may want to add a default like "All Programs" (optional)
                if (cmbprogram.Items.Count == 0)
                    cmbprogram.Items.Add("All Programs");
            }
            catch
            {
                // ignore load errors; leave cmbprogram as-is
            }
        }

        // load year levels from Subjects for selected program and this teacher
        private void LoadYearLevels()
        {
            string query = @"
                SELECT DISTINCT YearLevel 
                FROM Subjects 
                WHERE TeacherID = @TID";

            if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                query += " AND Course = @Course ";

            query += " ORDER BY YearLevel";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                    cmd.Parameters.AddWithValue("@Course", cmbprogram.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbYearLevel.Items.Clear();

                while (dr.Read())
                    cmbYearLevel.Items.Add(dr["YearLevel"].ToString());
            }

            if (cmbYearLevel.Items.Count > 0)
                cmbYearLevel.SelectedIndex = 0;
        }

        // load sections from Subjects for this teacher (+program and optionally year)
        private void LoadSections()
        {
            string query = @"
                SELECT DISTINCT Section
                FROM Subjects
                WHERE TeacherID = @TID";

            if (!string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                query += " AND YearLevel = @YearLevel ";

            if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                query += " AND Course = @Course ";

            query += " ORDER BY Section";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                if (!string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                    cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                    cmd.Parameters.AddWithValue("@Course", cmbprogram.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbSections.Items.Clear();

                // Add an option to show all sections for the selected year
                cmbSections.Items.Add("All Sections");

                while (dr.Read())
                    cmbSections.Items.Add(dr["Section"].ToString());
            }

            // default to All Sections if available
            if (cmbSections.Items.Count > 0)
                cmbSections.SelectedIndex = 0;
        }

        // load subjects filtered by Teacher + Year + Section + Program (uses cmbprogram.Text)
        private void LoadSubjects()
        {
            cmbsubjects.Items.Clear();

            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                return;

            string query = @"
                SELECT DISTINCT SubjectName
                FROM Subjects
                WHERE TeacherID = @TID
                  AND YearLevel = @YearLevel";

            bool filterSection = !string.IsNullOrWhiteSpace(cmbSections.Text) && cmbSections.Text != "All Sections";
            if (filterSection)
                query += " AND Section = @Section ";

            if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                query += " AND Course = @Course ";

            query += " ORDER BY SubjectName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                if (filterSection)
                    cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                    cmd.Parameters.AddWithValue("@Course", cmbprogram.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    cmbsubjects.Items.Add(dr["SubjectName"].ToString());
            }

            if (cmbsubjects.Items.Count > 0)
                cmbsubjects.SelectedIndex = 0;
            else
            {
                txtSchedule.Text = "";
            }
        }

        // show schedule for selected subject (uses cmbprogram.Text)
        private void ShowSchedule()
        {
            if (string.IsNullOrWhiteSpace(cmbsubjects.Text))
            {
                txtSchedule.Text = "";
                return;
            }

            string query = @"
                SELECT Schedule
                FROM Subjects
                WHERE TeacherID   = @TID
                  AND SubjectName = @SubName
                  AND YearLevel   = @YearLevel";

            bool filterSection = !string.IsNullOrWhiteSpace(cmbSections.Text) && cmbSections.Text != "All Sections";
            if (filterSection)
                query += " AND Section = @Section ";

            if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                query += " AND Course = @Course ";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                cmd.Parameters.AddWithValue("@SubName", cmbsubjects.Text);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                if (filterSection)
                    cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                if (!string.IsNullOrWhiteSpace(cmbprogram.Text) && cmbprogram.Text != "All Programs")
                    cmd.Parameters.AddWithValue("@Course", cmbprogram.Text);

                con.Open();
                object sched = cmd.ExecuteScalar();
                txtSchedule.Text = sched?.ToString() ?? "No schedule found";
            }
        }

        // show total students (by Year + Section + Program). If All Sections chosen, count by Year + Program only.
        private void ShowTotalStudents()
        {
            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text))
            {
                txtTotal.Text = "0";
                return;
            }

            bool allSections = cmbSections.Text == "All Sections" || string.IsNullOrWhiteSpace(cmbSections.Text);
            bool allPrograms = string.IsNullOrWhiteSpace(cmbprogram.Text) || cmbprogram.Text == "All Programs";

            string query;
            if (allSections)
            {
                query = @"
                    SELECT COUNT(*) 
                    FROM Students
                    WHERE YearLevel = @YearLevel";

                if (!allPrograms)
                    query += " AND Course = @Course";
            }
            else
            {
                query = @"
                    SELECT COUNT(*) 
                    FROM Students
                    WHERE YearLevel = @YearLevel
                      AND Section   = @Section";

                if (!allPrograms)
                    query += " AND Course = @Course";
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                if (!allSections)
                    cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                if (!(string.IsNullOrWhiteSpace(cmbprogram.Text) || cmbprogram.Text == "All Programs"))
                    cmd.Parameters.AddWithValue("@Course", cmbprogram.Text);

                con.Open();
                int total = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                txtTotal.Text = total.ToString();
            }
        }

        // load students to grid (by Year + Section + Program). If All Sections, show all sections for that year.
        private void LoadStudentsToGrid()
        {
            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text))
            {
                dgvClass.DataSource = null;
                return;
            }

            bool allSections = cmbSections.Text == "All Sections" || string.IsNullOrWhiteSpace(cmbSections.Text);
            bool allPrograms = string.IsNullOrWhiteSpace(cmbprogram.Text) || cmbprogram.Text == "All Programs";

            string query;
            if (allSections)
            {
                query = @"
                    SELECT 
                        FirstName AS [First Name],
                        LastName  AS [Last Name],
                        Classification,
                        YearLevel,
                        Section,
                        Course
                    FROM Students
                    WHERE YearLevel = @YearLevel";

                if (!allPrograms)
                    query += " AND Course = @Course";

                query += " ORDER BY LastName, FirstName";
            }
            else
            {
                query = @"
                    SELECT 
                        FirstName AS [First Name],
                        LastName  AS [Last Name],
                        Classification
                    FROM Students
                    WHERE YearLevel = @YearLevel
                      AND Section   = @Section";

                if (!allPrograms)
                    query += " AND Course = @Course";

                query += " ORDER BY LastName, FirstName";
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                if (!allSections)
                    da.SelectCommand.Parameters.AddWithValue("@Section", cmbSections.Text);
                if (!allPrograms)
                    da.SelectCommand.Parameters.AddWithValue("@Course", cmbprogram.Text);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvClass.DataSource = dt;
            }
        }

        // events
        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
            ShowSchedule();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the year changes, reload sections for that year and reset dependent controls
            LoadSections();        // will select "All Sections" by default
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
            ShowSchedule();
        }

        private void cmbsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSchedule();
        }

        private void cmbprogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when program selection changes, reload dependent lists using the selected program
            LoadYearLevels();
            LoadSections();
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
            ShowSchedule();
        }

        private void pnlFilters_Paint(object sender, PaintEventArgs e)
        {

        }

        // VisibleChanged handler to start/stop timer
        private void UcClass_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                    autoRefreshTimer?.Start();
                else
                    autoRefreshTimer?.Stop();
            }
            catch
            {
                // ignore errors here
            }
        }
    }
}
