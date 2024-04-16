using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$s1AikUCmutBbYJtO7ZZm2.D1lybPM1T/Trd.GASZIdL43PK7eOKoG");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$VPHfkMIdXH0EvTG2RMdFl.kyvme1xnkqAlUaSiemj1MdIcO0/U5De");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
