using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "users",
                newName: "is_delete");

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "user_roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "Personal_skillModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "MessageModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "jwts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "follows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "files",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "CommentModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "categorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_delete",
                table: "applicants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 4,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 5,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "MessageModel",
                keyColumn: "id",
                keyValue: 6,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "Personal_skillModel",
                keyColumn: "id",
                keyValue: 4,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "categorys",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "categorys",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "categorys",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 4,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "reports",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 4,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 5,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 6,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 4,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 5,
                column: "is_delete",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$4ARU/iTNOdwfKMTjLFN9ee184v8tquZjq30uqMuN2AoidEO3cdcTy");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$XsUhc0v8KExkTzg30z/snOsLnNyirJJi3dx8220VLLIAM8vzo1yWa");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$Yy8qE/ZfGmM5cj4ORIHWUOmS5b3TWuIo52mv0kpyctfB/2MVY14aC");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$jvCiNyAe.oc2ELjtEfBfm.JAruGhGmFJE6AkCQDnnRNmgSCoOi4ma");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$NL1GJs/.nsWcUOZc8c03QuQEHVKChDLXSOdcqsY9wAN5i1u7A38D.");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_roles_role_id",
                table: "user_roles",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_roles_role_id",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "Personal_skillModel");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "MessageModel");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "jwts");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "follows");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "files");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "categorys");

            migrationBuilder.DropColumn(
                name: "is_delete",
                table: "applicants");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "is_delete",
                table: "users",
                newName: "is_deleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$.APwi6U9Od0WSYtp1HYTR.VW.4FnarJOcHgQ9xa4QvbHZsbVTZSBi");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$lzS3ml1lsXBWbz1BoScHveadquB9f9wA7Fd42MwJW.Jfqzo7sU39.");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$YLMLuDzGe6o7H1R0FyJag.lVzQn3M51rtsK8RRH48pLD0F1ajJ9/a");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$Czh6AFtSobAgRRXHYV89Ue7d4bv4H7/Q8OFKhxUCkmtuDStDdQ9Lm");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$hgI.ffInzvvQaKATG.JE/./ThOdTGMkgDLpK53viGeklxcKmiRAsS");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
