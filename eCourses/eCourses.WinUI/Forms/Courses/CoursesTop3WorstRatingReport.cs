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
    public partial class CoursesTop3WorstRatingReport : UserControl
    {
        public CoursesTop3WorstRatingReport()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (eCoursesBazaEntities1 db = new eCoursesBazaEntities1())
            {
                Top3WorstAverageRatingCourses_ResultBindingSource.DataSource = db.Top3WorstAverageRatingCourses().ToList();
                reportViewer1.RefreshReport();
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ReportsPage());
        }
    }
}
