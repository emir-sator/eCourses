using eCourses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Mobile.Helpers
{
    public class LikeHelper
    {
        private readonly APIService userService = new APIService("User");
        public static List<MCourse> LikedCourses{ get; set; }
    

        public LikeHelper()
        {
            Init();
        }
        private async Task Init()
        {
            LikedCourses = await userService.GetLikedCourse(SignedInUser.User.UserID, null);
          
        }
        public static bool Remove(MCourse item)
        {
            var itemToRemove = LikedCourses.Where(i => i.CourseID == item.CourseID).FirstOrDefault();
            return LikedCourses.Remove(itemToRemove);
        }
        
    }
}
