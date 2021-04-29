using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class modifiedSubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 667, DateTimeKind.Local).AddTicks(2155));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 669, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 29, 16, 30, 41, 670, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 1,
                column: "CategoryName",
                value: "Development");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 2,
                column: "CategoryName",
                value: "Development");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 3,
                column: "CategoryName",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 4,
                column: "CategoryName",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 5,
                column: "CategoryName",
                value: "Marketing");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 6,
                column: "CategoryName",
                value: "Business");

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 7,
                column: "CategoryName",
                value: "Design");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "cyxtpbq6D0MEzx+hAfUK3JonE6k=", "xoab39Xcvqh4u6DN/FokuA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xBl8xy+gt9RRf/b6O1IP5GX9qCE=", "6YsmzVY7csDUun/wuJTloQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "cx2UzmOuXoG+844VBC02KSXX88U=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "T/AqFcHOpjHY1/6MGw2Pppb5r28=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/ARb2TGmJkKpms8oAduAq4c4oRA=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8Rr7HCsCxQLMXM1MGudEK9GVfmU=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "b/TET4O3xBu0VeQ9gvfX/I8zpiY=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lBnsFTVEu6ANVvYR4rklu4a/laQ=", "Iwf3rQb7SkHRilxkVEknHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6IPyiVw5s+LmODOsgWFw3HICRNM=", "Iwf3rQb7SkHRilxkVEknHQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Subcategories");

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
    }
}
