using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class removeUneccessaryColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "VerifiedAt",
                table: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Admin",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Admin",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedAt",
                table: "Admin",
                type: "datetime2",
                nullable: true);
        }
    }
}
