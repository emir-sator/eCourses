using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;

namespace eCourses.WebAPI.Controllers
{

    public class CategoryController : CRUDController<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(ICRUDService<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> service) : base(service)
        {

        }
    }
}
