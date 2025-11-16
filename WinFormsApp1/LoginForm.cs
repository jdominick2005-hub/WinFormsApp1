using System.Configuration;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnlogin;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password.", "Missing Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT L.Role, L.Name, T.TeacherID
                FROM Logins L
                LEFT JOIN Teachers T ON L.UserID = T.UserID
                WHERE L.Username = @username AND L.Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.Read())
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string role = reader["Role"].ToString();
                        string name = reader["Name"].ToString();

                        MessageBox.Show($"Welcome, {name}!", "Login Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        if (role == "Admin")
                        {
                            AdminForm adminForm = new AdminForm(name);
                            adminForm.Show();
                        }
                        else if (role == "Teacher")
                        {
                            int teacherID = reader["TeacherID"] != DBNull.Value
                                ? Convert.ToInt32(reader["TeacherID"])
                                : 0;

                            if (teacherID == 0)
                            {
                                MessageBox.Show("Teacher account is not linked to Teachers table!",
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            TeacherPanelForm teacherForm = new TeacherPanelForm(name, teacherID);
                            teacherForm.Show(); // CHANGED FROM ShowDialog()
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtpassword.PasswordChar = '\0';
            }

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtpassword.PasswordChar = '*';
            }


        }
    }
}
