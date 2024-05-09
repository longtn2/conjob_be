using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeFcm_tokeninUserAndAddToJwtModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fcm_token",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "fcm_token",
                table: "jwts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                column: "url",
                value: "https://media.2dep.vn/upload/thucquyen/2022/05/19/dat-villa-la-ai-hot-tiktoker-9x-trieu-view-co-chuyen-tinh-xuyen-bien-gioi-voi-ban-gai-indonesia-social-1652941149.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$G.emI9340ym4ukhapSqes.idq4sGSoNYR/nOELRpzMHBT5yJzN5Be");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$J09VFlhsU6Owz1SsMd9DeOyMBBwOf./AmcO1YB8eNbWYLpEXi897q");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$4J6iSVJrp.vNMuwbG9L24uWR5cx.DNPWG.nKQFeXVDzyChgZ6JyVS");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$tphYiWvKbK7yiK6/dZgV1eqmoSPi8FCoKkTiAH/vGpptTCx40WmGu");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$ISXxPQrowTqkCTUebn16Ue.Fd.hf2leQa6bseMtUtoDyIg.bz2pAW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fcm_token",
                table: "jwts");

            migrationBuilder.AddColumn<string>(
                name: "fcm_token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "files",
                keyColumn: "id",
                keyValue: 1,
                column: "url",
                value: "https://cdn.eva.vn/upload/2-2020/images/2020-05-05/don-xin-viec-ba-dao-6-1588672247-471-width1212height798.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "fcm_token", "password" },
                values: new object[] { null, "$2a$11$66bUDFe1ETMAZY33cOHRe.fASCN/iXF3xcbOKIyf0dt5yyvpbb41C" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "fcm_token", "password" },
                values: new object[] { null, "$2a$11$uBS/kwSOGEh7nM05xYgtcuPbztfh9orPMJUHr5hdXdbeyFVN9bKSm" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "fcm_token", "password" },
                values: new object[] { null, "$2a$11$hkSLSZcq5q5sj3HatiD70uZwZ2APXqFk2je6lOA1RgvIGneo22oTK" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "fcm_token", "password" },
                values: new object[] { null, "$2a$11$5u7PXyEDoqFO6Qpts/SHyesVD8Ev.Dt3WzihNMXrL5rDTgZZBOzD6" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "fcm_token", "password" },
                values: new object[] { null, "$2a$11$J71tO.8X3vBLx/SOyS4EGOe/5f51LO5Gculi4Hy7tXxDXksTe.2Yi" });
        }
    }
}
