using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Controllers
{
    public class CourseController : CRUDController<MCourse, CourseSearchRequest, CourseUpsertRequest, CourseUpsertRequest>
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("{ID}/Lectures")]
        public async Task<List<MVideoLecture>> GetLectures(int ID, [FromQuery] VideoLectureSearchRequest request)
        {
            return await _service.GetLectures(ID, request);
        }
        [HttpGet("{ID}/GetAvarageRating")]
        public async Task<float> GetAvarageRating(int ID)
        {
            return await _service.GetAverage(ID);
        }
        [HttpGet("{ID}/GetTotalStudents")]
        public async Task<float> GetTotalStudents(int ID)
        {
            return await _service.GetTotal(ID);
        }

        [HttpGet("{ID}/GetTotalInstructorsCourses")]
        public async Task<float> GetTotalInstructorsCourses(int ID)
        {
            return await _service.GetTotalInstructorsCourses(ID);
        }

        [HttpGet("{ID}/GetTotalStudentsFromInstructorsCourses")]
        public async Task<float> GetTotalStudentsFromInstructorsCourses(int ID)
        {
            return await _service.GetTotalStudentsFromInstructorsCourses(ID);
        }

        [HttpGet("{ID}/GetAverageInstructorsCoursesRating")]
        public async Task<float> GetAverageInstructorsCoursesRating(int ID)
        {
            return await _service.GetAverageInstructorsCoursesRating(ID);
        }


    }
}
