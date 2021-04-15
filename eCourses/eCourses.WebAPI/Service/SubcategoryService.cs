using AutoMapper;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Exceptions;
using eCourses.WebAPI.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class SubcategoryService : CRUDService<MSubcategory, SubcategorySearchRequest, Subcategory, SubcategoryUpsertRequest, SubcategoryUpsertRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public SubcategoryService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MSubcategory>> Get(SubcategorySearchRequest request)
        {
            var query = _context.Subcategories.AsQueryable().OrderBy(c => c.Name);

            if (request.CategoryID != null)
            {
                query = query.Where(x => x.CategoryID == request.CategoryID).OrderBy(x => x.Name);
            }
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name)).OrderBy(c => c.Name);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MSubcategory>>(list);
        }
        public override async Task<MSubcategory> GetById(int ID)
        {
            var entity = await _context.Subcategories
                .Where(i => i.SubcategoryID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MSubcategory>(entity);
        }
        public override async Task<MSubcategory> Insert(SubcategoryUpsertRequest request)
        {
            if (await _context.Subcategories.AnyAsync(i => i.Name == request.Name))
            {
                throw new UserException("Subategory with that name already exists!");
            }
            var entity = _mapper.Map<Subcategory>(request);

            _context.Set<Subcategory>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MSubcategory>(entity);
        }
        public override async Task<MSubcategory> Update(int ID, SubcategoryUpsertRequest request)
        {
            var subcategory = await _context.Subcategories.FindAsync(ID);
            if (await _context.Subcategories.AnyAsync(i => i.Name == request.Name) && request.Name != subcategory.Name)
            {
                throw new UserException("Subcategory with that name already exists!");
            }

            var entity = _context.Set<Subcategory>().Find(ID);
            _context.Set<Subcategory>().Attach(entity);
            _context.Set<Subcategory>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MSubcategory>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var subcategory = await _context.Subcategories.Where(s => s.SubcategoryID == ID).FirstOrDefaultAsync();

            var course = await _context.Courses.Where(i => i.SubcategoryID == subcategory.SubcategoryID).ToListAsync();

            var BuyCourse = await _context.BuyCourses.Where(i => i.Course.SubcategoryID == subcategory.SubcategoryID).ToListAsync();
           
            if (subcategory != null)
            {
                if (course.Count > 0)
                {
                    _context.Courses.RemoveRange(course);
                    if (BuyCourse.Count > 0)
                        _context.BuyCourses.RemoveRange(BuyCourse);

                    await _context.SaveChangesAsync();
                }

                _context.Subcategories.Remove(subcategory);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
