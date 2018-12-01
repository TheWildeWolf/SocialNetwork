using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    Like = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Likes_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Likes_Post_Masters_PostId",
                        column: x => x.PostId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_MemberId",
                table: "Post_Likes",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_PostId",
                table: "Post_Likes",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Likes");
        }
    }
}
