using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class CreateMemPhotoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMaster_Mem_Masters_CLogin",
                table: "Post_GroupMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMember_Mem_Masters_AddedBy",
                table: "Post_GroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMember_Post_GroupMaster_GroupId",
                table: "Post_GroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMember_Mem_Masters_ModifiedBy",
                table: "Post_GroupMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_GroupMember",
                table: "Post_GroupMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_GroupMaster",
                table: "Post_GroupMaster");

            migrationBuilder.RenameTable(
                name: "Post_GroupMember",
                newName: "Post_GroupMembers");

            migrationBuilder.RenameTable(
                name: "Post_GroupMaster",
                newName: "Post_GroupMasters");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMember_ModifiedBy",
                table: "Post_GroupMembers",
                newName: "IX_Post_GroupMembers_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMember_GroupId",
                table: "Post_GroupMembers",
                newName: "IX_Post_GroupMembers_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMember_AddedBy",
                table: "Post_GroupMembers",
                newName: "IX_Post_GroupMembers_AddedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMaster_CLogin",
                table: "Post_GroupMasters",
                newName: "IX_Post_GroupMasters_CLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_GroupMembers",
                table: "Post_GroupMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_GroupMasters",
                table: "Post_GroupMasters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Mem_Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_Photos_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Photos_MemberId",
                table: "Mem_Photos",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_AddedBy",
                table: "Post_GroupMembers",
                column: "AddedBy",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMembers_Post_GroupMasters_GroupId",
                table: "Post_GroupMembers",
                column: "GroupId",
                principalTable: "Post_GroupMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_ModifiedBy",
                table: "Post_GroupMembers",
                column: "ModifiedBy",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMasters_Mem_Masters_CLogin",
                table: "Post_GroupMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_AddedBy",
                table: "Post_GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Post_GroupMasters_GroupId",
                table: "Post_GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_GroupMembers_Mem_Masters_ModifiedBy",
                table: "Post_GroupMembers");

            migrationBuilder.DropTable(
                name: "Mem_Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_GroupMembers",
                table: "Post_GroupMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_GroupMasters",
                table: "Post_GroupMasters");

            migrationBuilder.RenameTable(
                name: "Post_GroupMembers",
                newName: "Post_GroupMember");

            migrationBuilder.RenameTable(
                name: "Post_GroupMasters",
                newName: "Post_GroupMaster");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMembers_ModifiedBy",
                table: "Post_GroupMember",
                newName: "IX_Post_GroupMember_ModifiedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMembers_GroupId",
                table: "Post_GroupMember",
                newName: "IX_Post_GroupMember_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMembers_AddedBy",
                table: "Post_GroupMember",
                newName: "IX_Post_GroupMember_AddedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Post_GroupMasters_CLogin",
                table: "Post_GroupMaster",
                newName: "IX_Post_GroupMaster_CLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_GroupMember",
                table: "Post_GroupMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_GroupMaster",
                table: "Post_GroupMaster",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMaster_Mem_Masters_CLogin",
                table: "Post_GroupMaster",
                column: "CLogin",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMember_Mem_Masters_AddedBy",
                table: "Post_GroupMember",
                column: "AddedBy",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMember_Post_GroupMaster_GroupId",
                table: "Post_GroupMember",
                column: "GroupId",
                principalTable: "Post_GroupMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_GroupMember_Mem_Masters_ModifiedBy",
                table: "Post_GroupMember",
                column: "ModifiedBy",
                principalTable: "Mem_Masters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
