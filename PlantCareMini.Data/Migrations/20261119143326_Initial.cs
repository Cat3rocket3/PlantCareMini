using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlantCareMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrowingLocations",
                columns: table => new
                {
                    GrowingLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowingLocations", x => x.GrowingLocationId);
                });

            migrationBuilder.CreateTable(
                name: "PlantTypes",
                columns: table => new
                {
                    PlantTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    LightRequirement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTypes", x => x.PlantTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlantTypeId = table.Column<int>(type: "int", nullable: false),
                    GrowingLocationId = table.Column<int>(type: "int", nullable: false),
                    WateringIntervalDays = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                    table.CheckConstraint("CK_Plants_WateringIntervalDays", "[WateringIntervalDays] > 0");
                    table.ForeignKey(
                        name: "FK_Plants_GrowingLocations_GrowingLocationId",
                        column: x => x.GrowingLocationId,
                        principalTable: "GrowingLocations",
                        principalColumn: "GrowingLocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plants_PlantTypes_PlantTypeId",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantTypes",
                        principalColumn: "PlantTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GrowingLocations",
                columns: new[] { "GrowingLocationId", "LocationType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Room" },
                    { 2, 2, "Balcony" },
                    { 3, 3, "Outdoor garden" }
                });

            migrationBuilder.InsertData(
                table: "PlantTypes",
                columns: new[] { "PlantTypeId", "Category", "LightRequirement", "Name" },
                values: new object[,]
                {
                    { 1, 1, 3, "Garden rose" },
                    { 2, 2, 3, "Basil" },
                    { 3, 3, 2, "Aloe" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Description", "GrowingLocationId", "Name", "PlantTypeId", "WateringIntervalDays" },
                values: new object[,]
                {
                    { 1, "A rose in the garden.", 3, "Red rose", 1, 3 },
                    { 2, "Basil in a pot on the balcony.", 2, "Green basil", 2, 2 },
                    { 3, "An indoor plant with fleshy leaves.", 1, "Aloe vera", 3, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_GrowingLocationId",
                table: "Plants",
                column: "GrowingLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PlantTypeId",
                table: "Plants",
                column: "PlantTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "GrowingLocations");

            migrationBuilder.DropTable(
                name: "PlantTypes");
        }
    }
}
