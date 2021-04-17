using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class fixedRatingDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "UserCourseReviews",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 215, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 217, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 218, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 26, 31, 218, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9VPW3nAZNvrmrarSOgFEqsCR50Q=", "pp4I1DYuDAOm2kqm4GqCWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "QkfC0q6TkSbfGQK+FcbDE91z088=", "oAgh2cof/Fhp7eit5GsekQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "pZEpWmTLN06PW8tR+JHG/1mLsh0=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "WX0jboBbJQw4plqlp1fakWDjOqg=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "PV3PI9sJnKsN0jLYOkLTrB7LRBo=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8SC/MeuRiKXeEl9hIurLHuFk74E=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CjHUkBdPMkWEM6Zx994nACS7RWA=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sXuDisFfnF3hrHAzBrjzFHk3b54=", "wVqjgNRzNVZ7witJRiZ2pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1QzvMITyQ46O7SGB4Ld0u7+abNU=", "wVqjgNRzNVZ7witJRiZ2pw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "UserCourseReviews",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 649, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(4024));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 18, 1, 22, 26, 652, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Q1VSQnewhK5u9csra2xQs0P09Fo=", "j3y7iGENHBJnr35C/o14iA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sJTSMXHF79NJ3RIlu/aS4c8QTO4=", "pMavMO6gChhzR8F6pxoi7g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "BiuaL9orVgkYfbFkx4lNul+PA/g=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kO+2oyy1h9NV3+L5eJSs06jk3qg=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "N0cVZrQrYVC/2BMY6S6FT9igFkc=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9dtSw4Vu4NkIr39fNoI8Qeh6CYE=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "+6A56/OJ5JrMBabzdIYaMMx/E2A=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Ed80k5lbqfCcBBJf2/Jn1eaNoHY=", "p3JOXrfQqJtX6Z0PqLXgZw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9QnwD7BB38g0iXFhPnWjSRII7NA=", "p3JOXrfQqJtX6Z0PqLXgZw==" });
        }
    }
}
