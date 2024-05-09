using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_file_type_to_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "type", "url" },
                values: new object[] { "jpg", "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 2,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 3,
                column: "type",
                value: "mp4");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 4,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 5,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 6,
                column: "type",
                value: "mp4");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 7,
                column: "type",
                value: "mp4");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 8,
                column: "type",
                value: "mp4");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 9,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 10,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 11,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 12,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 13,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 14,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 15,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 16,
                column: "type",
                value: "jpg");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 17,
                column: "type",
                value: "mp4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$QefbVKpiRlaecWWumV18a.2qOz5zfizoofUYFN/.FhxbOMeCcvaqa");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$lJCAp66UvAfMqShU5T9.JOscNwJ1IzWDaQJvvFFMXTwMr/tvgAob6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$xOEhn1hhNCUZvyT0ICw8/OPn3xPTj10QtGxKtuYyedkDO8eUQsWsu");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$2u0jJIYMxnwF8Mr.IdKYyOeduCVjLrD7.Lrd6/PGHiALFG6QkB4dW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$GeDR7NzipseG0tJYm/l.K..3me/1k/n6lOKXP24FL/WKk6h4jwHpO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "files",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "type", "url" },
                values: new object[] { 1, "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-6-1588672247-471-width1212height798.jpg" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 2,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 3,
                column: "type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 4,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 5,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 6,
                column: "type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 7,
                column: "type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 8,
                column: "type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 9,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 10,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 11,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 12,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 13,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 14,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 15,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 16,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 17,
                column: "type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$66bUDFe1ETMAZY33cOHRe.fASCN/iXF3xcbOKIyf0dt5yyvpbb41C");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$uBS/kwSOGEh7nM05xYgtcuPbztfh9orPMJUHr5hdXdbeyFVN9bKSm");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$hkSLSZcq5q5sj3HatiD70uZwZ2APXqFk2je6lOA1RgvIGneo22oTK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$5u7PXyEDoqFO6Qpts/SHyesVD8Ev.Dt3WzihNMXrL5rDTgZZBOzD6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$J71tO.8X3vBLx/SOyS4EGOe/5f51LO5Gculi4Hy7tXxDXksTe.2Yi");
        }
    }
}
