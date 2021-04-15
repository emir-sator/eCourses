using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class ReviewService : IReviewService
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public ReviewService(eCoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MCourseReview>> Get(ReviewSearchRequest search)
        {

            var query = _context.UserCourseReviews.AsQueryable();

            if (search.UserID != 0)
            {
                query = query.Where(i => i.UserID == search.UserID);
            }

            if (search.CourseID != 0)
            {
                query = query.Where(i => i.CourseID == search.CourseID);
            }

            if (search.Rating != 0)
            {
                query = query.Where(i => i.Rating == search.Rating);
            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<MCourseReview>>(list);
        }

        public async Task<MCourseReview> GetById(int ID)
        {
            var entity = await _context.UserCourseReviews
               .Include(i => i.Course)
               .Where(i => i.UserID == ID)
               .SingleOrDefaultAsync();

            return _mapper.Map<MCourseReview>(entity);
        }

        public async Task<MCourseReview> Insert(ReviewUpsertRequest request)
        {
            var entity = _mapper.Map<UserCourseReview>(request);
            _context.Set<UserCourseReview>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MCourseReview>(entity);
        }

        public async Task<MCourseReview> Update(int ID, ReviewUpsertRequest request)
        {
            var entity = _context.Set<UserCourseReview>().Find(ID);
            _context.Set<UserCourseReview>().Attach(entity);
            _context.Set<UserCourseReview>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MCourseReview>(entity);
        }

        public async Task<bool> Delete(int ID)
        {
            var review = await _context.UserCourseReviews.Where(i => i.UserID == ID).Include(i => i.CourseID).FirstOrDefaultAsync();
            if (review != null)
            {
                _context.UserCourseReviews.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
