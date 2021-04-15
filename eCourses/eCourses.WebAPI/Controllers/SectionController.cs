using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Model.Request;
using eCourses.WebAPI.Request;
using Microsoft.AspNetCore.Mvc;

namespace eCourses.WebAPI.Controllers
{
    public class SectionController:CRUDController<MSection,SectionSearchRequest,SectionUpsertRequest, SectionUpsertRequest>
    {
        public SectionController(ICRUDService<MSection,SectionSearchRequest,SectionUpsertRequest,SectionUpsertRequest> service) : base(service)
        {

        }
    }
}
