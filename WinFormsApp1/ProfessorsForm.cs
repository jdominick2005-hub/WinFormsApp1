using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WinFormsApp1
{
    public partial class ProfessorsForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        // Private variables to hold selected IDs instead of hidden TextBoxes
        private int selectedTeacherId = 0;
        private int selectedUserId = 0;

        public ProfessorsForm()
        {
            InitializeComponent();

            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.MultiSelect = false;

            btnManage.Click += btnManage_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnHome.Click += btnHome_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            dgvTeachers.CellClick += dgvTeachers_CellClick;

            LoadTeachers();
        }

        private void ShowOrCreateForm<T>() where T : Form, new()
        {
            var existing = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existing != null)
            {
                existing.Show();
                existing.BringToFront();
                existing.WindowState = FormWindowState.Normal;
            }
            else
            {
                var f = new T();
                f.Show();
            }

            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e) => ShowOrCreateForm<AdminForm>();
        private void btnManage_Click(object sender, EventArgs e) => ShowOrCreateForm<ManageForm>();
        private void btnProfessors_Click(object sender, EventArgs e)
        {
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }
        private void btnStudentRegistration_Click(object sender, EventArgs e) => ShowOrCreateForm<StudentRegistration>();

        private void LoadTeachers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"
                        SELECT
                            T.TeacherID,
                            CONCAT(L.FirstName, ' ', L.LastName) AS FullName,
                            L.Username,
                            T.Email,
                            T.Program,
                            L.UserID
                        FROM Teachers T
                        JOIN Logins L ON T.UserID = L.UserID
                    ";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTeachers.DataSource = dt;

                    if (dgvTeachers.Columns.Contains("TeacherID"))
                        dgvTeachers.Columns["TeacherID"].Visible = false;

                    if (dgvTeachers.Columns.Contains("UserID"))
                        dgvTeachers.Columns["UserID"].Visible = false;

                    dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTeachers.ReadOnly = true;
                    dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvTeachers.MultiSelect = false;
                    dgvTeachers.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load teachers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UsernameExists(string username, int excludeUserId = 0)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string q = "SELECT COUNT(1) FROM Logins WHERE Username = @username AND (@exclude = 0 OR UserID <> @exclude)";
                    using (SqlCommand cmd = new SqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@exclude", excludeUserId);
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return true;
            }
        }

        private async Task SendCredentialsEmailAsync(string to, string firstName, string lastName, string username, string password)
        {
            try
            {
                string fromEmail = "ashlydavin436@gmail.com";
                string appPassword = "dbirnjcvohejvtin";

                string fullName = $"{firstName} {lastName}";

                string htmlBody = $@"
<html>
<body style='font-family: Arial; padding: 15px;'>
    <h2>Hello {fullName},</h2>
    <p>Your teacher account has been created. Here are your login credentials:</p>

    <p><b>Username:</b> {username}</p>
    <p><b>Password:</b> {password}</p>

    <p style='color:red; font-weight:bold; margin-top:20px;'>
        This password is TEMPORARY.  
        Please change it immediately after logging in.
    </p>

    <p>Thank you!<br>School Administration</p>
</body>
</html>";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail, "School Admin");
                    mail.To.Add(to);
                    mail.Subject = "Your Teacher Account Login Credentials";
                    mail.Body = htmlBody;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(fromEmail, appPassword);

                        await smtp.SendMailAsync(mail); // <-- async
                    }
                }

                MessageBox.Show("Email sent to teacher successfully.", "Email Sent",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email sending failed:\n" + ex.Message, "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateProfessorInputs(requirePassword: true)) return;

            string username = txtUsername.Text.Trim();

            if (UsernameExists(username))
            {
                MessageBox.Show("Username already exists. Choose another.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trx = conn.BeginTransaction())
                {
                    try
                    {
                        string insertLogin = @"
                    INSERT INTO Logins (Username, Password, FirstName, LastName, Role)
                    VALUES (@username, @password, @fn, @ln, 'Teacher');
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                ";

                        int newUserId;
                        using (SqlCommand cmd = new SqlCommand(insertLogin, conn, trx))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                            newUserId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string insertTeacher = @"
                    INSERT INTO Teachers (UserID, Program, Email)
                    VALUES (@userid, @program, @mail);
                ";

                        using (SqlCommand cmd2 = new SqlCommand(insertTeacher, conn, trx))
                        {
                            cmd2.Parameters.AddWithValue("@userid", newUserId);

                            cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                            cmd2.ExecuteNonQuery();
                        }

                        trx.Commit();

                        MessageBox.Show("Teacher added successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await SendCredentialsEmailAsync
                             (
                            txtEmail.Text.Trim(),
                            txtFirstName.Text.Trim(),
                            txtLastName.Text.Trim(),
                            txtUsername.Text.Trim(),
                            txtPassword.Text.Trim()
                               );

                        LoadTeachers();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        try { trx.Rollback(); } catch { }
                        MessageBox.Show($"Add failed: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvTeachers.Rows[e.RowIndex];

            if (dgvTeachers.Columns.Contains("TeacherID"))
                selectedTeacherId = Convert.ToInt32(row.Cells["TeacherID"].Value);

            if (dgvTeachers.Columns.Contains("UserID"))
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
            txtPassword.Text = "";

            string full = row.Cells["FullName"].Value?.ToString() ?? "";
            SplitFullNameToFields(full);

            txtprogram.Text = row.Cells["Program"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void SplitFullNameToFields(string full)
        {
            if (string.IsNullOrWhiteSpace(full))
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                return;
            }

            var parts = full.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            txtFirstName.Text = parts.Length > 0 ? parts[0] : "";
            txtLastName.Text = parts.Length > 1 ? string.Join(" ", parts, 1, parts.Length - 1) : "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher row first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvTeachers_CellClick(this, new DataGridViewCellEventArgs(0, dgvTeachers.SelectedRows[0].Index));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0 || selectedTeacherId == 0)
            {
                MessageBox.Show("Select a teacher to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateProfessorInputs(requirePassword: false)) return;

            int userId = selectedUserId;
            int teacherId = selectedTeacherId;

            if (UsernameExists(txtUsername.Text.Trim(), excludeUserId: userId))
            {
                MessageBox.Show("Username already used by another account.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trx = conn.BeginTransaction())
                {
                    try
                    {
                        string updateLogin = @"
                            UPDATE Logins
                            SET Username = @username,
                                FirstName = @fn,
                                LastName = @ln
                            WHERE UserID = @uid;
                        ";

                        using (SqlCommand cmd = new SqlCommand(updateLogin, conn, trx))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("@uid", userId);
                            cmd.ExecuteNonQuery();
                        }

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            string updatePw = "UPDATE Logins SET Password = @pw WHERE UserID = @uid";

                            using (SqlCommand cmdPw = new SqlCommand(updatePw, conn, trx))
                            {
                                cmdPw.Parameters.AddWithValue("@pw", txtPassword.Text);
                                cmdPw.Parameters.AddWithValue("@uid", userId);
                                cmdPw.ExecuteNonQuery();
                            }
                        }

                        // UPDATE TEACHER TABLE
                        string updateTeacher = @"
    UPDATE Teachers
    SET Program = @program,
        Email = @mail
    WHERE TeacherID = @tid;
";

                        using (SqlCommand cmd2 = new SqlCommand(updateTeacher, conn, trx))
                        {
                            cmd2.Parameters.AddWithValue("@program", txtprogram.Text.Trim());  // REQUIRED - This was missing
                            cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                            cmd2.Parameters.AddWithValue("@tid", teacherId);

                            cmd2.ExecuteNonQuery();
                        }

                        trx.Commit();
                        MessageBox.Show("Teacher updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTeachers();
                    }
                    catch (Exception ex)
                    {
                        try { trx.Rollback(); } catch { }
                        MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int teacherId = selectedTeacherId;

            DialogResult confirm = MessageBox.Show("Delete this teacher?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdCredits = new SqlCommand(
                     "DELETE FROM TeacherCredits WHERE TeacherID = @tid", conn))
                    {
                        cmdCredits.Parameters.AddWithValue("@tid", teacherId);
                        cmdCredits.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdTeacher = new SqlCommand(
                        "DELETE FROM Teachers WHERE TeacherID = @tid", conn))
                    {
                        cmdTeacher.Parameters.AddWithValue("@tid", teacherId);
                        cmdTeacher.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Teacher deleted successfully.");
                LoadTeachers();
            }
        }

        private bool ValidateProfessorInputs(bool requirePassword)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtprogram.Text)  ||

                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill First Name, Last Name, Username, Program and Email.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (requirePassword && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required when creating a new teacher.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Enter a valid email address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch
            {
                return false;
            }
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtprogram.Clear();


            selectedTeacherId = 0;
            selectedUserId = 0;

            dgvTeachers.ClearSelection();

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

