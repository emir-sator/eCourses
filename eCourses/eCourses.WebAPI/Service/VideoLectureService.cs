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
    public class VideoLectureService : CRUDService<MVideoLecture, VideoLectureSearchRequest, VideoLecture, VideoLectureUpsertRequest, VideoLectureUpsertRequest>
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        public VideoLectureService(eCoursesContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<MVideoLecture>> Get(VideoLectureSearchRequest request)
        {
            var query = _context.VideoLectures.AsQueryable().OrderBy(c => c.LectureName);

            if (request.CourseID !=0)
            {
                query = query.Where(x => x.CourseID == request.CourseID).OrderBy(c => c.UploadedOn);
            }

            if (request.SectionID != 0)
            {
                query = query.Where(x => x.SectionID == request.SectionID).OrderBy(c => c.UploadedOn);
            }

            if (!string.IsNullOrWhiteSpace(request?.LectureName))
            {
                query = query.Where(x => x.LectureName.StartsWith(request.LectureName)).OrderBy(c => c.UploadedOn);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<MVideoLecture>>(list);
        }
        public override async Task<MVideoLecture> GetById(int ID)
        {
            var entity = await _context.VideoLectures
                .Where(i => i.VideoLectureID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<MVideoLecture>(entity);
        }
        public override async Task<MVideoLecture> Insert(VideoLectureUpsertRequest request)
        {
            if (await _context.VideoLectures.AnyAsync(i => i.LectureName == request.LectureName))
            {
                throw new UserException("Lecture with that name already exists!");
            }
            var entity = _mapper.Map<VideoLecture>(request);

            _context.Set<VideoLecture>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<MVideoLecture>(entity);
        }
        public override async Task<MVideoLecture> Update(int ID, VideoLectureUpsertRequest request)
        {
            var lecture = await _context.VideoLectures.FindAsync(ID);
            if (await _context.VideoLectures.AnyAsync(i => i.LectureName == request.LectureName) && request.LectureName != lecture.LectureName)
            {
                throw new UserException("Lecture with that name already exists!");
            }

            var entity = _context.Set<VideoLecture>().Find(ID);
            _context.Set<VideoLecture>().Attach(entity);
            _context.Set<VideoLecture>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<MVideoLecture>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var lecture = await _context.VideoLectures.Where(c => c.VideoLectureID == ID).FirstOrDefaultAsync();

            if (lecture != null)
            {
                _context.VideoLectures.Remove(lecture);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
