using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class rename_table_to_lowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_job_id",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_user_id",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Posts_post_id",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Users_user_id",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_from_user_id",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_to_user_id",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_user_id",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JWTs_Users_user_id",
                table: "JWTs");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_post_id",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_user_id",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_receive_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_send_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserModelid",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_from_user_notifi_id",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Skills_skill_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Users_user_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Files_file_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Jobs_job_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Posts_post_id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_user_id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_role_id",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_user_id",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JWTs",
                table: "JWTs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follows",
                table: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "skills");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "reports");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "likes");

            migrationBuilder.RenameTable(
                name: "JWTs",
                newName: "jwts");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "jobs");

            migrationBuilder.RenameTable(
                name: "Follows",
                newName: "follows");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "files");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "categorys");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "applicants");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "user_roles");

            migrationBuilder.RenameIndex(
                name: "IX_Users_email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_user_id",
                table: "reports",
                newName: "IX_reports_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_post_id",
                table: "reports",
                newName: "IX_reports_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_user_id",
                table: "posts",
                newName: "IX_posts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_job_id",
                table: "posts",
                newName: "IX_posts_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_file_id",
                table: "posts",
                newName: "IX_posts_file_id");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserModelid",
                table: "notifications",
                newName: "IX_notifications_UserModelid");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_from_user_notifi_id",
                table: "notifications",
                newName: "IX_notifications_from_user_notifi_id");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_user_id",
                table: "likes",
                newName: "IX_likes_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_post_id",
                table: "likes",
                newName: "IX_likes_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_JWTs_user_id",
                table: "jwts",
                newName: "IX_jwts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_user_id",
                table: "jobs",
                newName: "IX_jobs_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_category_id",
                table: "jobs",
                newName: "IX_jobs_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_to_user_id",
                table: "follows",
                newName: "IX_follows_to_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_from_user_id",
                table: "follows",
                newName: "IX_follows_from_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_user_id",
                table: "applicants",
                newName: "IX_applicants_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_job_id",
                table: "applicants",
                newName: "IX_applicants_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_user_id",
                table: "user_roles",
                newName: "IX_user_roles_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_role_id",
                table: "user_roles",
                newName: "IX_user_roles_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skills",
                table: "skills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reports",
                table: "reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_likes",
                table: "likes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jwts",
                table: "jwts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobs",
                table: "jobs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_follows",
                table: "follows",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_files",
                table: "files",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorys",
                table: "categorys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_applicants",
                table: "applicants",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles",
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
                name: "FK_applicants_jobs_job_id",
                table: "applicants",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_applicants_users_user_id",
                table: "applicants",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_posts_post_id",
                table: "CommentModel",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_users_user_id",
                table: "CommentModel",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_follows_users_from_user_id",
                table: "follows",
                column: "from_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_follows_users_to_user_id",
                table: "follows",
                column: "to_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_categorys_category_id",
                table: "jobs",
                column: "category_id",
                principalTable: "categorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_users_user_id",
                table: "jobs",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_jwts_users_user_id",
                table: "jwts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_posts_post_id",
                table: "likes",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_users_user_id",
                table: "likes",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_users_receive_user_id",
                table: "MessageModel",
                column: "receive_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_users_send_user_id",
                table: "MessageModel",
                column: "send_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserModelid",
                table: "notifications",
                column: "UserModelid",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_from_user_notifi_id",
                table: "notifications",
                column: "from_user_notifi_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_skillModel_skills_skill_id",
                table: "Personal_skillModel",
                column: "skill_id",
                principalTable: "skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_skillModel_users_user_id",
                table: "Personal_skillModel",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_files_file_id",
                table: "posts",
                column: "file_id",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts",
                column: "job_id",
                principalTable: "jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_posts_post_id",
                table: "reports",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_users_user_id",
                table: "reports",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_users_user_id",
                table: "user_roles",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicants_jobs_job_id",
                table: "applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_applicants_users_user_id",
                table: "applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_posts_post_id",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_users_user_id",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_follows_users_from_user_id",
                table: "follows");

            migrationBuilder.DropForeignKey(
                name: "FK_follows_users_to_user_id",
                table: "follows");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_categorys_category_id",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jobs_users_user_id",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_jwts_users_user_id",
                table: "jwts");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_posts_post_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_users_user_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_users_receive_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_users_send_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserModelid",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_from_user_notifi_id",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_skills_skill_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_users_user_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_files_file_id",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_jobs_job_id",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_posts_post_id",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_users_user_id",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Roles_role_id",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_users_user_id",
                table: "user_roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skills",
                table: "skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reports",
                table: "reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_likes",
                table: "likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jwts",
                table: "jwts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobs",
                table: "jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_follows",
                table: "follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_files",
                table: "files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorys",
                table: "categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_applicants",
                table: "applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_roles",
                table: "user_roles");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "skills",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "reports",
                newName: "Reports");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "likes",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "jwts",
                newName: "JWTs");

            migrationBuilder.RenameTable(
                name: "jobs",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "follows",
                newName: "Follows");

            migrationBuilder.RenameTable(
                name: "files",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "categorys",
                newName: "Categorys");

            migrationBuilder.RenameTable(
                name: "applicants",
                newName: "Applicants");

            migrationBuilder.RenameTable(
                name: "user_roles",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "Users",
                newName: "IX_Users_email");

            migrationBuilder.RenameIndex(
                name: "IX_reports_user_id",
                table: "Reports",
                newName: "IX_Reports_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_reports_post_id",
                table: "Reports",
                newName: "IX_Reports_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_user_id",
                table: "Posts",
                newName: "IX_Posts_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_job_id",
                table: "Posts",
                newName: "IX_Posts_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_posts_file_id",
                table: "Posts",
                newName: "IX_Posts_file_id");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserModelid",
                table: "Notifications",
                newName: "IX_Notifications_UserModelid");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_from_user_notifi_id",
                table: "Notifications",
                newName: "IX_Notifications_from_user_notifi_id");

            migrationBuilder.RenameIndex(
                name: "IX_likes_user_id",
                table: "Likes",
                newName: "IX_Likes_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_likes_post_id",
                table: "Likes",
                newName: "IX_Likes_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_jwts_user_id",
                table: "JWTs",
                newName: "IX_JWTs_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_user_id",
                table: "Jobs",
                newName: "IX_Jobs_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_category_id",
                table: "Jobs",
                newName: "IX_Jobs_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_follows_to_user_id",
                table: "Follows",
                newName: "IX_Follows_to_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_follows_from_user_id",
                table: "Follows",
                newName: "IX_Follows_from_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_applicants_user_id",
                table: "Applicants",
                newName: "IX_Applicants_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_applicants_job_id",
                table: "Applicants",
                newName: "IX_Applicants_job_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_roles_user_id",
                table: "UserRoles",
                newName: "IX_UserRoles_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_user_roles_role_id",
                table: "UserRoles",
                newName: "IX_UserRoles_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JWTs",
                table: "JWTs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follows",
                table: "Follows",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$ERlFL0E9VPW.24fHfytRv.eo51TgL4j//w0d1fu.boxNomLOVx71m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$5T3O2uJBd4cthDWGLjhy1OyzWLa/RwfCpUbs4m70ALMIzEdlkitku");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$KSS1SkxNCDrR2dBZRs4TzuXSeMvX77zD0hPAPvN0EHXV.T.QKGpwm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$XAilPha6UXTNJefGNpNG7ubKjWwGOCrwtxS9/PC1YRAPfiBPX8DoO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$zCYBsNWgdDje.5rnne2UfOGs8kfA0/jqNVTnf9WrKCOTRxDmC9n5e");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_job_id",
                table: "Applicants",
                column: "job_id",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Users_user_id",
                table: "Applicants",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Posts_post_id",
                table: "CommentModel",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Users_user_id",
                table: "CommentModel",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_from_user_id",
                table: "Follows",
                column: "from_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_to_user_id",
                table: "Follows",
                column: "to_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categorys",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_user_id",
                table: "Jobs",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JWTs_Users_user_id",
                table: "JWTs",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_post_id",
                table: "Likes",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_user_id",
                table: "Likes",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_Users_receive_user_id",
                table: "MessageModel",
                column: "receive_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageModel_Users_send_user_id",
                table: "MessageModel",
                column: "send_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserModelid",
                table: "Notifications",
                column: "UserModelid",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_from_user_notifi_id",
                table: "Notifications",
                column: "from_user_notifi_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_skillModel_Skills_skill_id",
                table: "Personal_skillModel",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personal_skillModel_Users_user_id",
                table: "Personal_skillModel",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Files_file_id",
                table: "Posts",
                column: "file_id",
                principalTable: "Files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Jobs_job_id",
                table: "Posts",
                column: "job_id",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_user_id",
                table: "Posts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Posts_post_id",
                table: "Reports",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_user_id",
                table: "Reports",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_role_id",
                table: "UserRoles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_user_id",
                table: "UserRoles",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
