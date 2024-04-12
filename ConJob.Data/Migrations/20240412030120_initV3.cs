using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class initV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowModel_User_FromUserID",
                table: "FollowModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowModel_User_UserId",
                table: "FollowModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowModel",
                table: "FollowModel");

            migrationBuilder.RenameTable(
                name: "FollowModel",
                newName: "Follow");

            migrationBuilder.RenameIndex(
                name: "IX_FollowModel_UserId",
                table: "Follow",
                newName: "IX_Follow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FollowModel_FromUserID",
                table: "Follow",
                newName: "IX_Follow_FromUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follow",
                table: "Follow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_User_FromUserID",
                table: "Follow",
                column: "FromUserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follow_User_UserId",
                table: "Follow",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follow_User_FromUserID",
                table: "Follow");

            migrationBuilder.DropForeignKey(
                name: "FK_Follow_User_UserId",
                table: "Follow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follow",
                table: "Follow");

            migrationBuilder.RenameTable(
                name: "Follow",
                newName: "FollowModel");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_UserId",
                table: "FollowModel",
                newName: "IX_FollowModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follow_FromUserID",
                table: "FollowModel",
                newName: "IX_FollowModel_FromUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowModel",
                table: "FollowModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowModel_User_FromUserID",
                table: "FollowModel",
                column: "FromUserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowModel_User_UserId",
                table: "FollowModel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
