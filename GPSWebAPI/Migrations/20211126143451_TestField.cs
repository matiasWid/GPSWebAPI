using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPSWebAPI.Migrations
{
    public partial class TestField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "prueba",
                table: "Devices",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prueba",
                table: "Devices");
        }
    }
}
