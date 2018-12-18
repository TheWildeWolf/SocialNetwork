using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AlterDeviceLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Sett_DeviceInfoLogs",
                maxLength: 125,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceModel",
                table: "Sett_DeviceInfoLogs",
                maxLength: 125,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Sett_DeviceInfoLogs");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "Sett_DeviceInfoLogs");
        }
    }
}
