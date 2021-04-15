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
    public partial class SearchCourseByNamePage : ContentPage
    {
        private CourseSearchByNameVM model = null;
        public SearchCourseByNamePage()
        {
            InitializeComponent();
            BindingContext = model = new CourseSearchByNameVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
     
        private async void Course_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var courseVM = (e.SelectedItem as CourseVM);
            await Navigation.PushAsync(new CourseDetailPage(courseVM.Course));
        }
    }
}