using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Model;
using eCourses.WebAPI.Model.Request;
using eCourses.WebAPI.Request;

namespace eCourses.WebAPI.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, MCategory>();
            CreateMap<Category, CategorySearchRequest>().ReverseMap();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();

            CreateMap<Role, MRole>();
            CreateMap<UserRoles, MUserRole>();

            CreateMap<User, MUser>();
            CreateMap<User, UserUpsertRequest>().ReverseMap();

            CreateMap<Subcategory, MSubcategory>();
            CreateMap<Subcategory, SubcategoryUpsertRequest>().ReverseMap();

            CreateMap<Course, MCourse>().ReverseMap();
            CreateMap<Course, CourseUpsertRequest>().ReverseMap();

            CreateMap<VideoLecture, MVideoLecture>();
            CreateMap<VideoLecture, VideoLectureUpsertRequest>().ReverseMap();

            CreateMap<UserCourseReview, MCourseReview>();
            CreateMap<UserCourseReview, ReviewUpsertRequest>().ReverseMap();

            CreateMap<UserLikedCourse, MCourse>().ReverseMap();
            
            CreateMap<BuyCourse, Course>().ReverseMap();
            CreateMap<BuyCourse, MBuyCourse>().ReverseMap();
            CreateMap<BuyCourse, BuyCourseRequest>().ReverseMap();

            CreateMap<Section, MSection>();
            CreateMap<Section, SectionUpsertRequest>().ReverseMap();

            CreateMap<Transaction, MTransaction>();
            CreateMap<Transaction, TransactionUpsertRequest>().ReverseMap();

        }
    }
}
