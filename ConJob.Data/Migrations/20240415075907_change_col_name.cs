using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_col_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "UserRole",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "UserRole",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "User",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Role",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Role",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "JWT",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "JWT",
                newName: "created_at");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "JWT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personal_skillModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillModelId = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_skillModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personal_skillModel_Skill_SkillModelId",
                        column: x => x.SkillModelId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personal_skillModel_SkillModelId",
                table: "Personal_skillModel",
                column: "SkillModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal_skillModel");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "JWT");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "UserRole",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "UserRole",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "User",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Role",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Role",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "JWT",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "JWT",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
