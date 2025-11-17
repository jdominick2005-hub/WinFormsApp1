using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace WinFormsApp1
{
    public partial class ProfessorsForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

        public ProfessorsForm()
        {
            InitializeComponent();
            this.Load += ProfessorsForm_Load;  // Load Data on Form Load
        }

        private void ProfessorsForm_Load(object sender, EventArgs e)
        {
            LoadProfessors();
        }

        private void LoadProfessors()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT T.TeacherID, T.FullName, T.Department, T.Email, L.Username 
                                     FROM Teachers T
                                     INNER JOIN Logins L ON T.UserID = L.UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRegisteredProf.DataSource = dt;   // Display data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadProfessors();   // Correct method
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string department = txtDepartment.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertLogin = "INSERT INTO Logins (Username, Password, Name, Role) " +
                                         "OUTPUT INSERTED.UserID VALUES (@Username, @Password, @Name, 'Teacher')";
                    SqlCommand cmdLogin = new SqlCommand(insertLogin, conn);
                    cmdLogin.Parameters.AddWithValue("@Username", username);
                    cmdLogin.Parameters.AddWithValue("@Password", password);
                    cmdLogin.Parameters.AddWithValue("@Name", fullName);

                    int newUserID = (int)cmdLogin.ExecuteScalar();

                    string insertTeacher = "INSERT INTO Teachers (UserID, FullName, Department, Email) " +
                                           "VALUES (@UserID, @FullName, @Department, @Email)";
                    SqlCommand cmdTeacher = new SqlCommand(insertTeacher, conn);
                    cmdTeacher.Parameters.AddWithValue("@UserID", newUserID);
                    cmdTeacher.Parameters.AddWithValue("@FullName", fullName);
                    cmdTeacher.Parameters.AddWithValue("@Department", department);
                    cmdTeacher.Parameters.AddWithValue("@Email", email);
                    cmdTeacher.ExecuteNonQuery();

                    MessageBox.Show("Professor account successfully added!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProfessors(); // Refresh DataGrid after adding
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvRegisteredProf.SelectedRows.Count > 0)
            {
                int teacherId = Convert.ToInt32(dgvRegisteredProf.SelectedRows[0].Cells["TeacherID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this professor?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Step 1: Get UserID of the selected teacher
                        string getUserIdQuery = "SELECT UserID FROM Teachers WHERE TeacherID = @TeacherID";
                        SqlCommand cmdGetUserId = new SqlCommand(getUserIdQuery, conn);
                        cmdGetUserId.Parameters.AddWithValue("@TeacherID", teacherId);
                        object userIdObj = cmdGetUserId.ExecuteScalar();

                        if (userIdObj == null)
                        {
                            MessageBox.Show("Teacher not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int userId = (int)userIdObj;

                        // Step 2: Delete from Teachers table
                        string deleteTeacher = "DELETE FROM Teachers WHERE TeacherID = @TeacherID";
                        SqlCommand cmdTeacher = new SqlCommand(deleteTeacher, conn);
                        cmdTeacher.Parameters.AddWithValue("@TeacherID", teacherId);
                        cmdTeacher.ExecuteNonQuery();

                        // Step 3: Delete corresponding login ONLY if Role = 'Teacher'
                        string deleteLogin = "DELETE FROM Logins WHERE UserID = @UserID AND Role = 'Teacher'";
                        SqlCommand cmdLogin = new SqlCommand(deleteLogin, conn);
                        cmdLogin.Parameters.AddWithValue("@UserID", userId);
                        cmdLogin.ExecuteNonQuery();

                        MessageBox.Show("Professor deleted successfully!");
                        LoadProfessors(); // Refresh DataGrid
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a professor to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string recipientEmail = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(recipientEmail))
            {
                MessageBox.Show("Please enter a valid email address.", "Missing Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string senderEmail = ConfigurationManager.AppSettings["EmailAddress"];
                string senderPassword = ConfigurationManager.AppSettings["EmailPassword"];

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = "Your Professor Account Details";
                mail.Body = $"Hello {fullName},\n\n" +
                            $"Your account has been created successfully.\n\n" +
                            $"Username: {username}\nPassword: {password}\n\n" +
                            "You may now log in to the system.\n\n- Admin";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("Email sent successfully!", "Notification Sent",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email:\n" + ex.Message,
                    "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

