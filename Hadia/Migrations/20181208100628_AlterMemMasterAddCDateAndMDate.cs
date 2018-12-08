using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AlterMemMasterAddCDateAndMDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CDate",
                table: "Mem_Masters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MDate",
                table: "Mem_Masters",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DegreeName",
                table: "Mem_EducationalQualifications",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CDate",
                table: "Mem_Masters");

            migrationBuilder.DropColumn(
                name: "MDate",
                table: "Mem_Masters");

            migrationBuilder.AlterColumn<string>(
                name: "DegreeName",
                table: "Mem_EducationalQualifications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
