using eCourses.Model;
using eCourses.Model.Request;
using eCourses.WinUI.Helper;
using eCourses.WinUI.Properties;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourses.WinUI.Forms.Courses
{
    public partial class CourseAddVideoLecture : UserControl
    {
        private static MUser _user;
        public static readonly MCourse _course;
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService sectionService = new APIService("Section");
        private readonly APIService userService = new APIService("User");
        private readonly APIService videoLectureService = new APIService("VideoLecture");

        private static int _ID;
        private static int _UserID;

        public CourseAddVideoLecture(MUser user,int ID)
        {
            _user = user;
            SignedInUser.User = _user;
            //_UserID = UserID;
            _ID = ID;
            InitializeComponent();
        }

        private async void CourseAddVideoLecture_Load(object sender, EventArgs e)
        {

      
            var course = await courseService.GetById<MCourse>(_ID);
            txtCourseName.Text = course.Name;
            txtDate.Text = DateTime.Now.ToString();
            
            var sections = await sectionService.Get<List<MSection>>(null);
            cbSection.DataSource = sections;
            cbSection.ValueMember = "SectionID";
            cbSection.DisplayMember = "SectionNumber";

            var section = cbSection.SelectedItem as MSection;
            var sectionID = section.SectionID;
            var result = await videoLectureService.Get<List<MVideoLecture>>(new VideoLectureSearchRequest()
            {
                CourseID = _ID,
                SectionID=sectionID
            });
            dgvVideoLectures.AutoGenerateColumns = false;
            dgvVideoLectures.DataSource = result;

        }

        private async void btnBack_Click(object sender, EventArgs e)
        {
            //var user = await userService.GetById<MUser>(_UserID);
            PanelHelper.SwapPanels(this.Parent, this, new CourseList(_user, _course));
         
        }


        private async Task LoadList(VideoLectureSearchRequest request)
        {

            var result = await videoLectureService.Get<List<MVideoLecture>>(request);
            dgvVideoLectures.AutoGenerateColumns = false;
            dgvVideoLectures.ReadOnly = true;
            dgvVideoLectures.DataSource = result;
        }

        private async void cbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var section = cbSection.SelectedItem as MSection;
            var sectionID = section.SectionID;

            if (cbSection.SelectedIndex != -1)
            {
                var request = new VideoLectureSearchRequest
                {
                    CourseID = _ID,
                    SectionID = sectionID
                };
                await LoadList(request);
            }
        }

        private void ClearControls()
        {

            txtLectureName.Text = string.Empty;
            txtURL.Text = string.Empty;
            txtDate.Text = string.Empty;





        }
        private async void btnSave_Click(object sender, EventArgs e)
        {



            if (ValidateChildren())
            {
              
                var LectureSection = Convert.ToInt32(cbSection.SelectedValue);
                var request = new VideoLectureUpsertRequest
                {
                    LectureName = txtLectureName.Text,
                    SectionID = LectureSection,
                    UploadedOn = DateTime.Now,
                    CourseID = _ID,
                    URL=txtURL.Text
                };
                await videoLectureService.Insert<MVideoLecture>(request);
                MessageBox.Show("Video lecture added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PanelHelper.SwapPanels(this.Parent, this, new CourseAddVideoLecture(_user,request.CourseID));
                ClearControls();
            }
        }

      

        private void txtLectureName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLectureName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLectureName, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider1.SetError(txtLectureName, null);
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



    }

}
