using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class SubcategoryUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
