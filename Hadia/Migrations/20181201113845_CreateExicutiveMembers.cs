using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateExicutiveMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Mem_Masters",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Com_ExecutiveMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommitteeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Com_ExecutiveMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Com_ExecutiveMembers_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_ExecutiveMembers_Com_Masters_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Com_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_ExecutiveMembers_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_ExecutiveMembers_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Com_ExecutiveMembers_CLogin",
                table: "Com_ExecutiveMembers",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Com_ExecutiveMembers_CommitteeId",
                table: "Com_ExecutiveMembers",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Com_ExecutiveMembers_MLogin",
                table: "Com_ExecutiveMembers",
                column: "MLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Com_ExecutiveMembers_MemberId",
                table: "Com_ExecutiveMembers",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Com_ExecutiveMembers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
