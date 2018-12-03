using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hadia.Migrations
{
    public partial class AddColumnPhoneAndCountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Mem_Masters",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Mem_Masters",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Mem_Masters",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Mem_Masters");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Mem_Masters");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Mem_Masters",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}
