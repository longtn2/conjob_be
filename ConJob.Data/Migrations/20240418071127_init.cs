using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                keyValue: 1,
                column: "password",
                value: "$2a$11$ERlFL0E9VPW.24fHfytRv.eo51TgL4j//w0d1fu.boxNomLOVx71m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$5T3O2uJBd4cthDWGLjhy1OyzWLa/RwfCpUbs4m70ALMIzEdlkitku");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$KSS1SkxNCDrR2dBZRs4TzuXSeMvX77zD0hPAPvN0EHXV.T.QKGpwm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$XAilPha6UXTNJefGNpNG7ubKjWwGOCrwtxS9/PC1YRAPfiBPX8DoO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$zCYBsNWgdDje.5rnne2UfOGs8kfA0/jqNVTnf9WrKCOTRxDmC9n5e");

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
