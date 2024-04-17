using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatefilemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Files",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Files",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Files",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "id",
                keyValue: 1,
                column: "url",
                value: "file.jpeg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$kj.q0us./tPU4U4E8rXJg.CNSWCRiWcBaSsW60Iht81n/rKgaCWbu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Files",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Files",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Files",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Files",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$Y1wz6njFEgiXzAFuTpba4.0ku61lTU/0eP6ZSdtW8ZaXnQd.jOa02");
        }
    }
}
