using System.Configuration;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

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
            SELECT 
                U.Role,
                CONCAT(U.FirstName, ' ', U.LastName) AS FullName,
                T.TeacherID
            FROM Logins U
            LEFT JOIN Teachers T ON U.UserID = T.UserID
            WHERE U.Username = @username
              AND U.Password = @password";

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
                        string name = reader["FullName"].ToString();

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
                                MessageBox.Show("Teacher account is not linked in Teachers table!",
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            TeacherPanelForm teacherForm = new TeacherPanelForm(name, teacherID);
                            teacherForm.Show();
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
