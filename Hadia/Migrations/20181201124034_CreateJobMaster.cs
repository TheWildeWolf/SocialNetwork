using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateJobMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostedId = table.Column<int>(nullable: false),
                    Narration = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    DDate = table.Column<DateTime>(nullable: true),
                    MDate = table.Column<DateTime>(nullable: true),
                    DLogin = table.Column<int>(nullable: true),
                    AppointedMemId = table.Column<int>(nullable: true),
                    AppoinmentDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Masters_Mem_Masters_AppointedMemId",
                        column: x => x.AppointedMemId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_Masters_Mem_Masters_DLogin",
                        column: x => x.DLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_Masters_Mem_Masters_PostedId",
                        column: x => x.PostedId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_Masters_AppointedMemId",
                table: "Job_Masters",
                column: "AppointedMemId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Masters_DLogin",
                table: "Job_Masters",
                column: "DLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Masters_PostedId",
                table: "Job_Masters",
                column: "PostedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job_Masters");
        }
    }
}
