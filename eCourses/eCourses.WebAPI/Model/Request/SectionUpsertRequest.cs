using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Request
{
    public class SectionUpsertRequest
    {
        public int SectionID { get; set; }
        public int SectionNumber { get; set; }
    }
}
