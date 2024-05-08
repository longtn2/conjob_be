using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_datetime_type_to_dateonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "dob",
                table: "users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateOnly(1, 1, 1), "$2a$11$/d30RnNczulaGJ4VLRzvoe.xPEcnKo5xtc0GMjYRFErqKmaq8sqDq" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateOnly(1, 1, 1), "$2a$11$/VPnQD4y9ENknGN7rqXBT.f4w3RUAiW6czt4v15UQ2gV6eL1HRW02" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateOnly(1, 1, 1), "$2a$11$jlGg04ifBheneMOYT4fL.On3BYS37bBPoNR/TZqVkFDB9PW6EHOFK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateOnly(1, 1, 1), "$2a$11$Fz0yp4UpIWdmPVOuG6PPeudqUf4W5faiSs0GSZy8cNqHjUKOcF.bW" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateOnly(1, 1, 1), "$2a$11$xvC392ydPn4NmgStcw.MIut7R3dyf4Lc84MlkDwXZIz/u9Daz3KY6" });

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$5nZX1qTnXrylK.d3TaSGFuOBS2Y0bVPRjhoMECzpG4r.vRb/mixNi" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$NgOvCGCpZNXC18dpD2YOPOhM2DMOtmf2CopIibFfQjzwBOuMOZn3O" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$zjkcSOxCOsJzRbB.3LAsGelEYy2JBVsrK.fIwbMWDceQP93YWofWe" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$WDHChQhkZo5MF8xtRvEdFujFugkbamOR5rtDfgYMM8xB/jgb4thYK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "dob", "password" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$O7.s8DGGKVQgAi5/gZUd3uJLQCTOzHirndnJcigTFdt/wd9roZeF6" });

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
