using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostReportReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_ReportReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Reason = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_ReportReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_ReportReasons_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_ReportReasons_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_ReportReasons_CLogin",
                table: "Post_ReportReasons",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ReportReasons_MLogin",
                table: "Post_ReportReasons",
                column: "MLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_ReportReasons");
        }
    }
}
