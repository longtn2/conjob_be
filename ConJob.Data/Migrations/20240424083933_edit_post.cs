using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit_post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$5Xnh5Np30LZJRaupUMoFa..ivaF.J0Y/Ms7UnMrTg.9W6w46K.eDy");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$cIFxaqcIPZ5xGt0bLcyG1OtRIrLwCxZWCib6qxei3YCUqx5UjaMgK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$xzzf6.jjdFb/kUuAp.cJA.J7kugtqfa1Xz1/AHkUiSp4ZunohCHGi");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$RXRA5MVhlGRomR5csaoVN.QI1AvVyC6nToQl4sCJ0sU7HEp695LgW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$PuyUjoctHNR3kfQbAXsLw.agx5jb.k0Lk4G5vVRsHLkkkoFvyr9XG");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$5nZX1qTnXrylK.d3TaSGFuOBS2Y0bVPRjhoMECzpG4r.vRb/mixNi");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$NgOvCGCpZNXC18dpD2YOPOhM2DMOtmf2CopIibFfQjzwBOuMOZn3O");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$zjkcSOxCOsJzRbB.3LAsGelEYy2JBVsrK.fIwbMWDceQP93YWofWe");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$WDHChQhkZo5MF8xtRvEdFujFugkbamOR5rtDfgYMM8xB/jgb4thYK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$O7.s8DGGKVQgAi5/gZUd3uJLQCTOzHirndnJcigTFdt/wd9roZeF6");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
