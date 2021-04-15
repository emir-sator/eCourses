using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class BuyCourseService : CRUDService<MBuyCourse, BuyCourseSearchRequest, BuyCourse, BuyCourseRequest, BuyCourseRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public BuyCourseService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<MBuyCourse>> Get(BuyCourseSearchRequest request)
        {
            var query = _context.BuyCourses.AsQueryable();

            if (request.From != null)
            {
                query = query.Where(i => i.DateOfBuying >= request.From);
            }
            if (request.To != null)
            {
                query = query.Where(i => i.DateOfBuying <= request.To);
            }
            if (request.CourseID != 0)
            {
                query = query.Where(i => i.CourseID ==request.CourseID);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MBuyCourse>>(query);
        }
        

    }
}
