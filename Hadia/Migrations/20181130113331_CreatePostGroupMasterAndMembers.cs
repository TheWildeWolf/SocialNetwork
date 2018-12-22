using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreatePostGroupMasterAndMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_GroupMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    OpenOrClosed = table.Column<byte>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GroupImage = table.Column<string>(nullable: true),
                    FormedOn = table.Column<DateTime>(nullable: false),
                    PassoutYear = table.Column<string>(maxLength: 125, nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    CLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_GroupMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_GroupMaster_Mem_Masters_CLogin",
                        column: x => x.CLogin,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post_GroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    IsGroupAdmin = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    MDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_GroupMember_Mem_Masters_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_GroupMember_Post_GroupMaster_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Post_GroupMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_GroupMember_Mem_Masters_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMaster_CLogin",
                table: "Post_GroupMaster",
                column: "CLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMember_AddedBy",
                table: "Post_GroupMember",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMember_GroupId",
                table: "Post_GroupMember",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_GroupMember_ModifiedBy",
                table: "Post_GroupMember",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_GroupMember");

            migrationBuilder.DropTable(
                name: "Post_GroupMaster");
        }
    }
}
