using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateLoginLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sett_LoginLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    LogoutTime = table.Column<DateTime>(nullable: true),
                    KeyValue = table.Column<string>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sett_LoginLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sett_LoginLogs_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sett_LoginLogs_MemberId",
                table: "Sett_LoginLogs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sett_LoginLogs");
        }
    }
}
