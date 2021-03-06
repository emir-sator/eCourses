using eCourses.Mobile.ViewModels.VideoPlayer;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourses.Mobile.Views.VideoPlayer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPlayerPreviewPage : ContentPage
    {
        private VideoPlayerPreviewVM model = null;
        public VideoPlayerPreviewPage(MCourse course)
        {

            InitializeComponent();
            BindingContext = model = new VideoPlayerPreviewVM(course);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            videoPlayer.Play();

            if (Device.RuntimePlatform == Device.UWP)
                videoPlayer.IsVisible = true;
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            videoPlayer.Pause();

            if (Device.RuntimePlatform == Device.UWP)
                videoPlayer.IsVisible = false;
        }
    }
}