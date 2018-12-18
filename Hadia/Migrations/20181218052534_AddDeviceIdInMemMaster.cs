using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AddDeviceIdInMemMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_GroupMembers_MemberId",
                table: "Post_GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_MemberId",
                table: "Post_GroupMembers");


            //from down ^
            migrationBuilder.AddColumn<int>(
                name: "ActiveDeviceId",
                table: "Mem_Masters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMembers_MemberId",
                table: "Post_GroupMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_ActiveDeviceId",
                table: "Mem_Masters",
                column: "ActiveDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Sett_DeviceInfoLogs_ActiveDeviceId",
                table: "Mem_Masters",
                column: "ActiveDeviceId",
                principalTable: "Sett_DeviceInfoLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Mem_Masters_Sett_DeviceInfoLogs_ActiveDeviceId",
                table: "Mem_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_MemberId",
                table: "Post_GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_Post_GroupMembers_MemberId",
                table: "Post_GroupMembers");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_ActiveDeviceId",
                table: "Mem_Masters");

            migrationBuilder.DropColumn(
                name: "ActiveDeviceId",
                table: "Mem_Masters");
        }
    }
}
