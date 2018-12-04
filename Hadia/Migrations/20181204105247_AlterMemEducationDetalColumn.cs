using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AlterMemEducationDetalColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhdTopic",
                table: "Mem_EducationDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhd",
                table: "Mem_EducationalQualifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhdTopic",
                table: "Mem_EducationDetails");

            migrationBuilder.DropColumn(
                name: "IsPhd",
                table: "Mem_EducationalQualifications");
        }
    }
}
