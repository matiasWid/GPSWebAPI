using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSWebAPI.Migrations
{
    public partial class ModelBrandUniqueDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Description",
                table: "VehicleModels",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBrands_Description",
                table: "VehicleBrands",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_Description",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBrands_Description",
                table: "VehicleBrands");
        }
    }
}
