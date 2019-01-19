using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AlterTableReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sett_Reset_Mem_Masters_MemberId",
                table: "Sett_Reset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sett_Reset",
                table: "Sett_Reset");

            migrationBuilder.RenameTable(
                name: "Sett_Reset",
                newName: "Sett_Resets");

            migrationBuilder.RenameIndex(
                name: "IX_Sett_Reset_MemberId",
                table: "Sett_Resets",
                newName: "IX_Sett_Resets_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sett_Resets",
                table: "Sett_Resets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sett_Resets_Mem_Masters_MemberId",
                table: "Sett_Resets",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sett_Resets_Mem_Masters_MemberId",
                table: "Sett_Resets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sett_Resets",
                table: "Sett_Resets");

            migrationBuilder.RenameTable(
                name: "Sett_Resets",
                newName: "Sett_Reset");

            migrationBuilder.RenameIndex(
                name: "IX_Sett_Resets_MemberId",
                table: "Sett_Reset",
                newName: "IX_Sett_Reset_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sett_Reset",
                table: "Sett_Reset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sett_Reset_Mem_Masters_MemberId",
                table: "Sett_Reset",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
