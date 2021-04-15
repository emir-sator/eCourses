using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class VideoLecture
    {
        public int VideoLectureID { get; set; }
        public string LectureName { get; set; }
        public string URL { get; set; }
        public DateTime UploadedOn { get; set; }
        public int SectionID { get; set; }
        public virtual Section Section { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

    }
}
