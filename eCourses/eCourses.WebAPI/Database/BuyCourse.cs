using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class BuyCourse
    {
        [Key]
        public int BuyCourseID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime DateOfBuying { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Username { get; set; }
        public string CourseName { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
