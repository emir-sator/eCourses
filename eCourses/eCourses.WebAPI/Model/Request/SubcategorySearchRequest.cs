using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class SubcategorySearchRequest
    {
        public string Name { get; set; }
        public int? CategoryID { get; set; }
    }
}
