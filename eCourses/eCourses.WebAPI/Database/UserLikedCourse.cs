using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class UserLikedCourse
    {
       
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
