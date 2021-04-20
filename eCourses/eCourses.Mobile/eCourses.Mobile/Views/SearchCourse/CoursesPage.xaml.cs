using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.Course;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Course;
using eCourses.Model;
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
    public partial class CoursesPage : ContentPage
    {
        public APIService courseService = new APIService("Course");
        private CourseSearchVM modelSearchCourse = null;
        MUser _user;
        public CoursesPage()
        {
            InitializeComponent();
            BindingContext = modelSearchCourse = new CourseSearchVM();
        }
        public CoursesPage(MUser user)
        {
            InitializeComponent();
            _user = user;
            SignedInUser.User = user;
            BindingContext = modelSearchCourse = new CourseSearchVM();
           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await modelSearchCourse.Init(_user);
        
       }

  

        private async void Course_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = e.SelectedItem as CourseVM;
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }

     
    }
}