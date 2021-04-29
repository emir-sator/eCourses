using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryName { get; set; }
    }
}
