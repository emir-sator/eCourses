using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Mobile.ViewModels.MyCourses
{
    public class WishlistVM : BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        public ObservableCollection<CourseVM> courseList { get; set; } = new ObservableCollection<CourseVM>();

        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }
        public async Task Init(CourseSearchRequest request = null)
        {
            try
            {
                var userID = SignedInUser.User.UserID;
                courseList.Clear();
                var courses = await courseService.GetLikedCourse(userID, request);
                var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
                foreach (var course in courses)
                {
                    var DoesItContain = usersBoughtCourses.Where(m => m.CourseID == course.CourseID).Any();
                    if (usersBoughtCourses.Count > 0)
                    {
                            if (DoesItContain == false)
                            {
                                courseList.Add(new CourseVM(course));
                               
                            }
                    }
                    else
                    {
                        courseList.Add(new CourseVM(course));
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
