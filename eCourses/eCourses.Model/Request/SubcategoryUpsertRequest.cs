using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class SubcategoryUpsertRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
