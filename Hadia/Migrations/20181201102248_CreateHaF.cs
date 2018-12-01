using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateHaF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HAFs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true),
                    HadiyaYearId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HAFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HAFs_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HAFs_HadiyaYearMasters_HadiyaYearId",
                        column: x => x.HadiyaYearId,
                        principalTable: "HadiyaYearMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HAFs_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HAFs_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HAFs_CLogin",
                table: "HAFs",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_HAFs_HadiyaYearId",
                table: "HAFs",
                column: "HadiyaYearId");

            migrationBuilder.CreateIndex(
                name: "IX_HAFs_MLogin",
                table: "HAFs",
                column: "MLogin");

            migrationBuilder.CreateIndex(
                name: "IX_HAFs_MemberId",
                table: "HAFs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HAFs");
        }
    }
}
