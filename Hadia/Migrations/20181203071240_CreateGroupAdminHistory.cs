using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateGroupAdminHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sett_GroupAdminHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sett_GroupAdminHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sett_GroupAdminHistories_Post_GroupMasters_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Post_GroupMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sett_GroupAdminHistories_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sett_GroupAdminHistories_GroupId",
                table: "Sett_GroupAdminHistories",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sett_GroupAdminHistories_MemberId",
                table: "Sett_GroupAdminHistories",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sett_GroupAdminHistories");
        }
    }
}
