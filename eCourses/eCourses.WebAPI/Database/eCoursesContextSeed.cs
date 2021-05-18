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
                    PasswordHash = GenerateHash(Salt[0], "Admin123."),
                    FullName = "Admin Admin",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
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
                    PasswordHash = GenerateHash(Salt[1], "Admin123."),
                    FullName = "Admin Admin",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
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
                    PasswordHash = GenerateHash(Salt[2], "Mobile123."),
                    FullName = "Mobile Mobile",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                new User
                {
                    UserID = 4,
                    FirstName = "Instructor1Ime",
                    LastName = "Instructor1Prezime",
                    Username = "Instructor1",
                    Email = "instructor1@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor1."),
                    FullName = "InstructorIme InstructorPrezime",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                new User
                {
                    UserID = 5,
                    FirstName = "Instructor2Ime",
                    LastName = "Instructor2Prezime",
                    Username = "Instructor2",
                    Email = "instructor2@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor2."),
                    FullName = "Instructor2Ime Instructor2Prezime",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                new User
                {
                    UserID = 6,
                    FirstName = "Instructor3Ime",
                    LastName = "Instructor3Prezime",
                    Username = "Instructor3",
                    Email = "instructor3@ecourses.com",
                    PhoneNumber = "242151222",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Instructor3."),
                    FullName = "Instructor3Ime Instructor3Prezime",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                 new User
                 {
                     UserID = 7,
                     FirstName = "Instructor4Ime",
                     LastName = "Instructor4Prezime",
                     Username = "Instructor4",
                     Email = "instructor4@ecourses.com",
                     PhoneNumber = "242151222",
                     PasswordSalt = Salt[2],
                     PasswordHash = GenerateHash(Salt[2], "Instructor4."),
                     FullName = "Instructor4Ime Instructor4Prezime",
                     Image = File.ReadAllBytes("Files/user.jpg"),
                     GitHubURL = "https://github.com/emir-sator",
                     LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                 },
                  new User
                  {
                      UserID = 8,
                      FirstName = "Instructor5Ime",
                      LastName = "Instructor5Prezime",
                      Username = "Instructor5",
                      Email = "instructor5@ecourses.com",
                      PhoneNumber = "242151222",
                      PasswordSalt = Salt[2],
                      PasswordHash = GenerateHash(Salt[2], "Instructor5."),
                      FullName = "Instructor5Ime Instructor5Prezime",
                      Image = File.ReadAllBytes("Files/user.jpg"),
                      GitHubURL = "https://github.com/emir-sator",
                      LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                  },
                new User
                {
                    UserID = 9,
                    FirstName = "Polaznik1Ime",
                    LastName = "Polaznik1Prezime",
                    Username = "Polaznik1",
                    Email = "polaznik1@ecourses.com",
                    PhoneNumber = "252612661",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Polaznik1."),
                    FullName = "Polaznik1Ime Polaznik1Prezime",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                new User
                {
                    UserID = 10,
                    FirstName = "Polaznik2Ime",
                    LastName = "Polaznik2Prezime",
                    Username = "Polaznik2",
                    Email = "polaznik2@ecourses.com",
                    PhoneNumber = "252612661",
                    PasswordSalt = Salt[2],
                    PasswordHash = GenerateHash(Salt[2], "Polaznik2."),
                    FullName = "Polaznik2Ime Polaznik2Prezime",
                    Image = File.ReadAllBytes("Files/user.jpg"),
                    GitHubURL = "https://github.com/emir-sator",
                    LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                },
                 new User
                 {
                     UserID = 11,
                     FirstName = "Polaznik3Ime",
                     LastName = "Polaznik3Prezime",
                     Username = "Polaznik3",
                     Email = "polaznik3@ecourses.com",
                     PhoneNumber = "252612661",
                     PasswordSalt = Salt[2],
                     PasswordHash = GenerateHash(Salt[2], "Polaznik3."),
                     FullName = "Polaznik3Ime Polaznik3Prezime",
                     Image = File.ReadAllBytes("Files/user.jpg"),
                     GitHubURL = "https://github.com/emir-sator",
                     LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                 },
                 new User
                 {
                     UserID = 12,
                     FirstName = "Polaznik4Ime",
                     LastName = "Polaznik4Prezime",
                     Username = "Polaznik4",
                     Email = "polaznik4@ecourses.com",
                     PhoneNumber = "252612661",
                     PasswordSalt = Salt[2],
                     PasswordHash = GenerateHash(Salt[2], "Polaznik4."),
                     FullName = "Polaznik4Ime Polaznik4Prezime",
                     Image = File.ReadAllBytes("Files/user.jpg"),
                     GitHubURL = "https://github.com/emir-sator",
                     LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
                 },
                 new User
                 {
                     UserID = 13,
                     FirstName = "Polaznik5Ime",
                     LastName = "Polaznik5Prezime",
                     Username = "Polaznik5",
                     Email = "polaznik5@ecourses.com",
                     PhoneNumber = "252612661",
                     PasswordSalt = Salt[2],
                     PasswordHash = GenerateHash(Salt[2], "Polaznik5."),
                     FullName = "Polaznik5Ime Polaznik5Prezime",
                     Image = File.ReadAllBytes("Files/user.jpg"),
                     GitHubURL = "https://github.com/emir-sator",
                     LinkedinURL = "https://www.linkedin.com/in/emir-sator-a51629130/"
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
                new Category { CategoryID = 4, Name = "Business" },
                new Category { CategoryID = 5, Name = "Photography&Video" }
                );
            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { SubcategoryID = 1, Name = "Web Development", CategoryID = 1, CategoryName = "Development" },
                new Subcategory { SubcategoryID = 2, Name = "Game Development", CategoryID = 1, CategoryName = "Development" },
                new Subcategory { SubcategoryID = 3, Name = "Web Design", CategoryID = 2, CategoryName = "Design" },
                new Subcategory { SubcategoryID = 4, Name = "Game Design", CategoryID = 2, CategoryName = "Design" },
                new Subcategory { SubcategoryID = 5, Name = "Advertising", CategoryID = 3, CategoryName = "Marketing" },
                new Subcategory { SubcategoryID = 6, Name = "Business strategy ", CategoryID = 4, CategoryName = "Business" },
                new Subcategory { SubcategoryID = 7, Name = "3D Design ", CategoryID = 2, CategoryName = "Design" },
                new Subcategory { SubcategoryID = 8, Name = "Mobile Development", CategoryID = 1, CategoryName = "Development" },
                new Subcategory { SubcategoryID = 9, Name = "Software testing", CategoryID = 1, CategoryName = "Development" },
                new Subcategory { SubcategoryID = 10, Name = "Digital photography", CategoryID = 5, CategoryName = "Photography&Video" },
                new Subcategory { SubcategoryID = 11, Name = "Photography tools", CategoryID = 5, CategoryName = "Photography&Video" },
                new Subcategory { SubcategoryID = 12, Name = "Video design", CategoryID = 5, CategoryName = "Photography&Video" },
                new Subcategory { SubcategoryID = 13, Name = "Data Science", CategoryID = 1, CategoryName = "Development" }




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
                new UserRoles { UserRoleID = 17, UserID = 9, RoleID = 3 },
                new UserRoles { UserRoleID = 18, UserID = 10, RoleID = 2 },
                new UserRoles { UserRoleID = 19, UserID = 10, RoleID = 3 },
                new UserRoles { UserRoleID = 20, UserID = 11, RoleID = 2 },
                new UserRoles { UserRoleID = 21, UserID = 11, RoleID = 3 },
                new UserRoles { UserRoleID = 22, UserID = 12, RoleID = 2 },
                new UserRoles { UserRoleID = 23, UserID = 12, RoleID = 3 },
                new UserRoles { UserRoleID = 24, UserID = 13, RoleID = 2 },
                new UserRoles { UserRoleID = 25, UserID = 13, RoleID = 3 }

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
                    DateCreated = DateTime.Now,
                    Image = File.ReadAllBytes("Files/csharp.jpg"),
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    UserID = 4,
                    URL = "http://vjs.zencdn.net/v/oceans.mp4"

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
                       UserID = 5

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
                        UserID = 5

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
                         UserID = 5

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
                          UserID = 5

                      },
                       new Course
                       {
                           CourseID = 8,
                           Name = "Getting started with Unity",
                           SubcategoryID = 2,
                           Language = "English",
                           Price = 15,
                           DateCreated = DateTime.Now,
                           Image = File.ReadAllBytes("Files/test.jpg"),
                           Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                           UserID = 6

                       },
                        new Course
                        {
                            CourseID = 9,
                            Name = "Getting started with Unreal Engine",
                            SubcategoryID = 2,
                            Language = "English",
                            Price = 13.99f,
                            DateCreated = DateTime.Now,
                            Image = File.ReadAllBytes("Files/test.jpg"),
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            UserID = 6

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

                          },
                           new Course
                           {
                               CourseID = 12,
                               Name = "Python for DataScience",
                               SubcategoryID = 13,
                               Language = "English",
                               Price = 45.99f,
                               DateCreated = DateTime.Now,
                               Image = File.ReadAllBytes("Files/test.jpg"),
                               Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                               UserID = 8

                           },
                            new Course
                            {
                                CourseID = 13,
                                Name = "testni2",
                                SubcategoryID = 13,
                                Language = "English",
                                Price = 15.99f,
                                DateCreated = DateTime.Now,
                                Image = File.ReadAllBytes("Files/test.jpg"),
                                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                UserID = 8

                            },
                             new Course
                             {
                                 CourseID = 14,
                                 Name = "testni3",
                                 SubcategoryID = 6,
                                 Language = "English",
                                 Price = 10.99f,
                                 DateCreated = DateTime.Now,
                                 Image = File.ReadAllBytes("Files/test.jpg"),
                                 Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                 UserID = 7

                             },
                              new Course
                              {
                                  CourseID = 15,
                                  Name = "R programming language",
                                  SubcategoryID = 13,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 7

                              },
                              new Course
                              {
                                  CourseID = 16,
                                  Name = "Complete C++ course",
                                  SubcategoryID = 2,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/cplusplus.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 6,
                                  URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342886/Videos/lectures/lekcija1_u4gn8c.mp4"

                              },
                              new Course
                              {
                                  CourseID = 17,
                                  Name = "Beginner Nikon Digital SLR (DSLR) Photography",
                                  SubcategoryID = 10,
                                  Language = "English",
                                  Price = 29.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 7

                              },
                              new Course
                              {
                                  CourseID = 18,
                                  Name = "Photoshop Effects - How to Create Photo Effects",
                                  SubcategoryID = 11,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 6

                              },
                              new Course
                              {
                                  CourseID = 19,
                                  Name = "Complete Guide to Photo Editing in Affinity",
                                  SubcategoryID = 11,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 6

                              },
                              new Course
                              {
                                  CourseID = 20,
                                  Name = "Adobe Lightroom For Beginners",
                                  SubcategoryID = 11,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 6

                              },
                              new Course
                              {
                                  CourseID = 21,
                                  Name = "Learn Photoshop From Scratch Practically",
                                  SubcategoryID = 11,
                                  Language = "English",
                                  Price = 35.99f,
                                  DateCreated = DateTime.Now,
                                  Image = File.ReadAllBytes("Files/test.jpg"),
                                  Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                  UserID = 6

                              },
                               new Course
                               {
                                   CourseID = 22,
                                   Name = "Photoshop Elements 2019 Training",
                                   SubcategoryID = 11,
                                   Language = "English",
                                   Price = 35.99f,
                                   DateCreated = DateTime.Now,
                                   Image = File.ReadAllBytes("Files/test.jpg"),
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                   UserID = 6

                               },
                                new Course
                                {
                                    CourseID = 23,
                                    Name = "Video Editing in DaVinci Resolve 17",
                                    SubcategoryID = 12,
                                    Language = "English",
                                    Price = 35.99f,
                                    DateCreated = DateTime.Now,
                                    Image = File.ReadAllBytes("Files/test.jpg"),
                                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                    UserID = 6

                                },
                                 new Course
                                 {
                                     CourseID = 24,
                                     Name = "Become an Incredible Video Creator",
                                     SubcategoryID = 12,
                                     Language = "English",
                                     Price = 35.99f,
                                     DateCreated = DateTime.Now,
                                     Image = File.ReadAllBytes("Files/test.jpg"),
                                     Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                     UserID = 6

                                 },
                                  new Course
                                  {
                                      CourseID = 25,
                                      Name = "The Complete iOS App Development Bootcamp",
                                      SubcategoryID = 8,
                                      Language = "English",
                                      Price = 35.99f,
                                      DateCreated = DateTime.Now,
                                      Image = File.ReadAllBytes("Files/test.jpg"),
                                      Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                      UserID = 5

                                  },
                                  new Course
                                  {
                                      CourseID = 26,
                                      Name = "Flutter & Dart - The Complete Guide",
                                      SubcategoryID = 8,
                                      Language = "English",
                                      Price = 35.99f,
                                      DateCreated = DateTime.Now,
                                      Image = File.ReadAllBytes("Files/test.jpg"),
                                      Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                      UserID = 5

                                  }

                );


            modelBuilder.Entity<BuyCourse>().HasData(

                new BuyCourse
                {
                    BuyCourseID = 1,
                    CourseID = 16,
                    UserID = 9,
                    DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                    Price = 35.99f,
                    Username = "Polaznik1",
                    CourseName = "Complete C++ course"
                },
                 new BuyCourse
                 {
                     BuyCourseID = 2,
                     CourseID = 16,
                     UserID = 10,
                     DateOfBuying = Convert.ToDateTime("2021-05-13 21:17:37"),
                     Price = 35.99f,
                     Username = "Polaznik2",
                     CourseName = "Complete C++ course"
                 },
                  new BuyCourse
                  {
                      BuyCourseID = 3,
                      CourseID = 16,
                      UserID = 11,
                      DateOfBuying = Convert.ToDateTime("2021-05-10 21:17:37"),
                      Price = 35.99f,
                      Username = "Polaznik3",
                      CourseName = "Complete C++ course"
                  },
                   new BuyCourse
                   {
                       BuyCourseID = 4,
                       CourseID = 21,
                       UserID = 9,
                       DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                       Price = 35.99f,
                       Username = "Polaznik1",
                       CourseName = "Learn Photoshop From Scratch Practically"
                   },
                    new BuyCourse
                    {
                        BuyCourseID = 5,
                        CourseID = 18,
                        UserID = 9,
                        DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                        Price = 35.99f,
                        Username = "Polaznik1",
                        CourseName = "Photoshop Effects - How to Create Photo Effects"
                    },
                     new BuyCourse
                     {
                         BuyCourseID = 6,
                         CourseID = 10,
                         UserID = 9,
                         DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                         Price = 44,
                         Username = "Polaznik1",
                         CourseName = "Introduction to Google Ads (Adwords)"
                     },
                      new BuyCourse
                      {
                          BuyCourseID = 7,
                          CourseID = 16,
                          UserID = 13,
                          DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                          Price = 35.99f,
                          Username = "Polaznik5",
                          CourseName = "Complete C++ course"
                      },
                       new BuyCourse
                       {
                           BuyCourseID = 8,
                           CourseID = 25,
                           UserID = 5,
                           DateOfBuying = Convert.ToDateTime("2021-05-17 21:17:37"),
                           Price = 35.99f,
                           Username = "Polaznik4",
                           CourseName = "The Complete iOS App Development Bootcamp"
                       },
                       new BuyCourse
                       {
                           BuyCourseID = 9,
                           CourseID = 18,
                           UserID = 10,
                           DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                           Price = 35.99f,
                           Username = "Polaznik2",
                           CourseName = "Learn Photoshop From Scratch Practically"
                       },
                       new BuyCourse
                       {
                              BuyCourseID = 10,
                              CourseID = 8,
                              UserID = 9,
                              DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                              Price = 35.99f,
                              Username = "Polaznik1",
                              CourseName = "Getting started with Unity"
                       },
                       new BuyCourse
                       {
                           BuyCourseID = 11,
                           CourseID = 2,
                           UserID = 11,
                           DateOfBuying = Convert.ToDateTime("2021-05-12 21:17:37"),
                           Price = 35.99f,
                           Username = "Polaznik3",
                           CourseName = "Getting started with Unity"
                       }



                );

            modelBuilder.Entity<Transaction>().HasData
                (
                new Transaction
                {
                    TransactionID = 1,
                    CourseID = 16,
                    UserID = 9,
                    UserFullName = "Polaznik1Ime Polaznik1Prezime",
                    CourseName = "Complete C++ course",
                    TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                    Price = 35.99f

                },
                new Transaction
                {
                    TransactionID = 2,
                    CourseID = 16,
                    UserID = 10,
                    TransactionDate = Convert.ToDateTime("2021-05-13 21:17:37"),
                    Price = 35.99f,
                    UserFullName = "Polaznik2Ime Polaznik2Prezime",
                    CourseName = "Complete C++ course"
                },
                  new Transaction
                  {
                      TransactionID = 3,
                      CourseID = 16,
                      UserID = 11,
                      TransactionDate = Convert.ToDateTime("2021-05-10 21:17:37"),
                      Price = 35.99f,
                      UserFullName = "Polaznik3Ime Polaznik3Prezime",
                      CourseName = "Complete C++ course"
                  },
                   new Transaction
                   {
                       TransactionID = 4,
                       CourseID = 21,
                       UserID = 9,
                       TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                       Price = 35.99f,
                       UserFullName = "Polaznik1Ime Polaznik1Prezime",
                       CourseName = "Learn Photoshop From Scratch Practically"
                   },
                    new Transaction
                    {
                        TransactionID = 5,
                        CourseID = 18,
                        UserID = 9,
                        TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                        Price = 35.99f,
                        UserFullName = "Polaznik1Ime Polaznik1Prezime",
                        CourseName = "Learn Photoshop From Scratch Practically"
                    },

                     new Transaction
                     {
                         TransactionID = 6,
                         CourseID = 10,
                         UserID = 9,
                         TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                         Price = 44,
                         UserFullName = "Polaznik1Ime Polaznik1Prezime",
                         CourseName = "Introduction to Google Ads (Adwords)"
                     },
                      new Transaction
                      {
                          TransactionID = 7,
                          CourseID = 16,
                          UserID = 13,
                          TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                          Price = 35.99f,
                          UserFullName = "Polaznik5Ime Polaznik5Prezime",
                          CourseName = "Complete C++ course"
                      },
                       new Transaction
                       {
                           TransactionID = 8,
                           CourseID = 25,
                           UserID = 5,
                           TransactionDate = Convert.ToDateTime("2021-05-17 21:17:37"),
                           Price = 35.99f,
                           UserFullName = "Polaznik4Ime Polaznik4Prezime",
                           CourseName = "The Complete iOS App Development Bootcamp"
                       },
                        new Transaction
                        {
                            TransactionID = 9,
                            CourseID = 18,
                            UserID = 10,
                            TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                            Price = 35.99f,
                            UserFullName = "Polaznik2Ime Polaznik2Prezime",
                            CourseName = "Learn Photoshop From Scratch Practically"
                        },
                         new Transaction
                         {
                             TransactionID = 10,
                             CourseID = 8,
                             UserID = 9,
                             TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                             Price = 35.99f,
                             UserFullName = "Polaznik1Ime Polaznik1Prezime",
                             CourseName = "Getting started with Unity"
                         },
                          new Transaction
                          {
                              TransactionID = 11,
                              CourseID = 2,
                              UserID = 11,
                              TransactionDate = Convert.ToDateTime("2021-05-12 21:17:37"),
                              Price = 35.99f,
                              UserFullName = "Polaznik3Ime Polaznik3Prezime",
                              CourseName = "Getting started with Unity"
                          }


                );
            modelBuilder.Entity<UserCourseReview>().HasData
                (
                new UserCourseReview
                {
                    UserCourseReviewID = 1,
                    UserID = 9,
                    CourseID = 16,
                    Rating = 5
                },
                new UserCourseReview
                {
                    UserCourseReviewID = 2,
                    UserID = 10,
                    CourseID = 16,
                    Rating = 4
                },
                new UserCourseReview
                {
                    UserCourseReviewID = 3,
                    UserID = 11,
                    CourseID = 16,
                    Rating = 4
                },
                new UserCourseReview
                {
                    UserCourseReviewID = 4,
                    UserID = 9,
                    CourseID = 21,
                    Rating = 5
                },
                new UserCourseReview
                {
                    UserCourseReviewID = 5,
                    UserID = 9,
                    CourseID = 18,
                    Rating = 5
                },
                 new UserCourseReview
                 {
                     UserCourseReviewID = 6,
                     UserID = 9,
                     CourseID = 10,
                     Rating = 3
                 },
                 new UserCourseReview
                 {
                     UserCourseReviewID = 7,
                     UserID = 13,
                     CourseID = 16,
                     Rating = 4
                 },
                 new UserCourseReview
                 {
                     UserCourseReviewID = 8,
                     UserID = 5,
                     CourseID = 25,
                     Rating = 2
                 },
                 new UserCourseReview
                 {
                     UserCourseReviewID = 9,
                     UserID = 10,
                     CourseID = 18,
                     Rating = 2
                 },
                 new UserCourseReview
                 {
                      UserCourseReviewID = 10,
                      UserID = 9,
                      CourseID =8,
                      Rating = 3
                 },
                 new UserCourseReview
                 {
                     UserCourseReviewID = 11,
                     UserID = 11,
                     CourseID = 2,
                     Rating = 3
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

            modelBuilder.Entity<VideoLecture>().HasData
                (
                new VideoLecture
                {
                    VideoLectureID = 1,
                    CourseID = 16,
                    LectureName = "First program “Hello World” using Visual Studio 2019",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342886/Videos/lectures/lekcija1_u4gn8c.mp4",
                    SectionID = 1
                },
                new VideoLecture
                {
                    VideoLectureID = 2,
                    CourseID = 16,
                    LectureName = " Variables, Data Types, Overflow, Sizeof",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342825/Videos/lectures/lekcija2_m00qsr.mp4",
                    SectionID = 1
                },
                new VideoLecture
                {
                    VideoLectureID = 3,
                    CourseID = 16,
                    LectureName = "ASCII Table, Program for ciphering text",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342629/Videos/lectures/lekcija3_ctqpey.mp4",
                    SectionID = 1
                },
                new VideoLecture
                {
                    VideoLectureID = 4,
                    CourseID = 16,
                    LectureName = "If/else statement, check odd/even number, flowchart",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342860/Videos/lectures/lekcija4_kfqss0.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 5,
                    CourseID = 16,
                    LectureName = "Operators in C++",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342902/Videos/lectures/lekcija5_josfkg.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 6,
                    CourseID = 16,
                    LectureName = "Switch/case statement, Make Calculator application",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342873/Videos/lectures/lekcija6_xsuytu.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 7,
                    CourseID = 16,
                    LectureName = "What is while loop, What is infinite loop",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342664/Videos/lectures/lekcija7_iv5hlq.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 8,
                    CourseID = 16,
                    LectureName = "Do while loop, Difference between while and do while",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342651/Videos/lectures/lekcija8_o57psc.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 9,
                    CourseID = 16,
                    LectureName = "For loop, How to calculate factorial of a number",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342746/Videos/lectures/lekcija9_kjt9io.mp4",
                    SectionID = 2
                },
                new VideoLecture
                {
                    VideoLectureID = 10,
                    CourseID = 16,
                    LectureName = "How to draw triangle and inverted/reversed triangle",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342688/Videos/lectures/lekcija10_s0dndw.mp4",
                    SectionID = 3
                },
                new VideoLecture
                {
                    VideoLectureID = 11,
                    CourseID = 16,
                    LectureName = "Introduction to classes and objects",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342704/Videos/lectures/lekcija11_owspmf.mp4",
                    SectionID = 3
                },
                new VideoLecture
                {
                    VideoLectureID = 12,
                    CourseID = 16,
                    LectureName = "What are constructors and class methods?",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342858/Videos/lectures/lekcija12_lkrn0j.mp4",
                    SectionID = 3
                },
                new VideoLecture
                {
                    VideoLectureID = 13,
                    CourseID = 16,
                    LectureName = "Introduction to C++ pointers",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342700/Videos/lectures/lekcija13_mdidrf.mp4",
                    SectionID = 4
                },
                new VideoLecture
                {
                    VideoLectureID = 14,
                    CourseID = 16,
                    LectureName = "What is recursion? Learn recursive functions!",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342766/Videos/lectures/lekcija14_eimgez.mp4",
                    SectionID = 4
                },
                new VideoLecture
                {
                    VideoLectureID = 15,
                    CourseID = 16,
                    LectureName = "What is a dynamic two-dimensional array?",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342867/Videos/lectures/lekcija15_hitabq.mp4",
                    SectionID = 4
                },
                new VideoLecture
                {
                    VideoLectureID = 16,
                    CourseID = 16,
                    LectureName = "What are generic functions and templates?",
                    URL = "https://res.cloudinary.com/dkafrzcco/video/upload/v1621342870/Videos/lectures/lekcija16_xqsuz5.mp4",
                    SectionID = 4
                }


                );
        }
    }
}
