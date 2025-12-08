using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ProfessorsForm : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        private int selectedTeacherId = 0;
        private int selectedUserId = 0;

        public ProfessorsForm()
        {
            InitializeComponent();

            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.MultiSelect = false;
            dgvTeachers.CellClick += dgvTeachers_CellClick;

            btnHome.Click += btnHome_Click;
            btnManage.Click += btnManage_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            InitializeProgramCombo();
            LoadTeachers();
        }

        // Program options
        private void InitializeProgramCombo()
        {
            cmbprogram.Items.Clear();
            cmbprogram.Items.Add("BSIT");
            cmbprogram.Items.Add("BSCpE");
            cmbprogram.Items.Add("BSCS");
            cmbprogram.Items.Add("BMMA");
            cmbprogram.SelectedIndex = -1;
        }

        // Go home
        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm home = new AdminForm();
            home.Show();
            this.Hide();
        }

        // Go manage
        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm form = new ManageForm();
            form.Show();
            this.Hide();
        }

        // Stay here
        private void btnProfessors_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        // Go students
        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration form = new StudentRegistration();
            form.Show();
            this.Hide();
        }

        // Load teachers
        private void LoadTeachers()
        {
            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                string sql = @"
                    SELECT 
                        T.TeacherID,
                        L.UserID,
                        CONCAT(L.FirstName, ' ', L.LastName) AS FullName,
                        L.Username,
                        T.Email,
                        T.Program
                    FROM Teachers T
                    JOIN Logins L ON T.UserID = L.UserID";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTeachers.DataSource = dt;
                dgvTeachers.Columns["TeacherID"].Visible = false;
                dgvTeachers.Columns["UserID"].Visible = false;
                dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers:\n" + ex.Message);
            }
        }

        // Select row
        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTeachers.Rows[e.RowIndex];

            selectedTeacherId = Convert.ToInt32(row.Cells["TeacherID"].Value);
            selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

            string[] names = row.Cells["FullName"].Value.ToString().Split(' ');
            txtFirstName.Text = names[0];
            txtLastName.Text = string.Join(" ", names.Skip(1));

            txtUsername.Text = row.Cells["Username"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            cmbprogram.Text = row.Cells["Program"].Value.ToString();
        }

        // Edit button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher to edit.");
                return;
            }

            dgvTeachers_CellClick(this,
                new DataGridViewCellEventArgs(0, dgvTeachers.SelectedRows[0].Index));
        }

        // Validate fields
        private bool ValidateInputs(bool requirePassword)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(cmbprogram.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            return true;
        }

        // Check username
        private bool UsernameExists(string username, int excludeUserId = 0)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) FROM Logins 
                  WHERE Username=@u AND (@id=0 OR UserID<>@id)",
                conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@id", excludeUserId);

            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        // Add teacher
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(requirePassword: false)) return;

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trx = conn.BeginTransaction();

            try
            {
                int newUserId;
                using SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Logins (Username, Password, FirstName, LastName, Role)
                    VALUES (@u, @p, @fn, @ln, 'Teacher');
                    SELECT SCOPE_IDENTITY();",
                    conn, trx);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", "coi123");
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());

                newUserId = Convert.ToInt32(cmd.ExecuteScalar());

                using SqlCommand cmd2 = new SqlCommand(@"
                    INSERT INTO Teachers (UserID, Program, Email)
                    VALUES (@uid, @prog, @mail)",
                    conn, trx);
                cmd2.Parameters.AddWithValue("@uid", newUserId);
                cmd2.Parameters.AddWithValue("@prog", cmbprogram.Text.Trim());
                cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                cmd2.ExecuteNonQuery();

                trx.Commit();

                MessageBox.Show("Teacher added successfully!\nDefault password: coi123");
                LoadTeachers();
                ClearFields();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show("Error adding teacher:\n" + ex.Message);
            }
        }

        // Update teacher
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == 0 || selectedUserId == 0)
            {
                MessageBox.Show("Select a teacher first.");
                return;
            }

            if (!ValidateInputs(requirePassword: false)) return;

            if (UsernameExists(txtUsername.Text.Trim(), selectedUserId))
            {
                MessageBox.Show("Username already taken!");
                return;
            }

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trx = conn.BeginTransaction();

            try
            {
                using SqlCommand cmd = new SqlCommand(@"
                    UPDATE Logins SET
                        Username=@u,
                        FirstName=@fn,
                        LastName=@ln
                    WHERE UserID=@id",
                    conn, trx);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@id", selectedUserId);
                cmd.ExecuteNonQuery();

                using SqlCommand cmd2 = new SqlCommand(@"
                    UPDATE Teachers SET
                        Program=@prog,
                        Email=@mail
                    WHERE TeacherID=@tid",
                    conn, trx);
                cmd2.Parameters.AddWithValue("@prog", cmbprogram.Text.Trim());
                cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                cmd2.Parameters.AddWithValue("@tid", selectedTeacherId);
                cmd2.ExecuteNonQuery();

                trx.Commit();

                MessageBox.Show("Teacher updated successfully!");
                LoadTeachers();
                ClearFields();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show("Update failed:\n" + ex.Message);
            }
        }

        // Delete teacher
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == 0 || selectedUserId == 0)
            {
                MessageBox.Show("Select a teacher first.");
                return;
            }

            if (MessageBox.Show("Delete this teacher and their subjects?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trx = conn.BeginTransaction();

            try
            {
                using SqlCommand cmdCredits = new SqlCommand(
                    "DELETE FROM TeacherCredits WHERE TeacherID=@tid", conn, trx);
                cmdCredits.Parameters.AddWithValue("@tid", selectedTeacherId);
                cmdCredits.ExecuteNonQuery();

                using SqlCommand cmdSub = new SqlCommand(
                    "DELETE FROM Subjects WHERE TeacherID=@tid", conn, trx);
                cmdSub.Parameters.AddWithValue("@tid", selectedTeacherId);
                cmdSub.ExecuteNonQuery();

                using SqlCommand cmdT = new SqlCommand(
                    "DELETE FROM Teachers WHERE TeacherID=@tid", conn, trx);
                cmdT.Parameters.AddWithValue("@tid", selectedTeacherId);
                cmdT.ExecuteNonQuery();

                using SqlCommand cmdL = new SqlCommand(
                    "DELETE FROM Logins WHERE UserID=@uid", conn, trx);
                cmdL.Parameters.AddWithValue("@uid", selectedUserId);
                cmdL.ExecuteNonQuery();

                trx.Commit();

                MessageBox.Show("Teacher and related data deleted!");
                LoadTeachers();
                ClearFields();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show("Error deleting teacher:\n" + ex.Message);
            }
        }

        // Clear fields
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUsername.Clear();
            txtEmail.Clear();
            cmbprogram.SelectedIndex = -1;

            selectedTeacherId = 0;
            selectedUserId = 0;
            dgvTeachers.ClearSelection();
        }

        // Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();

                login.FormClosed += (s, args) =>
                {
                    this.Close();
                };

                this.Hide();
            }
        }

        // Program label
        private void lblPrograms_Click(object sender, EventArgs e)
        {
        }

        // Program change
        private void cmbprogram_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
