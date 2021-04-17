using eCourses.Model;
using eCourses.WinUI.Forms.Reports;
using eCourses.WinUI.Helper;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Users
{
    public partial class UserReport : UserControl
    {
        private List<MUser> _source;
        public UserReport(List<MUser> source)
        {
            _source = source;
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            //ReportDataSource rds = new ReportDataSource("dsUsers", _source);
            //this.rptUsers.LocalReport.DataSources.Add(rds);
            UserListVMBindingSource.DataSource = _source;
            this.rptUsers.RefreshReport();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new UserList());
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ReportsPage());
        }
    }
}
