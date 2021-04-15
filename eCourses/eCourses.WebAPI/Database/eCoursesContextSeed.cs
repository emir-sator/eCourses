using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCourses.WebAPI.Database
{
    public partial class eCoursesContext
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {


            List<string> Salt = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                Salt.Add(GenerateSalt());
            }
            modelBuilder.Entity<User>().HasData
            (
                new User
                {
                    UserID = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Admin",
                    Email = "admin@ecourses.com",
                    PhoneNumber = "061435234",
                    PasswordSalt = Salt[0],
                    PasswordHash = GenerateHash(Salt[0], "Admin123.")
                },
                new User
                {
                    UserID = 2,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Username = "Desktop",
                    Email = "adminDeskop@ecourses.com",
                    PhoneNumber = "061525234",
                    PasswordSalt = Salt[1],
                    PasswordHash = GenerateHash(Salt[1], "Admin123.")
                },
                new User
                {
                    UserID = 3,
                    FirstName = "Mobile",
                    LastName = "Mobile",
                    Username = "Mobile",
                    Email = "mobile@ecourses.com",
                    PhoneNumber = "061121777",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Mobile123.")
                },
                new User
                {
                    UserID = 4,
                    FirstName = "InstructorIme",
                    LastName = "InstructorPrezime",
                    Username = "Instructor1",
                    Email = "instructor1@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor1.")
                },
                new User
                {
                    UserID = 8,
                    FirstName = "Instructor2Ime",
                    LastName = "Instructor2Prezime",
                    Username = "Instructor2",
                    Email = "instructor2@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor2.")
                },
                new User
                {
                    UserID = 9,
                    FirstName = "Instructor3Ime",
                    LastName = "Instructor3Prezime",
                    Username = "Instructor3",
                    Email = "instructor1@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor3.")
                },
                new User
                {
                    UserID = 5,
                    FirstName = "Polaznik1Ime",
                    LastName = "Polaznik1Prezime",
                    Username = "Polaznik1",
                    Email = "polaznik1@ecourses.com",
                    PhoneNumber = "252612661",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Polaznik1.")
                },
                new User
                {
                    UserID = 6,
                    FirstName = "Polaznik2Ime",
                    LastName = "Polaznik2Prezime",
                    Username = "Polaznik2",
                    Email = "polaznik2@ecourses.com",
                    PhoneNumber = "252612661",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Polaznik2.")
                },
                 new User
                 {
                     UserID = 7,
                     FirstName = "Polaznik3Ime",
                     LastName = "Polaznik3Prezime",
                     Username = "Polaznik3",
                     Email = "polaznik3@ecourses.com",
                     PhoneNumber = "252612661",
                     PasswordSalt = Salt[2],
                     PasswordHash = GenerateHash(Salt[2], "Polaznik3.")
                 }
            );
            modelBuilder.Entity<Role>().HasData
            (
                new Role { RoleID = 1, Name = "Admin" },
                new Role { RoleID = 2, Name = "Instruktor" },
                new Role { RoleID = 3, Name = "Polaznik" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Development" },
                new Category { CategoryID = 2, Name = "Design" },
                new Category { CategoryID = 3, Name = "Marketing" },
                new Category { CategoryID = 4, Name = "Business" }
                );
            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { SubcategoryID = 1, Name = "Web Development", CategoryID = 1 },
                new Subcategory { SubcategoryID = 2, Name = "Game Development", CategoryID = 1 },
                new Subcategory { SubcategoryID = 3, Name = "Web Design", CategoryID = 2 },
                new Subcategory { SubcategoryID = 4, Name = "Game Design", CategoryID = 2 },
                new Subcategory { SubcategoryID = 5, Name = "Advertising", CategoryID = 3 },
                new Subcategory { SubcategoryID = 6, Name = "Business strategy ", CategoryID = 4 },
                new Subcategory { SubcategoryID = 7, Name = "3D Design ", CategoryID = 2 }

                );
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { UserRoleID = 1, UserID = 1, RoleID = 1 },
                new UserRoles { UserRoleID = 2, UserID = 2, RoleID = 2 },
                new UserRoles { UserRoleID = 3, UserID = 2, RoleID = 3 },
                new UserRoles { UserRoleID = 4, UserID = 3, RoleID = 2 },
                new UserRoles { UserRoleID = 5, UserID = 3, RoleID = 3 },
                new UserRoles { UserRoleID = 6, UserID = 4, RoleID = 2 },
                new UserRoles { UserRoleID = 7, UserID = 4, RoleID = 3 },
                new UserRoles { UserRoleID = 8, UserID = 5, RoleID = 2 },
                new UserRoles { UserRoleID = 9, UserID = 5, RoleID = 3 },
                new UserRoles { UserRoleID = 10, UserID = 6, RoleID = 2 },
                new UserRoles { UserRoleID = 11, UserID = 6, RoleID = 3 },
                new UserRoles { UserRoleID = 12, UserID = 7, RoleID = 2 },
                new UserRoles { UserRoleID = 13, UserID = 7, RoleID = 3 },
                new UserRoles { UserRoleID = 14, UserID = 8, RoleID = 2 },
                new UserRoles { UserRoleID = 15, UserID = 8, RoleID = 3 },
                new UserRoles { UserRoleID = 16, UserID = 9, RoleID = 2 },
                new UserRoles { UserRoleID = 17, UserID = 9, RoleID = 3 }
                );
            modelBuilder.Entity<Course>().HasData
                (
                new Course
                {
                    CourseID = 1,
                    Name = "Getting started with c#",
                    SubcategoryID = 1,
                    Language = "English",
                    Price = 300,
                    DateCreated=DateTime.Now,
                    Image = File.ReadAllBytes("Files/csharp.jpg"),
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    UserID = 9,
                    URL= "http://vjs.zencdn.net/v/oceans.mp4"

                },
                 new Course
                 {
                     CourseID = 2,
                     Name = "Getting started with JavaScript",
                     SubcategoryID = 1,
                     Language = "English",
                     Price = 88,
                     DateCreated = DateTime.Now,
                     Image = File.ReadAllBytes("Files/js.jpg"),
                     Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                     UserID = 4

                 },
                  new Course
                  {
                      CourseID = 3,
                      Name = "Getting started with CSS",
                      SubcategoryID = 3,
                      Language = "English",
                      Price = 99,
                      DateCreated = DateTime.Now,
                      Image = File.ReadAllBytes("Files/css.jpg"),
                      Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                      UserID = 4

                  },
                   new Course
                   {
                       CourseID = 4,
                       Name = "Getting started with React",
                       SubcategoryID = 1,
                       Language = "English",
                       Price = 50,
                       DateCreated = DateTime.Now,
                       Image = File.ReadAllBytes("Files/react.jpg"),
                       Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                       UserID = 9

                   },
                    new Course
                    {
                        CourseID = 5,
                        Name = "Getting started with testni",
                        SubcategoryID = 4,
                        Language = "English",
                        Price = 69,
                        DateCreated = DateTime.Now,
                        Image = File.ReadAllBytes("Files/test.jpg"),
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        UserID = 9

                    },
                     new Course
                     {
                         CourseID = 6,
                         Name = "Mastering Adobe Illustrator 2021",
                         SubcategoryID = 3,
                         Language = "English",
                         Price = 100,
                         DateCreated = DateTime.Now,
                         Image = File.ReadAllBytes("Files/ai.jpg"),
                         Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                         UserID = 9

                     },
                      new Course
                      {
                          CourseID = 7,
                          Name = "TOGAF 9 Foundation",
                          SubcategoryID = 6,
                          Language = "English",
                          Price = 25,
                          DateCreated = DateTime.Now,
                          Image = File.ReadAllBytes("Files/test.jpg"),
                          Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                          UserID = 4

                      },
                       new Course
                       {
                           CourseID = 8,
                           Name = "Getting started with Unity",
                           SubcategoryID = 4,
                           Language = "English",
                           Price = 15,
                           DateCreated = DateTime.Now,
                           Image = File.ReadAllBytes("Files/test.jpg"),
                           Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                           UserID = 8

                       },
                        new Course
                        {
                            CourseID = 9,
                            Name = "Getting started with Unreal Engine",
                            SubcategoryID = 4,
                            Language = "English",
                            Price = 13.99f,
                            DateCreated = DateTime.Now,
                            Image = File.ReadAllBytes("Files/test.jpg"),
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            UserID = 9

                        },
                         new Course
                         {
                             CourseID = 10,
                             Name = "Introduction to Google Ads (Adwords)",
                             SubcategoryID = 5,
                             Language = "English",
                             Price = 44,
                             DateCreated = DateTime.Now,
                             Image = File.ReadAllBytes("Files/test.jpg"),
                             Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                             UserID = 8

                         },
                          new Course
                          {
                              CourseID = 11,
                              Name = "testni1",
                              SubcategoryID = 6,
                              Language = "English",
                              Price = 65.99f,
                              DateCreated = DateTime.Now,
                              Image = File.ReadAllBytes("Files/test.jpg"),
                              Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                              UserID = 8

                          }


                );
            modelBuilder.Entity<Section>().HasData(
                new Section { SectionID = 1, SectionNumber = 1 },
                new Section { SectionID = 2, SectionNumber = 2 },
                new Section { SectionID = 3, SectionNumber = 3 },
                new Section { SectionID = 4, SectionNumber = 4 },
                new Section { SectionID = 5, SectionNumber = 5 },
                new Section { SectionID = 6, SectionNumber = 6 },
                new Section { SectionID = 7, SectionNumber = 7 },
                new Section { SectionID = 8, SectionNumber = 8 },
                new Section { SectionID = 9, SectionNumber = 9 },
                new Section { SectionID = 10, SectionNumber = 10 },
                new Section { SectionID = 11, SectionNumber = 11 },
                new Section { SectionID = 12, SectionNumber = 12 },
                new Section { SectionID = 13, SectionNumber = 13 },
                new Section { SectionID = 14, SectionNumber = 14 },
                new Section { SectionID = 15, SectionNumber = 15 },
                new Section { SectionID = 16, SectionNumber = 16 },
                new Section { SectionID = 17, SectionNumber = 17 },
                new Section { SectionID = 18, SectionNumber = 18 },
                new Section { SectionID = 19, SectionNumber = 19 },
                new Section { SectionID = 20, SectionNumber = 20 },
                new Section { SectionID = 21, SectionNumber = 21 },
                new Section { SectionID = 22, SectionNumber = 22 },
                new Section { SectionID = 23, SectionNumber = 23 },
                new Section { SectionID = 24, SectionNumber = 24 },
                new Section { SectionID = 25, SectionNumber = 25 },
                new Section { SectionID = 26, SectionNumber = 26 },
                new Section { SectionID = 27, SectionNumber = 27 },
                new Section { SectionID = 28, SectionNumber = 28 },
                new Section { SectionID = 29, SectionNumber = 29 },
                new Section { SectionID = 30, SectionNumber = 30 },
                new Section { SectionID = 31, SectionNumber = 31 },
                new Section { SectionID = 32, SectionNumber = 32 },
                new Section { SectionID = 33, SectionNumber = 33 },
                new Section { SectionID = 34, SectionNumber = 34 },
                new Section { SectionID = 35, SectionNumber = 35 },
                new Section { SectionID = 36, SectionNumber = 36 },
                new Section { SectionID = 37, SectionNumber = 37 },
                new Section { SectionID = 38, SectionNumber = 38 },
                new Section { SectionID = 39, SectionNumber = 39 },
                new Section { SectionID = 40, SectionNumber = 40 },
                new Section { SectionID = 41, SectionNumber = 41 },
                new Section { SectionID = 42, SectionNumber = 42 },
                new Section { SectionID = 43, SectionNumber = 43 },
                new Section { SectionID = 44, SectionNumber = 44 },
                new Section { SectionID = 45, SectionNumber = 45 },
                new Section { SectionID = 46, SectionNumber = 46 },
                new Section { SectionID = 47, SectionNumber = 47 },
                new Section { SectionID = 48, SectionNumber = 48 },
                new Section { SectionID = 49, SectionNumber = 49 },
                new Section { SectionID = 50, SectionNumber = 50 }


                );

        }
    }
}
