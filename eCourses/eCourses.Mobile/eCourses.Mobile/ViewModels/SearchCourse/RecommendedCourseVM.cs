using eCourses.Mobile.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Mobile.ViewModels.SearchCourse
{
    public class RecommendedCourseVM : BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService recommendService = new APIService("Recommendation");

        public ObservableCollection<CourseVM> recommendedCoursesList { get; set; } = new ObservableCollection<CourseVM>();
        public async Task Init()
        {
            try
            {
                int userID = SignedInUser.User.UserID;
                recommendedCoursesList.Clear();
                var recommendCourses = await recommendService.GetRecommandedCourses(userID);
                var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
                foreach (var course in recommendCourses)
                {
                    recommendedCoursesList.Add(new CourseVM(course));
                }
            }
            catch
            {

            }
        }
    }
}
