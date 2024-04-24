using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_JobId_NotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$0MgeUzKpamNxU2Erhj.EKOm2DtAXsLRNiUSFlHpY8Zgftn.xBdhWa");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$Cu3F/xRQNFRdl4FTAi5P7ebxfcwaNk8Jo6I1GL9bCrYEkrVxFgExe");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$idwY9OkDTqrltKt0FwFZ.uNWaz6gcYtdorjobGxagzUIveVNY7YS6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$bWF5gTZS7FmrxNp/zQSOeOmFosb62N.shO28AWFm/k7L95NgN7DJO");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$2NSwQeFA6qTCVab7U2ua9epiNT2E/lwTFakgxXzDd4utID9AZROX.");
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.AlterColumn<int>(
                name: "job_id",
                table: "posts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
            migrationBuilder.AddForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$EHcVC1VhvopqfWFISlD0sO/5/tVu5iPW5YbAgMFSa1eRBoRDtMAq2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$lmKX0Jo9FpmI52/RCzLRdujiPieTJHhAos4AqLocX4zhBpsqeGo4S");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$oSXCqhYgdmGflHUhJ4LPkOfoBG9ROYBtmaip8NUvImWyxyXMfvW3y");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$8Y2kPXlPRZcqibMF7Y1auOLEnq53qwV5Y0CM5f9qO95E7EfLyv.7i");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$ziJGr4x.xguOVA/u4AzT0OtXXf9RXlTWp5HFWk1STcgHbKkK.YUqa");
        }
    }
}
