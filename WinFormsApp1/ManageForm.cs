using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ManageForm : Form
    {
        // db string
        private readonly string cs =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        // state vars
        private int subjectID = 0;
        private readonly Color mainColor = Color.SteelBlue;

        // ctor form
        public ManageForm()
        {
            InitializeComponent();

            // Ensure handlers are not attached multiple times:
            // Unsubscribe then subscribe (safe even if designer already wired events).
            this.Load -= ManageFormLoad;
            this.Load += ManageFormLoad;

            this.Activated -= ManageFormLoad;
            this.Activated += ManageFormLoad;

            dgvProfessors.CellClick -= dgvProfessors_CellClick;
            dgvProfessors.CellClick += dgvProfessors_CellClick;

            dgvProfessors.CellMouseEnter -= dgvProfessors_CellMouseEnter;
            dgvProfessors.CellMouseEnter += dgvProfessors_CellMouseEnter;

            dgvProfessors.CellMouseLeave -= dgvProfessors_CellMouseLeave;
            dgvProfessors.CellMouseLeave += dgvProfessors_CellMouseLeave;

            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;

            btnupdate.Click -= btnupdate_Click;
            btnupdate.Click += btnupdate_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            btnHome.Click -= btnHome_Click;
            btnHome.Click += btnHome_Click;

            btnProfessors.Click -= btnProfessors_Click;
            btnProfessors.Click += btnProfessors_Click;

            btnManage.Click -= btnManage_Click;
            btnManage.Click += btnManage_Click;

            btnStudentRegistration.Click -= btnStudentRegistration_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;

            btnLogout.Click -= btnLogout_Click;
            btnLogout.Click += btnLogout_Click;
        }

        // load main
        private void ManageFormLoad(object sender, EventArgs e)
        {
            Round(btnAdd);
            Round(btnupdate);
            Round(btnDelete);

            LoadComboDefaults();
            LoadTeachers();
            LoadSubjects();
        }

        // combo data
        private void LoadComboDefaults()
        {
            cmbyearlevel.Items.Clear();
            cmbsection.Items.Clear();
            cmbcourse.Items.Clear();

            cmbyearlevel.Items.AddRange(new object[]
            {
                "1st Year","2nd Year","3rd Year","4th Year"
            });

            cmbsection.Items.AddRange(new object[] { "A", "B", "C" });

            // program list
            cmbcourse.Items.AddRange(new object[]
            {
                "BSIT","BSCS","BMMA","BSCpE"
            });
        }

        // round btn
        private void Round(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = mainColor;
            b.ForeColor = Color.White;

            var p = new System.Drawing.Drawing2D.GraphicsPath();
            p.AddArc(0, 0, 20, 20, 180, 90);
            p.AddArc(b.Width - 20, 0, 20, 20, 270, 90);
            p.AddArc(b.Width - 20, b.Height - 20, 20, 20, 0, 90);
            p.AddArc(0, b.Height - 20, 20, 20, 90, 90);
            p.CloseFigure();
            b.Region = new Region(p);
        }

        // load profs
        private void LoadTeachers()
        {
            using var c = new SqlConnection(cs);
            var da = new SqlDataAdapter(
                "SELECT TeacherID, CONCAT(L.FirstName,' ',L.LastName) AS Teacher " +
                "FROM Teachers T JOIN Logins L ON T.UserID=L.UserID " +
                "ORDER BY L.LastName", c);

            DataTable dt = new();
            da.Fill(dt);

            cmbProfessor.DataSource = dt;
            cmbProfessor.DisplayMember = "Teacher";
            cmbProfessor.ValueMember = "TeacherID";
            cmbProfessor.SelectedIndex = -1;
        }

        // load subs
        private void LoadSubjects()
        {
            using var c = new SqlConnection(cs);
            var da = new SqlDataAdapter(@"
                SELECT SubjectID,
                       SubjectName,
                       Schedule,
                       YearLevel,
                       Course AS Program,
                       Section,
                       CONCAT(L.FirstName,' ',L.LastName) AS Professor
                FROM Subjects S
                LEFT JOIN Teachers T ON S.TeacherID = T.TeacherID
                LEFT JOIN Logins L ON T.UserID = L.UserID
                ORDER BY SubjectName", c);

            DataTable dt = new();
            da.Fill(dt);

            dgvProfessors.DataSource = dt;

            if (dgvProfessors.Columns.Contains("SubjectID"))
                dgvProfessors.Columns["SubjectID"].Visible = false;

            // header texts (display only)
            dgvProfessors.Columns["SubjectName"].HeaderText = "Subject";
            dgvProfessors.Columns["Program"].HeaderText = "Program";
            dgvProfessors.Columns["Professor"].HeaderText = "Professor";

            dgvProfessors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProfessors.EnableHeadersVisualStyles = false;
            dgvProfessors.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvProfessors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfessors.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);
            dgvProfessors.ColumnHeadersHeight = 38;

            dgvProfessors.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProfessors.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 249, 255);
        }

        // pick row
        private void dgvProfessors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProfessors.Rows[e.RowIndex];

            // ✅ use real column name, NOT "Subject"
            subjectID = Convert.ToInt32(row.Cells["SubjectID"].Value);

            txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
            txtSchedule.Text = row.Cells["Schedule"].Value.ToString();
            cmbyearlevel.Text = row.Cells["YearLevel"].Value.ToString();
            cmbcourse.Text = row.Cells["Program"].Value.ToString();
            cmbsection.Text = row.Cells["Section"].Value.ToString();
            cmbProfessor.Text = row.Cells["Professor"].Value.ToString();
        }

        // hover in
        private void dgvProfessors_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvProfessors.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                Color.FromArgb(230, 238, 255);
        }

        // hover out
        private void dgvProfessors_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvProfessors.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        // check fields
        private bool Valid()
        {
            return
                !string.IsNullOrWhiteSpace(txtSubjectName.Text) &&
                !string.IsNullOrWhiteSpace(txtSchedule.Text) &&
                !string.IsNullOrWhiteSpace(cmbyearlevel.Text) &&
                !string.IsNullOrWhiteSpace(cmbcourse.Text) &&
                !string.IsNullOrWhiteSpace(cmbsection.Text) &&
                cmbProfessor.SelectedIndex != -1;
        }

        // add click - FIXED: explicit column list to avoid column-order/type mismatch
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                MessageBox.Show("Complete all fields.");
                return;
            }

            using var c = new SqlConnection(cs);

            // IMPORTANT: specify columns explicitly so values map correctly to columns.
            var cmd = new SqlCommand(@"
                INSERT INTO Subjects
                    (SubjectName, Schedule, YearLevel, Course, Section, TeacherID)
                VALUES
                    (@n, @sc, @y, @c, @s, @t);", c);

            // Use AddWithValue for simplicity but ensure SelectedValue for teacher is numeric
            cmd.Parameters.AddWithValue("@n", txtSubjectName.Text);
            cmd.Parameters.AddWithValue("@sc", txtSchedule.Text);
            cmd.Parameters.AddWithValue("@y", cmbyearlevel.Text);
            cmd.Parameters.AddWithValue("@c", cmbcourse.Text);
            cmd.Parameters.AddWithValue("@s", cmbsection.Text);

            // teacher id should be numeric; SelectedValue comes from LoadTeachers (TeacherID)
            object teacherVal = cmbProfessor.SelectedValue ?? DBNull.Value;
            cmd.Parameters.AddWithValue("@t", teacherVal);

            c.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Subject added successfully.");
            LoadSubjects();
            ClearForm();
        }

        // update click
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (subjectID == 0)
            {
                MessageBox.Show("Select a subject first.");
                return;
            }
            if (!Valid())
            {
                MessageBox.Show("Complete all fields.");
                return;
            }

            using var c = new SqlConnection(cs);
            var cmd = new SqlCommand(@"
                UPDATE Subjects SET
                    SubjectName = @n,
                    Schedule = @sc,
                    YearLevel = @y,
                    Course = @c,
                    Section = @s,
                    TeacherID = @t
                WHERE SubjectID = @id", c);

            cmd.Parameters.AddWithValue("@n", txtSubjectName.Text);
            cmd.Parameters.AddWithValue("@sc", txtSchedule.Text);
            cmd.Parameters.AddWithValue("@y", cmbyearlevel.Text);
            cmd.Parameters.AddWithValue("@c", cmbcourse.Text);
            cmd.Parameters.AddWithValue("@s", cmbsection.Text);
            cmd.Parameters.AddWithValue("@t", cmbProfessor.SelectedValue ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@id", subjectID);

            c.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Subject updated successfully.");
            LoadSubjects();
            ClearForm();
        }

        // delete click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (subjectID == 0)
            {
                MessageBox.Show("Select a subject first.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this subject?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using var c = new SqlConnection(cs);
            var cmd = new SqlCommand(
                "DELETE FROM Subjects WHERE SubjectID = @id", c);
            cmd.Parameters.AddWithValue("@id", subjectID);

            c.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("Subject deleted.");
            LoadSubjects();
            ClearForm();
        }

        // clear form
        private void ClearForm()
        {
            txtSubjectName.Clear();
            txtSchedule.Clear();
            cmbyearlevel.SelectedIndex = -1;
            cmbsection.SelectedIndex = -1;
            cmbcourse.SelectedIndex = -1;
            cmbProfessor.SelectedIndex = -1;
            subjectID = 0;
        }

        // home nav
        private void btnHome_Click(object sender, EventArgs e) => Open<AdminForm>();

        // prof nav
        private void btnProfessors_Click(object sender, EventArgs e) => Open<ProfessorsForm>();

        // manage nav
        private void btnManage_Click(object sender, EventArgs e) => LoadSubjects();

        // stud nav
        private void btnStudentRegistration_Click(object sender, EventArgs e) => Open<StudentRegistration>();

        // logout click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                login.FormClosed += (s, args) => this.Close();
                this.Hide();
            }
        }

        // open form
        private void Open<T>() where T : Form, new()
        {
            var f = Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
            f.Show();
            Hide();
        }
    }
}
