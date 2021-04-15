using eCourses.WebAPI.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Interface
{
    public interface ICourseService : ICRUDService<MCourse, CourseSearchRequest, CourseUpsertRequest, CourseUpsertRequest>
    {
        Task<List<MVideoLecture>> GetLectures(int ID, CourseSearchRequest request);

        Task<float> GetAverage(int ID);

        Task<int> GetTotal(int ID);

        
    }
}
