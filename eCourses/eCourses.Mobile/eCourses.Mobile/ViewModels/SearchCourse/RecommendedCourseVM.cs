using eCourses.Mobile.Helpers;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.SearchCourse
{
    public class RecommendedCourseVM : BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService recommendService = new APIService("Recommendation");
        public ObservableCollection<CourseVM> recommendedCoursesList { get; set; } = new ObservableCollection<CourseVM>();
        public ICommand InitCommand { get; set; }

        MUser _user = SignedInUser.User;
        public RecommendedCourseVM()
        {
            InitCommand = new Command(async () => await Init(_user));
        }

        public async Task Init(MUser user)
        {
            _user = user;
            try
            {
                if (user != null)
                {
                    int userID = SignedInUser.User.UserID;
                    recommendedCoursesList.Clear();
                    var recommendCourses = await recommendService.GetRecommandedCourses(userID);
                    var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
                    foreach (var course in recommendCourses)
                    {
                        if (course.UserID != user.UserID)
                            recommendedCoursesList.Add(new CourseVM(course));
                    }
                }
                
            }
            catch
            {

            }
        }
    }
}
