using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatedRelationToGroupMembersToMemMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMembers_MemberId",
                table: "Post_GroupMembers",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_MemberId",
                table: "Post_GroupMembers",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_MemberId",
                table: "Post_GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_Post_GroupMembers_MemberId",
                table: "Post_GroupMembers");
        }
    }
}
