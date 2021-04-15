using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eCourses.WebAPI.Database
{
    public class Course
    {
        public Course()
        {
            UserCourseReviews = new HashSet<UserCourseReview>();
            Sections = new HashSet<Section>();
            Lectures = new HashSet<VideoLecture>();
        }
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int SubcategoryID { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public  int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserCourseReview> UserCourseReviews { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<VideoLecture> Lectures { get; set; }




    }
}
