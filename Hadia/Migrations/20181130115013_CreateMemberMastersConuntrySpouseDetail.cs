using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateMemberMastersConuntrySpouseDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UniversityMaster_Mem_Masters_Mem_MasterId",
                table: "Mem_UniversityMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mem_UniversityMaster",
                table: "Mem_UniversityMaster");

            migrationBuilder.DropIndex(
                name: "IX_Mem_UniversityMaster_Mem_MasterId",
                table: "Mem_UniversityMaster");

            migrationBuilder.DropColumn(
                name: "Mem_MasterId",
                table: "Mem_UniversityMaster");

            migrationBuilder.RenameTable(
                name: "Mem_UniversityMaster",
                newName: "Mem_UniversityMasters");

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "Mem_StateMasters",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mem_UniversityMasters",
                table: "Mem_UniversityMasters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mem_CountryCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mem_UgColleges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UgCollegeName = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_UgColleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_UgColleges_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_UniversityMasters_CLogin",
                table: "Mem_UniversityMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_UniversityMasters_CountryId",
                table: "Mem_UniversityMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_UgColleges_CLogin",
                table: "Mem_UgColleges",
                column: "CLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_CountryCodes_CountryId",
                table: "Mem_UniversityMasters",
                column: "CountryId",
                principalTable: "Mem_CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_Masters_CLogin",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_UniversityMasters_Mem_CountryCodes_CountryId",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropTable(
                name: "Mem_CountryCodes");

            migrationBuilder.DropTable(
                name: "Mem_UgColleges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mem_UniversityMasters",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_UniversityMasters_CLogin",
                table: "Mem_UniversityMasters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_UniversityMasters_CountryId",
                table: "Mem_UniversityMasters");

            migrationBuilder.RenameTable(
                name: "Mem_UniversityMasters",
                newName: "Mem_UniversityMaster");

            migrationBuilder.AlterColumn<string>(
                name: "StateName",
                table: "Mem_StateMasters",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mem_MasterId",
                table: "Mem_UniversityMaster",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mem_UniversityMaster",
                table: "Mem_UniversityMaster",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_UniversityMaster_Mem_MasterId",
                table: "Mem_UniversityMaster",
                column: "Mem_MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_UniversityMaster_Mem_Masters_Mem_MasterId",
                table: "Mem_UniversityMaster",
                column: "Mem_MasterId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
