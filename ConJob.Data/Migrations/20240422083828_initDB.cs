using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.id);
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
                        principalColumn: "id");
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
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JWTs", x => x.id);
                    table.ForeignKey(
                        name: "FK_JWTs_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_user_id = table.Column<int>(type: "int", nullable: false),
                    receive_user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_receive_user_id",
                        column: x => x.receive_user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_send_user_id",
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
                    notifi_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    is_accept = table.Column<bool>(type: "bit", nullable: false),
                    from_user_notifi_id = table.Column<int>(type: "int", nullable: false),
                    UserModelid = table.Column<int>(type: "int", nullable: true),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserModelid",
                        column: x => x.UserModelid,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_from_user_notifi_id",
                        column: x => x.from_user_notifi_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persional_Skills",
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
                    table.PrimaryKey("PK_Persional_Skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persional_Skills_Skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "Skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persional_Skills_Users_user_id",
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
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    is_actived = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Posts_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Likes_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reports_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "change_on", "create_on", "created_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "các ngành liên quan đến truyền thông", "media", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Đây là cách gọi chung nhất cho người viết mã, sử dụng các ngôn ngữ lập trình để tạo ra các chương trình máy tính.", "Programmer", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, " Đây là cách gọi chung cho những người tạo ra nội dung, bao gồm bài viết, hình ảnh, video, âm nhạc, v.v. Nội dung này có thể được sử dụng cho mục đích giải trí, giáo dục, quảng cáo hoặc kinh doanh", "Content creator", null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "id", "change_on", "create_on", "created_at", "name", "size", "type", "updated_at", "url" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anh datvila", 100.0, 1, null, "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "anh thong soai ca", 100.0, 1, null, "https://newsmd2fr.keeng.vn/tiin/archive/imageslead/2023/06/14/90_c373d5ac0433257417f21a0a5e07fa11.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "change_on", "create_on", "created_at", "role_description", "role_name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là admin cuyền lực.", "Admin", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là nole tư bản đi tìm kiếm miếng cơm manh áo.", "Job Seeker", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Là tư bản đi kiếm những con chiêng ngoan đạo.", "Job Giver", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "id", "change_on", "create_on", "created_at", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Content Creator là người sáng tạo nội dung cho các nền tảng như mạng xã hội, blog, website, YouTube, v.v. Họ có thể viết bài viết, quay video, chụp ảnh, livestream để thu hút người theo dõi và truyền tải thông điệp đến đông đảo người dùng", "Content Creator", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viết mã HTML, CSS và JavaScript: Đây là những ngôn ngữ lập trình cơ bản để xây dựng giao diện web. HTML tạo cấu trúc cho trang web, CSS định dạng giao diện và JavaScript tạo tính năng tương tác cho người dùng.", "Front-end developer", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Người mẫu ảnh là những người có ngoại hình ưa nhìn, vóc dáng cân đối, làn da khỏe đẹp và thần thái cuốn hút. Họ được đào tạo bài bản về cách tạo dáng, biểu cảm trước ống kính máy ảnh để có thể truyền tải thông điệp của nhiếp ảnh gia hoặc thương hiệu một cách hiệu quả nhất.", "Fashion Model", null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "người sử dụng máy ảnh để ghi lại hình ảnh, khoảnh khắc, sự kiện, v.v. Họ sử dụng kỹ năng và óc sáng tạo để tạo ra những bức ảnh đẹp mắt, truyền tải thông điệp hoặc lưu giữ kỷ niệm.", "Photograper", null },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "những người biểu diễn nghệ thuật múa, sử dụng chuyển động cơ thể, biểu cảm gương mặt và ngôn ngữ cơ thể để truyền tải thông điệp, cảm xúc và kể chuyện", "Dance", null },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nhà sản xuất âm nhạc, hay còn được ví như người họa nên sản phẩm âm nhạc chất lượng.", "Music Producer", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "address", "avatar", "change_on", "create_on", "created_at", "dob", "email", "fcm_token", "first_name", "gender", "is_deleted", "is_email_confirmed", "last_name", "password", "phone_number", "updated_at" },
                values: new object[,]
                {
                    { 1, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@com.com", null, "Admin", 0, false, false, "Dat", "$2a$11$l3bvDBF9QwETalhZy1yxFu8AxCfUdI6qx1.VLF/I3tX.Lcwbwczn2", "0335487991", null },
                    { 2, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apeacocke1@google.ca", null, "Fawnia", 0, false, false, "Alexandros", "$2a$11$pGUb.VfqUITDC/uX7kSsKebAags/DrpszkdZ/Lvejcu9eZjqZIBmK", "0354579415", null },
                    { 3, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cpancoast2@wsj.com", null, "Cazzie", 0, false, false, "Pancoast", "$2a$11$D0dGon92BipLHPleXdExT.dSJXGrNuenihZ3Ltcxw8uAtGJxo2udO", "0354596415", null },
                    { 4, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datmarri@google.ca", null, "Marri", 0, false, false, "Dat", "$2a$11$LkrMhqjbW3mudDX1FJVzluxfSa4XbtxrZL/dn61n6r/HpaP2ZTuw.", "0354579415", null },
                    { 5, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datkhongchin@google.ca", null, "Dat", 0, false, false, "khong chin", "$2a$11$hCYwKlSwt1E7e/EQsbv6OuKj807Ugx6cHGgL3v6mdjTyrPDm/sb2m", "0354579415", null }
                });

            migrationBuilder.InsertData(
                table: "Follows",
                columns: new[] { "id", "change_on", "create_on", "created_at", "from_user_id", "to_user_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 4, null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "id", "budget", "category_id", "change_on", "create_on", "created_at", "description", "expired_day", "job_type", "location", "quanlity", "status", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 2000.0, 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "photograper làm để chụp ảnh cá xấu đang ăn", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bắc băng dương", 20, "gần đầy", "Đây là công việc về media", null, 3 },
                    { 2, 5000.0, 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Code dự án Web trong 2 tháng", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ấn độ dương", 1, "không một ai ", "Đây là công việc liên quan đến Backend", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "change_on", "create_on", "created_at", "message_content", "receive_user_id", "send_user_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ê tao có công việc này ngon nè ", 3, 2, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Việc gì vậy?", 2, 3, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Đi múa lân 2 ngày cho lân sư đoàn, giá cả thương lượng", 3, 2, null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nghe cũng okela á.Tao muốn due giá là 200k cho 1 ngày . Mày chốt không", 2, 3, null },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Oke thôi.2h ngày 12th 5 nhé ", 3, 2, null },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "oke chốt", 2, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "id", "UserModelid", "change_on", "create_on", "created_at", "from_user_notifi_id", "is_accept", "notifi_content", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, "node ", false, null },
                    { 2, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, "node", false, null },
                    { 3, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, "node", false, null }
                });

            migrationBuilder.InsertData(
                table: "Persional_Skills",
                columns: new[] { "id", "change_on", "create_on", "created_at", "desciption", "exp", "skill_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trong suốt 2 năm làm nghề thì tôi khá tự tin với tài năng của mình", "2 năm ", 1, null, 3 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "I'am The Best", "3 năm ", 2, null, 2 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tôi là một người đa tài", "10 năm", 3, null, 3 },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Người có năng khiếu từ nhỏ , siêu vippro", "từ lúc sinh ra ", 4, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "caption", "change_on", "create_on", "created_at", "file_id", "is_actived", "is_deleted", "job_id", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, "Là một người có trách nghiệm tôi luồn hoàn thành mọi việc một cách hoàn hảo", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, false, 2, "Luôn là người có trách nghiệm , I'am vippro", null, 2 },
                    { 2, "Là một người đỉnh cao tôi tự tin , khoe cá tính", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, false, 1, "Ai tuyển tôi không", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "change_on", "create_on", "created_at", "role_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 1 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 2 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 3 },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, 4 },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Applicants",
                columns: new[] { "id", "apply_date", "change_on", "create_on", "created_at", "job_id", "status", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Mới nộp", null, 2 },
                    { 2, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Mới nộp", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "id", "change_on", "create_on", "created_at", "post_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 4 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 3 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "id", "change_on", "create_on", "created_at", "post_id", "reason", "updated_at", "user_id" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "lừa đảo ", null, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_job_id",
                table: "Applicants",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_user_id",
                table: "Applicants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_user_id",
                table: "Comments",
                column: "user_id");

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
                name: "IX_JWTs_user_id",
                table: "JWTs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_post_id",
                table: "Likes",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_user_id",
                table: "Likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_receive_user_id",
                table: "Messages",
                column: "receive_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_send_user_id",
                table: "Messages",
                column: "send_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_from_user_notifi_id",
                table: "Notifications",
                column: "from_user_notifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserModelid",
                table: "Notifications",
                column: "UserModelid");

            migrationBuilder.CreateIndex(
                name: "IX_Persional_Skills_skill_id",
                table: "Persional_Skills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_Persional_Skills_user_id",
                table: "Persional_Skills",
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
                name: "IX_Reports_post_id",
                table: "Reports",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_user_id",
                table: "Reports",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_role_id",
                table: "UserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_user_id",
                table: "UserRoles",
                column: "user_id");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "JWTs");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Persional_Skills");

            migrationBuilder.DropTable(
                name: "Reports");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
