using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class softDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Personal_skillModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "MessageModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "JWTs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Follows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "CommentModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Applicants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Follows",
                keyColumn: "id",
                keyValue: 4,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 4,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 5,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 6,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 4,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 4,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 5,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "id",
                keyValue: 6,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: 1,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: 2,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: 3,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: 4,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: 5,
                column: "is_deleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$H8gyM1EIHX1JwOI4T8v8l.vGqPsi8WEIZNWuOZVv3YvZjzDIlLQb2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$ZtkbXv2n5J.frnWgD7e3CuBOmd30qnVZNk0J3hBQzdpF4M.kTU9.y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$tgrk/SWo3JeMPHmT5lIm3.293c.2IQ0OJO3eACuL/05pQZykC/6tu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$Xatt7JLyWMqKveiPvqr5n.AP7k0CvN2PRpk31SlJaw.LFFA84N48K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$5DqfrlShOYDa8HmWkABqG.DOQVnEo1A2ggXbmtqTJ.IYxKLgZN2mm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Personal_skillModel");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "JWTs");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Applicants");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$.CERnqT9ko9moKM9Vr9W2usgHwDekCCHqfQ1tY46Y8b3ilNrwoP3S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$59M5jGXVVWjPgKjsq5HjM.cKDMdDWARUrJlr8bwxjQGrzJs7oCCwi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$5l6QfFCjlMSBGFz7SGe/veEXbLjHbEu/W1N6VVDisXnrm07LwrXki");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$hakD80y4SA8aLFHGUYvqE.SPPbzWk0GU.kFduUvf2jIGj6/xvRyVu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$cLZHjW0oU9AGusfjmYHsmOseT6rrB6BZ0CTPaIVpZ0qyk78/ZnNSy");
        }
    }
}
