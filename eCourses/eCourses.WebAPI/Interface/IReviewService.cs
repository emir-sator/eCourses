using eCourses.WebAPI.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Interface
{
    public interface IReviewService
    {
        Task<List<MCourseReview>> Get(ReviewSearchRequest search);
        Task<MCourseReview> GetById(int ID);
        Task<MCourseReview> Insert(ReviewUpsertRequest request);
        Task<MCourseReview> Update(int ID, ReviewUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
