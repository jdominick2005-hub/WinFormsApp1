using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class ProfessorsForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;
        private object txtTeacherId;

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

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRegisteredProf.DataSource = dt;

                    if (dgvRegisteredProf.Columns.Contains("TeacherID"))
                        dgvRegisteredProf.Columns["TeacherID"].Visible = false;

                    dgvRegisteredProf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegisteredProf.ReadOnly = true;
                    dgvRegisteredProf.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    MessageBox.Show("Professor account successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProfessors(); // Refresh DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding account:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dgvRegisteredProf.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a professor first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected row data
            string fullName = dgvRegisteredProf.SelectedRows[0].Cells["FullName"].Value.ToString();
            string email = dgvRegisteredProf.SelectedRows[0].Cells["Email"].Value.ToString();
            string username = dgvRegisteredProf.SelectedRows[0].Cells["Username"].Value.ToString();

            // Get password from database
            string password = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password FROM Logins WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                password = cmd.ExecuteScalar()?.ToString();
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password not found for this user.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("AttendanceSystem.test@outlook.com");
                msg.To.Add(email);
                msg.Subject = "Your Faculty Account Has Been Created";

                msg.Body =
                    $"Hello {fullName},\n\n" +
                    "Your faculty account has been successfully created.\n\n" +
                    "Here are your login credentials:\n" +
                    $"• Username: {username}\n" +
                    $"• Password: {password}\n\n" +
                    "You may now log in to the system using these credentials. " +
                    "If you did not request this account, please contact the administrator immediately.\n\n" +
                    "Regards,\n" +
                    "Admin Team";

                SmtpClient client = new SmtpClient("", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                    "AttendanceSystem.test@outlook.com",
                    "spblmrrgadotcvkj"
                );

                client.Send(msg);

                MessageBox.Show("Account notification email sent!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email:\n" + ex.Message, "Email Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            ManageForm manage = new ManageForm();
            manage.Show();
            this.Hide();
        }

        private void btnProfessors_Click(object sender, EventArgs e)
        {
            ProfessorsForm proffesors = new ProfessorsForm();
            proffesors.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersForm users = new UsersForm();
            users.Show();
            this.Hide();
        }
        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            StudentRegistration StudentRegister = new StudentRegistration();
            StudentRegister.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRegisteredProf.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRegisteredProf.SelectedRows[0];

                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Password FROM Logins WHERE Username=@Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    object result = cmd.ExecuteScalar();
                    txtPassword.Text = result?.ToString() ?? "";
                }

                txtFullName.Enabled = true;
                txtDepartment.Enabled = true;
                txtEmail.Enabled = true;
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;

                MessageBox.Show("You can now edit the fields. Click UPDATE to save changes.");
            }
            else
            {
                MessageBox.Show("Please select a professor FullName first.");
            }
        }

        private void dgvRegisteredProf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRegisteredProf.Rows[e.RowIndex];

               
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtDepartment.Text = row.Cells["Department"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();

                // Load password from database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Password FROM Logins WHERE Username=@Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    txtPassword.Text = cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please select a professor FullName to update.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get the TeacherID from FullName
                string getTeacherIdQuery = "SELECT TeacherID FROM Teachers WHERE FullName=@FullName";
                SqlCommand cmdGet = new SqlCommand(getTeacherIdQuery, conn);
                cmdGet.Parameters.AddWithValue("@FullName", txtFullName.Text);
                object result = cmdGet.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Professor not found in database.");
                    return;
                }

                int teacherId = Convert.ToInt32(result);

                // Update only fields that are not empty
                if (!string.IsNullOrWhiteSpace(txtDepartment.Text))
                {
                    string updateTeacher = "UPDATE Teachers SET Department=@Department WHERE TeacherID=@TeacherID";
                    SqlCommand cmd = new SqlCommand(updateTeacher, conn);
                    cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    string updateTeacher = "UPDATE Teachers SET Email=@Email WHERE TeacherID=@TeacherID";
                    SqlCommand cmd = new SqlCommand(updateTeacher, conn);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmd.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    string updateLogin = "UPDATE Logins SET Username=@Username WHERE UserID=(SELECT UserID FROM Teachers WHERE TeacherID=@TeacherID)";
                    SqlCommand cmdLogin = new SqlCommand(updateLogin, conn);
                    cmdLogin.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmdLogin.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmdLogin.ExecuteNonQuery();
                }

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    string updateLogin = "UPDATE Logins SET Password=@Password WHERE UserID=(SELECT UserID FROM Teachers WHERE TeacherID=@TeacherID)";
                    SqlCommand cmdLogin = new SqlCommand(updateLogin, conn);
                    cmdLogin.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmdLogin.Parameters.AddWithValue("@TeacherID", teacherId);
                    cmdLogin.ExecuteNonQuery();
                }

                MessageBox.Show("Professor updated successfully!");
                LoadProfessors(); // Refresh DataGridView
            }
        }
      }
}

