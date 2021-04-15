using eCourses.Mobile.ViewModels.SearchCourse;
using eCourses.Mobile.Views.Course;
using eCourses.Mobile.Views.VideoPlayer;
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

namespace eCourses.Mobile.ViewModels.Course
{
    public class CourseDetailVM : BaseVM
    {
        private readonly APIService courseService = new APIService("Course");
        private readonly APIService sectionService = new APIService("Section");
        private readonly APIService lectureService = new APIService("VideoLecture");
        private readonly APIService boughtCoursesSerivce = new APIService("BuyCourse");

        public ObservableCollection<MVideoLecture> videoLectureList { get; set; } = new ObservableCollection<MVideoLecture>();
        public ObservableCollection<CourseVM> InstructorList { get; set; } = new ObservableCollection<CourseVM>();
        public ObservableCollection<MSection> sectionList { get; set; } = new ObservableCollection<MSection>();
        public ObservableCollection<MSection> NewsectionList { get; set; } = new ObservableCollection<MSection>();
        public ObservableCollection<MSection> ThirdsectionList { get; set; } = new ObservableCollection<MSection>();

        public CourseDetailVM()
        {
            BuyCommand = new Command(async () => await Buy());
            WatchCommand = new Command(async () => await Watch());


        }
        private MCourse _course;
        public MCourse Course
        {
            get { return _course; }
            set { SetProperty(ref _course, value); }

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

        private float rating;
        public float Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }

        }

        public CourseDetailVM(MCourse course)
        {
            Course = course;
            InitCommand = new Command(async () => await InitLectures());
        }

        public CourseDetailVM(INavigation nav)
        {
            this.Navigation = nav;
            InitCommand = new Command(async () => await InitLectures());
            WatchCommand = new Command(async () => await Watch());
            BuyCommand = new Command(async () => await Buy());

        }
        private readonly INavigation Navigation;

        public ICommand InitCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand WatchCommand { get; set; }



        public async Task Buy()
        {
            await Navigation.PushAsync(new PaymentPage(Course));
        }

        public async Task Watch()
        {
            await Navigation.PushAsync(new VideoPlayerPreviewPage(Course));
        }

        public async Task InitLectures()
        {
            Rating = await courseService.GetAverageRating<float>(Course.CourseID);
            Total = await courseService.GetTotalStudents<int>(Course.CourseID);
            videoLectureList.Clear();
            try
            {

                var lectures = await courseService.GetLectures<List<MVideoLecture>>(Course.CourseID, null);
                if (lectures.Count() != 0)
                {
                    foreach (var lecture in lectures)
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



                CourseSearchRequest request = new CourseSearchRequest()
                {
                    UserID = Course.User.UserID
                };
                InstructorList.Clear();
                var courses = await courseService.Get<List<MCourse>>(request);
                foreach (var course in courses)
                {
                    if (courses.Count > 0)
                    {
                        if (course.CourseID != Course.CourseID)
                        {
                            InstructorList.Add(new CourseVM(course));
                        }
                    }
                    else
                    {
                        InstructorList.Add(new CourseVM(course));
                    }
                }
            }
            catch (Exception)
            {

            }
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
