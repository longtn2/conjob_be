using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
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
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "follows",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_user_id = table.Column<int>(type: "int", nullable: false),
                    to_user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follows", x => x.id);
                    table.ForeignKey(
                        name: "FK_follows_users_from_user_id",
                        column: x => x.from_user_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_follows_users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "jobs",
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
                    quantity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_jobs_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "jwts",
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
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jwts", x => x.id);
                    table.ForeignKey(
                        name: "FK_jwts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messages",
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
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_users_receive_user_id",
                        column: x => x.receive_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_users_send_user_id",
                        column: x => x.send_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notifi_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    is_accept = table.Column<bool>(type: "bit", nullable: false),
                    from_user_notifi_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_users_from_user_notifi_id",
                        column: x => x.from_user_notifi_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "persional_skills",
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
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persional_skills", x => x.id);
                    table.ForeignKey(
                        name: "FK_persional_skills_skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persional_skills_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicants",
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
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.id);
                    table.ForeignKey(
                        name: "FK_applicants_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicants_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    is_actived = table.Column<bool>(type: "bit", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    job_id = table.Column<int>(type: "int", nullable: false),
                    file_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_files_file_id",
                        column: x => x.file_id,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    post_id = table.Column<int>(type: "int", nullable: false),
                    change_on = table.Column<int>(type: "int", nullable: false),
                    create_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_likes_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reports",
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
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.id);
                    table.ForeignKey(
                        name: "FK_reports_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reports_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "files",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "name", "type", "updated_at", "url" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "anh datvila", 1, null, "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg" },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "anh thong soai ca", 1, null, "https://newsmd2fr.keeng.vn/tiin/archive/imageslead/2023/06/14/90_c373d5ac0433257417f21a0a5e07fa11.jpg" },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "justin", 0, null, "https://youtu.be/x3LGCLNq33c?t=48" },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "guiboss", 1, null, "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-2-1588672247-395-width1214height806.jpg" },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Xinnn", 1, null, "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-1-1588672247-922-width610height813.jpg" },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Xinviecti", 0, null, "https://youtu.be/F8-LHRu5cDU" },
                    { 7, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Diemyeu", 0, null, "https://youtu.be/nm4XvSf6IWw" },
                    { 8, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DungDai", 0, null, "https://youtu.be/5QPu-wDmeTA" },
                    { 9, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LonR", 1, null, "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-6-1588672247-471-width1212height798.jpg" },
                    { 10, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NgonHonNYC", 1, null, "https://jobsgo.vn/blog/wp-content/uploads/2023/03/stt-tuyen-dung-hay-content-tuyen-dung-hai-huoc.png" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "role_description", "role_name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Là admin cuyền lực.", "Admin", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Là nole tư bản đi tìm kiếm miếng cơm manh áo.", "TimViec", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Là tư bản đi kiếm những con chiêng ngoan đạo.", "PhatViec", null }
                });

            migrationBuilder.InsertData(
                table: "skills",
                columns: new[] { "id", "change_on", "create_on", "created_at", "description", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Content Creator là người sáng tạo nội dung cho các nền tảng như mạng xã hội, blog, website, YouTube, v.v. Họ có thể viết bài viết, quay video, chụp ảnh, livestream để thu hút người theo dõi và truyền tải thông điệp đến đông đảo người dùng", false, "Content Creator", null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viết mã HTML, CSS và JavaScript: Đây là những ngôn ngữ lập trình cơ bản để xây dựng giao diện web. HTML tạo cấu trúc cho trang web, CSS định dạng giao diện và JavaScript tạo tính năng tương tác cho người dùng.", false, "Front-end developer", null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Người mẫu ảnh là những người có ngoại hình ưa nhìn, vóc dáng cân đối, làn da khỏe đẹp và thần thái cuốn hút. Họ được đào tạo bài bản về cách tạo dáng, biểu cảm trước ống kính máy ảnh để có thể truyền tải thông điệp của nhiếp ảnh gia hoặc thương hiệu một cách hiệu quả nhất.", false, "Fashion Model", null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "người sử dụng máy ảnh để ghi lại hình ảnh, khoảnh khắc, sự kiện, v.v. Họ sử dụng kỹ năng và óc sáng tạo để tạo ra những bức ảnh đẹp mắt, truyền tải thông điệp hoặc lưu giữ kỷ niệm.", false, "Photograper", null },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "những người biểu diễn nghệ thuật múa, sử dụng chuyển động cơ thể, biểu cảm gương mặt và ngôn ngữ cơ thể để truyền tải thông điệp, cảm xúc và kể chuyện", false, "Dance", null },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "nhà sản xuất âm nhạc, hay còn được ví như người họa nên sản phẩm âm nhạc chất lượng.", false, "Music Producer", null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address", "avatar", "change_on", "create_on", "created_at", "dob", "email", "fcm_token", "first_name", "gender", "is_deleted", "is_email_confirmed", "last_name", "password", "phone_number", "updated_at" },
                values: new object[,]
                {
                    { 1, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@com.com", null, "Admin", 0, false, true, "Dat", "$2a$11$tawV6mVjt2t6dc/AjKBjwu02a62owFZv.MquM8QWpS1AHegQsDGi.", "0335487991", null },
                    { 2, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "apeacocke1@google.ca", null, "Fawnia", 0, false, true, "Alexandros", "$2a$11$qS0mBDLyugCvOWXdQy/B3.GnrQRlL/zK730n8sjLKx.oOFdxEAtqu", "0354579415", null },
                    { 3, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cpancoast2@wsj.com", null, "Cazzie", 0, false, true, "Pancoast", "$2a$11$Z52Ge2.zjgXoUzD0NLWBG.SMXCtA9yWB4LthKfKUD2hus2Qg1L7ZW", "0354596415", null },
                    { 4, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datmarri@google.ca", null, "Marri", 0, false, true, "Dat", "$2a$11$BhhEKh/BljHmvpbleffHSemAWUUKCfYyyXpsPdGIjsuP0ka5zLJiK", "0354579415", null },
                    { 5, "Hue", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "datkhongchin@google.ca", null, "Dat", 0, false, true, "khong chin", "$2a$11$vSTrG62ZLHqkAYDuXv95e.BMhQt9Qdm1zZKueA6xoKfEFTyBjteI2", "0354579415", null }
                });

            migrationBuilder.InsertData(
                table: "follows",
                columns: new[] { "id", "change_on", "create_on", "created_at", "from_user_id", "is_deleted", "to_user_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, 3, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, 3, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, 4, null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, 5, null }
                });

            migrationBuilder.InsertData(
                table: "jobs",
                columns: new[] { "id", "budget", "change_on", "create_on", "created_at", "description", "expired_day", "is_deleted", "job_type", "location", "quantity", "status", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 2000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "photograper làm để chụp ảnh cá xấu đang ăn", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "12 Đường Nguyễn Văn Linh, Phường Hải Châu, Quận Hải Châu, Thành phố Đà Nẵng", 20, 1, "Đây là công việc về media", null, 3 },
                    { 2, 5000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Code dự án Web trong 2 tháng", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "45 Lê Lợi, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", 1, 0, "Đây là công việc liên quan đến Backend", null, 5 },
                    { 3, 2000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tìm kiếm nhà ảnh độc lập để chụp hình cho đời sống dưới biển.", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "78 Đường Lý Thường Kiệt, Phường Văn Miếu, Quận Đống Đa, Thành phố Hà Nội", 20, 0, "Nhà ảnh độc lập từ xa", null, 3 },
                    { 4, 5000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phát triển dự án web trong 2 tháng.", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "23 Phố Hàng Gai, Quận Hoàn Kiếm, Thành phố Hà Nội", 1, 1, "Lập trình viên Backend toàn thời gian", null, 4 },
                    { 5, 2500.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chỉnh sửa video cho các dự án khác nhau.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "56 Đường Nguyễn Huệ, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh", 8, 1, "Biên tập video bán thời gian", null, 5 },
                    { 6, 1200.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tạo ra nội dung hấp dẫn cho blog của công ty.", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, "34 Phố Hàng Bông, Quận Hoàn Kiếm, Thành phố Hà Nội", 12, 0, "Người viết nội dung tại chỗ", null, 3 },
                    { 7, 4000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "87 Đường Hai Bà Trưng, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "101 Đường Hùng Vương, Phường Nguyễn Du, Quận 1, Thành phố Hồ Chí Minh", 1, 1, "Phát triển viên RESTful API kết hợp", null, 2 },
                    { 8, 3000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tạo ra các thiết kế đồ họa cho các khách hàng khác nhau theo cách tự do.", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, "29 Đường Lê Lai, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", 1, 1, "Thiết kế đồ họa tự do", null, 4 },
                    { 9, 6000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phát triển ứng dụng phần mềm toàn thời gian cho một công ty công nghệ.", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "17 Đường Lý Tự Trọng, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", 1, 0, "Kỹ sư phần mềm toàn thời gian", null, 3 },
                    { 10, 1800.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quản lý tài khoản truyền thông xã hội từ xa cho một công ty tiếp thị.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0, "63 Phố Hàng Trống, Quận Hoàn Kiếm, Thành phố Hà Nội", 1, 1, "Quản lý truyền thông xã hội từ xa", null, 5 },
                    { 11, 1500.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tạo nội dung bán thời gian cho các nền tảng trực tuyến khác nhau.", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "8 Phố Hàng Điếu, Quận Hoàn Kiếm, Thành phố Hà Nội", 10, 0, "Người tạo nội dung bán thời gian", null, 2 },
                    { 12, 3000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phát triển và triển khai các chiến lược tiếp thị với khả năng làm việc từ xa.", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "72 Đường Trần Hưng Đạo, Phường Phan Chu Trinh, Quận Hoàn Kiếm, Thành phố Hà Nội", 1, 1, "Chuyên gia tiếp thị kết hợp", null, 3 },
                    { 13, 3500.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thiết kế giao diện người dùng và trải nghiệm tại chỗ cho một công ty phần mềm.", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, "39 Đường Lê Thánh Tôn, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", 1, 0, "Thiết kế UI/UX tại chỗ", null, 4 },
                    { 14, 2000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viết bài cho các khách hàng khác nhau theo cách tự do.", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, "20 Phố Hàng Bài, Quận Hoàn Kiếm, Thành phố Hà Nội", 1, 1, "Người viết bài tự do", null, 5 },
                    { 15, 1000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Hỗ trợ các nhiệm vụ hành chính bán thời gian cho một công ty từ xa.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "54 Đường Hồ Tùng Mậu, Phường Bến Nghé, Quận 1, Thành phố Hồ Chí Minh", 5, 0, "Trợ lý ảo bán thời gian", null, 2 },
                    { 16, 4500.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quản lý các dự án với khả năng làm việc từ xa và tại chỗ.", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "95 Đường Đề Thám, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh", 1, 1, "Quản lý dự án kết hợp", null, 3 },
                    { 17, 3000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chụp ảnh cưới cho cặp đôi tại Hà Nội.", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, "41 Phố Hàng Trống, Quận Hoàn Kiếm, Thành phố Hà Nội", 1, 0, "Nhà ảnh tự do", null, 4 },
                    { 18, 5000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Phát triển ứng dụng di động cho một công ty khởi nghiệp.", new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "68 Đường Lê Lợi, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", 1, 0, "Phát triển viên ứng dụng di động toàn thời gian", null, 5 },
                    { 19, 2500.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Biên tập video quảng cáo cho các doanh nghiệp tại Hà Nội.", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, "25 Đường Lý Thường Kiệt, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh", 3, 0, "Biên tập viên phim tự do", null, 3 },
                    { 20, 4000.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thiết kế đồ họa cho các dự án web và in ấn.", new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "10 Đường Trần Phú, Phường Lê Lợi, Thành phố Vinh, Tỉnh Nghệ An", 2, 1, "Nhà thiết kế đồ họa toàn thời gian", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "messages",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "message_content", "receive_user_id", "send_user_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ê tao có công việc này ngon nè ", 3, 2, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Việc gì vậy?", 2, 3, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Đi múa lân 2 ngày cho lân sư đoàn, giá cả thương lượng", 3, 2, null },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Nghe cũng okela á.Tao muốn due giá là 200k cho 1 ngày . Mày chốt không", 2, 3, null },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Oke thôi.2h ngày 12th 5 nhé ", 3, 2, null },
                    { 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "oke chốt", 2, 3, null }
                });

            migrationBuilder.InsertData(
                table: "notifications",
                columns: new[] { "id", "change_on", "create_on", "created_at", "from_user_notifi_id", "is_accept", "is_deleted", "notifi_content", "status", "updated_at" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, false, "node ", false, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, false, "node", false, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, false, "node", false, null }
                });

            migrationBuilder.InsertData(
                table: "persional_skills",
                columns: new[] { "id", "change_on", "create_on", "created_at", "desciption", "exp", "is_deleted", "skill_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Trong suốt 2 năm làm nghề thì tôi khá tự tin với tài năng của mình", "2 năm ", false, 1, null, 3 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "I'am The Best", "3 năm ", false, 2, null, 2 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tôi là một người đa tài", "10 năm", false, 3, null, 3 },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Người có năng khiếu từ nhỏ , siêu vippro", "từ lúc sinh ra ", false, 4, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "role_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 1 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, null, 2 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, null, 3 },
                    { 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, null, 4 },
                    { 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "applicants",
                columns: new[] { "id", "apply_date", "change_on", "create_on", "created_at", "is_deleted", "job_id", "status", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "Mới nộp", null, 2 },
                    { 2, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, "Mới nộp", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "caption", "change_on", "create_on", "created_at", "file_id", "is_actived", "is_deleted", "job_id", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, "Bạn là một nhiếp ảnh gia tài năng và đam mê việc ghi lại những khoảnh khắc độc đáo dưới nước? Chúng tôi đang tìm kiếm những nhà ảnh độc lập để ghi lại cuộc sống đa dạng dưới biển.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, false, 3, "Nhà ảnh độc lập từ xa", null, 3 },
                    { 2, "Bạn có kinh nghiệm trong lập trình và muốn thử thách bản thân với một dự án web trong vòng 2 tháng? Hãy tham gia vào đội ngũ của chúng tôi và đóng góp vào việc phát triển dự án!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, false, 2, "Code dự án Web trong 2 tháng", null, 3 },
                    { 3, "Bạn là một nhiếp ảnh gia tự do và đam mê việc ghi lại những khoảnh khắc đẹp của cặp đôi trong ngày trọng đại? Hãy tham gia vào đội ngũ của chúng tôi và tạo ra những bức ảnh cưới đẹp nhất cho khách hàng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, false, 17, "Nhà ảnh tự do", null, 3 },
                    { 4, "Chúng tôi đang tìm kiếm một Lập trình viên Backend tài năng để tham gia vào dự án web và đóng góp vào việc phát triển trong 2 tháng.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, false, 4, "Lập trình viên Backend toàn thời gian", null, 3 },
                    { 5, "Bạn có khả năng chỉnh sửa video và muốn tham gia vào các dự án sáng tạo khác nhau? Hãy gia nhập đội ngũ của chúng tôi và đóng góp vào việc tạo ra video chất lượng cao!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, false, 5, "Biên tập video bán thời gian", null, 3 },
                    { 6, "Bạn có khả năng tạo ra nội dung sáng tạo và muốn thể hiện tài năng của mình trên blog của công ty? Hãy tham gia vào đội ngũ của chúng tôi và tạo ra những bài viết hấp dẫn!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, false, 11, "Người viết nội dung tại chỗ", null, 3 },
                    { 7, "Bạn có kỹ năng phát triển RESTful APIs và muốn làm việc từ xa? Chúng tôi đang tìm kiếm những Phát triển viên RESTful API kết hợp để đóng góp vào dự án web của chúng tôi.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, false, 7, "Phát triển viên RESTful API kết hợp", null, 3 },
                    { 8, "Bạn là một người sáng tạo và muốn tự do trong việc thiết kế đồ họa? Chúng tôi đang tìm kiếm Thiết kế đồ họa tự do để tạo ra các thiết kế độc đáo cho khách hàng.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, false, 8, "Thiết kế đồ họa tự do", null, 3 },
                    { 9, "Bạn là một kỹ sư phần mềm tài năng và muốn tham gia vào việc phát triển ứng dụng phần mềm toàn thời gian? Hãy tham gia vào đội ngũ của chúng tôi và đóng góp vào dự án công nghệ của chúng tôi.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, false, 9, "Kỹ sư phần mềm toàn thời gian", null, 3 },
                    { 10, "Bạn có khả năng quản lý truyền thông xã hội và muốn làm việc từ xa? Hãy tham gia vào đội ngũ của chúng tôi và quản lý tài khoản truyền thông xã hội cho các chiến dịch tiếp thị của chúng tôi.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, false, 16, "Quản lý truyền thông xã hội từ xa", null, 5 },
                    { 11, "Bạn là một người sáng tạo và muốn tạo nội dung độc đáo cho các nền tảng trực tuyến? Chúng tôi đang tìm kiếm Người tạo nội dung bán thời gian để tham gia vào các dự án sáng tạo.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, false, 15, "Người tạo nội dung bán thời gian", null, 5 },
                    { 12, "Bạn là một chuyên gia tiếp thị sáng tạo và muốn tham gia vào việc phát triển các chiến lược tiếp thị? Chúng tôi đang tìm kiếm Chuyên gia tiếp thị kết hợp để đóng góp vào các dự án tiếp thị của chúng tôi.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, false, 12, "Chuyên gia tiếp thị kết hợp", null, 5 },
                    { 13, "Bạn có khả năng thiết kế giao diện người dùng và muốn làm việc tại chỗ? Chúng tôi đang tìm kiếm Thiết kế UI/UX tại chỗ để tham gia vào các dự án phần mềm.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, false, 14, "Thiết kế UI/UX tại chỗ", null, 5 },
                    { 14, "Bạn là một người viết bài có tài năng và muốn làm việc tự do? Chúng tôi đang tìm kiếm Người viết bài tự do để tạo ra nội dung chất lượng cho các khách hàng.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, false, 20, "Người viết bài tự do", null, 5 },
                    { 15, "Viết bài cho các khách hàng khác nhau theo cách tự do.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, false, false, 14, "Tìm việc người viết bài tự do", null, 5 },
                    { 16, "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, false, false, 5, "Biên tập video", null, 4 },
                    { 17, "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, false, 5, "Biên tập video", null, 4 },
                    { 18, "Tôi là một người đam mê viết lập trình và muốn tham gia vào lĩnh vực phát triển RESTful APIs. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc phát triển các dự án web. Rất mong nhận được cơ hội từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, false, false, 7, "Phát triển viên RESTful API", null, 4 },
                    { 19, "Tôi là một người đam mê sáng tạo và muốn tham gia vào lĩnh vực biên tập video. Tôi có kinh nghiệm trong chỉnh sửa video và mong muốn được góp phần vào các dự án sáng tạo. Rất mong được cơ hội làm việc cùng các bạn!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, false, false, 5, "Biên tập video", null, 4 },
                    { 20, "Tôi là một người đam mê viết lập trình và muốn tham gia vào lĩnh vực phát triển RESTful APIs. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc phát triển các dự án web. Rất mong nhận được cơ hội từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, false, 7, "Phát triển viên RESTful API", null, 2 },
                    { 21, "Tôi là một người đam mê viết lập trình và mong muốn có cơ hội tham gia vào các dự án phát triển ứng dụng di động. Tôi tự tin vào khả năng lập trình của mình và mong muốn được góp phần vào việc tạo ra các sản phẩm chất lượng. Rất mong nhận được sự quan tâm từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, false, 18, "Phát triển viên ứng dụng di động", null, 2 },
                    { 22, "Tôi là một người đam mê viết lách và mong muốn có cơ hội làm việc trong lĩnh vực tạo nội dung. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc phát triển nội dung cho các dự án trực tuyến. Rất mong nhận được sự quan tâm và cơ hội từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, false, 11, "Người tạo nội dung", null, 2 },
                    { 23, "Tôi là một người đam mê thiết kế đồ họa và mong muốn có cơ hội làm việc trong lĩnh vực này. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc tạo ra các thiết kế đẹp mắt cho các dự án web và in ấn. Rất mong nhận được cơ hội từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, false, false, 20, "Nhà thiết kế đồ họa", null, 2 },
                    { 24, "Tôi là một người yêu thích viết lách và mong muốn có cơ hội làm việc trong lĩnh vực tạo nội dung. Tôi tự tin vào khả năng sáng tạo của mình và mong muốn được góp phần vào việc phát triển nội dung cho các dự án trực tuyến. Rất mong nhận được sự quan tâm và cơ hội từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, false, false, 11, "Người tạo nội dung", null, 4 },
                    { 25, "Tôi là một lập trình viên có kinh nghiệm trong phát triển ứng dụng di động và đam mê công việc của mình. Tôi mong muốn có cơ hội tham gia vào các dự án phát triển ứng dụng di động và đóng góp vào việc tạo ra các sản phẩm chất lượng. Rất mong nhận được sự quan tâm từ các nhà tuyển dụng!", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, false, false, 18, "Phát triển viên ứng dụng di động", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "likes",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "post_id", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 4 },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 3 },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "reports",
                columns: new[] { "id", "change_on", "create_on", "created_at", "is_deleted", "post_id", "reason", "updated_at", "user_id" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, "lừa đảo ", null, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_applicants_job_id",
                table: "applicants",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_applicants_user_id",
                table: "applicants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_follows_from_user_id",
                table: "follows",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_follows_to_user_id",
                table: "follows",
                column: "to_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_user_id",
                table: "jobs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_jwts_user_id",
                table: "jwts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_post_id",
                table: "likes",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_user_id",
                table: "likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_receive_user_id",
                table: "messages",
                column: "receive_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_send_user_id",
                table: "messages",
                column: "send_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_from_user_notifi_id",
                table: "notifications",
                column: "from_user_notifi_id");

            migrationBuilder.CreateIndex(
                name: "IX_persional_skills_skill_id",
                table: "persional_skills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_persional_skills_user_id",
                table: "persional_skills",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_file_id",
                table: "posts",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_job_id",
                table: "posts",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_post_id",
                table: "reports",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_reports_user_id",
                table: "reports",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "follows");

            migrationBuilder.DropTable(
                name: "jwts");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "persional_skills");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
