using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Voice = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    OpnedId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Category = table.Column<byte>(nullable: false),
                    DonationType = table.Column<byte>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    DDate = table.Column<DateTime>(nullable: true),
                    DLogin = table.Column<int>(nullable: true),
                    DeletedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Masters_Mem_Masters_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Masters_Post_GroupMasters_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Post_GroupMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Masters_Mem_Masters_OpnedId",
                        column: x => x.OpnedId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Masters_DeletedById",
                table: "Post_Masters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Masters_GroupId",
                table: "Post_Masters",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Masters_OpnedId",
                table: "Post_Masters",
                column: "OpnedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Masters");
        }
    }
}
