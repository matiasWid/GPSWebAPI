using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSWebAPI.Migrations
{
    public partial class SerialUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Devices_Serial",
                table: "Devices",
                column: "Serial",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Devices_Serial",
                table: "Devices");
        }
    }
}
