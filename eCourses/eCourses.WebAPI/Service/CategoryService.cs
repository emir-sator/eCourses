using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Exceptions;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class CategoryService : CRUDService<MCategory, CategorySearchRequest, Category, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public CategoryService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MCategory>> Get(CategorySearchRequest request)
        {
            var query = _context.Categories.AsQueryable().OrderBy(c => c.Name);

            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name)).OrderBy(c => c.Name);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MCategory>>(list);
        }
        public override async Task<MCategory> GetById(int ID)
        {
            var entity = await _context.Categories
                .Where(i => i.CategoryID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MCategory>(entity);
        }
        public override async Task<MCategory> Insert(CategoryUpsertRequest request)
        {
            if (await _context.Categories.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Category with that name already exists!");
            }
            var entity = _mapper.Map<Category>(request);

            _context.Set<Category>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MCategory>(entity);
        }
        public override async Task<MCategory> Update(int ID, CategoryUpsertRequest request)
        {
            var category = await _context.Categories.FindAsync(ID);
            if (await _context.Categories.AnyAsync(i => i.Name == request.Name) && request.Name != category.Name)
            {
                throw new UserException("Category with that name already exists!");
            }

            var entity = _context.Set<Category>().Find(ID);
            _context.Set<Category>().Attach(entity);
            _context.Set<Category>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MCategory>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var category = await _context.Categories.Where(i => i.CategoryID == ID).FirstOrDefaultAsync();
            var subcategory = await _context.Subcategories.Where(i => i.CategoryID == ID).ToListAsync();
            var course = await _context.Courses.Where(i => i.Subcategory.CategoryID == ID).ToListAsync();

            var BuyCourse = await _context.BuyCourses.Where(i => i.Course.Subcategory.CategoryID == ID).ToListAsync();
            if (subcategory.Count > 0)
            {
                _context.Courses.RemoveRange(course);
                if (BuyCourse.Count > 0)
                    _context.BuyCourses.RemoveRange(BuyCourse);
                _context.Subcategories.RemoveRange(subcategory);
                await _context.SaveChangesAsync();
            }
            if (category != null)
            {

                var userCourses = await _context.UserLikedCourses.Where(i => i.Course.Subcategory.CategoryID == ID).ToListAsync();
                _context.UserLikedCourses.RemoveRange(userCourses);
                var userReview = await _context.UserCourseReviews.Where(i => i.Course.Subcategory.CategoryID == ID).ToListAsync();
                await _context.SaveChangesAsync();


                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
