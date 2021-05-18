using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Properties;
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
    public partial class CourseEdit : UserControl
    {
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService subcategoryService = new APIService("Subcategory");

        private MUser _user;
        private static int _courseID;
        public CourseEdit(MUser user, int CourseID)
        {
            _user = user;
            _courseID = CourseID;
            InitializeComponent();
        }

        private async void CourseEdit_Load(object sender, EventArgs e)
        {

            var course = await courseService.GetById<MCourse>(_courseID);
            var subcategory = await subcategoryService.GetById<MSubcategory>(course.SubcategoryID);
            txtCourseName.Text = course.Name;
            txtSubcategory.Text = subcategory.Name;
            txtLanguage.Text = course.Language;
            txtDateCreated.Text = course.DateCreated.ToString();
            txtPrice.Text = course.Price.ToString();
            txtURL.Text = course.URL;
            txtDescription.Text = course.Description;

            if (course.Image.Length > 3)
            {
                pbCourseImage.Image = ImageHelper.ByteArrayToSystemDrawing(course.Image);
                pbCourseImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var course = await courseService.GetById<MCourse>(_courseID);
            var subcategory = await subcategoryService.GetById<MSubcategory>(course.SubcategoryID);
            if (ValidateChildren())
            {

                var request = new CourseUpsertRequest
                {
                    Name = txtCourseName.Text,
                    Language = txtLanguage.Text,
                    DateCreated = DateTime.Now,
                    Price = float.Parse(txtPrice.Text),
                    //Convert.ToInt32(txtPrice.Text),
                    UserID = course.UserID,
                    Description = txtDescription.Text,
                    Image = pbCourseImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbCourseImage.Image) : null,
                    SubcategoryID = subcategory.SubcategoryID,
                    URL = txtURL.Text

                };
                await courseService.Update<MCourse>(_courseID, request);
                MessageBox.Show("Course updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, course));
            }
        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            var course = await courseService.GetById<MCourse>(_courseID);
            PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, course));
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
            if (c!=',')
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
    }
}
