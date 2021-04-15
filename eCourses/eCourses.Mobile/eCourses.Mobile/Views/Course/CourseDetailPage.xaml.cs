using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.Course;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.Course
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailPage : ContentPage
    {
        private CourseDetailVM model = null;
        private readonly APIService courseService = new APIService("Course");
        public CourseDetailPage(MCourse course)
        {
            InitializeComponent();
            BindingContext = model = new CourseDetailVM(this.Navigation)
            {
                Course = course
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.InitLectures();  
        }

        private async  void InstructorCourse_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = e.SelectedItem as CourseVM;
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }
    }
}