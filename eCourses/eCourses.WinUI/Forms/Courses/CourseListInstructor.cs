using eCourses.Model;
using eCourses.Model.Request;
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

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseListInstructor : UserControl
    {
        private static MUser _user;
        public static MCourse _course;
        private APIService courseService = new APIService("Course");
        private APIService subcategoryService = new APIService("Subcategory");

        public CourseListInstructor(MUser user, MCourse course)
        {
            _course = course;
            _user = user;
            SignedInUser.User = _user;
            CurrentCourse.Course = _course;
            InitializeComponent();
        }

        private async void CourseListInstructor_Load(object sender, EventArgs e)
        {

            await LoadList();
        }

        private async Task LoadList(CourseSearchRequest request)
        {

            var result = await courseService.Get<List<MCourse>>(request);
            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.ReadOnly = true;
            dgvCourses.DataSource = result;
        }

        private async Task LoadList()
        {

            var result = await courseService.Get<List<MCourse>>(null);
            var subcategories = await subcategoryService.Get<List<MSubcategory>>(null);

            subcategories.Insert(0, new MSubcategory { Name = "All subcategories" });
            cbSubcategories.DataSource = subcategories;
            cbSubcategories.DisplayMember = "Name";
            cbSubcategories.ValueMember = "SubcategoryID";

            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.ReadOnly = true;
            dgvCourses.DataSource = result;
        }

        private async void cbSubcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subcategory = cbSubcategories.SelectedItem as MSubcategory;
            var subcategoryID = subcategory.SubcategoryID;
            var userID = _user.UserID;
            if (subcategory.Name == "All subcategories")
            {
                var request = new CourseSearchRequest
                {
                    UserID = userID
                };
                await LoadList(request);
            }
            else
            {
                var request = new CourseSearchRequest()
                {
                    SubcategoryID = subcategoryID,
                    UserID = userID
                };
                await LoadList(request);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {

            var search = txtSearch.Text;
            if (search.StartsWith("Enter"))
            {
                search = "";
            }
            var request = new CourseSearchRequest()
            {
                Name = search
            };
            await LoadList(request);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Enter a course name";
                txtSearch.ForeColor = Color.Silver;
            }
        }
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            PanelHelper.SwapPanels(this.Parent, this, new CourseAdd(_user, _course));
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dgvCourses.CurrentRow != null)
            {
                var result = false;
                int ID = Convert.ToInt32(dgvCourses.CurrentRow.Cells["CourseID"].Value);
                if (MessageBox.Show("Do you really want to delete this course?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await courseService.Delete<dynamic>(ID);
                }
                if (result == true)
                {
                    MessageBox.Show("You have deleted course successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PanelHelper.SwapPanels(this.Parent, this, new CourseListInstructor(_user, _course));
            }
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {

        }

        private void btnLectures_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvCourses.CurrentRow.Cells["CourseID"].Value);
            PanelHelper.SwapPanels(this.Parent, this, new CourseAddVideoLecture(_user,ID));
        }
    }
}
