using eCourses.WinUI.Helper;
using eCourses.WinUI.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eCourses.WinUI.Reports;

namespace eCourses.WinUI.Forms.Users
{
    public partial class Top3UsersWithMostPurchases : UserControl
    {
        public Top3UsersWithMostPurchases()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Welcome());
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (Top3Users db=new Top3Users())
            {
                Top3UsersWithMostCoursePurchases_ResultBindingSource.DataSource = db.Top3UsersWithMostCoursePurchases().ToList();
                reportViewer1.RefreshReport();
            };
        }
    }
}
