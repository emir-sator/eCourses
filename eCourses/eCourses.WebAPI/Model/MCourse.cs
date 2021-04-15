using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI
{
    public class MCourse
    {
        
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int SubcategoryID { get; set; }
        public  MSubcategory Subcategory { get; set; }
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public int UserID { get; set; }
        public  MUser User { get; set; }
        //public virtual ICollection<UserCourseReview> UserCourseReviews { get; set; }
        public virtual ICollection<MVideoLecture> VideoLectures { get; set; }


    }
}
