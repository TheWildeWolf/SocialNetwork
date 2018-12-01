using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class NewChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_MemberContancts");

            migrationBuilder.CreateTable(
                name: "Mem_Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    ConuntryCodeId = table.Column<int>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    CDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_Contacts_Mem_CountryCodes_ConuntryCodeId",
                        column: x => x.ConuntryCodeId,
                        principalTable: "Mem_CountryCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_Contacts_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Contacts_ConuntryCodeId",
                table: "Mem_Contacts",
                column: "ConuntryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_Contacts_MemberId",
                table: "Mem_Contacts",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mem_Contacts");

            migrationBuilder.CreateTable(
                name: "Mem_MemberContancts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CDate = table.Column<DateTime>(nullable: false),
                    ConuntryCodeId = table.Column<int>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mem_MemberContancts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mem_MemberContancts_Mem_CountryCodes_ConuntryCodeId",
                        column: x => x.ConuntryCodeId,
                        principalTable: "Mem_CountryCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mem_MemberContancts_Mem_Masters_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Mem_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mem_MemberContancts_ConuntryCodeId",
                table: "Mem_MemberContancts",
                column: "ConuntryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mem_MemberContancts_MemberId",
                table: "Mem_MemberContancts",
                column: "MemberId");
        }
    }
}
