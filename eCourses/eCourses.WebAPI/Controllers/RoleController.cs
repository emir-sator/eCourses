using eCourses.WebAPI.Interface;

namespace eCourses.WebAPI.Controllers
{

    public class RoleController : BaseController<MRole, object>
    {
        public RoleController(IBaseService<MRole, object> service) : base(service)
        {
        }
    }
}
