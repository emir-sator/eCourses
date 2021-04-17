using eCourses.Model;
using eCourses.WinUI.Forms.Courses;
using eCourses.WinUI.Forms.Users;
using eCourses.WinUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Reports
{
    public partial class ReportsPage : UserControl
    {
        private MUser _user;
        private MCourse _course;

        public ReportsPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Top3UsersWithMostPurchases());
        }

        private void btnCourseReport_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseTop3ListReport());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseSaleList(_user, _course));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CoursesPerSubcategoriesReport());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseTop3BestRatingReport());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
