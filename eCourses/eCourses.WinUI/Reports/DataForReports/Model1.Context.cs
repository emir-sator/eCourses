﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCourses.WinUI.Reports.DataForReports
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class eCoursesBazaEntities1 : DbContext
    {
        public eCoursesBazaEntities1()
            : base("name=eCoursesBazaEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Top3WorstAverageRatingCourses_Result> Top3WorstAverageRatingCourses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Top3WorstAverageRatingCourses_Result>("Top3WorstAverageRatingCourses");
        }
    }
}
