using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Interface
{
    public interface IRecommendationService
    {
        Task<List<MCourse>> GetRecommendedCourses(int ID);
    }
}
