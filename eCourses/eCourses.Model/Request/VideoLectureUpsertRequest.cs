using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class VideoLectureUpsertRequest
    {
        public int VideoLectureID { get; set; }
        [Required]
        public string LectureName { get; set; }
        public string URL { get; set; }
        public DateTime UploadedOn { get; set; }
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        
    }
}
