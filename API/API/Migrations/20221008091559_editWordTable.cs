using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class editWordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordUnits_WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Unit_Id",
                table: "Words",
                column: "Unit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordUnits_Unit_Id",
                table: "Words",
                column: "Unit_Id",
                principalTable: "WordUnits",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordUnits_Unit_Id",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_Unit_Id",
                table: "Words");

            migrationBuilder.AddColumn<int>(
                name: "WordUnitUnit_Id",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordUnitUnit_Id",
                table: "Words",
                column: "WordUnitUnit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordUnits_WordUnitUnit_Id",
                table: "Words",
                column: "WordUnitUnit_Id",
                principalTable: "WordUnits",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
