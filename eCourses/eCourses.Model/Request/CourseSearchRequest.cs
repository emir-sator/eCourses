using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class CourseSearchRequest
    {
        public int UserID { get; set; }
        public int? SubcategoryID { get; set; }
        public string Name { get; set; }
    }
}
