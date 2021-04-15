using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class VideoLectureSearchRequest
    {

        public int? SectionID { get; set; }
        public int CourseID { get; set; }
        public string LectureName { get; set; }
    }
}
