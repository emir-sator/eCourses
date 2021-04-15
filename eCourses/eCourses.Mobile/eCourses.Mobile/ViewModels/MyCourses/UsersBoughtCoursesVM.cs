using eCourses.Mobile.Helpers;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Mobile.ViewModels.MyCourses
{
    public class UsersBoughtCoursesVM:BaseVM
    {
        private readonly APIService courseService = new APIService("Course");

        public ObservableCollection<MBuyCourse> courseList { get; set; } = new ObservableCollection<MBuyCourse>();
        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }
        public async Task Init()
        {
            var userID = SignedInUser.User.UserID;
            courseList.Clear();
            var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
            foreach(var courses in usersBoughtCourses)
            {
                courseList.Add(courses);
            }
        }
    }
}
