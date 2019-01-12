using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AddColumnSyncTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SyncTime",
                table: "Mem_Masters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SyncTime",
                table: "Mem_Masters");
        }
    }
}
