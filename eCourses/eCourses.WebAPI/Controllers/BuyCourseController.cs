using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;

namespace eCourses.WebAPI.Controllers
{
    public class BuyCourseController : CRUDController<MBuyCourse, BuyCourseSearchRequest, BuyCourseRequest, BuyCourseRequest>
    {
        public BuyCourseController(ICRUDService<MBuyCourse, BuyCourseSearchRequest, BuyCourseRequest, BuyCourseRequest> service) : base(service)
        {
        }
    }
}
