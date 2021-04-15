using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Exceptions;
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class CourseService : CRUDService<MCourse, CourseSearchRequest, Course, CourseUpsertRequest, CourseUpsertRequest>, ICourseService
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public CourseService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MCourse>> Get(CourseSearchRequest request)
        {
            var query = _context.Courses.Include(i => i.User).AsQueryable().OrderBy(c=>c.Name);

            if (request.UserID!=0)
            {
                query = query.Where(x => x.UserID == request.UserID).Include(i=>i.User).OrderBy(c => c.Name);
            }

            if (request?.SubcategoryID.HasValue == true)
            {
                query = query.Where(x => x.SubcategoryID == request.SubcategoryID).Include(i => i.Subcategory).Include(i=>i.User).OrderBy(c => c.Name);
            }

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name)).Include(i => i.User).OrderBy(c => c.Name);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MCourse>>(list);
        }
        public override async Task<MCourse> GetById(int ID)
        {
            var entity = await _context.Courses
                .Where(i => i.CourseID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MCourse>(entity);
        }
        public override async Task<MCourse> Insert(CourseUpsertRequest request)
        {
            if (await _context.Courses.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Course with that name already exists!");
            }
            var entity = _mapper.Map<Course>(request);

            _context.Set<Course>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MCourse>(entity);
        }
        public override async Task<MCourse> Update(int ID, CourseUpsertRequest request)
        {
            var course = await _context.Courses.FindAsync(ID);
            if (await _context.Courses.AnyAsync(i => i.Name == request.Name) && request.Name != course.Name)
            {
                throw new UserException("Course with that name already exists!");
            }

            var entity = _context.Set<Course>().Find(ID);
            _context.Set<Course>().Attach(entity);
            _context.Set<Course>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MCourse>(entity);
        }
        public async Task<List<MVideoLecture>> GetLectures(int ID, CourseSearchRequest request)
        {
            var query = _context.VideoLectures.Where(i => i.CourseID == ID)
                .AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<MVideoLecture>>(list);
        }
        public override async Task<bool> Delete(int ID)
        {
            var course = await _context.Courses.Where(c => c.CourseID == ID).FirstOrDefaultAsync();

            //var BuyCourse = await _context.BuyCourses.Where(i => i.Course.Subcategory.CategoryID == ID).ToListAsync();
            //if (BuyCourse.Count > 0)
            //    _context.BuyCourses.RemoveRange(BuyCourse);

            if (course != null)
            {

                var courselectures = await _context.VideoLectures.Where(i => i.CourseID == ID).ToListAsync();
                if (courselectures != null)
                    _context.VideoLectures.RemoveRange(courselectures);

                var userCourses = await _context.UserLikedCourses.Where(i => i.CourseID == ID).ToListAsync();
                if (userCourses != null)
                    _context.UserLikedCourses.RemoveRange(userCourses);

                var userReview = await _context.UserCourseReviews.Where(i => i.CourseID == ID).ToListAsync();
                if (userReview != null)
                    _context.UserCourseReviews.RemoveRange(userReview);

                await _context.SaveChangesAsync();


                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async  Task<float> GetAverage(int CourseID)
        {
            var list = await _context.UserCourseReviews.Where(i => i.CourseID == CourseID).ToListAsync();
            return (float)list.Average(i => i.Rating);
        }

        public async Task<int> GetTotal(int CourseID)
        {
            var list = await _context.BuyCourses.Where(i => i.CourseID == CourseID).ToListAsync();
            return list.Count();
        }
    }
}
