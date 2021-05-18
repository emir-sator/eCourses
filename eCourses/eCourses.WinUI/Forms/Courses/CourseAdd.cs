using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Forms.Categories_and_Subcategories;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Properties;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseAdd : UserControl
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService subcategoryService = new APIService("Subcategory");

        private static MCourse _course;
        private static MUser _user;
        public CourseAdd(MUser user, MCourse course)
        {
            _course = course;
            _user = user;
            CurrentCourse.Course = _course;
            SignedInUser.User = _user;
            InitializeComponent();
        }

        private async void CourseAdd_Load(object sender, EventArgs e)
        {
            txtDateCreated.Text = DateTime.Now.ToString();

            var subcategory = await subcategoryService.Get<List<MSubcategory>>(null);
            subcategory.Insert(0, new MSubcategory());
            cbSubcategory.DataSource = subcategory;
            cbSubcategory.ValueMember = "SubcategoryID";
            cbSubcategory.DisplayMember = "Name";
            var user = await userService.GetById<MUser>(_user.UserID);

            foreach (var userRole in user.UserRoles)
            {
                if (userRole.RoleID == 1)
                {
                    btnAddSubcategory.Visible = true;


                }
                if (userRole.RoleID == 2)
                {
                    btnAddSubcategory.Visible = false;
                }
            }
        }



        private void txtUploadPicture_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;*.gif;)|*.jpg;*.jpeg;*.gif;"
            };
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                pbCourseImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbCourseImage.Image = new Bitmap(openfd.FileName);
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
           
            if (ValidateChildren())
            {
             
                var courseSubcategory = Convert.ToInt32(cbSubcategory.SelectedValue);

                var request = new CourseUpsertRequest
                {
                    Name = txtCourseName.Text,
                    Language = txtLanguage.Text,
                    DateCreated = DateTime.Now,
                    Price = Convert.ToInt32(txtPrice.Text),
                    UserID = _user.UserID,
                    Description = txtDescription.Text,
                    Image = pbCourseImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbCourseImage.Image) : null,
                    SubcategoryID = courseSubcategory,
                    URL=txtURL.Text
                

                };
                await courseService.Insert<MCourse>(request);
                MessageBox.Show("Course added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, _course));
            }
        }

        private void txtURL_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtURL.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtURL, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtURL, null);
            }
        }

        private void txtCourseName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCourseName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtCourseName, null);
            }
        }
        private void cbSubategory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbSubcategory.Text))
            {
                MessageBox.Show("Please select a value");
            }

            else
            {

                errorProvider1.SetError(cbSubcategory, null);

            }

        }
        private void txtLanguage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLanguage.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLanguage, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLanguage, null);
            }
        }

        bool DoesItContainComma(char c)
        {
            if (c != ',')
            {
                return true;
            }
            return false;
        }


        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && DoesItContainComma(c))
                    return false;
            }

            return true;
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            string price = txtPrice.Text.ToString();
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || txtPrice.Text.Length < 1)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPrice, "Price field can't be empty!");
            }
            else
            {
                errorProvider1.SetError(txtPrice, null);
                if (IsDigitsOnly(price) == false)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPrice, "You must use decimal numbers with comma or integer numbers!");
                }
                else
                {
                    errorProvider1.SetError(txtPrice, null);
                }
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLanguage.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLanguage, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLanguage, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, _course));
        }

        private void btnAddSubcategory_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseAddSubcategory(_user,_course));
        }

        private void txtDateCreated_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDateCreated.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDateCreated, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtDateCreated, null);

            }
        }

       
    }
}
