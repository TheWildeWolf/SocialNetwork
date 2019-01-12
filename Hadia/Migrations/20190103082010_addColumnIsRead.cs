using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class addColumnIsRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Post_Views",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Post_Views");
        }
    }
}
