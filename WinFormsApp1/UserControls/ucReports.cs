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

            cmbSection.SelectedIndexChanged += CmbSection_SelectedIndexChanged;
            cmbSubject.SelectedIndexChanged += CmbSubject_SelectedIndexChanged;
            dtpDate.ValueChanged += DtpDate_ValueChanged;
            btnLoad.Click += BtnLoad_Click;
            btnExportPDF.Click += BtnExportPDF_Click;

            LoadSections();
            LoadYearLevels();
            LoadCourses();


        }


        //  LOAD SECTIONS
        private void LoadSections()
        {
            cmbSection.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd =
                new SqlCommand("SELECT DISTINCT Section FROM Subjects ORDER BY Section", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbSection.Items.Add(dr["Section"].ToString());
                }
            }

            if (cmbSection.Items.Count > 0)
                cmbSection.SelectedIndex = 0;
        }

        private void LoadYearLevels()
        {
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.Add(""); // allow no filter

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT YearLevel FROM Students ORDER BY YearLevel", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbYearLevel.Items.Add(dr["YearLevel"].ToString());
                }
            }
        }

        private void LoadCourses()
        {
            cmbCourse.Items.Clear();
            cmbCourse.Items.Add("");

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT Course FROM Students ORDER BY Course", conn))
            {
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbCourse.Items.Add(dr["Course"].ToString());
                }
            }
        }


        //  LOAD SUBJECTS BASED ON SECTION
        private void LoadSubjects()
        {
            string section = cmbSection.Text;
            if (string.IsNullOrWhiteSpace(section)) return;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT SubjectID, SubjectName 
                FROM Subjects 
                WHERE Section = @Section
                ORDER BY SubjectName", conn))
            {
                cmd.Parameters.AddWithValue("@Section", section);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.DataSource = dt;
        }


        //  LOAD SUMMARY TABLE
        private void LoadSummary()
        {
            if (cmbSubject.SelectedValue == null) return;

            int subjectID = Convert.ToInt32(cmbSubject.SelectedValue);
            DateTime date = dtpDate.Value.Date;

            string yearLevel = cmbYearLevel.Text;
            string course = cmbCourse.Text;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(@"
        SELECT 
            s.StudentID,
            (s.FirstName + ' ' + s.LastName) AS FullName,
            s.YearLevel,
            s.Course,
            a.Status,
            a.Remarks
        FROM Attendance a
        INNER JOIN Students s ON a.StudentID = s.StudentID
        WHERE 
            a.SubjectID = @SubjectID
            AND CAST(a.DateTaken AS DATE) = @DateTaken
            " + (string.IsNullOrEmpty(yearLevel) ? "" : " AND s.YearLevel = @YearLevel ") + @"
            " + (string.IsNullOrEmpty(course) ? "" : " AND s.Course = @Course ") + @"
        ORDER BY s.LastName, s.FirstName
    ", conn))
            {
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.Parameters.AddWithValue("@DateTaken", date);

                if (!string.IsNullOrEmpty(yearLevel))
                    cmd.Parameters.AddWithValue("@YearLevel", yearLevel);

                if (!string.IsNullOrEmpty(course))
                    cmd.Parameters.AddWithValue("@Course", course);

                if (dvgSummary.Columns.Contains("StudentID"))
                    dvgSummary.Columns["StudentID"].Visible = false;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            dvgSummary.DataSource = dt;
            CalculateTotals(dt);

            if (dt.Rows.Count == 0)
                MessageBox.Show("No attendance found for this filter.", "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        //  TOTAL COUNTS
        private void CalculateTotals(DataTable dt)
        {
            int present = dt.Select("Status = 'Present'").Length;
            int absent = dt.Select("Status = 'Absent'").Length;
            int late = dt.Select("Status = 'Late'").Length;

            lblTotals.Text = $"Summary → Present: {present}   |   Absent: {absent}   |   Late: {late}";
        }


        //  EVENT HANDLERS
        private void BtnLoad_Click(object sender, EventArgs e) => LoadSummary();
        private void DtpDate_ValueChanged(object sender, EventArgs e) => LoadSummary();

        private void CmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadSummary();
        }

        private void CmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSummary();
        }


        //  EXPORT TO PDF
        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            if (dvgSummary.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "AttendanceSummary.pdf";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // ✅ Embedded Logo
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

                    Paragraph title = new Paragraph("ATTENDANCE SUMMARY REPORT", headerFont);
                    title.Alignment = Element.ALIGN_CENTER;

                    pdfDoc.Add(title);
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph details = new Paragraph(
                        $"Section:  {cmbSection.Text}\n" +
                        $"Subject:  {cmbSubject.Text}\n" +
                        $"Date:     {dtpDate.Value:MMMM dd, yyyy}\n\n",
                        normalFont);

                    pdfDoc.Add(details);

                    // TABLE
                    PdfPTable table = new PdfPTable(dvgSummary.Columns.Count);
                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn col in dvgSummary.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, normalFont));
                        cell.BackgroundColor = new BaseColor(230, 230, 250);
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


        private void cmbSubject_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dvgSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbSection_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
