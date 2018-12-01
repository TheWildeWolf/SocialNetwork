using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateSettAdminActivityLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sett_AdminActivityLogses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ActivityType = table.Column<string>(maxLength: 125, nullable: true),
                    Page = table.Column<string>(maxLength: 125, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sett_AdminActivityLogses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sett_AdminActivityLogses_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sett_PrivacySettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Chapter = table.Column<bool>(nullable: false),
                    Batch = table.Column<bool>(nullable: false),
                    MyNetwork = table.Column<bool>(nullable: false),
                    All = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sett_PrivacySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sett_PrivacySettings_Sett_PrivacyInfoCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Sett_PrivacyInfoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sett_PrivacySettings_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sett_AdminActivityLogses_MemberId",
                table: "Sett_AdminActivityLogses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Sett_PrivacySettings_CategoryId",
                table: "Sett_PrivacySettings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sett_PrivacySettings_MemberId",
                table: "Sett_PrivacySettings",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sett_AdminActivityLogses");

            migrationBuilder.DropTable(
                name: "Sett_PrivacySettings");
        }
    }
}
