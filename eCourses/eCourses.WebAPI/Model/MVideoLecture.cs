using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI
{
    public class MVideoLecture
    {
        public int VideoLectureID { get; set; }
        public string LectureName { get; set; }
        public string VideoName { get; set; }
        public string Length { get; set; }
        public string URL { get; set; }
        public DateTime UploadedOn { get; set; }
        public int SectionID { get; set; }
        public MSection Section { get; set; }
        public int CourseID { get; set; }
        public MCourse Course { get; set; }
    }
}
