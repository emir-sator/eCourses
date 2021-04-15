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
    public class UserController : CRUDController<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserService _service;
        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("Authenticate")]
        public async Task<MUser> Authenticate(UserAuthenticationRequest request)
        {
            return await _service.Authenticate(request);
        }
        [HttpPost("Register")]
        public async Task<MUser> Register(UserUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpGet("{ID}/LikedCourses")]
        [Authorize]
        public async Task<List<MCourse>> GetLikedCourse(int ID, [FromQuery] CourseSearchRequest request)
        {
            return await _service.GetLikedCourse(ID, request);
        }
        [HttpPost("{ID}/LikedCourse/{CourseID}")]
        [Authorize]
        public async Task<MCourse> InsertLikedCourse(int ID, int CourseID)
        {
            return await _service.InsertLikedCourse(ID, CourseID);
        }
        [HttpDelete("{ID}/LikedCourse/{CourseID}")]
        [Authorize]
        public async Task<MCourse> DeleteLikedCourse(int ID, int CourseID)
        {
            return await _service.DeleteLikedCourse(ID, CourseID);
        }
        [HttpGet("{ID}/GetBoughtCourses")]
        [Authorize]
        public async Task<List<MBuyCourse>> GetBoughtCourses(int ID)
        {
            return await _service.GetBoughtCourses(ID);
        }
    }
}
