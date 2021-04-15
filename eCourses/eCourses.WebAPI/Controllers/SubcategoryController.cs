using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;

namespace eCourses.WebAPI.Controllers
{
    public class SubcategoryController : CRUDController<MSubcategory, SubcategorySearchRequest, SubcategoryUpsertRequest, SubcategoryUpsertRequest>
    {
        public SubcategoryController(ICRUDService<MSubcategory, SubcategorySearchRequest, SubcategoryUpsertRequest, SubcategoryUpsertRequest> service) : base(service)
        {

        }
    }
}
