using AutoMapper;
using eCourses.WebAPI.Database;

namespace eCourses.WebAPI.Service
{
    public class RoleService : BaseService<MRole, object, Role>
    {
        public RoleService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
