using eCourses.WinUI.Forms.Reports;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Reports.DataForReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseTop3BestRatingReport : UserControl
    {
        public CourseTop3BestRatingReport()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (eCoursesBazaEntities db = new eCoursesBazaEntities())
            {
                Top3BestAverageRatingCourses_ResultBindingSource.DataSource = db.Top3BestAverageRatingCourses().ToList();
                reportViewer1.RefreshReport();
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ReportsPage());
        }
    }
}
