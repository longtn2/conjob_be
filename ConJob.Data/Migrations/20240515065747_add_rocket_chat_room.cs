using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_rocket_chat_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "rocket_room_id",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "rocket_room_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "rocket_room_id",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rocket_auth_token",
                table: "users");

            migrationBuilder.DropColumn(
                name: "rocket_user_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "rocket_room_id",
                table: "applicants");
        }
    }
}
