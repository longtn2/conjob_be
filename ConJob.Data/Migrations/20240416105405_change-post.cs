using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class changepost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Jobs_job_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_job_id",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "JobModelid",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$Y1wz6njFEgiXzAFuTpba4.0ku61lTU/0eP6ZSdtW8ZaXnQd.jOa02");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_JobModelid",
                table: "Posts",
                column: "JobModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Jobs_JobModelid",
                table: "Posts",
                column: "JobModelid",
                principalTable: "Jobs",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Jobs_JobModelid",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_JobModelid",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "JobModelid",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 6,
                column: "password",
                value: "$2a$11$A46N85RwsnzbfaDkNbl3BeP32gvL8KkY4vSrh29eG9VeRBhS82T7.");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_job_id",
                table: "Posts",
                column: "job_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Jobs_job_id",
                table: "Posts",
                column: "job_id",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
