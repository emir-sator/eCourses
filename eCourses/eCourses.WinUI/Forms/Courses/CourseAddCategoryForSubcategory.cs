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
    public partial class CourseAddCategoryForSubcategory : UserControl
    {
        private APIService categoryService = new APIService("Category");
        private static MCourse _course;
        private static MUser _user;
        public CourseAddCategoryForSubcategory(MUser user, MCourse course)
        {
            _course = course;
            _user = user;
            CurrentCourse.Course = _course;
            SignedInUser.User = _user;
            InitializeComponent();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var request = new CategoryUpsertRequest
                    {
                        Name = txtName.Text

                    };

                    await categoryService.Insert<MCategory>(request);

                    MessageBox.Show("Category added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelHelper.SwapPanels(this.Parent, this, new CourseAddSubcategory(_user,_course));
                }
                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseAddSubcategory(_user, _course));
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }
        }
    }
}
