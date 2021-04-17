using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Model.Request
{
    public class TransactionSearchRequest
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string CourseName { get; set; }
    }
}
