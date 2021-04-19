using eCourses.Mobile.Helpers;
using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Course;
using eCourses.Model;
using eCourses.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourses.Mobile.ViewModels.MyCourses
{
    public class UsersBoughtCoursesDetailVM:BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService sectionService = new APIService("Section");
        private readonly APIService lectureService = new APIService("VideoLecture");
        private readonly APIService reviewService = new APIService("Review");
        public ObservableCollection<MVideoLecture> videoLectureList { get; set; } = new ObservableCollection<MVideoLecture>();
        public ObservableCollection<MSection> sectionList { get; set; } = new ObservableCollection<MSection>();
        public ObservableCollection<MSection> NewsectionList { get; set; } = new ObservableCollection<MSection>();

        private MCourse _course;

        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course,value); }
        }

        private decimal rating;
        public decimal Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        private MCourseReview courseReview;
        public MCourseReview CourseReview
        {
            get { return courseReview; }
            set { SetProperty(ref courseReview, value); }
        }

    

        MSection _selectedSection = null;
        public MSection SelectedSection
        {
            get { return _selectedSection; }
            set
            {
                SetProperty(ref _selectedSection, value);
                GetLectures();

            }
        }
        private readonly INavigation Navigation;
        public ICommand ShowDetailCommand { get; set; }
        public UsersBoughtCoursesDetailVM()
        {
            ShowDetailCommand = new Command(async () => await ShowDetail());
        }
        public UsersBoughtCoursesDetailVM(MCourse course, INavigation nav)
        {
            this.Navigation = nav;
            Course = course;
            GetReview();
            ShowDetailCommand = new Command(async () => await ShowDetail());
        }

        public async Task ShowDetail()
        {
            await Navigation.PushAsync(new InstructorDetailPage(Course.User));
        }

        public async Task Init(CourseSearchRequest request= null)
        {
            videoLectureList.Clear();
            try
            {
                
                var lectures = await courseService.GetLectures<List<MVideoLecture>>(Course.CourseID, request);
                foreach(var lecture in lectures)
                {
                    videoLectureList.Add(lecture);

                    var req = new SectionSearchRequest
                    {
                        SectionID = lecture.SectionID
                    };


                    var sections = await sectionService.Get<List<MSection>>(req);


                    foreach (var section in sections)
                    {
                        if (lecture.SectionID == section.SectionID)
                        {
                            sectionList.Add(section);
                        }
                    }
                }

                foreach (var x in sectionList)
                {
                    var DoesItContain = NewsectionList.Where(m => m.SectionID == x.SectionID).Any();
                    if (DoesItContain == false)
                    {
                        NewsectionList.Add(x);
                    }

                }

            }
            catch
            {

            }
        }

        public async void GetReview()
        {
            await SetCourseReview(Course.CourseID);
            Rating = (decimal)(courseReview != null ? courseReview.Rating : 0);
        }

        private async Task SetCourseReview(int CourseID)
        {
            var request = new ReviewSearchRequest()
            {
                CourseID = CourseID,
                UserID = SignedInUser.User.UserID
            };

            var list = await reviewService.Get<List<MCourseReview>>(request);
            if (list != null)
                CourseReview = list.FirstOrDefault();
        }
    


        public async void GetLectures()
        {


            if (SelectedSection != null)
            {
                VideoLectureSearchRequest search = new VideoLectureSearchRequest
                {
                    SectionID = _selectedSection.SectionID,
                    CourseID = _course.CourseID
                };
                videoLectureList.Clear();
                var lectures = await lectureService.Get<List<MVideoLecture>>(search);

                foreach (var x in lectures)
                {
                    videoLectureList.Add(x);
                }
            }

        }
    }
}
