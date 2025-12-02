using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics; // for Debug.WriteLine

namespace WinFormsApp1.UserControls
{
    public partial class ucSubject : UserControl
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;
        private readonly int professorId;
        private readonly string professorName;

        public ucSubject(string teacherName, int profId)
        {
            InitializeComponent();

            professorId = profId;
            professorName = teacherName;

            txtProfessor.Text = professorName;

            // Developer-only debug log (no popup for users)
            Debug.WriteLine($"ucSubject initialized with TeacherID={professorId}, Name={professorName}");

            // Subscribe event handler once
            cmbSection.SelectedIndexChanged += cmbSections_SelectedIndexChanged;

            // Load sections and subjects
            LoadSections();
            LoadSubjectsForProfessor(professorId, showDebug: false);
        }

        /// <summary>
        /// Loads subjects for the professor, optionally filtered by section.
        /// </summary>
        public void LoadSubjectsForProfessor(int professorId, string sectionFilter = "", bool showDebug = true)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT s.SubjectID, s.SubjectName, s.Section, s.Schedule, s.YearLevel
                        FROM Subjects s
                        INNER JOIN Teachers t ON s.TeacherID = t.TeacherID
                        WHERE t.TeacherID = @TeacherID";

                    if (!string.IsNullOrEmpty(sectionFilter))
                    {
                        query += " AND s.Section = @Section";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", professorId);

                        if (!string.IsNullOrEmpty(sectionFilter))
                        {
                            cmd.Parameters.AddWithValue("@Section", sectionFilter);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSubjects.DataSource = dt;
                        dgvSubjects.AutoGenerateColumns = true;
                        dgvSubjects.ReadOnly = true;
                        dgvSubjects.AllowUserToAddRows = false;
                        dgvSubjects.AllowUserToDeleteRows = false;
                        dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvSubjects.Columns.Contains("SubjectID"))
                        {
                            dgvSubjects.Columns["SubjectID"].Visible = false;
                        }

                        if (showDebug)
                        {
                            Debug.WriteLine($"Loaded {dt.Rows.Count} subjects for TeacherID {professorId} with section filter '{sectionFilter}'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads sections associated with the professor's subjects.
        /// </summary>
        private void LoadSections()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT DISTINCT s.Section
                        FROM Subjects s
                        INNER JOIN Teachers t ON s.TeacherID = t.TeacherID
                        WHERE t.TeacherID = @TeacherID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", professorId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Prevent event firing during DataSource assignment
                        cmbSection.SelectedIndexChanged -= cmbSections_SelectedIndexChanged;

                        cmbSection.DataSource = dt;
                        cmbSection.DisplayMember = "Section";
                        cmbSection.ValueMember = "Section";

                        // No initial selection
                        cmbSection.SelectedIndex = -1;

                        // Re-subscribe event after assignment
                        cmbSection.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sections: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler to filter subjects by section when a section is selected.
        /// </summary>
        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSection.SelectedIndex != -1)
            {
                string selectedSection = cmbSection.Text;
                LoadSubjectsForProfessor(professorId, selectedSection, showDebug: false);
            }
            else
            {
                LoadSubjectsForProfessor(professorId, showDebug: false);
            }
        }

        private void lblProfessor_Click(object sender, EventArgs e)
        {

        }

        private void lblSection_Click(object sender, EventArgs e)
        {

        }
    }
}