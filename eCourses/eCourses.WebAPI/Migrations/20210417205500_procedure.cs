using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            string procedure1 = @"create  PROCEDURE GetTop3Courses
as
Select top 3 c.[Name], c.[Language], c.Price, Count(bc.CourseID) as 'Number of purchasing' from Courses as c inner join BuyCourses as bc
on c.CourseID = bc.CourseID
group by c.[Name], c.[Language], c.Price
order by Count(bc.CourseID) desc";
            migrationBuilder.Sql(procedure1);

            string procedure2 = @"CREATE PROCEDURE GetCoursesBySubcategory
(
@SubcategoryID int
)
as
select [Name],[Language], DateCreated, Price from Courses
where  SubcategoryID=@SubcategoryID
order by [Name] ASC
";
            migrationBuilder.Sql(procedure2);

            string procedure3 = @"CREATE PROCEDURE Top3UsersWithMostCoursePurchases
as 
Begin
select top 3 u.FirstName +' '+ u.LastName as 'User', u.Email, u.PhoneNumber, COUNT(bc.UserID) as 'Total purchases'
from Users as u inner join BuyCourses as bc
on u.UserID = bc.UserID
group by u.FirstName + ' ' + u.LastName, u.Email, u.PhoneNumber
  order by COUNT(bc.UserID) desc

  end ";
            migrationBuilder.Sql(procedure3);

            string procedure4 = @"create procedure Top3BestAverageRatingCourses
as 
Begin
select top 3 c.Name,c.Language,c.Price, Round(AVG(usr.Rating),2) as 'Average rating'
from UserCourseReviews as usr inner join Courses as c
on c.CourseID=usr.CourseID
group by  c.Name,c.Language,c.Price
order by Round(AVG(usr.Rating),2) desc
end";
            migrationBuilder.Sql(procedure4);

            string procedure5 = @"create procedure Top3WorstAverageRatingCourses
as 
Begin
select top 3 c.Name,c.Language,c.Price, Round(AVG(usr.Rating),2) as 'Average rating'
from UserCourseReviews as usr inner join Courses as c
on c.CourseID=usr.CourseID
group by  c.Name,c.Language,c.Price
order by Round(AVG(usr.Rating),2)
end";
            migrationBuilder.Sql(procedure5);




            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 634, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 636, DateTimeKind.Local).AddTicks(9742));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 637, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 637, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 637, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 22, 54, 59, 637, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "eMq1SyNbJ5WTg0wCEHa2Js3YpTM=", "6WpJnB/5sti+0g91dzvV4g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "h19s1c2bu05MYZpu3oZTuahRdiA=", "c4v8LhGbQTjtsljJ4Cjl5g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CIKxmrdlj/yV9V6Ea/bQO1WOOfY=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "OIoLct9DqT+5280lRwDu4ri5f0E=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1ANQl2j2BPkIfds0PcHZTWMF8Bs=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rscJulxbTV1AX1v6syJ8g+IiFYQ=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "XpiEf3Rwd7CUbJxoSNDI13Bt8Xw=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4nfoKS4KIkrsjy9uz3suMYsho5w=", "bRJtdLn7L6XLCkRpQlMa3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yYrqGiuAacjDnjkqnKiYh1HC5a4=", "bRJtdLn7L6XLCkRpQlMa3Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string procedure1 = @"create  PROCEDURE GetTop3Courses";
            migrationBuilder.Sql(procedure1);

            string procedure2 = @"CREATE PROCEDURE GetCoursesBySubcategory";
            migrationBuilder.Sql(procedure2);

            string procedure3 = @"CREATE PROCEDURE Top3UsersWithMostCoursePurchases";
            migrationBuilder.Sql(procedure3);

            string procedure4 = @"CREATE PROCEDURE Top3BestAverageRatingCourses";
            migrationBuilder.Sql(procedure4);

            string procedure5 = @"CREATE PROCEDURE Top3WorstAverageRatingCourses";
            migrationBuilder.Sql(procedure5);


            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 576, DateTimeKind.Local).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 1, 14, 3, 578, DateTimeKind.Local).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "T63eSSf+jBps7wD4U4Gy9el4+vY=", "tBLZhnjVhW73E2YM+UNKKg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "V8hCePemomx+Lz4agYGduzD+5m4=", "BsM14tl77Qn9y81bmGZi9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "VsmiiGQgB8xxIe7RsGzQDGUk6Js=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0eq0SagHhpbS8qqbNYLRh99mJFQ=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "T1X6HdwIksvujg31AyslWVctmys=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rOikAxyW89glChf+so2eJLe7Sdo=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "DTcpHhysBPkDDCyJZGxfxIdbJg8=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mUq3j90L3Je8pXEy8vpRH06+K8g=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lypfipa0rI5+iGi4wg/G1MgOgsY=", "Qi2siYD9WqAbwVZ8OSb14w==" });
        }
    }
}
