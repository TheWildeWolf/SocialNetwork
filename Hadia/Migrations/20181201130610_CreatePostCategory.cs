using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Post_Masters");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Post_Masters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Post_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Categories_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Categories_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Masters_CategoryId",
                table: "Post_Masters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categories_CLogin",
                table: "Post_Categories",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Categories_MLogin",
                table: "Post_Categories",
                column: "MLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Masters_Post_Categories_CategoryId",
                table: "Post_Masters",
                column: "CategoryId",
                principalTable: "Post_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Masters_Post_Categories_CategoryId",
                table: "Post_Masters");

            migrationBuilder.DropTable(
                name: "Post_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Post_Masters_CategoryId",
                table: "Post_Masters");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Post_Masters");

            migrationBuilder.AddColumn<byte>(
                name: "Category",
                table: "Post_Masters",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
