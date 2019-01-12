using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class MakeUniqueMemberIdandPostIdInPostLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_Likes_MemberId",
                table: "Post_Likes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Post_Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_MemberId_PostId",
                table: "Post_Likes",
                columns: new[] { "MemberId", "PostId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_Likes_MemberId_PostId",
                table: "Post_Likes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Post_Comments");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Likes_MemberId",
                table: "Post_Likes",
                column: "MemberId");
        }
    }
}
