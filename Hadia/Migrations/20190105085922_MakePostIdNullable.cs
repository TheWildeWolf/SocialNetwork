using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class MakePostIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Post_Comments",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Post_Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
