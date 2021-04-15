﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.Model.Request
{
    public class ReviewUpsertRequest
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}