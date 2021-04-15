using AutoMapper;
using eCourses.WebAPI.Request;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class SectionService :CRUDService<MSection,SectionSearchRequest,Section,SectionUpsertRequest, SectionUpsertRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public SectionService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        public  override async Task<List<MSection>> Get(SectionSearchRequest request)

        {
            var query = _context.Sections.AsQueryable().OrderBy(c => c.SectionID);

            if (request.SectionID != 0)
            {
                query = (IOrderedQueryable<Section>)query.Where(x => x.SectionID == request.SectionID);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<MSection>>(list);
        }
        public override async Task<MSection> GetById(int ID)
        {
            var entity = await _context.Sections
                .Where(i => i.SectionID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MSection>(entity);
        }
        public override async Task<MSection> Insert(SectionUpsertRequest request)
        {
            if (await _context.Sections.AnyAsync(i => i.SectionNumber == request.SectionNumber))
            {
                throw new UserException("Section with that number already exists!");
            }
            var entity = _mapper.Map<Section>(request);

            _context.Set<Section>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MSection>(entity);
        }
        public override async Task<MSection> Update(int ID, SectionUpsertRequest request)
        {
            var section = await _context.Sections.FindAsync(ID);
            if (await _context.Sections.AnyAsync(i => i.SectionNumber == request.SectionNumber))
            {
                throw new UserException("Section with that number already exists!");
            }

            var entity = _context.Set<Section>().Find(ID);
            _context.Set<Section>().Attach(entity);
            _context.Set<Section>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MSection>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var section = await _context.Sections.Where(c => c.SectionID == ID).FirstOrDefaultAsync();

            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}


