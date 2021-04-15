using eCourses.Mobile.Helpers;
using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.SearchCourse
{
    public class CourseVM : BaseVM
    {

        private readonly APIService userService = new APIService("User");
        private readonly APIService LectureService = new APIService("VideoLecture");


        public ICommand LikeCommand { get; set; }


        private bool _isLiked;
        public bool IsLiked
        {
            get { return _isLiked; }
            set
            {
                _isLiked = value;
                OnPropertyChanged(nameof(IsLikedImage));
            }
        }
        public string IsLikedImage
        {
            get => IsLiked ? "heart.png" : "heart-empty.png";
        }



        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }
        }

        public CourseVM()
        {

        }
        public CourseVM(MCourse course)
        {
            Course = course;
            if (LikeHelper.LikedCourses != null)
                IsLiked = LikeHelper.LikedCourses.Find(i => i.CourseID == Course.CourseID) != null;

            LikeCommand = new Command(async () => await ToggleLike());
        }

        private async Task ToggleLike()
        {
            try
            {
                if (IsLiked)
                {
                    await userService.DeleteLikedCourse(SignedInUser.User.UserID, Course.CourseID);
                    IsLiked = false;
                    LikeHelper.Remove(Course);
                }
                else
                {
                    await userService.InsertLikedCourse(SignedInUser.User.UserID, Course.CourseID);
                    IsLiked = true;
                    LikeHelper.LikedCourses.Add(Course);
                }
            }
            catch
            {

            }
        }
    }
}
