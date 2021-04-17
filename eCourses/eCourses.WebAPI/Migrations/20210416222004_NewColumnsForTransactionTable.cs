using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class NewColumnsForTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 771, DateTimeKind.Local).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 773, DateTimeKind.Local).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 774, DateTimeKind.Local).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 774, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 17, 0, 20, 3, 774, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "I0PpxSVPkJe5HF7mJNAXZdUWDe4=", "sbXmDnleuCQhAoXY+Pw+qQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sttBylste8LllqGR4QFEG72NpHQ=", "0FzwNfFsStiBHpk+DhSLhQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "thdgWmfnycSU4y2Ww5LOs46j5Mo=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MZnSesfx/yJpUzVP5IzSMrOamBY=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "eHFdIdoEGxMV9pKD7noQv7oIRIQ=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ST2jm+r1czhsqEUfgirORSzEjOA=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0Hl0Z2usBvyO3DzlxH+qR6rMv8Y=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Re8Rdtvq9z9D74gNJgrWMx0ahrc=", "5AYv18e4ORGHGDfhlqhqgQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "IftPJTLCwoAk2V8iE2axWaBQjag=", "5AYv18e4ORGHGDfhlqhqgQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 509, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 512, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 513, DateTimeKind.Local).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 513, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 513, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2021, 4, 16, 23, 23, 35, 513, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Mmt3Sd+fL8kd2vKNUKh0yvylM9g=", "GLHfYZOh/2Q4ugrVC60Ppg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xfZ/L67eep3rIYFqQgj6zSi5mYw=", "8L5i+W9qbLpw/VPHkJv9AA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "7+nc9Ubj7Cy/hE49ghjpVJ4aMns=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2fVryeIN7YMN7v2VNoh64L36VhM=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xqkNTkeSHfijGfYJnIxnmJuNc60=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CUQnI6CI45cVg0ivE6TEsZciWUU=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Cd3YxORypOty/WX2nltuwHOBzMA=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "60L18q59y0VmKoV2u6e/qCReljM=", "pCByGoPEtUpuEPiOl9C61g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rHoVJDg4QchraWhC9xf464VbH4o=", "pCByGoPEtUpuEPiOl9C61g==" });
        }
    }
}
