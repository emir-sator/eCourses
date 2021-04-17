using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public DateTime TransactionDate { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string CourseName { get; set; }
        public string UserFullName { get; set; }

    }
}
