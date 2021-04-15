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


namespace eCourses.WinUI.Main
{
    public partial class frmInstructorIndex : Form
    {
        private static MUser _user;
        private static MCourse _course;
        public frmInstructorIndex(MUser user)
        {

            _user = user;
            SignedInUser.User = _user;
            InitializeComponent();
        }

        private void frmInstructorIndex_Load(object sender, EventArgs e)
        {
          
            PanelHelper.AddPanel(InstructorContent, new Welcome());
        }

        private void IUsername_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(InstructorContent, new UserEditOnUsernameClick(_user.UserID));
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
            PanelHelper.AddPanel(InstructorContent, new Welcome());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(InstructorContent, new CourseList(_user, _course));
        }

        private void btnEditInstructorProfile_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(InstructorContent, new EditProfile(_user.UserID));
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            PanelHelper.AddPanel(InstructorContent, new CourseAdd(_user, _course));
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            var form = new frmLogin();
            form.Show();
            Hide();
        }

        
    }
}
