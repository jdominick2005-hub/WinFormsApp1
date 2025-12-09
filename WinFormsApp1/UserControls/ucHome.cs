using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1.UserControls
{
    public partial class ucHome : UserControl
    {
        // db string
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AttendanceDB_v2"].ConnectionString;

        public ucHome()
        {
            InitializeComponent();

            // load event
            this.Load += ucHome_Load;
        }

        // load form
        private void ucHome_Load(object sender, EventArgs e)
        {
            LoadAttendanceDonut();
            LoadProgramChart();
            LoadTeacherLine();
        }

        // donut chart
        private void LoadAttendanceDonut()
        {
            try
            {
                chart1.Series.Clear();

                Series s = new Series("Attendance");
                s.ChartType = SeriesChartType.Doughnut;
                s.IsValueShownAsLabel = true;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Status, COUNT(*) AS Total
                        FROM Attendance
                        GROUP BY Status", conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string status = r["Status"].ToString();
                            int total = Convert.ToInt32(r["Total"]);
                            s.Points.AddXY(status, total);
                        }
                    }
                }

                chart1.Series.Add(s);

                if (chart1.ChartAreas.Count > 0)
                {
                    chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
                }
            }
            catch
            {
                // ignore errors on dashboard
            }
        }

        // program chart
        private void LoadProgramChart()
        {
            try
            {
                chart2.Series.Clear();

                Series s = new Series("Programs");
                s.ChartType = SeriesChartType.Column;
                s.IsValueShownAsLabel = true;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT Course AS Program, COUNT(*) AS TotalStudents
                        FROM Students
                        GROUP BY Course", conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string program = r["Program"].ToString();
                            int total = Convert.ToInt32(r["TotalStudents"]);
                            s.Points.AddXY(program, total);
                        }
                    }
                }

                chart2.Series.Add(s);

                if (chart2.ChartAreas.Count > 0)
                {
                    chart2.ChartAreas[0].AxisX.Interval = 1;
                    chart2.ChartAreas[0].AxisX.Title = "Program";
                    chart2.ChartAreas[0].AxisY.Title = "Students";
                }
            }
            catch
            {
                // ignore errors on dashboard
            }
        }

        // teacher line
        private void LoadTeacherLine()
        {
            try
            {
                chart3.Series.Clear();

                Series s = new Series("StudentsPerTeacher");
                s.ChartType = SeriesChartType.Line;
                s.MarkerStyle = MarkerStyle.Circle;
                s.MarkerSize = 7;
                s.IsValueShownAsLabel = true;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                        SELECT 
                            CONCAT(L.FirstName,' ',L.LastName) AS TeacherName,
                            COUNT(DISTINCT E.StudentID) AS TotalStudents
                        FROM Teachers T
                        JOIN Logins L ON T.UserID = L.UserID
                        JOIN Subjects S ON S.TeacherID = T.TeacherID
                        JOIN Enrollments E ON E.SubjectID = S.SubjectID
                        GROUP BY CONCAT(L.FirstName,' ',L.LastName)
                        ORDER BY TeacherName", conn))
                {
                    conn.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            string teacher = r["TeacherName"].ToString();
                            int total = Convert.ToInt32(r["TotalStudents"]);
                            s.Points.AddXY(teacher, total);
                        }
                    }
                }

                chart3.Series.Add(s);

                if (chart3.ChartAreas.Count > 0)
                {
                    chart3.ChartAreas[0].AxisX.Interval = 1;
                    chart3.ChartAreas[0].AxisX.Title = "Teacher";
                    chart3.ChartAreas[0].AxisY.Title = "Students";
                }
            }
            catch
            {
                // ignore errors on dashboard
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
