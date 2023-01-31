using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargoApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "parcelDepth", "parcelDimensionPrice", "parcelFinalPrice", "parcelHeight", "parcelName", "parcelWeight", "parcelWeightPrice", "parcelWidth" },
                values: new object[,]
                {
                    { 2, 50, 0, 0, 50, null, 50, 0, 50 },
                    { 3, 25, 0, 0, 25, null, 25, 0, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
