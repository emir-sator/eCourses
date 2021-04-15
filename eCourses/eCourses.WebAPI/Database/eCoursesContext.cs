using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public partial class eCoursesContext :DbContext
    {
        public eCoursesContext(DbContextOptions<eCoursesContext> options)
           : base(options)
        {
        }
      
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserLikedCourse> UserLikedCourses { get; set; }
        public DbSet<UserCourseReview> UserCourseReviews { get; set; }
        public DbSet<BuyCourse> BuyCourses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<VideoLecture> VideoLectures { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserLikedCourse>()
                .HasKey(k => new { k.UserID, k.CourseID });
            modelBuilder.Entity<Transaction>().
                HasKey(t => new { t.TransactionID, t.CourseID, t.UserID });
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
