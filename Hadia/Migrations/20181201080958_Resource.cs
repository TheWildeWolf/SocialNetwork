using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class Resource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    AvailableFrom = table.Column<DateTime>(nullable: false),
                    AvailableUpto = table.Column<DateTime>(nullable: false),
                    Narration = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    DDate = table.Column<DateTime>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true),
                    DLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Mem_Masters_DLogin",
                        column: x => x.DLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_DLogin",
                table: "Resources",
                column: "DLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_MemberId",
                table: "Resources",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
