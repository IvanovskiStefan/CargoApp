using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoApp.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parcelWidth = table.Column<int>(type: "int", nullable: false),
                    parcelHeight = table.Column<int>(type: "int", nullable: false),
                    parcelDepth = table.Column<int>(type: "int", nullable: false),
                    parcelWeight = table.Column<int>(type: "int", nullable: false),
                    parcelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parcelDimensionPrice = table.Column<int>(type: "int", nullable: false),
                    parcelWeightPrice = table.Column<int>(type: "int", nullable: false),
                    parcelFinalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "parcelDepth", "parcelDimensionPrice", "parcelFinalPrice", "parcelHeight", "parcelName", "parcelWeight", "parcelWeightPrice", "parcelWidth" },
                values: new object[] { 1, 100, 0, 0, 100, null, 100, 0, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");
        }
    }
}
