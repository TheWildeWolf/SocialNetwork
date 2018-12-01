using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateCommityMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Com_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormedOn = table.Column<DateTime>(nullable: false),
                    PresidentId = table.Column<int>(nullable: false),
                    Vice1Id = table.Column<int>(nullable: false),
                    Vice2Id = table.Column<int>(nullable: false),
                    SecreteryId = table.Column<int>(nullable: false),
                    JointSecretery1Id = table.Column<int>(nullable: false),
                    JointSecretery2Id = table.Column<int>(nullable: false),
                    TreasurerId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false),
                    MLogin = table.Column<int>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Com_Masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_JointSecretery1Id",
                        column: x => x.JointSecretery1Id,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_JointSecretery2Id",
                        column: x => x.JointSecretery2Id,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_MLogin",
                        column: x => x.MLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_SecreteryId",
                        column: x => x.SecreteryId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_TreasurerId",
                        column: x => x.TreasurerId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_Vice1Id",
                        column: x => x.Vice1Id,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Com_Masters_Mem_Masters_Vice2Id",
                        column: x => x.Vice2Id,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_CLogin",
                table: "Com_Masters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_JointSecretery1Id",
                table: "Com_Masters",
                column: "JointSecretery1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_JointSecretery2Id",
                table: "Com_Masters",
                column: "JointSecretery2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_MLogin",
                table: "Com_Masters",
                column: "MLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_PresidentId",
                table: "Com_Masters",
                column: "PresidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_SecreteryId",
                table: "Com_Masters",
                column: "SecreteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_TreasurerId",
                table: "Com_Masters",
                column: "TreasurerId");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_Vice1Id",
                table: "Com_Masters",
                column: "Vice1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Com_Masters_Vice2Id",
                table: "Com_Masters",
                column: "Vice2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Com_Masters");
        }
    }
}
