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
        private string teacherProgram = ""; // BSIT, BSCS, BMMAM, BSCpE

        public ucClass(int currentTeacherId)
        {
            InitializeComponent();

            teacherID = currentTeacherId;

            LoadTeacherProgram();   // get Program from Teachers table
            LoadYearLevels();       // from Subjects of this teacher
            LoadSections();         // from Subjects of this teacher

            // if you want, lock program to teacher’s Program
            cmbprogram.Items.Clear();
            if (!string.IsNullOrWhiteSpace(teacherProgram))
            {
                cmbprogram.Items.Add(teacherProgram);
                cmbprogram.SelectedIndex = 0;
                cmbprogram.Enabled = false;   // teacher program is fixed
            }

            // wire events
            cmbYearLevel.SelectedIndexChanged += cmbYearLevel_SelectedIndexChanged;
            cmbSections.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            cmbsubjects.SelectedIndexChanged += cmbsubjects_SelectedIndexChanged;
            cmbprogram.SelectedIndexChanged += cmbprogram_SelectedIndexChanged;

            // initial load if we have at least one year/section
            if (cmbYearLevel.Items.Count > 0)
                cmbYearLevel.SelectedIndex = 0;
            if (cmbSections.Items.Count > 0)
                cmbSections.SelectedIndex = 0;

            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
        }

        // get teacher program (BSIT, BSCS, etc.)
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

        // load sections from Subjects for this teacher (+program if set)
        private void LoadSections()
        {
            string query = @"
                SELECT DISTINCT Section
                FROM Subjects 
                WHERE TeacherID = @TID";

            if (!string.IsNullOrWhiteSpace(teacherProgram))
                query += " AND Course = @Course ";

            query += " ORDER BY Section";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                if (!string.IsNullOrWhiteSpace(teacherProgram))
                    cmd.Parameters.AddWithValue("@Course", teacherProgram);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbSections.Items.Clear();

                while (dr.Read())
                    cmbSections.Items.Add(dr["Section"].ToString());
            }
        }

        // load year levels from Subjects for this teacher (+program if set)
        private void LoadYearLevels()
        {
            string query = @"
                SELECT DISTINCT YearLevel 
                FROM Subjects 
                WHERE TeacherID = @TID";

            if (!string.IsNullOrWhiteSpace(teacherProgram))
                query += " AND Course = @Course ";

            query += " ORDER BY YearLevel";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                if (!string.IsNullOrWhiteSpace(teacherProgram))
                    cmd.Parameters.AddWithValue("@Course", teacherProgram);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                cmbYearLevel.Items.Clear();

                while (dr.Read())
                    cmbYearLevel.Items.Add(dr["YearLevel"].ToString());
            }
        }

        // load subjects filtered by Teacher + Year + Section + Program
        private void LoadSubjects()
        {
            cmbsubjects.Items.Clear();

            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text) ||
                string.IsNullOrWhiteSpace(cmbSections.Text))
                return;

            string query = @"
                SELECT SubjectName
                FROM Subjects
                WHERE TeacherID = @TID
                  AND YearLevel = @YearLevel
                  AND Section   = @Section";

            if (!string.IsNullOrWhiteSpace(teacherProgram))
                query += " AND Course = @Course ";

            query += " ORDER BY SubjectName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);

                if (!string.IsNullOrWhiteSpace(teacherProgram))
                    cmd.Parameters.AddWithValue("@Course", teacherProgram);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    cmbsubjects.Items.Add(dr["SubjectName"].ToString());
            }

            if (cmbsubjects.Items.Count > 0)
                cmbsubjects.SelectedIndex = 0;
        }

        // show schedule for selected subject
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
                  AND SubjectName = @SubName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TID", teacherID);
                cmd.Parameters.AddWithValue("@SubName", cmbsubjects.Text);

                con.Open();
                object sched = cmd.ExecuteScalar();
                txtSchedule.Text = sched?.ToString() ?? "No schedule found";
            }
        }

        // show total students (by Year + Section + Program)
        private void ShowTotalStudents()
        {
            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text) ||
                string.IsNullOrWhiteSpace(cmbSections.Text) ||
                string.IsNullOrWhiteSpace(teacherProgram))
            {
                txtTotal.Text = "0";
                return;
            }

            string query = @"
                SELECT COUNT(*) 
                FROM Students
                WHERE YearLevel = @YearLevel
                  AND Section   = @Section
                  AND Course    = @Course";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                cmd.Parameters.AddWithValue("@Section", cmbSections.Text);
                cmd.Parameters.AddWithValue("@Course", teacherProgram);

                con.Open();
                int total = (int)cmd.ExecuteScalar();
                txtTotal.Text = total.ToString();
            }
        }

        // load students to grid (by Year + Section + Program)
        private void LoadStudentsToGrid()
        {
            if (string.IsNullOrWhiteSpace(cmbYearLevel.Text) ||
                string.IsNullOrWhiteSpace(cmbSections.Text) ||
                string.IsNullOrWhiteSpace(teacherProgram))
            {
                dgvClass.DataSource = null;
                return;
            }

            string query = @"
                SELECT 
                    FirstName AS [First Name],
                    LastName  AS [Last Name],
                    Classification
                FROM Students
                WHERE YearLevel = @YearLevel
                  AND Section   = @Section
                  AND Course    = @Course
                ORDER BY LastName, FirstName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                da.SelectCommand.Parameters.AddWithValue("@Section", cmbSections.Text);
                da.SelectCommand.Parameters.AddWithValue("@Course", teacherProgram);

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
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
        }

        private void cmbsubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSchedule();
        }

        private void cmbprogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if you ever enable program switching:
            teacherProgram = cmbprogram.Text;
            LoadYearLevels();
            LoadSections();
            LoadSubjects();
            LoadStudentsToGrid();
            ShowTotalStudents();
        }
    }
}
