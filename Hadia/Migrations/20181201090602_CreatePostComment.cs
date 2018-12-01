using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    RemovedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Comments_Post_Masters_PostId",
                        column: x => x.PostId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Comments_Mem_Masters_RemovedId",
                        column: x => x.RemovedId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Comments_PostId",
                table: "Post_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Comments_RemovedId",
                table: "Post_Comments",
                column: "RemovedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Comments");
        }
    }
}
