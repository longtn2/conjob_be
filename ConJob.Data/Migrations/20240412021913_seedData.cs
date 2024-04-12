using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "Id", "CreatedAt", "Name", "Size", "Type", "UpdatedAt" },
                values: new object[] { 1, null, "file", 100.0, 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "File",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
