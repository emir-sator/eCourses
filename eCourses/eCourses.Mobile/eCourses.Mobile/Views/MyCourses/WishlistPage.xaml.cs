using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.MyCourses;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Course;
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
    public partial class WishlistPage : ContentPage
    {
        private readonly APIService userService = new APIService("User");
        private WishlistVM model = null;
        public WishlistPage()
        {
            InitializeComponent();
            BindingContext = model = new WishlistVM();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            var userId = SignedInUser.User.UserID;
            var courses = await userService.GetLikedCourse(userId, null);
            if (courses.Count > 0)
            {
                Course.IsVisible = false;
                CourseList.IsVisible = true;
            }
            else
            {
                Course.IsVisible = true;
                CourseList.IsVisible = false;
            }
        }
        private async void Course_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = e.SelectedItem as CourseVM;
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }
    }
}