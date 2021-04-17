using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class CourseUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        public int SubcategoryID { get; set; }
        [Required]
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string URL { get; set; }
        public int UserID { get; set; }
     
    }
}
