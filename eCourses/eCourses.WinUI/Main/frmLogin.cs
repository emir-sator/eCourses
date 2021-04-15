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
    public partial class frmLogin : Form
    {

        private readonly APIService userService = new APIService("User");
        public frmLogin()
        {
            InitializeComponent();
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
                MessageBox.Show("Please use Admin or Instructor credentials to login!");
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsrName.Text;
            APIService.Password = txtPass.Text;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
