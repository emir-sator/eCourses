using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Price { get; set; }

    }
}
