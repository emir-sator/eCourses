using eCourses.Mobile.ViewModels.Course;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.Course
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructorDetailPage : ContentPage
    {
        Uri uri;
        public InstructorDetailVM model = null;
        public InstructorDetailPage(MUser User)
        {
            InitializeComponent();
            BindingContext = model = new InstructorDetailVM(User);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitCourses();
            if (model.User.GitHubURL != null)
            {
                btnOpenBrowserGitHub.IsVisible = true;
            }
            else
            {
                btnOpenBrowserGitHub.IsVisible = false;
            }

            if (model.User.LinkedinURL != null)
            {
                btnOpenBrowserLinkedIn.IsVisible = true;
            }
            else
            {
                btnOpenBrowserLinkedIn.IsVisible = false;
            }

        }
        public async void OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri);
        }

        private async void Course_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = e.SelectedItem as CourseVM;
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }

        private void btnOpenBrowserGitHub_Clicked(object sender, EventArgs e)
        {

            uri = new Uri(model.User.GitHubURL);
            OpenBrowser(uri);
        }

        private void btnOpenBrowserLinkedIn_Clicked(object sender, EventArgs e)
        {
           
            uri = new Uri(model.User.LinkedinURL);
            OpenBrowser(uri);

        }
    }
}