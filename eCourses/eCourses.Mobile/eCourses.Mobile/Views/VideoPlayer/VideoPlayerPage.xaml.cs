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
    public partial class VideoPlayerPage : ContentPage
    {
        

        private VideoPlayerVM model = null;
        public VideoPlayerPage(MVideoLecture lecture)
        {

            InitializeComponent();
            BindingContext = model = new VideoPlayerVM(lecture);

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