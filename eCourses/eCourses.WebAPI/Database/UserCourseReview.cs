using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class UserCourseReview
    {
        [Key]
        public int UserCourseReviewID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Rating { get; set; }
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
