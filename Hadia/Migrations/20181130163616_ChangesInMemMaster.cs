using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class ChangesInMemMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Mem_Masters");

            migrationBuilder.RenameColumn(
                name: "IsBatchAdmin",
                table: "Mem_Masters",
                newName: "IsGroupAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "VarifiedBy",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UgCollageId",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SpouseEducationId",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_DistrictId",
                table: "Mem_Masters",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_GroupId",
                table: "Mem_Masters",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_SpouseEducationId",
                table: "Mem_Masters",
                column: "SpouseEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_UgCollageId",
                table: "Mem_Masters",
                column: "UgCollageId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Masters_VarifiedBy",
                table: "Mem_Masters",
                column: "VarifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Mem_DistrictMasters_DistrictId",
                table: "Mem_Masters",
                column: "DistrictId",
                principalTable: "Mem_DistrictMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Post_GroupMasters_GroupId",
                table: "Mem_Masters",
                column: "GroupId",
                principalTable: "Post_GroupMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Mem_SpouseEducationMasters_SpouseEducationId",
                table: "Mem_Masters",
                column: "SpouseEducationId",
                principalTable: "Mem_SpouseEducationMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Mem_UgColleges_UgCollageId",
                table: "Mem_Masters",
                column: "UgCollageId",
                principalTable: "Mem_UgColleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mem_Masters_Mem_Masters_VarifiedBy",
                table: "Mem_Masters",
                column: "VarifiedBy",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mem_Masters_Mem_DistrictMasters_DistrictId",
                table: "Mem_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_Masters_Post_GroupMasters_GroupId",
                table: "Mem_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_Masters_Mem_SpouseEducationMasters_SpouseEducationId",
                table: "Mem_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_Masters_Mem_UgColleges_UgCollageId",
                table: "Mem_Masters");

            migrationBuilder.DropForeignKey(
                name: "FK_Mem_Masters_Mem_Masters_VarifiedBy",
                table: "Mem_Masters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_DistrictId",
                table: "Mem_Masters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_GroupId",
                table: "Mem_Masters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_SpouseEducationId",
                table: "Mem_Masters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_UgCollageId",
                table: "Mem_Masters");

            migrationBuilder.DropIndex(
                name: "IX_Mem_Masters_VarifiedBy",
                table: "Mem_Masters");

            migrationBuilder.RenameColumn(
                name: "IsGroupAdmin",
                table: "Mem_Masters",
                newName: "IsBatchAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "VarifiedBy",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UgCollageId",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpouseEducationId",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Mem_Masters",
                nullable: false,
                defaultValue: 0);
        }
    }
}
