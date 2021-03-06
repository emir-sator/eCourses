using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Main;
using eCourses.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace eCourses.WinUI.Forms.Users
{
    public partial class UserEditOnUsernameClick : UserControl
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService roleService = new APIService("Role");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        private readonly int _ID;
        public UserEditOnUsernameClick(int ID)
        {
            _ID = ID;
            InitializeComponent();
        }

        private async void UserEditOnUsernameClick_Load(object sender, EventArgs e)
        {
            var user = await userService.GetById<MUser>(_ID);

            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtPhone.Text = user.PhoneNumber;

            if (user.Image.Length > 3)
            {
                pbUserPicture.Image = ImageHelper.ByteArrayToSystemDrawing(user.Image);
                pbUserPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            var roles = await roleService.Get<List<MRole>>(null);
            clbRoles.DataSource = roles;
            clbRoles.ValueMember = "RoleID";
            clbRoles.DisplayMember = "Name";
            clbRoles.SelectionMode = SelectionMode.None;

            var rolesList = clbRoles.Items.Cast<MRole>().Select(i => i.RoleID).ToList();
            foreach (var userRole in user.UserRoles)
            {
                for (int i = 0; i < clbRoles.Items.Count; i++)
                {
                    if (rolesList[i] == userRole.RoleID)
                    {
                        clbRoles.SetItemChecked(i, true);
                    }
                }
            }
            
        }
        private void btnPictureUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files (*.jpg;*.jpeg;*.gif;)|*.jpg;*.jpeg;*.gif";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbUserPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                pbUserPicture.Image = new Bitmap(openfd.FileName);
            }
        }

      
        private async void btnSavee_Click(object sender, EventArgs e)
        {
            var user = await userService.GetById<MUser>(_ID);
            if (ValidateChildren())
            {
                var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(x => x.RoleID).ToList();
              

                var request = new UserUpsertRequest
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Username = txtUsername.Text,
                    PhoneNumber = txtPhone.Text,
                    Image = pbUserPicture.Image != null ? ImageHelper.SystemDrawingToByteArray(pbUserPicture.Image) : null,
                    Roles = roleList,
                   
                };

                await userService.Update<MUser>(_ID, request);
                MessageBox.Show("Your information/informations have been updated successfully! Please log in to confirm changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new Welcome());


            }
           
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLastName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
                bool isEmailValid = Regex.IsMatch(txtEmail.Text, emailPattern);
                if (isEmailValid == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Enter email in a valid format!");
                }
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = txtPhone.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text.Length < 9 || txtPhone.Text.Length > 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone number needs to contain 9 digits!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
                if (IsDigitsOnly(phone) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPhone, "You can't Use letters!");
                }
                else
                {
                    errorProvider1.SetError(txtPhone, null);
                }
            }
        }

        private void clbRoles_Validating(object sender, CancelEventArgs e)
        {
            var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(x => x.RoleID).ToList();
            if (roleList.Count() == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(clbRoles, "You must choose at least one role!");
            }
            else
            {
                errorProvider1.SetError(clbRoles, null);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new Welcome());
        }
    }
}
