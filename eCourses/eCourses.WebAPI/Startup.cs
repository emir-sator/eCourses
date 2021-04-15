
using eCourses.WebAPI.Database;
using eCourses.WebAPI.Interface;
using eCourses.WebAPI.Model;
using eCourses.WebAPI.Model.Request;
using eCourses.WebAPI.Request;
using eCourses.WebAPI.Security;
using eCourses.WebAPI.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace eCourses.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); /*(x => x.Filters.Add<ErrorFilter>());*/
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<eCoursesContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("eCourses")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eCourse API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "basic"
                              }
                          },
                          new string[] {}
                    }
                });
            });

            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            //services.AddScoped<IBaseService<MSection, object>, SectionService>();
            services.AddScoped<IBaseService<MRole, object>, RoleService>();
            services.AddScoped<ICRUDService<MCategory, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>, CategoryService>();
            services.AddScoped<ICRUDService<MSubcategory, SubcategorySearchRequest, SubcategoryUpsertRequest, SubcategoryUpsertRequest>, SubcategoryService>();
            services.AddScoped<ICRUDService<MBuyCourse, BuyCourseSearchRequest, BuyCourseRequest, BuyCourseRequest>, BuyCourseService>();
            services.AddScoped<ICRUDService<MVideoLecture, VideoLectureSearchRequest, VideoLectureUpsertRequest, VideoLectureUpsertRequest>, VideoLectureService>();
            services.AddScoped<ICRUDService<MTransaction, TransactionSearchRequest, TransactionUpsertRequest, TransactionUpsertRequest>, TransactionService>();
            services.AddScoped<ICRUDService<MSection,SectionSearchRequest,SectionUpsertRequest,SectionUpsertRequest>, SectionService>();
            services.AddScoped<IUserService, UserService>();


            
            

            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseAuthentication();

           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eCourse API");
            });
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
