using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.SearchCourse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendedCoursePage : ContentPage
    {
        private readonly APIService recommendService = new APIService("Recommendation");
        private readonly APIService courseService = new APIService("Course");
        private RecommendedCourseVM model = null;
        public RecommendedCoursePage()
        {
            InitializeComponent();
            BindingContext = model = new RecommendedCourseVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            int userID = SignedInUser.User.UserID;
            var recommendCourses = await recommendService.GetRecommandedCourses(userID);

            if (recommendCourses.Count < 1)
            {
                noReviews.IsVisible = true;
                Review.IsVisible = false;
                CoursesForYou.IsVisible = false;

            }
            else
            {
                noReviews.IsVisible = false;
                CoursesForYou.IsVisible = true;
                Review.IsVisible = true;

            }



        }

        private async void Course_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = e.SelectedItem as CourseVM;
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }

    }
}