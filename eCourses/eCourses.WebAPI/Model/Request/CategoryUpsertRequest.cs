using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class CategoryUpsertRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
