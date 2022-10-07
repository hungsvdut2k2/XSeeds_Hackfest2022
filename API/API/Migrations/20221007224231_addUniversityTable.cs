using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addUniversityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_University_University_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_University_University_Id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_University",
                table: "University");

            migrationBuilder.RenameTable(
                name: "University",
                newName: "Universities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "University_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_University_Id",
                table: "Students",
                column: "University_Id",
                principalTable: "Universities",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Universities_University_Id",
                table: "Teachers",
                column: "University_Id",
                principalTable: "Universities",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_University_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Universities_University_Id",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "University");

            migrationBuilder.AddPrimaryKey(
                name: "PK_University",
                table: "University",
                column: "University_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_University_University_Id",
                table: "Students",
                column: "University_Id",
                principalTable: "University",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_University_University_Id",
                table: "Teachers",
                column: "University_Id",
                principalTable: "University",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
