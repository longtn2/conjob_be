using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class edit_status_applicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.DropColumn(
               name: "status",
               table: "Applicants");
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$66bUDFe1ETMAZY33cOHRe.fASCN/iXF3xcbOKIyf0dt5yyvpbb41C");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$uBS/kwSOGEh7nM05xYgtcuPbztfh9orPMJUHr5hdXdbeyFVN9bKSm");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$hkSLSZcq5q5sj3HatiD70uZwZ2APXqFk2je6lOA1RgvIGneo22oTK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$5u7PXyEDoqFO6Qpts/SHyesVD8Ev.Dt3WzihNMXrL5rDTgZZBOzD6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$J71tO.8X3vBLx/SOyS4EGOe/5f51LO5Gculi4Hy7tXxDXksTe.2Yi");

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
            migrationBuilder.DropColumn(
                name: "status",
                table: "applicants");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "applicants",
                nullable: true,
                defaultValue: "DefaultValue");

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: "Đã nộp");

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: "Đã nộp");

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
