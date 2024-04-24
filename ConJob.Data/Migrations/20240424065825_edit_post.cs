using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "users");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "persional_skills");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "jwts");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "follows");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "files");

            migrationBuilder.DropColumn(
                name: "create_on",
                table: "applicants");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "users",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "user_roles",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "skills",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "roles",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "reports",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "posts",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "persional_skills",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "notifications",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "messages",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "likes",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "jwts",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "jobs",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "follows",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "files",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "change_on",
                table: "applicants",
                newName: "created_by");

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "user_roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "job_id",
                table: "posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "persional_skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "jwts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "follows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "changed_by",
                table: "applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "changed_by", "status" },
                values: new object[] { 0, "Đã nộp" });

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "changed_by", "status" },
                values: new object[] { 0, "Đã nộp" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "changed_by", "url" },
                values: new object[] { 0, "https://videos.pexels.com/video-files/6698049/6698049-uhd_3840_2160_25fps.mp4" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 5,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "changed_by", "url" },
                values: new object[] { 0, "https://videos.pexels.com/video-files/2084066/2084066-hd_1920_1080_24fps.mp4" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "changed_by", "url" },
                values: new object[] { 0, "https://videos.pexels.com/video-files/2795169/2795169-uhd_3840_2160_25fps.mp4" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "changed_by", "url" },
                values: new object[] { 0, "https://videos.pexels.com/video-files/3959712/3959712-uhd_4096_2160_25fps.mp4" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 9,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 10,
                column: "changed_by",
                value: 0);

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "changed_by", "created_at", "created_by", "is_deleted", "name", "type", "updated_at", "url" },
                values: new object[,]
                {
                    { 11, 0, null, 0, false, "Bia", 1, null, "https://th.bing.com/th/id/OIP.HY0HMmxb_o1ri0wKsIq2jgHaHa?rs=1&pid=ImgDetMain" },
                    { 12, 0, null, 0, false, "Ảnh khỏa thân", 1, null, "https://th.bing.com/th/id/OIP.aVQAa1WSb_Ct4kzZpeCm7AHaHa?rs=1&pid=ImgDetMain" },
                    { 13, 0, null, 0, false, "Ngón giữa", 1, null, "https://toigingiuvedep.vn/wp-content/uploads/2021/12/anh-ngon-tay-giua-450x600.jpg" },
                    { 14, 0, null, 0, false, "Súng", 1, null, "https://videos.pexels.com/video-files/3223449/3223449-uhd_3840_2160_24fps.mp4" },
                    { 15, 0, null, 0, false, "Ảnh nhóm", 1, null, "https://th.bing.com/th/id/R.5f2c346baa2978dd9df6c4a2e093e00f?rik=VwvG7bfjVAc4bw&pid=ImgRaw&r=0" },
                    { 16, 0, null, 0, false, "Ảnh nữ", 1, null, "https://scontent.fdad3-4.fna.fbcdn.net/v/t39.30808-6/439864769_3640571656182795_4383749922632562270_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5f2048&_nc_ohc=x-BvE_1KWXMAb4mSMIZ&_nc_ht=scontent.fdad3-4.fna&oh=00_AfCr0ciTDobk0kNf6V8TLjSk1OQB5afqkW-526xvn0JPsw&oe=662E6F0F" },
                    { 17, 0, null, 0, false, "Ảnh nữ", 0, null, "https://videos.pexels.com/video-files/9335837/9335837-hd_1920_1080_25fps.mp4 " }
                });

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 5,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 6,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 7,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 8,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 9,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 10,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 11,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 12,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 13,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 14,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 15,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 16,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 17,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 18,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 19,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 20,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 5,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 6,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "changed_by", "created_at" },
                values: new object[] { 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "reports",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "changed_by", "role_description" },
                values: new object[] { 0, "manage it all" });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "changed_by", "role_description", "role_name" },
                values: new object[] { 0, "They are people looking for work", "Job Seeker" });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "changed_by", "role_description", "role_name" },
                values: new object[] { 0, "They are someone who goes to work", "Job Giver" });

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 5,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 6,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 4,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 5,
                column: "changed_by",
                value: 0);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "avatar", "changed_by", "password" },
                values: new object[] { "https://i.pinimg.com/originals/27/0c/be/270cbeb639f6d0ed64f3106daaeccc1d.jpg", 0, "$2a$11$xgFvOBfgKtGqASFRu87KMOvvkMai5TNJ2nfEv05Dza1HTN0xMl7BS" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "avatar", "changed_by", "password" },
                values: new object[] { "https://th.bing.com/th/id/OIP.MbAE6jT-VnWsVr9ANrkYNwHaKw?rs=1&pid=ImgDetMain", 0, "$2a$11$hdUkmsqqyXTmqUMQIAhzA.oxewud1WupbTgIYQWaT3sSi8gPbkusi" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "avatar", "changed_by", "password" },
                values: new object[] { "https://th.bing.com/th/id/R.47e446cab641c16b2a6f8c9db520ee19?rik=0vd8lTgoDpgUzQ&pid=ImgRaw&r=0", 0, "$2a$11$wts0KUMc3lQdwqVnOVz5N.Kfa0wCU9xd.3FGvv26l/cGfQZhmD6wC" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "avatar", "changed_by", "password" },
                values: new object[] { "https://th.bing.com/th/id/OIP.-Xu8PRNaVrwqZ1J-f4E16wHaHa?w=1200&h=1200&rs=1&pid=ImgDetMain", 0, "$2a$11$vj8gAWubBLdyY40pT7XOC.0o0PrP/QPIGWk4KyFj7xVxOjnl7STfa" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "avatar", "changed_by", "password" },
                values: new object[] { "https://th.bing.com/th/id/OIP.-q9JRr6eAAyyBL3s-3g1PgHaKt?rs=1&pid=ImgDetMain", 0, "$2a$11$T/FJH8jED2Vlglo65i7MmOYn6VMUN63oRj92kPUQdQaNx72VTVe2y" });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "caption", "changed_by", "created_at", "created_by", "file_id", "is_actived", "is_deleted", "job_id", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 26, "Yêu cái đẹp", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 12, false, false, 20, "Nhà thẩm định hình thể", null, 2 },
                    { 27, "Yêu nhậu nhẹt", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 11, false, false, 20, "Nhà thưởng ẩm thực", null, 2 },
                    { 28, "Nghệ thuật tay", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 13, false, false, 20, "Nghệ thuật tay", null, 2 },
                    { 29, "Hình ảnh mạnh mẽ", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 14, false, false, 20, "Hình ảnh mạnh mẽ", null, 2 },
                    { 30, "Chúng ta là những người bạn thân ", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 15, false, false, 20, "Chúng ta là những người bạn thân , luôn luôn đồng hành cùng nhau", null, 2 },
                    { 31, "Nghệ thuật lừa dối ánh trăng", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 15, false, false, 20, "Hình ảnh nghệ thuật", null, 2 },
                    { 32, "Đem đến cho người dùng trải nghiệm tuyệt vời ", 0, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 17, false, false, 3, "Mát xa bấm huyệt", null, 3 }
                });

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
            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "files",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "users");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "skills");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "persional_skills");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "likes");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "jwts");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "follows");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "files");

            migrationBuilder.DropColumn(
                name: "changed_by",
                table: "applicants");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "users",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "user_roles",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "skills",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "roles",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "reports",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "posts",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "persional_skills",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "notifications",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "messages",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "likes",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "jwts",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "jobs",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "follows",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "files",
                newName: "change_on");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "applicants",
                newName: "change_on");

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "user_roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "job_id",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "persional_skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "jwts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "follows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_on",
                table: "applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_on", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mới nộp" });

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_on", "status" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mới nộp" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_on", "url" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://youtu.be/x3LGCLNq33c?t=48" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 5,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_on", "url" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://youtu.be/F8-LHRu5cDU" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_on", "url" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://youtu.be/nm4XvSf6IWw" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_on", "url" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://youtu.be/5QPu-wDmeTA" });

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 9,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 10,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "follows",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 5,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 6,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 7,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 8,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 9,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 10,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 11,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 12,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 13,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 14,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 15,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 16,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 17,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 18,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 19,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "jobs",
                keyColumn: "id",
                keyValue: 20,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "likes",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 5,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "messages",
                keyColumn: "id",
                keyValue: 6,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "notifications",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "persional_skills",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "create_on", "created_at" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "reports",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "create_on", "role_description" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Là admin cuyền lực." });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "create_on", "role_description", "role_name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Là nole tư bản đi tìm kiếm miếng cơm manh áo.", "TimViec" });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "create_on", "role_description", "role_name" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Là tư bản đi kiếm những con chiêng ngoan đạo.", "PhatViec" });

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 5,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "skills",
                keyColumn: "id",
                keyValue: 6,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 1,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 2,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 3,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 4,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "user_roles",
                keyColumn: "id",
                keyValue: 5,
                column: "create_on",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "avatar", "create_on", "password" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$tawV6mVjt2t6dc/AjKBjwu02a62owFZv.MquM8QWpS1AHegQsDGi." });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "avatar", "create_on", "password" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$qS0mBDLyugCvOWXdQy/B3.GnrQRlL/zK730n8sjLKx.oOFdxEAtqu" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "avatar", "create_on", "password" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$Z52Ge2.zjgXoUzD0NLWBG.SMXCtA9yWB4LthKfKUD2hus2Qg1L7ZW" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "avatar", "create_on", "password" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$BhhEKh/BljHmvpbleffHSemAWUUKCfYyyXpsPdGIjsuP0ka5zLJiK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "avatar", "create_on", "password" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$vSTrG62ZLHqkAYDuXv95e.BMhQt9Qdm1zZKueA6xoKfEFTyBjteI2" });

            migrationBuilder.AddForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
