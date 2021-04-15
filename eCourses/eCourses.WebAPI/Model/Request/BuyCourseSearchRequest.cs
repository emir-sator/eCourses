using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class BuyCourseSearchRequest
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? SubcategoryID { get; set; }
        public int CourseID { get; set; }
    }
}
