using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CountryCodeAddLatColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "Mem_CountryCodes",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Long",
                table: "Mem_CountryCodes",
                type: "decimal(18, 2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Mem_CountryCodes");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Mem_CountryCodes");
        }
    }
}
