using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class addRocketChatUserIdAndAuthToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rocket_user_id",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "rocket_auth_token",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$GH9esAE4DQHXNMej272C9.99vWsrds3QhXeXipq4betrVRSp8KTWy", "", "" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$rjlubRrmmPSuhH8SFOa5/OZASaX8TMTp5TSHgcdljwDxIuuBYSwRy", "", "" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$FieEYQY01FW9w4mbJfy7luT8P4TbrCeotZlSq5QkQG7jkp9UbAIJ2", "", "" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$Z/GAEIpD74r1RIaluU78TuEi9IGUAaKGDObKw5AsHWVP6jP9tC4ri", "", "" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$w9OaNSjAhvBgK3Wp9K3vpejxq.PidBcHdl5ONP0tIg9OTrIWudjH2", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rocket_user_id",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "rocket_auth_token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$J/iG9reVVgiPnx5yHcRKc.aIoBTtcLExGunHO.gNc0w7nCV9zHm9S", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$NEDJm8ptVqgBo1cEeWMhVu53q8QuHGLW/F2xL06jo66nQ7AG6iybu", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$9J0kVjDUnecvzrfJGPH9wepcMOF0rmuVr1Vc8l0ReUHzl2FONXCeC", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$LrulKFOGEvnTe97UF.9J7.TzMRKWGtV3Fui4iHUhqbxgwf5FlM.M.", null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "password", "rocket_auth_token", "rocket_user_id" },
                values: new object[] { "$2a$11$woVHHuVxzvtx8ZzeTAQ3auDGzxWBEKEIVTLUhv7ffHDcKRUta3RlW", null, null });
        }
    }
}
