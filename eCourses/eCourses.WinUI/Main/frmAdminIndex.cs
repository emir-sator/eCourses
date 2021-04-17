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
using eCourses.WinUI.Forms.Users;
using eCourses.WinUI.Forms.Categories;
using eCourses.WinUI.Forms.Subcategories;
using eCourses.WinUI.Forms.Courses;
using eCourses.WinUI.Forms.Transactions;
using eCourses.WinUI.Forms.Reports;

namespace eCourses.WinUI.Main
{
    public partial class frmAdminIndex : Form
    {
        public static MCourse _course;
        private static MUser _user;
        public frmAdminIndex(MUser user)
        {
            _user = user;
            SignedInUser.User = _user;
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(ContentPanel);
            PanelHelper.AddPanel(ContentPanel, new UserList());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(ContentPanel);
            PanelHelper.AddPanel(ContentPanel, new CategoryList());
        }

        private void btnSubcategory_Click(object sender, EventArgs e)
        {
            PanelHelper.RemovePanels(ContentPanel);
            PanelHelper.AddPanel(ContentPanel, new SubcategoryList());
        }

        private void frmAdminIndex_Load(object sender, EventArgs e)
        {

            PanelHelper.AddPanel(ContentPanel, new Welcome());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new Welcome());
        }


        private void lUsername_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new UserEditOnUsernameClick(_user.UserID));
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new CourseList(_user,_course));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new Welcome());
        }

        private void btnEditAdminProfile_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new EditProfile(_user.UserID));
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            var form = new frmLogin();
            form.Show();
            Hide();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new TransactionList());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(ContentPanel, new ReportsPage());
        }
    }
}
