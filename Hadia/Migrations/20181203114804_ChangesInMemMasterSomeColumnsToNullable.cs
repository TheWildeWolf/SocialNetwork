using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class ChangesInMemMasterSomeColumnsToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Res_Views_Resources_ResourceId",
                table: "Res_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Mem_Masters_DLogin",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Mem_Masters_MemberId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Mem_Masters");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Res_Masters");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_MemberId",
                table: "Res_Masters",
                newName: "IX_Res_Masters_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_DLogin",
                table: "Res_Masters",
                newName: "IX_Res_Masters_DLogin");

            migrationBuilder.AlterColumn<string>(
                name: "PresentAddress",
                table: "Mem_Masters",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AdNo",
                table: "Mem_Masters",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                table: "Mem_Masters",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Res_Masters",
                table: "Res_Masters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Res_Masters_Mem_Masters_DLogin",
                table: "Res_Masters",
                column: "DLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Res_Masters_Mem_Masters_MemberId",
                table: "Res_Masters",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Res_Views_Res_Masters_ResourceId",
                table: "Res_Views",
                column: "ResourceId",
                principalTable: "Res_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Res_Masters_Mem_Masters_DLogin",
                table: "Res_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Res_Masters_Mem_Masters_MemberId",
                table: "Res_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Res_Views_Res_Masters_ResourceId",
                table: "Res_Views");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Res_Masters",
                table: "Res_Masters");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Mem_Masters");

            migrationBuilder.RenameTable(
                name: "Res_Masters",
                newName: "Resources");

            migrationBuilder.RenameIndex(
                name: "IX_Res_Masters_MemberId",
                table: "Resources",
                newName: "IX_Resources_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Res_Masters_DLogin",
                table: "Resources",
                newName: "IX_Resources_DLogin");

            migrationBuilder.AlterColumn<string>(
                name: "PresentAddress",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdNo",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "Mem_Masters",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Res_Views_Resources_ResourceId",
                table: "Res_Views",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Mem_Masters_DLogin",
                table: "Resources",
                column: "DLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Mem_Masters_MemberId",
                table: "Resources",
                column: "MemberId",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
