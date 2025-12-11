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
            if (dgvTeachers != null)
            {
                dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTeachers.MultiSelect = false;
                dgvTeachers.ReadOnly = true;
                dgvTeachers.AllowUserToAddRows = false;

                // Wire selection events so clicking anywhere on the row (body, header, selector) fills fields
                dgvTeachers.CellClick -= dgvTeachers_CellClick;
                dgvTeachers.CellClick += dgvTeachers_CellClick;

                dgvTeachers.RowHeaderMouseClick -= dgvTeachers_RowHeaderMouseClick;
                dgvTeachers.RowHeaderMouseClick += dgvTeachers_RowHeaderMouseClick;

                dgvTeachers.SelectionChanged -= dgvTeachers_SelectionChanged;
                dgvTeachers.SelectionChanged += dgvTeachers_SelectionChanged;

                dgvTeachers.CellMouseEnter -= dgvTeachers_CellMouseEnter;
                dgvTeachers.CellMouseEnter += dgvTeachers_CellMouseEnter;

                dgvTeachers.CellMouseLeave -= dgvTeachers_CellMouseLeave;
                dgvTeachers.CellMouseLeave += dgvTeachers_CellMouseLeave;
            }

            // nav buttons (ensure they hide this form when opening others)
            if (this.Controls.ContainsKey("btnHome")) { btnHome.Click -= btnHome_Click_1; btnHome.Click += btnHome_Click_1; }
            if (this.Controls.ContainsKey("btnManage")) { btnManage.Click -= btnManage_Click_1; btnManage.Click += btnManage_Click_1; }
            if (this.Controls.ContainsKey("btnStudentRegistration")) { btnStudentRegistration.Click -= btnStudentRegistration_Click_1; btnStudentRegistration.Click += btnStudentRegistration_Click_1; }

            // crud buttons
            if (this.Controls.ContainsKey("btnAdd")) { btnAdd.Click -= btnAdd_Click; btnAdd.Click += btnAdd_Click; }
            if (this.Controls.ContainsKey("btnUpdate")) { btnUpdate.Click -= btnUpdate_Click; btnUpdate.Click += btnUpdate_Click; }
            if (this.Controls.ContainsKey("btnDelete")) { btnDelete.Click -= btnDelete_Click; btnDelete.Click += btnDelete_Click; }

            if (this.Controls.ContainsKey("btnLogout")) { btnLogout.Click -= btnLogout_Click; btnLogout.Click += btnLogout_Click; }

            // form events
            this.Load -= ProfessorsForm_Load;
            this.Load += ProfessorsForm_Load;
            this.Activated -= ProfessorsForm_Activated;
            this.Activated += ProfessorsForm_Activated;
        }

        // form load
        private void ProfessorsForm_Load(object sender, EventArgs e)
        {
            InitializeProgramCombo();
            RoundButtons();
            LoadTeachers();
            UpdateButtonsState();
        }

        // auto refresh when the form becomes active
        private void ProfessorsForm_Activated(object sender, EventArgs e)
        {
            LoadTeachers();
            UpdateButtonsState();
        }

        // round buttons
        private void RoundButtons()
        {
            TryRound(btnAdd);
            TryRound(btnUpdate);
            TryRound(btnDelete);
        }

        private void TryRound(Button btn)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.SteelBlue;
            btn.ForeColor = Color.White;

            int radius = Math.Min(20, Math.Min(btn.Width, btn.Height));
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
            if (dgvTeachers == null) return;
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
            if (cmbprogram == null) return;
            cmbprogram.Items.Clear();
            cmbprogram.Items.Add("BSIT");
            cmbprogram.Items.Add("BSCpE");
            cmbprogram.Items.Add("BSCS");
            cmbprogram.Items.Add("BMMA");
            cmbprogram.SelectedIndex = -1;
        }

        private bool ValidateInputs()
        {
            if (txtFirstName == null || txtLastName == null || txtUsername == null || txtEmail == null || cmbprogram == null)
                return false;

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
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool UsernameExists(string username, int excludeUserId = 0)
        {
            try
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
            catch
            {
                // If query errors, avoid blocking user; treat as not exists
                return false;
            }
        }

        // ---------------- Load teachers ----------------
        private void LoadTeachers()
        {
            if (dgvTeachers == null) return;

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                string sql = @"
                    SELECT 
                        T.TeacherID,
                        L.UserID,
                        L.FirstName,
                        L.LastName,
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

                if (dgvTeachers.Columns.Contains("TeacherID")) dgvTeachers.Columns["TeacherID"].Visible = false;
                if (dgvTeachers.Columns.Contains("UserID")) dgvTeachers.Columns["UserID"].Visible = false;

                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers:\n" + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------- Selection/fill helpers ----------------

        // Centralized method that reads the row and fills the input fields
        private void FillFieldsFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            // guard against missing columns
            if (!dgvTeachers.Columns.Contains("TeacherID") || !dgvTeachers.Columns.Contains("UserID"))
                return;

            if (row.Cells["TeacherID"].Value == null || row.Cells["UserID"].Value == null)
            {
                selectedTeacherId = 0;
                selectedUserId = 0;
                UpdateButtonsState();
                return;
            }

            selectedTeacherId = Convert.ToInt32(row.Cells["TeacherID"].Value);
            selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

            // Prefer FirstName/LastName columns if present
            if (dgvTeachers.Columns.Contains("FirstName") && dgvTeachers.Columns.Contains("LastName"))
            {
                txtFirstName.Text = row.Cells["FirstName"].Value?.ToString() ?? "";
                txtLastName.Text = row.Cells["LastName"].Value?.ToString() ?? "";
            }
            else if (dgvTeachers.Columns.Contains("FullName"))
            {
                string full = row.Cells["FullName"].Value?.ToString() ?? "";
                string[] parts = full.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                txtFirstName.Text = parts.Length > 0 ? parts[0] : "";
                txtLastName.Text = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : "";
            }

            txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            cmbprogram.Text = row.Cells["Program"].Value?.ToString() ?? "";

            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = selectedTeacherId != 0 && selectedUserId != 0;
            if (this.Controls.ContainsKey("btnUpdate")) btnUpdate.Enabled = hasSelection;
            if (this.Controls.ContainsKey("btnDelete")) btnDelete.Enabled = hasSelection;
        }

        // Called when user clicks a cell (body)
        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            FillFieldsFromRow(dgvTeachers.Rows[e.RowIndex]);
        }

        // Called when user clicks the left row header (the side)
        private void dgvTeachers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            FillFieldsFromRow(dgvTeachers.Rows[e.RowIndex]);
        }

        // Called when selection changes (keyboard navigation or programmatic)
        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows != null && dgvTeachers.SelectedRows.Count > 0)
            {
                FillFieldsFromRow(dgvTeachers.SelectedRows[0]);
            }
        }

        private void dgvTeachers_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTeachers.Rows[e.RowIndex];
            if (row.Tag == null) row.Tag = row.DefaultCellStyle.BackColor;
            if (!row.Selected) row.DefaultCellStyle.BackColor = Color.FromArgb(230, 238, 255);
        }

        private void dgvTeachers_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvTeachers.Rows[e.RowIndex];
            if (!row.Selected && row.Tag is Color original) row.DefaultCellStyle.BackColor = original;
        }

        // ---------------- Add ----------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (UsernameExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username already exists!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string defaultPassword = "coi123";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trx = conn.BeginTransaction())
                {
                    try
                    {
                        int newUserId;
                        using (SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Logins (Username, Password, FirstName, LastName, Role)
                            VALUES (@u, @p, @fn, @ln, 'Teacher');
                            SELECT SCOPE_IDENTITY();", conn, trx))
                        {
                            cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@p", defaultPassword);
                            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());

                            newUserId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        using (SqlCommand cmd2 = new SqlCommand(@"
                            INSERT INTO Teachers (UserID, Program, Email)
                            VALUES (@uid, @prog, @mail)", conn, trx))
                        {
                            cmd2.Parameters.AddWithValue("@uid", newUserId);
                            cmd2.Parameters.AddWithValue("@prog", cmbprogram.Text.Trim());
                            cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                            cmd2.ExecuteNonQuery();
                        }

                        trx.Commit();

                        try
                        {
                            SendCredentialsEmail(txtEmail.Text.Trim(),
                                txtFirstName.Text.Trim(),
                                txtLastName.Text.Trim(),
                                txtUsername.Text.Trim(),
                                defaultPassword);
                        }
                        catch { }

                        MessageBox.Show("Teacher added successfully.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTeachers();

                        // Select the newly added row by username
                        SelectRowByUsername(txtUsername.Text.Trim());
                    }
                    catch (Exception ex)
                    {
                        try { trx.Rollback(); } catch { }
                        MessageBox.Show("Error adding teacher:\n" + ex.Message, "Add Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SelectRowByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return;
            for (int i = 0; i < dgvTeachers.Rows.Count; i++)
            {
                var row = dgvTeachers.Rows[i];
                if (row.Cells["Username"].Value?.ToString() == username)
                {
                    dgvTeachers.ClearSelection();
                    row.Selected = true;

                    // find first visible cell in this row (column visible AND cell visible)
                    int? visibleCellIndex = dgvTeachers.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c => c.Index)
                        .FirstOrDefault(idx =>
                        {
                            var cell = dgvTeachers.Rows[i].Cells[idx];
                            return cell != null && cell.Visible;
                        });

                    if (visibleCellIndex.HasValue)
                    {
                        dgvTeachers.CurrentCell = row.Cells[visibleCellIndex.Value];
                        dgvTeachers.FirstDisplayedScrollingRowIndex = i;
                    }

                    FillFieldsFromRow(row);
                    break;
                }
            }
        }

        // ---------------- Update ----------------
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == 0 || selectedUserId == 0)
            {
                MessageBox.Show("Select a teacher first.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validate before DB
            if (!ValidateInputs()) return;

            string username = txtUsername.Text.Trim();
            if (UsernameExists(username, selectedUserId))
            {
                MessageBox.Show("Username already taken!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Safely use transaction: commit then do UI refresh outside transaction, and only rollback if not committed.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trx = conn.BeginTransaction();
                bool committed = false;

                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"
                        UPDATE Logins
                        SET Username = @username,
                            FirstName = @first,
                            LastName = @last
                        WHERE UserID = @userid", conn, trx))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@first", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@last", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@userid", selectedUserId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(@"
                        UPDATE Teachers
                        SET Email = @mail,
                            Program = @prog
                        WHERE TeacherID = @teacherid", conn, trx))
                    {
                        cmd2.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                        cmd2.Parameters.AddWithValue("@prog", cmbprogram.Text.Trim());
                        cmd2.Parameters.AddWithValue("@teacherid", selectedTeacherId);
                        cmd2.ExecuteNonQuery();
                    }

                    trx.Commit();
                    committed = true;
                }
                catch (Exception ex)
                {
                    // Only attempt rollback if not committed
                    try
                    {
                        if (!committed)
                            trx.Rollback();
                    }
                    catch { /* ignore rollback errors */ }

                    MessageBox.Show("Error updating teacher (DB):\n" + ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    trx.Dispose();
                }
            }

            // UI work/refresh outside transaction scope
            try
            {
                LoadTeachers();
                SelectRowByTeacherId(selectedTeacherId);
                MessageBox.Show("Teacher updated successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update succeeded but UI refresh failed:\n" + ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------------- Delete ----------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTeacherId == 0 || selectedUserId == 0)
            {
                MessageBox.Show("Please select a teacher first.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete the selected teacher? This cannot be undone.",
                                         "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trx = conn.BeginTransaction();
                bool committed = false;
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        @"DELETE FROM Teachers WHERE TeacherID = @tid", conn, trx))
                    {
                        cmd.Parameters.AddWithValue("@tid", selectedTeacherId);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd2 = new SqlCommand(
                        @"DELETE FROM Logins WHERE UserID = @uid", conn, trx))
                    {
                        cmd2.Parameters.AddWithValue("@uid", selectedUserId);
                        cmd2.ExecuteNonQuery();
                    }

                    trx.Commit();
                    committed = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (!committed)
                            trx.Rollback();
                    }
                    catch { }
                    MessageBox.Show("Error deleting teacher:\n" + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    trx.Dispose();
                }
            }

            // UI refresh after deletion
            try
            {
                MessageBox.Show("Teacher deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedTeacherId = 0;
                selectedUserId = 0;
                LoadTeachers();
                ClearFields();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete succeeded but UI refresh failed:\n" + ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ---------------- Helpers ----------------
        private void SelectRowByTeacherId(int teacherId)
        {
            for (int i = 0; i < dgvTeachers.Rows.Count; i++)
            {
                var row = dgvTeachers.Rows[i];
                if (row.Cells["TeacherID"].Value != null && Convert.ToInt32(row.Cells["TeacherID"].Value) == teacherId)
                {
                    dgvTeachers.ClearSelection();
                    row.Selected = true;

                    // find first visible cell in this row (column visible AND cell visible)
                    int? visibleCellIndex = dgvTeachers.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Visible)
                        .Select(c => c.Index)
                        .FirstOrDefault(idx =>
                        {
                            var cell = dgvTeachers.Rows[i].Cells[idx];
                            return cell != null && cell.Visible;
                        });

                    if (visibleCellIndex.HasValue)
                    {
                        dgvTeachers.CurrentCell = row.Cells[visibleCellIndex.Value];
                        dgvTeachers.FirstDisplayedScrollingRowIndex = i;
                    }

                    FillFieldsFromRow(row);
                    break;
                }
            }
        }

        private void ClearFields()
        {
            if (txtFirstName != null) txtFirstName.Text = "";
            if (txtLastName != null) txtLastName.Text = "";
            if (txtUsername != null) txtUsername.Text = "";
            if (txtEmail != null) txtEmail.Text = "";
            if (cmbprogram != null) cmbprogram.SelectedIndex = -1;
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
                // don't block main flow for email issues
                MessageBox.Show("Failed to send email:\n" + ex.Message, "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        // stubbed event handlers from designer (safe no-op if designer references them)
        private void cmbprogram_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtLastName_TextChanged(object sender, EventArgs e) { }
        private void txtFirstName_TextChanged(object sender, EventArgs e) { }
        private void lblFirst_Click(object sender, EventArgs e) { }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            var home = new AdminForm();
            home.Show();
            this.Hide();
        }

        private void btnManage_Click_1(object sender, EventArgs e)
        {
            var form = new ManageForm();
            form.Show();
            this.Hide();
        }

        private void btnStudentRegistration_Click_1(object sender, EventArgs e)
        {
            var form = new StudentRegistration();
            form.Show();
            this.Hide();
        }
    }
}
