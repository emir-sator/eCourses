using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eCourses.WebAPI.ViewModels
{
    public class CourseSalesVM
    {
        public int BuyCourseID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime DateOfBuying { get; set; }
        public string Username { get; set; }
        public string CourseName { get; set; }
        public float Price { get; set; }
        public MUser User { get; set; }
        public MCourse Course { get; set; }

       
    }
}
