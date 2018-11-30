using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateMemberMasterAndOtherMasters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mem_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    AdNo = table.Column<string>(nullable: false),
                    PresentAddress = table.Column<string>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    UgCollageId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    SpouseName = table.Column<string>(nullable: true),
                    SpouseAge = table.Column<DateTime>(nullable: true),
                    SpouseEducationId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    IsBatchAdmin = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    IsVarified = table.Column<bool>(nullable: false),
                    VarifiedBy = table.Column<int>(nullable: false),
                    VarifiedDate = table.Column<DateTime>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mem_EducationalQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DegreeName = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_EducationalQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_EducationalQualifications_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mem_SpouseEducationMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QualificationName = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_SpouseEducationMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_SpouseEducationMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mem_StateMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_StateMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_StateMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mem_UniversityMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniversityName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    Mem_MasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_UniversityMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_UniversityMaster_Mem_Masters_Mem_MasterId",
                        column: x => x.Mem_MasterId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mem_DistrictMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictName = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_DistrictMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_DistrictMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mem_DistrictMasters_Mem_StateMasters_StateId",
                        column: x => x.StateId,
                        principalTable: "Mem_StateMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_DistrictMasters_CLogin",
                table: "Mem_DistrictMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_DistrictMasters_StateId",
                table: "Mem_DistrictMasters",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_EducationalQualifications_CLogin",
                table: "Mem_EducationalQualifications",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_SpouseEducationMasters_CLogin",
                table: "Mem_SpouseEducationMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_StateMasters_CLogin",
                table: "Mem_StateMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_UniversityMaster_Mem_MasterId",
                table: "Mem_UniversityMaster",
                column: "Mem_MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_DistrictMasters");

            migrationBuilder.DropTable(
                name: "Mem_EducationalQualifications");

            migrationBuilder.DropTable(
                name: "Mem_SpouseEducationMasters");

            migrationBuilder.DropTable(
                name: "Mem_UniversityMaster");

            migrationBuilder.DropTable(
                name: "Mem_StateMasters");

            migrationBuilder.DropTable(
                name: "Mem_Masters");
        }
    }
}
