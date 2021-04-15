using eCourses.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI
{
    public class SetupService
    {
        public static void Init(eCoursesContext context)
        {
            context.Database.Migrate();
        }
    }
}
