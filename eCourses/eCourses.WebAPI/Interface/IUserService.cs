using eCourses.WebAPI.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Interface
{
    public interface IUserService : ICRUDService<MUser, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        Task<MUser> Authenticate(UserAuthenticationRequest request);
        Task<MUser> Register(UserUpsertRequest request);
        Task<List<MCourse>> GetLikedCourse(int ID, CourseSearchRequest request);
        Task<MCourse> InsertLikedCourse(int ID, int TrackID);
        Task<MCourse> DeleteLikedCourse(int ID, int TrackID);
        Task<List<MBuyCourse>> GetBoughtCourses(int ID);
    }
}
