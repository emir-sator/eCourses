using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseSaleList : UserControl
    {
        private readonly APIService buycourseService = new APIService("BuyCourse");
        SqlConnection con = new SqlConnection("Server=.;Database=150031;Trusted_Connection=true;MultipleActiveResultSets=true;");
        private static MUser _user;
        private static MCourse _course;
        public CourseSaleList(MUser user, MCourse course)
        {
            _user =user;
            _course = course;
            SignedInUser.User = _user;
            InitializeComponent();
        }
        private async void CourseSaleList_Load(object sender, EventArgs e)
        {

            await LoadCourses();
        }

        async Task LoadCourses()
        {
            var courses = await buycourseService.Get<List<MBuyCourse>>(null);

            dgvCoursSales.AutoGenerateColumns = false;
            dgvCoursSales.ReadOnly = true;
            dgvCoursSales.DataSource = courses;
        }



        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            TimeSpan fromBeginningOfTheDay = new TimeSpan(00, 00, 0);
            dtpFrom.Value = dtpFrom.Value.Date + fromBeginningOfTheDay;

            TimeSpan UntilEndOfTheDay = new TimeSpan(23, 59, 59);
            dtpTo.Value = dtpTo.Value.Date + UntilEndOfTheDay;

          


            SqlDataAdapter search = new SqlDataAdapter("SELECT * FROM BuyCourses where DateOfBuying between '" + dtpFrom.Value.ToString("O") + "' And '" + dtpTo.Value.ToString("O") + "'", con);
            DataTable dt = new DataTable();
            search.Fill(dt);
            dgvCoursSales.DataSource = dt;
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            //var datefrom = Convert.ToDateTime(dtpFrom.Value);
            //var dateto = Convert.ToDateTime(dtpTo.Value);
            //PanelHelper.SwapPanels(this.Parent, this, new CourseSalesReport(datefrom, dateto));


            var datefrom = Convert.ToDateTime(dtpFrom.Value.ToString("O"));
            var dateto = Convert.ToDateTime(dtpTo.Value.ToString("O"));
            PanelHelper.SwapPanels(this.Parent, this, new CourseSalesBetweenDatesReport(datefrom, dateto));


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, _course));
        }
    }
}