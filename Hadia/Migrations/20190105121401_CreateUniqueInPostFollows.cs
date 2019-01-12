using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateUniqueInPostFollows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_Followers_MemberId",
                table: "Post_Followers");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Followers_MemberId_PostId",
                table: "Post_Followers",
                columns: new[] { "MemberId", "PostId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_Followers_MemberId_PostId",
                table: "Post_Followers");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Followers_MemberId",
                table: "Post_Followers",
                column: "MemberId");
        }
    }
}
