using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.MyCourses;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.MyCourses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersBoughtCoursesPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        private UsersBoughtCoursesVM model = null;
        public UsersBoughtCoursesPage()
        {
            InitializeComponent();
            BindingContext = model = new UsersBoughtCoursesVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var userID = SignedInUser.User.UserID;
            var courses = await userService.GetBoughtCourses(userID);
            if (courses.Count > 0)
            {
                BoughtCourses.IsVisible = false;
                CourseList.IsVisible = true;
            }
            else
            {
                BoughtCourses.IsVisible = true;
                CourseList.IsVisible = false;
            }
        }

        private async void BoughtCourse_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var course = (e.SelectedItem as MBuyCourse);
            await Navigation.PushAsync(new UserBoughtCoursesDetailPage(course.Course));
        }
    }
}