using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Request;

namespace eCourses.WebAPI.Controllers
{

    public class VideoLectureController : CRUDController<MVideoLecture, VideoLectureSearchRequest, VideoLectureUpsertRequest, VideoLectureUpsertRequest>
    {
        public VideoLectureController(ICRUDService<MVideoLecture, VideoLectureSearchRequest, VideoLectureUpsertRequest, VideoLectureUpsertRequest> service) : base(service)
        {

        }
    }
}
