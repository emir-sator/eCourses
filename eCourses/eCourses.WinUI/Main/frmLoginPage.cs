using eCourses.Model;
using eCourses.Model.Request;
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
    public partial class frmLoginPage : UserControl
    {
        private readonly APIService userService = new APIService("User");
        public frmLoginPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;

            var request = new UserAuthenticationRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var user = await userService.Authenticate(request);

            if (user != null)
            {
                LoadPanel(user);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username Or Password!");
            }
        }
        private void LoadPanel(MUser user)
        {
            var instruktor = user.UserRoles.Select(i => i.Role.Name).FirstOrDefault();
            var admin = user.UserRoles.Select(i => i.Role.Name).FirstOrDefault();
            if (admin == "Admin")
            {
                var form = new frmAdminIndex(user);
                form.Show();
            }
            else if (instruktor == "Instruktor")
            {
                var form = new frmInstructorIndex(user);
                form.Show();
            }
            else
            {
                MessageBox.Show("Use Admin or Instructor Credentials to Login!");
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }
    }
}
