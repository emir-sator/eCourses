using eCourses.WebAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _service;
        public RecommendationController(IRecommendationService service)
        {
            _service = service;
        }
        [HttpGet("GetRecommendedCourses")]
        public Task<List<MCourse>> GetRecommendedCourses(int UserID)
        {
            return _service.GetRecommendedCourses(UserID);
        }
    }
}
