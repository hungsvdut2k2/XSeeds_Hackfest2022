using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addColumnTango : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Student_Id",
                table: "Words");

            migrationBuilder.AddColumn<string>(
                name: "Word_Tango",
                table: "Tangos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Word_Tango",
                table: "Tangos");

            migrationBuilder.AddColumn<int>(
                name: "Student_Id",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
