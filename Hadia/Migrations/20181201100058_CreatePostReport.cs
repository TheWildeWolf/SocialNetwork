using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    ReportedId = table.Column<int>(nullable: false),
                    ReasonId = table.Column<int>(nullable: false),
                    Narration = table.Column<string>(nullable: true),
                    ReportedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Reports_Post_Masters_PostId",
                        column: x => x.PostId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Reports_Post_ReportReasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Post_ReportReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Reports_Mem_Masters_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Reports_PostId",
                table: "Post_Reports",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Reports_ReasonId",
                table: "Post_Reports",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Reports_ReportedById",
                table: "Post_Reports",
                column: "ReportedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Reports");
        }
    }
}
