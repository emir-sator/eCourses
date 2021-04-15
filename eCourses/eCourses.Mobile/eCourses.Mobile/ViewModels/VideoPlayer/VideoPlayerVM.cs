using eCourses.Mobile.Helpers;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.VideoPlayer
{
    public class VideoPlayerVM : BaseVM
    {
        private MVideoLecture _lecture;
        public MVideoLecture Lecture
        {
            get { return _lecture; }
            set { SetProperty(ref _lecture, value); }
        }

        public VideoPlayerVM()
        {

        }
        public VideoPlayerVM(MVideoLecture lecture)
        {
            Lecture = lecture;
          
        }

    }
}
