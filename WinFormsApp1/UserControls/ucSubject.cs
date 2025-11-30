using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucSubject : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;
        private int professorId;
        private string professorname;

        public ucSubject(string teacherName, int profId)
        {
            InitializeComponent();
            professorId = profId;

            txtprofessor.Text = professorname;
            LoadSections();
            cmbsection.SelectedIndexChanged += cmbSections_SelectedIndexChanged;
            LoadSubjectsForProfessor(professorId);
        }

        
        public void LoadSubjectsForProfessor(int professorId, string sectionFilter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT SubjectID, SubjectName, Section, Schedule, YearLevel, TeacherID
                             FROM Subjects
                             WHERE TeacherID = @TeacherID";

                    if (!string.IsNullOrEmpty(sectionFilter))
                    {
                        query += " AND Section = @Section";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TeacherID", professorId);

                    if (!string.IsNullOrEmpty(sectionFilter))
                    {
                        cmd.Parameters.AddWithValue("@Section", sectionFilter);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvsubjects.DataSource = dt;
                    dgvsubjects.AutoGenerateColumns = true;
                    dgvsubjects.ReadOnly = true;
                    dgvsubjects.AllowUserToAddRows = false;
                    dgvsubjects.AllowUserToDeleteRows = false;
                    dgvsubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvsubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvsubjects.Columns.Contains("SubjectID"))
                    {
                        dgvsubjects.Columns["SubjectID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }


        }

        public void LoadAllSubjects()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT SubjectID, SubjectName, Section, Schedule, YearLevel, TeacherID FROM Subjects";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvsubjects.DataSource = dt;
                    dgvsubjects.AutoGenerateColumns = true;
                    dgvsubjects.ReadOnly = true;
                    dgvsubjects.AllowUserToAddRows = false;
                    dgvsubjects.AllowUserToDeleteRows = false;
                    dgvsubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvsubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgvsubjects.Columns.Contains("SubjectID"))
                    {
                        dgvsubjects.Columns["SubjectID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }


        private void LoadSections()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT DISTINCT Section FROM Subjects WHERE TeacherID = @TeacherID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TeacherID", professorId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbsection.DataSource = dt;
                cmbsection.DisplayMember = "Section";
                cmbsection.ValueMember = "Section";
                cmbsection.SelectedIndex = -1;
            }
        }

        private void cmbSections_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        {
            if (cmbsection.SelectedIndex != -1)
            {
                string selectedSection = cmbsection.Text;
                LoadSubjectsForProfessor(professorId, selectedSection);
            }
        }

    }
}
}