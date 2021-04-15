using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class Section
    {
        public Section()
        {
            VideoLectures = new HashSet<VideoLecture>();
        }
        public int SectionID { get; set; }
        public int SectionNumber { get; set; }

        public virtual ICollection<VideoLecture> VideoLectures { get; set; }
    }
}
