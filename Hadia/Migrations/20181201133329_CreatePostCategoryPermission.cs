using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostCategoryPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_Categorypermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostCategoryId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    IsPermitted = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true),
                    ModifiedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Categorypermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Categorypermissions_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Categorypermissions_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Categorypermissions_Mem_Masters_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Categorypermissions_Post_Categories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "Post_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categorypermissions_CLogin",
                table: "Post_Categorypermissions",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categorypermissions_MemberId",
                table: "Post_Categorypermissions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categorypermissions_ModifiedById",
                table: "Post_Categorypermissions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categorypermissions_PostCategoryId",
                table: "Post_Categorypermissions",
                column: "PostCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Categorypermissions");
        }
    }
}
