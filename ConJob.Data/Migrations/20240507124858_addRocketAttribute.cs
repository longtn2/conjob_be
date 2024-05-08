using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRocketAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "rocket_auth_token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rocket_user_id",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rocket_room_id",
                table: "applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 1,
                column: "rocket_room_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "applicants",
                keyColumn: "id",
                keyValue: 2,
                column: "rocket_room_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$yHH.QrjXkgJ7S66EiQmbC.W53KHP.3pwihxg3H43MUrjME1MsBFAK", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$wNC0Z5sxKP/FaElwwacrmOg5Lhr8iLMVo.oGkUXfPwwEzPhieIUpq", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$lJdBgTU6zqivkxLA0LDt5ORs2/QBoQDdWPumuCWtrws1lmdZ3VWqS", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$yNLMVIP5mPwNSTUiy.RHc.jbWzB5FL4stsa7cWhBWDyKCpzr9kqLi", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$Ldv/pX6aZmx.DlsXXc2BLue.VanHyLkeEJG/T2dB4mEvzdgr6pvJa", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rocket_auth_token",
                table: "users");

            migrationBuilder.DropColumn(
                name: "rocket_user_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "rocket_room_id",
                table: "applicants");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$da5z5tr/NqsqTiPtGSnr7u2lST0exk6M.d7OqrV63MT9YxAuhlwWG");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$UgT7FsEtDvoZLqEhyFKrl.2dsQmTIS31f2ePqDPD1yP0rYZ3O5wny");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$rlxKZc1.agGyGuJiqCU8iuhaoNJO4cuGgbny3LBALdUjP2uUzCpe6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$xhjRELpRiUiOO/DcbqsxyOASJ9kcqGEVeDAj8jzPZh2eF4bzJJ6Fi");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$Ovc4ZRhrhCxugj/iV5WPOeT59kamtFL8pQx40TMK8eg0vi9PzxCfG");
        }
    }
}
