using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateProjectMasterWorkCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "Mem_WorkDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mem_JobCategoryMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_JobCategoryMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_JobCategoryMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mem_ProjectWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    ProjectTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_ProjectWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_ProjectWorks_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_WorkDetails_JobCategoryId",
                table: "Mem_WorkDetails",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_JobCategoryMasters_CLogin",
                table: "Mem_JobCategoryMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_ProjectWorks_MemberId",
                table: "Mem_ProjectWorks",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_WorkDetails_Mem_JobCategoryMasters_JobCategoryId",
                table: "Mem_WorkDetails",
                column: "JobCategoryId",
                principalTable: "Mem_JobCategoryMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_WorkDetails_Mem_JobCategoryMasters_JobCategoryId",
                table: "Mem_WorkDetails");

            migrationBuilder.DropTable(
                name: "Mem_JobCategoryMasters");

            migrationBuilder.DropTable(
                name: "Mem_ProjectWorks");

            migrationBuilder.DropIndex(
                name: "IX_Mem_WorkDetails_JobCategoryId",
                table: "Mem_WorkDetails");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "Mem_WorkDetails");
        }
    }
}
