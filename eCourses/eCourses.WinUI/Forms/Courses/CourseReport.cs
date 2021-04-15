using eCourses.Model;
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

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseReport : UserControl
    {
        private static MUser _user;
        private static MCourse _course;
        private List<MCourse> _source;
        public CourseReport(MUser user,List<MCourse> source)
        {
            _user = user;
            _source = source;
            SignedInUser.User = _user;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user,_course));
        }

        private void CourseReport_Load(object sender, EventArgs e)
        {
            MCourseListVMBindingSource.DataSource = _source;
            this.reportViewer1.RefreshReport();
        }
    }
}
