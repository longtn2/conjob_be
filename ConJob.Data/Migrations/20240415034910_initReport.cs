using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class initReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportModel_PostModel_PostId",
                table: "ReportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportModel_User_UserId",
                table: "ReportModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportModel",
                table: "ReportModel");

            migrationBuilder.RenameTable(
                name: "ReportModel",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_ReportModel_UserId",
                table: "Report",
                newName: "IX_Report_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportModel_PostId",
                table: "Report",
                newName: "IX_Report_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_PostModel_PostId",
                table: "Report",
                column: "PostId",
                principalTable: "PostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_PostModel_PostId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_UserId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "ReportModel");

            migrationBuilder.RenameIndex(
                name: "IX_Report_UserId",
                table: "ReportModel",
                newName: "IX_ReportModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_PostId",
                table: "ReportModel",
                newName: "IX_ReportModel_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportModel",
                table: "ReportModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportModel_PostModel_PostId",
                table: "ReportModel",
                column: "PostId",
                principalTable: "PostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportModel_User_UserId",
                table: "ReportModel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
