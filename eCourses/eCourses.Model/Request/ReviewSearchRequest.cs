using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class ReviewSearchRequest
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public int Rating { get; set; }
    }
}
