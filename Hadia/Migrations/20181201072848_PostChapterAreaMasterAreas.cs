using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class PostChapterAreaMasterAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_ChapterLeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_ChapterLeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_ChapterLeaders_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_ChapterLeaders_Post_GroupMasters_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Post_GroupMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_ChapterLeaders_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post_InterestedAreaMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InterestName = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_InterestedAreaMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_InterestedAreaMasters_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_InterestedAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    InterestedAreaId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_InterestedAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_InterestedAreas_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_InterestedAreas_Post_GroupMasters_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Post_GroupMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_InterestedAreas_Post_InterestedAreaMasters_InterestedAreaId",
                        column: x => x.InterestedAreaId,
                        principalTable: "Post_InterestedAreaMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_ChapterLeaders_CLogin",
                table: "Post_ChapterLeaders",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ChapterLeaders_GroupId",
                table: "Post_ChapterLeaders",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ChapterLeaders_MemberId",
                table: "Post_ChapterLeaders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_InterestedAreaMasters_CLogin",
                table: "Post_InterestedAreaMasters",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_InterestedAreas_CLogin",
                table: "Post_InterestedAreas",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_InterestedAreas_GroupId",
                table: "Post_InterestedAreas",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_InterestedAreas_InterestedAreaId",
                table: "Post_InterestedAreas",
                column: "InterestedAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_ChapterLeaders");

            migrationBuilder.DropTable(
                name: "Post_InterestedAreas");

            migrationBuilder.DropTable(
                name: "Post_InterestedAreaMasters");
        }
    }
}
