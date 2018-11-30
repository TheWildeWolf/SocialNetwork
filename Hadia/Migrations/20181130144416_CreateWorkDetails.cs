using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateWorkDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mem_WorkDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(maxLength: 100, nullable: true),
                    DateForm = table.Column<DateTime>(nullable: false),
                    DateUpto = table.Column<DateTime>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_WorkDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_WorkDetails_Mem_CountryCodes_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Mem_CountryCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_WorkDetails_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_WorkDetails_CountryId",
                table: "Mem_WorkDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_WorkDetails_MemberId",
                table: "Mem_WorkDetails",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_WorkDetails");
        }
    }
}
