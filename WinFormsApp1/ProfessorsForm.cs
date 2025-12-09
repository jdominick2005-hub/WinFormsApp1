using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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

            // grid basic
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.MultiSelect = false;
            dgvTeachers.ReadOnly = true;
            dgvTeachers.AllowUserToAddRows = false;

            dgvTeachers.CellClick += dgvTeachers_CellClick;
            dgvTeachers.CellMouseEnter += dgvTeachers_CellMouseEnter;
            dgvTeachers.CellMouseLeave += dgvTeachers_CellMouseLeave;

            // nav buttons
            btnHome.Click += btnHome_Click;
            btnManage.Click += btnManage_Click;
            btnProfessors.Click += btnProfessors_Click;
            btnStudentRegistration.Click += btnStudentRegistration_Click;

            // crud buttons
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;

            // form events
            this.Load += ProfessorsForm_Load;          // first time
            this.Activated += ProfessorsForm_Activated; // auto-refresh when returning
        }

        // form load
        private void ProfessorsForm_Load(object sender, EventArgs e)
        {
            InitializeProgramCombo();
            RoundButtons();
            LoadTeachers();
        }

        // auto refresh
        private void ProfessorsForm_Activated(object sender, EventArgs e)
        {
            LoadTeachers();
        }

        // round buttons
        private void RoundButtons()
        {
            RoundButton(btnAdd, 20);
            RoundButton(btnUpdate, 20);
            RoundButton(btnDelete, 20);
        }

        private void RoundButton(Button btn, int radius)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = Color.White;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        // grid style
        private void StyleGrid()
        {
            dgvTeachers.EnableHeadersVisualStyles = false;
            dgvTeachers.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvTeachers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTeachers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvTeachers.ColumnHeadersHeight = 38;

            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.BorderStyle = BorderStyle.None;
            dgvTeachers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvTeachers.RowsDefaultCellStyle.BackColor = Color.White;
            dgvTeachers.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 249, 255);
            dgvTeachers.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvTeachers.DefaultCellStyle.SelectionForeColor = Color.White;
        }

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
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                return true;
            }

            return false;
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

                if (dgvTeachers.Columns.Contains("TeacherID"))
                    dgvTeachers.Columns["TeacherID"].Visible = false;

                if (dgvTeachers.Columns.Contains("UserID"))
                    dgvTeachers.Columns["UserID"].Visible = false;

                if (dgvTeachers.Columns.Contains("StudentID"))
                    dgvTeachers.Columns["StudentID"].Visible = false;

                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers:\n" + ex.Message);
            }
        }

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

        private void dgvTeachers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTeachers.Rows[e.RowIndex];
            if (row.Tag == null)
                row.Tag = row.DefaultCellStyle.BackColor;
            if (!row.Selected)
                row.DefaultCellStyle.BackColor = Color.FromArgb(230, 238, 255);
        }

        private void dgvTeachers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTeachers.Rows[e.RowIndex];
            if (!row.Selected && row.Tag is Color original)
                row.DefaultCellStyle.BackColor = original;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            string defaultPassword = "coi123";

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

                SendCredentialsEmail(txtEmail.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    txtUsername.Text.Trim(),
                    defaultPassword);

                MessageBox.Show("Teacher added successfully! Credentials sent via email.");
                LoadTeachers();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show("Error adding teacher:\n" + ex.Message);
            }
        }

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
        }
    }
}




