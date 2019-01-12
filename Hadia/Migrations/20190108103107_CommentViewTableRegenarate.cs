using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CommentViewTableRegenarate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentView_Post_Comments_CommentId",
                table: "Post_CommentView");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentView_Mem_Masters_MemberId",
                table: "Post_CommentView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_CommentView",
                table: "Post_CommentView");

            migrationBuilder.RenameTable(
                name: "Post_CommentView",
                newName: "Post_CommentViews");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CommentView_MemberId",
                table: "Post_CommentViews",
                newName: "IX_Post_CommentViews_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CommentView_CommentId",
                table: "Post_CommentViews",
                newName: "IX_Post_CommentViews_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_CommentViews",
                table: "Post_CommentViews",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentViews_Post_Comments_CommentId",
                table: "Post_CommentViews",
                column: "CommentId",
                principalTable: "Post_Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentViews_Mem_Masters_MemberId",
                table: "Post_CommentViews",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentViews_Post_Comments_CommentId",
                table: "Post_CommentViews");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_CommentViews_Mem_Masters_MemberId",
                table: "Post_CommentViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_CommentViews",
                table: "Post_CommentViews");

            migrationBuilder.RenameTable(
                name: "Post_CommentViews",
                newName: "Post_CommentView");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CommentViews_MemberId",
                table: "Post_CommentView",
                newName: "IX_Post_CommentView_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_CommentViews_CommentId",
                table: "Post_CommentView",
                newName: "IX_Post_CommentView_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_CommentView",
                table: "Post_CommentView",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentView_Post_Comments_CommentId",
                table: "Post_CommentView",
                column: "CommentId",
                principalTable: "Post_Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_CommentView_Mem_Masters_MemberId",
                table: "Post_CommentView",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
