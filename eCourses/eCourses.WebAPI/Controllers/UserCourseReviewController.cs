using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public UserCourseReviewController(IReviewService service)
        {
            _service = service;
        }
        [HttpGet]
        
        public async Task<List<MCourseReview>> Get([FromQuery] ReviewSearchRequest search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        [Authorize]
        public async Task<MCourseReview> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        [Authorize]
        public async Task<MCourseReview> Insert(ReviewUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        [Authorize]
        public async Task<MCourseReview> Update(int ID, ReviewUpsertRequest request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        [Authorize]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}
