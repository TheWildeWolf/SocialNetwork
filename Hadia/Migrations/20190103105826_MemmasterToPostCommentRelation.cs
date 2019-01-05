using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class MemmasterToPostCommentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_Comments_MemberId",
                table: "Post_Comments",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comments_Mem_Masters_MemberId",
                table: "Post_Comments",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comments_Mem_Masters_MemberId",
                table: "Post_Comments");

            migrationBuilder.DropIndex(
                name: "IX_Post_Comments_MemberId",
                table: "Post_Comments");
        }
    }
}
