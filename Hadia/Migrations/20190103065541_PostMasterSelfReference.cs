using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class PostMasterSelfReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comments_Post_Masters_PostId",
                table: "Post_Comments");

            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "Post_Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Comments_MasterId",
                table: "Post_Comments",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comments_Post_Comments_MasterId",
                table: "Post_Comments",
                column: "MasterId",
                principalTable: "Post_Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comments_Post_Masters_PostId",
                table: "Post_Comments",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comments_Post_Comments_MasterId",
                table: "Post_Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Comments_Post_Masters_PostId",
                table: "Post_Comments");

            migrationBuilder.DropIndex(
                name: "IX_Post_Comments_MasterId",
                table: "Post_Comments");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "Post_Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Comments_Post_Masters_PostId",
                table: "Post_Comments",
                column: "PostId",
                principalTable: "Post_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
