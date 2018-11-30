using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateTableMemEducationDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_AdminPrivilage_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mem_AdminPrivilage",
                table: "Mem_AdminPrivilage");

            migrationBuilder.RenameTable(
                name: "Mem_AdminPrivilage",
                newName: "Mem_AdminPrivilages");

            migrationBuilder.RenameIndex(
                name: "IX_Mem_AdminPrivilage_MemberId",
                table: "Mem_AdminPrivilages",
                newName: "IX_Mem_AdminPrivilages_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mem_AdminPrivilages",
                table: "Mem_AdminPrivilages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mem_EducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    EducationQualificationId = table.Column<int>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false),
                    PassoutYear = table.Column<DateTime>(type: "date", nullable: false),
                    Specialization = table.Column<string>(maxLength: 125, nullable: true),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_EducationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_EducationDetails_Mem_EducationalQualifications_EducationQualificationId",
                        column: x => x.EducationQualificationId,
                        principalTable: "Mem_EducationalQualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_EducationDetails_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_EducationDetails_Mem_UniversityMasters_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Mem_UniversityMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_EducationDetails_EducationQualificationId",
                table: "Mem_EducationDetails",
                column: "EducationQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_EducationDetails_MemberId",
                table: "Mem_EducationDetails",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_EducationDetails_UniversityId",
                table: "Mem_EducationDetails",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_AdminPrivilages_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilages");

            migrationBuilder.DropTable(
                name: "Mem_EducationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mem_AdminPrivilages",
                table: "Mem_AdminPrivilages");

            migrationBuilder.RenameTable(
                name: "Mem_AdminPrivilages",
                newName: "Mem_AdminPrivilage");

            migrationBuilder.RenameIndex(
                name: "IX_Mem_AdminPrivilages_MemberId",
                table: "Mem_AdminPrivilage",
                newName: "IX_Mem_AdminPrivilage_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mem_AdminPrivilage",
                table: "Mem_AdminPrivilage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_AdminPrivilage_Mem_Masters_MemberId",
                table: "Mem_AdminPrivilage",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
