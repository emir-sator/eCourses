using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class BuyCourseRequest
    {
        public int BuyCourseID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime DateOfBuying { get; set; }
        public string Username { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
    }
}
