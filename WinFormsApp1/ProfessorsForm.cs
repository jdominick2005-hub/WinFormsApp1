using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            dgvTeachers.ReadOnly = true; // grid not inputable

            btnHome.Click += btnHome_Click;
            btnManage.Click += btnManage_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            InitializeProgramCombo();
            LoadTeachers();
        }

        // ---------------------- INITIAL SETUP -----------------------

        private void InitializeProgramCombo()
        {
            cmbprogram.Items.Clear();
            cmbprogram.Items.Add("BSIT");
            cmbprogram.Items.Add("BSCpE");
            cmbprogram.Items.Add("BSCS");
            cmbprogram.Items.Add("BMMA");
            cmbprogram.SelectedIndex = -1;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm home = new AdminForm();
            home.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm form = new ManageForm();
            form.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration form = new StudentRegistration();
            form.Show();
            this.Hide();
        }

        // ---------------------- VALIDATION -----------------------

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(cmbprogram.Text))
            {
                MessageBox.Show("Please complete all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

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

        // ---------------------- LOAD TEACHERS -----------------------

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
                dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // HIDE ID COLUMNS (TeacherID, UserID, and StudentID if ever present)
                if (dgvTeachers.Columns.Contains("TeacherID"))
                    dgvTeachers.Columns["TeacherID"].Visible = false;

                if (dgvTeachers.Columns.Contains("UserID"))
                    dgvTeachers.Columns["UserID"].Visible = false;

                if (dgvTeachers.Columns.Contains("StudentID"))
                    dgvTeachers.Columns["StudentID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers:\n" + ex.Message);
            }
        }

        // ---------------------- SELECT ROW -----------------------

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

        // ---------------------- ADD TEACHER -----------------------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            string defaultPassword = "coi123";   // FIXED DEFAULT PASSWORD

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
                cmd.Parameters.AddWithValue("@p", defaultPassword);
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

                // AUTO SEND EMAIL
                SendCredentialsEmail(txtEmail.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtUsername.Text.Trim(),
                    defaultPassword
                );

                MessageBox.Show("Teacher added successfully! Credentials sent via email.");
                LoadTeachers();
                ClearFields();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show("Error adding teacher:\n" + ex.Message);
            }
        }

        // ---------------------- EMAIL SENDER -----------------------

        private void SendCredentialsEmail(string to, string first, string last, string user, string pass)
        {
            try
            {
                string fromEmail = "ashlydavin436@gmail.com";
                string appPassword = "dbirnjcvohejvtin"; // Gmail App Password

                string fullName = first + " " + last;

                string htmlBody = $@"
                    <html>
                    <body style='font-family: Arial; padding: 15px;'>
                        <h2>Hello {fullName},</h2>
                        <p>Your account has been created. Here are your login details:</p>
                        <p><b>Username:</b> {user}</p>
                        <p><b>Password:</b> {pass}</p>
                        <br>
                        <p>Please keep this information secure.</p>
                    </body>
                    </html>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "School Admin");
                mail.To.Add(to);
                mail.Subject = "Your Login Credentials";
                mail.Body = htmlBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email:\n" + ex.Message);
            }
        }

        // ---------------------- UPDATE TEACHER -----------------------

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == 0 || selectedUserId == 0)
            {
                MessageBox.Show("Select a teacher first.");
                return;
            }

            if (!ValidateInputs()) return;

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

        // ---------------------- DELETE TEACHER -----------------------

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

        // ---------------------- CLEAR -----------------------

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

        // ---------------------- LOGOUT -----------------------

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

        private void dgvTeachers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
