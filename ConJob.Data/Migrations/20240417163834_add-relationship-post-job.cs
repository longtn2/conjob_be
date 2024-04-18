using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class addrelationshippostjob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_receive_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageModel_Users_send_user_id",
                table: "MessageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Skills_skill_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Personal_skillModel_Users_user_id",
                table: "Personal_skillModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Jobs_job_id",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_job_id",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personal_skillModel",
                table: "Personal_skillModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "job_id",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Personal_skillModel",
                newName: "Persional_Skills");

            migrationBuilder.RenameTable(
                name: "MessageModel",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_skillModel_user_id",
                table: "Persional_Skills",
                newName: "IX_Persional_Skills_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Personal_skillModel_skill_id",
                table: "Persional_Skills",
                newName: "IX_Persional_Skills_skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_send_user_id",
                table: "Messages",
                newName: "IX_Messages_send_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_MessageModel_receive_user_id",
                table: "Messages",
                newName: "IX_Messages_receive_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_user_id",
                table: "Comments",
                newName: "IX_Comments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_post_id",
                table: "Comments",
                newName: "IX_Comments_post_id");

            migrationBuilder.AddColumn<int>(
                name: "JobModelid",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persional_Skills",
                table: "Persional_Skills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 1,
                column: "JobModelid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 2,
                column: "JobModelid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$.9I/h0t5vRd6gXImROWCFOqXRwvcAy4r8ednR79uZbiURBc6hN6Ie");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$3vhn5LsoLhZHAI1Lt6FYReYwx6pW3V/5jFaei8K2EitH/i0CwLTFm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$jXTEvryioE.GMnhWMQ2e7upYw.xseMX4oCktepHJOEbRfgXOrjjJC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$G/Ds/GlEIGNolFn1yahpae/eS2mSjA1JQPNqh1mFCgONiTn8EYave");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$FcGFqaYT/G0P7erupduyMuumWTwUh8X2u.jKZvk76mCUhiIZDvSzy");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_JobModelid",
                table: "Posts",
                column: "JobModelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_post_id",
                table: "Comments",
                column: "post_id",
                principalTable: "Posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_user_id",
                table: "Comments",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_Users_from_user_id",
                table: "Follows",
                column: "from_user_id",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_receive_user_id",
                table: "Messages",
                column: "receive_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_send_user_id",
                table: "Messages",
                column: "send_user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persional_Skills_Skills_skill_id",
                table: "Persional_Skills",
                column: "skill_id",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persional_Skills_Users_user_id",
                table: "Persional_Skills",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Comments_Posts_post_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_user_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_Users_from_user_id",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_receive_user_id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_send_user_id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Persional_Skills_Skills_skill_id",
                table: "Persional_Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Persional_Skills_Users_user_id",
                table: "Persional_Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Jobs_JobModelid",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_JobModelid",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persional_Skills",
                table: "Persional_Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "JobModelid",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Persional_Skills",
                newName: "Personal_skillModel");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageModel");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentModel");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.RenameIndex(
                name: "IX_Persional_Skills_user_id",
                table: "Personal_skillModel",
                newName: "IX_Personal_skillModel_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Persional_Skills_skill_id",
                table: "Personal_skillModel",
                newName: "IX_Personal_skillModel_skill_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_send_user_id",
                table: "MessageModel",
                newName: "IX_MessageModel_send_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_receive_user_id",
                table: "MessageModel",
                newName: "IX_MessageModel_receive_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_user_id",
                table: "CommentModel",
                newName: "IX_CommentModel_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_post_id",
                table: "CommentModel",
                newName: "IX_CommentModel_post_id");

            migrationBuilder.AddColumn<int>(
                name: "job_id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personal_skillModel",
                table: "Personal_skillModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageModel",
                table: "MessageModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "id");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 1,
                column: "job_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 2,
                column: "job_id",
                value: 2);

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_job_id",
                table: "Posts",
                column: "job_id");

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
                name: "FK_Jobs_Categorys_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categorys",
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
                name: "FK_Posts_Jobs_job_id",
                table: "Posts",
                column: "job_id",
                principalTable: "Jobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
