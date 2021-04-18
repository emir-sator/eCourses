using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.Course
{
    public class InstructorDetailVM:BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        public ObservableCollection<CourseVM> InstructorList { get; set; } = new ObservableCollection<CourseVM>();

        public InstructorDetailVM()
        {

        }
        public InstructorDetailVM(MUser user)
        {
            User = user;
            InitCommand = new Command(async () => await InitCourses());
        }

        public ICommand InitCommand { get; set; }

        private MUser _user;
        public MUser User
        {
            get { return _user; }
            set { SetProperty(ref _user, value);}
        }

        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }

        }

        public async Task InitCourses()
        {
            try
            {

                CourseSearchRequest request = new CourseSearchRequest()
                {
                    UserID = User.UserID
                };
                InstructorList.Clear();
                var courses = await courseService.Get<List<MCourse>>(request);
                foreach (var course in courses)
                {
                    if (courses.Count > 0)
                    {

                        InstructorList.Add(new CourseVM(course));

                    }
                }
            }
            catch (Exception)
            {

            }
        }


    }
}
