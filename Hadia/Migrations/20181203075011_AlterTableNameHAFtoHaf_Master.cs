using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AlterTableNameHAFtoHaf_Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HAFs");

            migrationBuilder.DropTable(
                name: "HadiyaYearMasters");

            migrationBuilder.CreateTable(
                name: "Haf_YearMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearName = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateUpTo = table.Column<DateTime>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haf_YearMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haf_YearMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Haf_YearMasters_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Haf_Masters",
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
                    table.PrimaryKey("PK_Haf_Masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Haf_Masters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Haf_Masters_Haf_YearMasters_HadiyaYearId",
                        column: x => x.HadiyaYearId,
                        principalTable: "Haf_YearMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Haf_Masters_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Haf_Masters_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Haf_Masters_CLogin",
                table: "Haf_Masters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Haf_Masters_HadiyaYearId",
                table: "Haf_Masters",
                column: "HadiyaYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Haf_Masters_MLogin",
                table: "Haf_Masters",
                column: "MLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Haf_Masters_MemberId",
                table: "Haf_Masters",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Haf_YearMasters_CLogin",
                table: "Haf_YearMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Haf_YearMasters_MLogin",
                table: "Haf_YearMasters",
                column: "MLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haf_Masters");

            migrationBuilder.DropTable(
                name: "Haf_YearMasters");

            migrationBuilder.CreateTable(
                name: "HadiyaYearMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateUpTo = table.Column<DateTime>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true),
                    MLogin = table.Column<int>(nullable: true),
                    YearName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HadiyaYearMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HadiyaYearMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HadiyaYearMasters_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HAFs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    HadiyaYearId = table.Column<int>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true),
                    MLogin = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    YearId = table.Column<int>(nullable: false)
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
                name: "IX_HadiyaYearMasters_CLogin",
                table: "HadiyaYearMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_HadiyaYearMasters_MLogin",
                table: "HadiyaYearMasters",
                column: "MLogin");

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
    }
}
