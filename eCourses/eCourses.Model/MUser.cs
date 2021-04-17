using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model
{
   public class MUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string GitHubURL { get; set; }
        public string LinkedinURL { get; set; }
        public byte[] Image { get; set; }
        public string FullName { get; set; }
        public ICollection<MUserRole> UserRoles { get; set; }
    }
}
