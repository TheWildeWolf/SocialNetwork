using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateAdminPrivillageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mem_AdminPrivilage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    MemberPosting = table.Column<bool>(nullable: false),
                    AdminAccess = table.Column<bool>(nullable: false),
                    HafAccess = table.Column<bool>(nullable: false),
                    AluminiDataAccess = table.Column<bool>(nullable: false),
                    BlockAccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_AdminPrivilage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_AdminPrivilage_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_AdminPrivilage_MemberId",
                table: "Mem_AdminPrivilage",
                column: "MemberId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_AdminPrivilage");
        }
    }
}
