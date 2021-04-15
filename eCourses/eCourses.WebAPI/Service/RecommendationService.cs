using AutoMapper;
using eCourses.Mobile;
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Service
{
    public class RecommendationService : IRecommendationService
    {
        private readonly eCoursesContext _context;
        private readonly IMapper _mapper;
        private readonly APIService courseService = new APIService("Course");
        public RecommendationService(eCoursesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MCourse>> GetRecommendedCourses(int UserID)
        {
            try
            {
                if (UserID == 0)
                {
                    throw new Exception();
                }
                List<UserCourseReview> userReviews = await _context.UserCourseReviews.Where(x => x.UserID == UserID)
                    .Include(x => x.User)
                    .Include(x => x.Course)
                    .Include(x => x.Course.Subcategory)
                    .Include(x=>x.Course.User)
                    .ToListAsync();

                List<UserCourseReview> bestUserReviews = userReviews
                    .Where(x => x.Rating >= 3)
                    .ToList();

                if (bestUserReviews.Count > 0)
                {
                    List<Subcategory> subcategories = new List<Subcategory>();

                    foreach (var subcategory in bestUserReviews)
                    {
                        var courseSubcategory = await _context.Courses.Where(m => m.SubcategoryID == subcategory.Course.SubcategoryID)
                           .Select(s => s.Subcategory)
                           .ToListAsync();

                        foreach (var x in courseSubcategory)
                        {
                            bool add = true;
                            for (int i = 0; i < subcategories.Count; i++)
                            {
                                if (x.Name == subcategories[i].Name)
                                {
                                    add = false;
                                }
                            }
                            if (add)
                            {
                                subcategories.Add(x);
                            }
                        }
                    }


                    List<Course> final = new List<Course>();
                    var usersBoughtCourses = await _context.BuyCourses.Where(i => i.UserID == UserID).ToListAsync();
                    foreach (var item in subcategories)
                    {
                        var subcategoryCourses  = await _context.Courses
                            .Where(s => s.SubcategoryID == item.SubcategoryID)
                            .Include(i => i.User)
                            .ToListAsync();

                        foreach (var course in subcategoryCourses)
                        {
                            bool add = true;
                            var DoesItContain = usersBoughtCourses.Where(m => m.CourseID == course.CourseID).Any();
                            if (DoesItContain == false)
                            {
                                for (int i = 0; i < final.Count; i++)
                                {
                                    if (course.Name == final[i].Name)
                                    {
                                        add = false;
                                    }
                                }
                                foreach (var rate in userReviews)
                                {
                                    if (course.Name == rate.Course.Name)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    final.Add(course);
                                }
                            }

                            
                        }
                    }


                    final = final.OrderBy(x => Guid.NewGuid()).Take(6).ToList();

                    return _mapper.Map<List<MCourse>>(final);
                }
                throw new Exception();
            }
            catch
            {
                return _mapper.Map<List<MCourse>>(null);
            }
        }
    }
}
