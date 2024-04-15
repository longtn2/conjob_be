using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<double>(type: "float", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_email_confirmed = table.Column<bool>(type: "bit", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fcm_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_user_id = table.Column<int>(type: "int", nullable: false),
                    to_user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.id);
                    table.ForeignKey(
                        name: "FK_Follows_Users_from_user_id",
                        column: x => x.from_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Follows_Users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budget = table.Column<double>(type: "float", nullable: false),
                    job_type = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expired_day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quanlity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categorys_category_id",
                        column: x => x.category_id,
                        principalTable: "Categorys",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JWTs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token_hash_value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JWTs", x => x.id);
                    table.ForeignKey(
                        name: "FK_JWTs_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_JWTs_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_user_id = table.Column<int>(type: "int", nullable: false),
                    receive_user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_MessageModel_Users_receive_user_id",
                        column: x => x.receive_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageModel_Users_send_user_id",
                        column: x => x.send_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    is_accept = table.Column<bool>(type: "bit", nullable: false),
                    from_user_notifi_id = table.Column<int>(type: "int", nullable: false),
                    to_user_notiofi_id = table.Column<int>(type: "int", nullable: false),
                    to_user_notifi_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_from_user_notifi_id",
                        column: x => x.from_user_notifi_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_to_user_notifi_id",
                        column: x => x.to_user_notifi_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personal_SkillModels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    desciption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skill_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_SkillModels", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personal_SkillModels_Skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personal_SkillModels_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: false),
                    apply_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Applicants_Jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "Jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applicants_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Applicants_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    is_actived = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_Files_file_id",
                        column: x => x.file_id,
                        principalTable: "Files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "Jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Likes_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportModel_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportModel_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ReportModel_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "change_on", "create_on", "created_at", "role_description", "role_name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là admin cuyền lực.", "Admin", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là nole tư bản đi tìm kiếm miếng cơm manh áo.", "TimViec", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là tư bản đi kiếm những con chiêng ngoan đạo.", "PhatViec", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "address", "avatar", "change_on", "create_on", "created_at", "dob", "email", "fcm_token", "first_name", "gender", "is_deleted", "is_email_confirmed", "last_name", "password", "phone_number", "updated_at" },
                values: new object[] { 6, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@com.com", null, "Admin", 0, false, false, "Dat", "$2a$11$VPHfkMIdXH0EvTG2RMdFl.kyvme1xnkqAlUaSiemj1MdIcO0/U5De", "0335487991", null });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "UserModelid", "change_on", "create_on", "created_at", "role_id", "updated_at", "user_id" },
                values: new object[] { 1, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_job_id",
                table: "Applicants",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_user_id",
                table: "Applicants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_UserModelid",
                table: "Applicants",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_from_user_id",
                table: "Follows",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_to_user_id",
                table: "Follows",
                column: "to_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_category_id",
                table: "Jobs",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_user_id",
                table: "Jobs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserModelid",
                table: "Jobs",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_JWTs_user_id",
                table: "JWTs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_JWTs_UserModelid",
                table: "JWTs",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_post_id",
                table: "Likes",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_user_id",
                table: "Likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserModelid",
                table: "Likes",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModel_receive_user_id",
                table: "MessageModel",
                column: "receive_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModel_send_user_id",
                table: "MessageModel",
                column: "send_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_from_user_notifi_id",
                table: "Notifications",
                column: "from_user_notifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_to_user_notifi_id",
                table: "Notifications",
                column: "to_user_notifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_SkillModels_skill_id",
                table: "Personal_SkillModels",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_SkillModels_user_id",
                table: "Personal_SkillModels",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_file_id",
                table: "Posts",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_job_id",
                table: "Posts",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_user_id",
                table: "Posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserModelid",
                table: "Posts",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_ReportModel_post_id",
                table: "ReportModel",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportModel_user_id",
                table: "ReportModel",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportModel_UserModelid",
                table: "ReportModel",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserModelid",
                table: "UserRoles",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "JWTs");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "MessageModel");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Personal_SkillModels");

            migrationBuilder.DropTable(
                name: "ReportModel");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
