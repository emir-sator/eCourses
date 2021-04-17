using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class addcolumnforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Admin Admin", "T63eSSf+jBps7wD4U4Gy9el4+vY=", "tBLZhnjVhW73E2YM+UNKKg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Admin Admin", "V8hCePemomx+Lz4agYGduzD+5m4=", "BsM14tl77Qn9y81bmGZi9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Mobile Mobile", "VsmiiGQgB8xxIe7RsGzQDGUk6Js=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "InstructorIme InstructorPrezime", "0eq0SagHhpbS8qqbNYLRh99mJFQ=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Polaznik1Ime Polaznik1Prezime", "T1X6HdwIksvujg31AyslWVctmys=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Polaznik2Ime Polaznik2Prezime", "rOikAxyW89glChf+so2eJLe7Sdo=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Polaznik3Ime Polaznik3Prezime", "DTcpHhysBPkDDCyJZGxfxIdbJg8=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Instructor2Ime Instructor2Prezime", "mUq3j90L3Je8pXEy8vpRH06+K8g=", "Qi2siYD9WqAbwVZ8OSb14w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "FullName", "PasswordHash", "PasswordSalt" },
                values: new object[] { "Instructor3Ime Instructor3Prezime", "lypfipa0rI5+iGi4wg/G1MgOgsY=", "Qi2siYD9WqAbwVZ8OSb14w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

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
    }
}
