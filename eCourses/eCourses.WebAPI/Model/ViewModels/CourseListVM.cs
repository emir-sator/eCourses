using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.ViewModels
{
    public class CourseListVM
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
     
    }
}
