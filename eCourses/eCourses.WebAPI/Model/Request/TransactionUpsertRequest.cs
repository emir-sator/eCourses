using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Model.Request
{
    public class TransactionUpsertRequest
    {
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Price { get; set; }
        public string CourseName { get; set; }
        public string UserFullName { get; set; }
    }
}
