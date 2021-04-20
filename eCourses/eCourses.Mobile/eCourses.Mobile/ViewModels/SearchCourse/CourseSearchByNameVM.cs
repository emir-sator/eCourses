using eCourses.Mobile.Helpers;
using eCourses.Model;
using eCourses.Model.Request;
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
    public class CourseSearchByNameVM:BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        public ObservableCollection<CourseVM> courseList { get; set; } = new ObservableCollection<CourseVM>();

        public ICommand SearchCourse { get; set; }

        public CourseSearchByNameVM()
        {
            SearchCourse = new Command(async (object query) => await Search(query));
        }
        private async Task Search(object query)
        {
            var request = new CourseSearchRequest()
            {
                Name = query as string
            };
            await Init(request);
        }
        public async Task Init(CourseSearchRequest request = null)
        {
            courseList.Clear();
            try
            {
                int userID = SignedInUser.User.UserID;
                var courses = await courseService.Get<List<MCourse>>(request);
                var usersBoughtCourses = await courseService.GetBoughtCourses(userID);
                foreach (var course in courses)
                {
                    var DoesItContain = usersBoughtCourses.Where(m => m.CourseID == course.CourseID).Any();
                    if (usersBoughtCourses.Count > 0)
                    {
                        if (DoesItContain == false&&course.UserID!=userID)
                        {
                            courseList.Add(new CourseVM(course));
                        }
                    }
                    else if(course.UserID!=userID)
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
