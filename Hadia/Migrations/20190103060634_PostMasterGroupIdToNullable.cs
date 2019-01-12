using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class PostMasterGroupIdToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Post_Masters",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Post_Masters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
