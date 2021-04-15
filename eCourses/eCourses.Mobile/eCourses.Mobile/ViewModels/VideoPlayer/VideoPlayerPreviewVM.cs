using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCourses.Mobile.ViewModels.VideoPlayer
{
    public class VideoPlayerPreviewVM:BaseVM
    {
       
        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }

        public VideoPlayerPreviewVM()
        {

        }
       
        public VideoPlayerPreviewVM(MCourse course)
        {
            Course = course;

        }
    }
}
