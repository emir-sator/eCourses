using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCourses.WebAPI.Migrations
{
    public partial class fixesPriceDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Transactions",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Courses",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "BuyCourses",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 59, DateTimeKind.Local).AddTicks(7527), 300f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(138), 88f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(739), 99f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(1224), 50f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(1654), 69f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(2054), 100f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(2413), 25f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(2769), 15f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(3105), 13.99f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(3460), 44f });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 49, 20, 62, DateTimeKind.Local).AddTicks(3800), 65.99f });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "QTtbJ/pB4mYThjlhg2tC/hRK6DU=", "V477bgMsoOzVqh6hwVumuA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "X6MTX4eyEuFw/Gl7V4DTzdTqbkU=", "amMwIcPmRI+0RHRfoo/4EA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "YkJWFNNWhKYCwmkbko9c9p51+b4=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "kHGkBZxWp6nd6U6/aiCurdxhTeE=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "TRdbjAaC6MbXeok7bqujgn3Wmcw=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1ze5aghvdqNraouf66iGztjs8O4=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "aomeoNSwFiEukIMnkgI29oioYOA=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "49zK3ktnHnd7qQromdQ73H8G1uE=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "tn4fm1RRjqpM+GhELbSherEH7Mw=", "Pk3MtqLYPWuFnv8OWZ4aQA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Transactions",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Courses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "BuyCourses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 849, DateTimeKind.Local).AddTicks(2303), 300.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 2,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 851, DateTimeKind.Local).AddTicks(7240), 88.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 3,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 851, DateTimeKind.Local).AddTicks(8886), 99.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 4,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(461), 50.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 5,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(1958), 69.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 6,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(3362), 100.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 7,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(4714), 25.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 8,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(5142), 15.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 9,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(5516), 13.99 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 10,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(5858), 44.0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 11,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2021, 4, 17, 23, 43, 36, 852, DateTimeKind.Local).AddTicks(6243), 65.989999999999995 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "NVWOr+VtSQIVYW//YPgIQcwGvMA=", "qCqIjEkjZHA3tqtUtOfIyw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "jUG5zQ6CxPwSfrRwoLU4DPqs8xI=", "iSHh2SXVLm9kcBHyI5bsiQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "p++/9EI/YrIbGwV3pgu402k+g+4=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ENGj4vXPli5eBt6KqSvTZclivU8=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0Tgg5FDawJVLeZGiPDltXr5fu8o=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RzQXRWHp7tBirHh1WhRUfJtdUlc=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "7bkWKsgxr4BaoyqPD7KDpY9p218=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4FGvWDZmwDtBgrO6XQYXYNvzrx4=", "HeRhhQm26EObC+f/I3r8Aw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ae74scTIrRz2CNXp1VXUp1mwhaQ=", "HeRhhQm26EObC+f/I3r8Aw==" });
        }
    }
}
