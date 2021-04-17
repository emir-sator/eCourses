using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Model
{
    public class MTransaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public MUser User { get; set; }
        public int CourseID { get; set; }
        public MCourse Course { get; set; }
        public string CourseName { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Price { get; set; }
        public string UserFullName { get; set; }
    }
}
