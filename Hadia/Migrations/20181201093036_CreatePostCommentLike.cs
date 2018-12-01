using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostCommentLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_CommentsLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Like = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_CommentsLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_CommentsLikes_Post_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Post_Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_CommentsLikes_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CommentsLikes_CommentId",
                table: "Post_CommentsLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_CommentsLikes_MemberId",
                table: "Post_CommentsLikes",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_CommentsLikes");
        }
    }
}
