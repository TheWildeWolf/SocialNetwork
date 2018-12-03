using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateDeviceInfoLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sett_DeviceInfoLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    DeviceKey = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sett_DeviceInfoLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sett_DeviceInfoLogs_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sett_DeviceInfoLogs_MemberId",
                table: "Sett_DeviceInfoLogs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sett_DeviceInfoLogs");
        }
    }
}
