using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI
{
    public class MCourseReview
    {
        public int UserCourseReviewID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public float Rating { get; set; }
    }
}
