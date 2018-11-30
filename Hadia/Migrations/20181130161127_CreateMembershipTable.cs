using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateMembershipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mem_Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_Memberships_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_Memberships_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_Memberships_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Memberships_CLogin",
                table: "Mem_Memberships",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Memberships_MLogin",
                table: "Mem_Memberships",
                column: "MLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Memberships_MemberId",
                table: "Mem_Memberships",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_Memberships");
        }
    }
}
