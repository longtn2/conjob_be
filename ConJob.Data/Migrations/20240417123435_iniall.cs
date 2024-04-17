using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class iniall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Skills_skill_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Users_user_id",
                table: "Personal_skillModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal_skillModel",
                table: "Personal_skillModel");

            migrationBuilder.RenameTable(
                name: "Personal_skillModel",
                newName: "Personal_Skills");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_skillModel_user_id",
                table: "Personal_Skills",
                newName: "IX_Personal_Skills_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_skillModel_skill_id",
                table: "Personal_Skills",
                newName: "IX_Personal_Skills_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal_Skills",
                table: "Personal_Skills",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$1sVR2Gq.ClMN/YHPGJ1pyOoImy22J.rM48VMvhvmcw52ekgfxKAtW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$7qUbU70ne5YzZdjcQtx9eO3IAb89SJ/xrNlvAb2MnmIAQtw/zORJ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$GpE66INBII7dX06eKSM7ROa/nXO0D69LIFaGrS36OTpZ5L9FwyZoy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$VlMGtZTfoXdkU0JLxYyrlO89iDc2XdRLkDqxyIb9OZEszv0X.I6g6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$GchQwvarFEbnXmJ3PXvG6emZwE9z0wTV7aXDo0NCbUyu9U00w8zgS");

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Skills_Skills_skill_id",
                table: "Personal_Skills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_Skills_Users_user_id",
                table: "Personal_Skills",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Skills_Skills_skill_id",
                table: "Personal_Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_Skills_Users_user_id",
                table: "Personal_Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal_Skills",
                table: "Personal_Skills");

            migrationBuilder.RenameTable(
                name: "Personal_Skills",
                newName: "Personal_skillModel");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_Skills_user_id",
                table: "Personal_skillModel",
                newName: "IX_Personal_skillModel_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_Skills_skill_id",
                table: "Personal_skillModel",
                newName: "IX_Personal_skillModel_skill_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal_skillModel",
                table: "Personal_skillModel",
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
                name: "FK_Personal_skillModel_Skills_skill_id",
                table: "Personal_skillModel",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_skillModel_Users_user_id",
                table: "Personal_skillModel",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
