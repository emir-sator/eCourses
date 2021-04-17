using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Forms.Reports;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Main;
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

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseSalesBetweenDatesReport : UserControl
    {

        private DateTime _datefrom;
        private DateTime _dateto;
        private readonly APIService courseBuyService = new APIService("BuyCourse");
        public CourseSalesBetweenDatesReport(DateTime datefrom, DateTime dateto)
        {
            _datefrom = datefrom;
            _dateto = dateto;
            InitializeComponent();
        }

   

        private async void Sales_Load(object sender, EventArgs e)
        {
            var request = new BuyCourseSearchRequest
            {
                From = _datefrom,
                To = _dateto
            };

            var courses = await courseBuyService.Get<List<MBuyCourse>>(request);
            ReportDataSource ds = new ReportDataSource("DataSet1", courses);
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter("From", _datefrom.ToString("dd/MM/yyyy")));
            //this.reportViewer1.LocalReport.SetParameters(new ReportParameter("To", _dateto.ToString("dd/MM/yyyy")));

         
            ReportParameter[] reportParameters = new ReportParameter[]
         {
                 new ReportParameter("From", _datefrom.ToString("dd/MM/yyyy")),
                 new ReportParameter("To", _dateto.ToString("dd/MM/yyyy"))
                
         };
            reportViewer1.LocalReport.SetParameters(reportParameters);
            reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new ReportsPage());

        }
    }
}
