using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateNetwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mem_MyNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    NetworkMemberId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_MyNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_MyNetworks_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_MyNetworks_Mem_Masters_NetworkMemberId",
                        column: x => x.NetworkMemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_MyNetworks_MemberId",
                table: "Mem_MyNetworks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_MyNetworks_NetworkMemberId",
                table: "Mem_MyNetworks",
                column: "NetworkMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_MyNetworks");
        }
    }
}
