using System.Configuration;
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
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kunin ang input mula sa form at tanggalin ang extra spaces
            string fullName = txtFullName.Text.Trim();       // Gagamitin ito bilang Name sa Logins
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string department = txtDepartment.Text.Trim();

            // Basic validation para siguradong walang kulang
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(department))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // INSERT sa Logins table (kailangan ang Name column)
                    string insertLogin = "INSERT INTO Logins (Username, Password, Name, Role) OUTPUT INSERTED.UserID " +
                                         "VALUES (@Username, @Password, @Name, 'Teacher')";
                    SqlCommand cmdLogin = new SqlCommand(insertLogin, conn);
                    cmdLogin.Parameters.AddWithValue("@Username", username);
                    cmdLogin.Parameters.AddWithValue("@Password", password);
                    cmdLogin.Parameters.AddWithValue("@Name", fullName); // Gamitin ang FullName bilang Name

                    int newUserID = (int)cmdLogin.ExecuteScalar(); // Kunin ang bagong UserID

                    // INSERT sa Teachers table gamit ang UserID
                    string insertTeacher = "INSERT INTO Teachers (UserID, FullName, Department, Email) " +
                                           "VALUES (@UserID, @FullName, @Department, @Email)";
                    SqlCommand cmdTeacher = new SqlCommand(insertTeacher, conn);
                    cmdTeacher.Parameters.AddWithValue("@UserID", newUserID);
                    cmdTeacher.Parameters.AddWithValue("@FullName", fullName);
                    cmdTeacher.Parameters.AddWithValue("@Department", department);
                    cmdTeacher.Parameters.AddWithValue("@Email", email);
                    cmdTeacher.ExecuteNonQuery();

                    MessageBox.Show("Professor account successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please enter a valid email address.", "Missing Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get credentials from App.config
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
                MessageBox.Show("Email sent successfully!", "Notification Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email:\n" + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtDepartment.Clear();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            dgvRegisteredProf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

