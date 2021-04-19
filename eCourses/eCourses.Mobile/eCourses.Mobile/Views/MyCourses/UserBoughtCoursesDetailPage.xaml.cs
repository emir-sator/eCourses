using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.MyCourses;
using eCourses.Mobile.Views.VideoPlayer;
using eCourses.Model;
using eCourses.Model.Request;
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
    public partial class UserBoughtCoursesDetailPage : ContentPage
    {
        private readonly APIService reviewService = new APIService("Review");
        private UsersBoughtCoursesDetailVM model = null;
        public UserBoughtCoursesDetailPage(MCourse course)
        {
            InitializeComponent();
            BindingContext = model = new UsersBoughtCoursesDetailVM(course,this.Navigation);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Course_RatingChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            int Rate = Convert.ToInt32(e.Value);
            var request = new ReviewUpsertRequest()
            {
                UserID = SignedInUser.User.UserID,
                CourseID = model.Course.CourseID,
                Rating = Rate
            };

            if (model.CourseReview == null)
            {
                model.CourseReview = await reviewService.Insert<MCourseReview>(request);
            }
            else if (model.CourseReview != null && model.Rating == 0)
            {
                await reviewService.Delete<MCourseReview>(model.CourseReview.UserCourseReviewID);
            }
            else
            {
                await reviewService.Update<MCourseReview>(model.CourseReview.UserCourseReviewID, request);
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lecture = e.SelectedItem as MVideoLecture;
            await Navigation.PushAsync(new VideoPlayerPage(lecture));
        }
    }
}