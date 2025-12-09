using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1.UserControls
{
    public partial class ucReports : UserControl
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public ucReports()
        {
            InitializeComponent();

            // Filter events
            cmbSection.SelectedIndexChanged += (s, e) => ReloadAll();
            cmbSubject.SelectedIndexChanged += (s, e) => ReloadAll();
            cmbYearLevel.SelectedIndexChanged += (s, e) => ReloadAll();
            cmbCourse.SelectedIndexChanged += (s, e) => ReloadAll();
            dtpDate.ValueChanged += (s, e) => ReloadAll();

            // Buttons
            btnExportPDF.Click += BtnExportPDF_Click;

            LoadSections();
            LoadYearLevels();
            LoadCourses();

            SetupGrid();
        }

        // ====================== FILTER LOADERS ======================

        // Sections from Subjects
        private void LoadSections()
        {
            cmbSection.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT Section FROM Subjects ORDER BY Section", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    cmbSection.Items.Add("");   // allow no-section filter
                    while (dr.Read())
                        cmbSection.Items.Add(dr["Section"].ToString());
                }
            }

            cmbSection.SelectedIndex = 0;
        }

        // Year levels from Students
        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.Add(""); // no filter

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT YearLevel FROM Students ORDER BY YearLevel", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbYearLevel.Items.Add(dr["YearLevel"].ToString());
                }
            }

            cmbYearLevel.SelectedIndex = 0;
        }

        // Courses from Students
        private void LoadCourses()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DISTINCT Course FROM Students ORDER BY Course", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbCourse.Items.Add(dr["Course"].ToString());
                }
            }

            cmbCourse.SelectedIndex = 0;
        }

        // ====================== SUBJECTS FILTERED ======================

        private void LoadSubjects()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    SELECT SubjectID, SubjectName
                    FROM Subjects
                    WHERE 1 = 1
                ";

                // Filter by Section (if chosen)
                if (!string.IsNullOrWhiteSpace(cmbSection.Text))
                {
                    sql += " AND Section = @Section ";
                    cmd.Parameters.AddWithValue("@Section", cmbSection.Text);
                }

                // Filter by YearLevel (if chosen)
                if (!string.IsNullOrWhiteSpace(cmbYearLevel.Text))
                {
                    sql += " AND YearLevel = @YearLevel ";
                    cmd.Parameters.AddWithValue("@YearLevel", cmbYearLevel.Text);
                }

                // Filter by Course (if Subjects table has Course column)
                if (!string.IsNullOrWhiteSpace(cmbCourse.Text))
                {
                    sql += " AND Course = @Course ";
                    cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                }

                sql += " ORDER BY SubjectName";
                cmd.CommandText = sql;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.DataSource = dt;

            if (cmbSubject.Items.Count > 0)
                cmbSubject.SelectedIndex = 0;
        }

        // ====================== SUMMARY TABLE ======================

        private void LoadSummary()
        {
            if (cmbSubject.SelectedValue == null)
            {
                dvgSummary.DataSource = null;
                lblTotals.Text = "Summary → Present: 0   |   Absent: 0   |   Late: 0";
                return;
            }

            int subjectID = Convert.ToInt32(cmbSubject.SelectedValue);
            DateTime date = dtpDate.Value.Date;

            string yearLevel = cmbYearLevel.Text;
            string course = cmbCourse.Text;
            string section = cmbSection.Text;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                string sql = @"
                    SELECT 
                        s.StudentID,
                        (s.FirstName + ' ' + s.LastName) AS FullName,
                        s.YearLevel,
                        s.Course,
                        s.Section,
                        a.Status,
                        a.Remarks
                    FROM Attendance a
                    INNER JOIN Students s ON a.StudentID = s.StudentID
                    WHERE 
                        a.SubjectID = @SubjectID
                        AND CAST(a.DateTaken AS DATE) = @DateTaken
                ";

                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.Parameters.AddWithValue("@DateTaken", date);

                if (!string.IsNullOrEmpty(yearLevel))
                {
                    sql += " AND s.YearLevel = @YearLevel ";
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                }

                if (!string.IsNullOrEmpty(course))
                {
                    sql += " AND s.Course = @Course ";
                    cmd.Parameters.AddWithValue("@Course", course);
                }

                if (!string.IsNullOrEmpty(section))
                {
                    sql += " AND s.Section = @Section ";
                    cmd.Parameters.AddWithValue("@Section", section);
                }

                sql += " ORDER BY s.LastName, s.FirstName";

                cmd.CommandText = sql;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dvgSummary.DataSource = dt;
            FormatGrid();
            CalculateTotals(dt);

            if (dt.Rows.Count == 0)
                lblTotals.Text = "Summary → Present: 0   |   Absent: 0   |   Late: 0";
        }

        // ====================== GRID SETUP ======================

        private void SetupGrid()
        {
            dvgSummary.BorderStyle = BorderStyle.None;
            dvgSummary.BackgroundColor = Color.White;
            dvgSummary.EnableHeadersVisualStyles = false;

            dvgSummary.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dvgSummary.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            dvgSummary.RowTemplate.Height = 28;
            dvgSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatGrid()
        {
            if (dvgSummary.Columns.Contains("StudentID"))
                dvgSummary.Columns["StudentID"].Visible = false;
        }

        // ====================== TOTAL COUNTS ======================

        private void CalculateTotals(DataTable dt)
        {
            int present = dt.Select("Status = 'Present'").Length;
            int absent = dt.Select("Status = 'Absent'").Length;
            int late = dt.Select("Status = 'Late'").Length;

            lblTotals.Text = $"Summary → Present: {present}   |   Absent: {absent}   |   Late: {late}";
        }

        // ====================== PDF EXPORT ======================

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (dvgSummary.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = "AttendanceSummary.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Logo
                    iTextSharp.text.Image logo;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Properties.Resources.SchoolLogo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        logo = iTextSharp.text.Image.GetInstance(ms.ToArray());
                    }

                    logo.ScaleToFit(80f, 80f);
                    logo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                    pdfDoc.Add(logo);

                    pdfDoc.Add(new Paragraph("\n"));

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    Paragraph title = new Paragraph("ATTENDANCE SUMMARY REPORT", headerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(title);
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph details = new Paragraph(
                        $"Section:  {cmbSection.Text}\n" +
                        $"Subject:  {cmbSubject.Text}\n" +
                        $"Year:     {cmbYearLevel.Text}\n" +
                        $"Course:   {cmbCourse.Text}\n" +
                        $"Date:     {dtpDate.Value:MMMM dd, yyyy}\n\n",
                        normalFont);

                    pdfDoc.Add(details);

                    // Table
                    PdfPTable table = new PdfPTable(dvgSummary.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (DataGridViewColumn col in dvgSummary.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, normalFont))
                        {
                            BackgroundColor = new BaseColor(230, 230, 250)
                        };
                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dvgSummary.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                                table.AddCell(new Phrase(cell.Value?.ToString() ?? "", normalFont));
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Add(new Paragraph("\n" + lblTotals.Text, normalFont));

                    pdfDoc.Close();
                }

                MessageBox.Show("PDF exported successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Export Error:\n" + ex.Message);
            }
        }

        // ====================== HELPER ======================

        private void ReloadAll()
        {
            LoadSubjects();
            LoadSummary();
        }

        // Empty designer-generated handlers (safe to leave)
        private void cmbSubject_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void dvgSummary_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbSection_SelectedIndexChanged_1(object sender, EventArgs e) { }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
