using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostTablesFollowDonationCommentEditEventReg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_CommentEdits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_CommentEdits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_CommentEdits_Post_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Post_Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post_Donations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    AmountOrQuantity = table.Column<decimal>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Donations_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Donations_Post_Masters_PostId",
                        column: x => x.PostId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post_EventRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_EventRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_EventRegistrations_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_EventRegistrations_Post_Masters_PostId",
                        column: x => x.PostId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post_Followers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Follow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Followers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Followers_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Followers_Post_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Post_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_CommentEdits_CommentId",
                table: "Post_CommentEdits",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Donations_MemberId",
                table: "Post_Donations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Donations_PostId",
                table: "Post_Donations",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_EventRegistrations_MemberId",
                table: "Post_EventRegistrations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_EventRegistrations_PostId",
                table: "Post_EventRegistrations",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Followers_MemberId",
                table: "Post_Followers",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_CommentEdits");

            migrationBuilder.DropTable(
                name: "Post_Donations");

            migrationBuilder.DropTable(
                name: "Post_EventRegistrations");

            migrationBuilder.DropTable(
                name: "Post_Followers");
        }
    }
}
