using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class remove_fcmtoken_in_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fcm_token",
                table: "jwts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fcm_token",
                table: "jwts",
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
                column: "password",
                value: "$2a$11$IPu4SH5sl7KLqlvCIzabtuO2aPHj1hZBI/MFKQDrQfNXtS0XmPzTO");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$/42/TkT425FoqqQPF.2H2eIfDsOsSvR2O3qf50ph5wRqbOdvM5rEy");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$CkJMN./ScB4MxT.MDIQtw.mrVN5BiQ7b71H9ahPcbS1iBzFS6h.6G");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$QQadzeNhE4oyPNE13yVB0urZbuybGLG5MZ/WnYDc8wpMzCGDb1I0W");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$E5mY2OvIkD5VlSK28L717u9bC5WTGeoQ10I8UBTuWvrcb5xQgMyp2");
        }
    }
}
