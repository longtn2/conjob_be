using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConJob.Data.Migrations
{
    /// <inheritdoc />
    public partial class changeJob_IdInPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "job_id",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 1,
                column: "job_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 2,
                column: "job_id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$WdUpx2xd/bP2gWtsBGaVNuZ44WrRup5RZqGAmG919bm/qFlRphDea");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$EUhMYFf9p.P6o8m/dtLgW.hDtRawAduusn6GlG5wfp1azv5Wy6tbK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$DDyWtSfY3t10nBqgbZKE5.ubfLLN/4IeSL1DHOi8LvB4/roUEj9PG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$ca9hSvmbrjlXnC7JJoQlFegtOMbmTKkjHBFApGPMgK8YuRztB817m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$8GOaas2ard5vzfElZbXZbuEFI7tI/fM2p5fp.ROBo.ShtRfM3xgRO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "job_id",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 1,
                column: "job_id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "id",
                keyValue: 2,
                column: "job_id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "$2a$11$l3bvDBF9QwETalhZy1yxFu8AxCfUdI6qx1.VLF/I3tX.Lcwbwczn2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "$2a$11$pGUb.VfqUITDC/uX7kSsKebAags/DrpszkdZ/Lvejcu9eZjqZIBmK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3,
                column: "password",
                value: "$2a$11$D0dGon92BipLHPleXdExT.dSJXGrNuenihZ3Ltcxw8uAtGJxo2udO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4,
                column: "password",
                value: "$2a$11$LkrMhqjbW3mudDX1FJVzluxfSa4XbtxrZL/dn61n6r/HpaP2ZTuw.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5,
                column: "password",
                value: "$2a$11$hCYwKlSwt1E7e/EQsbv6OuKj807Ugx6cHGgL3v6mdjTyrPDm/sb2m");
        }
    }
}
