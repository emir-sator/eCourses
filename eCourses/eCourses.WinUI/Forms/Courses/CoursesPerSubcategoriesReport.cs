using eCourses.Model;
using eCourses.WinUI.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Main;

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CoursesPerSubcategoriesReport : UserControl
    {
        private readonly APIService subcategoryService = new APIService("Subcategory");
        public CoursesPerSubcategoriesReport()
        {
            InitializeComponent();
        }

        private async void CoursesPerSubcategoriesReport_Load(object sender, EventArgs e)
        {
            var subcategory = await subcategoryService.Get<List<MSubcategory>>(null);
            cbSubcategory.DataSource = subcategory;
            cbSubcategory.ValueMember = "SubcategoryID";
            cbSubcategory.DisplayMember = "Name";

            reportViewer1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CoursesPerSubcategory db = new CoursesPerSubcategory())
            {
                var source= db.GetCoursesBySubcategory(Convert.ToInt32(cbSubcategory.SelectedValue)).ToList();
               
                ReportDataSource ds = new ReportDataSource("Courses", source);
              
                ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("SubcategoryID", Convert.ToInt32(cbSubcategory.SelectedValue).ToString())
            };
                reportViewer1.LocalReport.SetParameters(reportParameters);
                reportViewer1.LocalReport.DataSources.Add(ds);
                reportViewer1.RefreshReport();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Welcome());
        }
    }
}

