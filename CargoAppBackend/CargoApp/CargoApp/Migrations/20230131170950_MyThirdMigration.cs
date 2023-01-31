using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoApp.Migrations
{
    /// <inheritdoc />
    public partial class MyThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "parcelFinalPrice",
                table: "Parcels",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 1,
                column: "parcelFinalPrice",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 2,
                column: "parcelFinalPrice",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 3,
                column: "parcelFinalPrice",
                value: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "parcelFinalPrice",
                table: "Parcels",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 1,
                column: "parcelFinalPrice",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 2,
                column: "parcelFinalPrice",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 3,
                column: "parcelFinalPrice",
                value: 0);
        }
    }
}
