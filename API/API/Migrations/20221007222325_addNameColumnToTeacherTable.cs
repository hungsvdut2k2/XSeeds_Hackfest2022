using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addNameColumnToTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Accounts_User_Id",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_University_University_Id",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Teacher_Teacher_Id",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordUnits_Unit_Id",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_Unit_Id",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_User_Id",
                table: "Teachers",
                newName: "IX_Teachers_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_University_Id",
                table: "Teachers",
                newName: "IX_Teachers_University_Id");

            migrationBuilder.AddColumn<int>(
                name: "Student_Id",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WordUnitUnit_Id",
                table: "Words",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Thread_Name",
                table: "ForumThreads",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Teacher_Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Teacher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordUnitUnit_Id",
                table: "Words",
                column: "WordUnitUnit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Accounts_User_Id",
                table: "Teachers",
                column: "User_Id",
                principalTable: "Accounts",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_University_University_Id",
                table: "Teachers",
                column: "University_Id",
                principalTable: "University",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Teachers_Teacher_Id",
                table: "Units",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordUnits_WordUnitUnit_Id",
                table: "Words",
                column: "WordUnitUnit_Id",
                principalTable: "WordUnits",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Accounts_User_Id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_University_University_Id",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Teachers_Teacher_Id",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordUnits_WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Student_Id",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "WordUnitUnit_Id",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "Teacher_Name",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_User_Id",
                table: "Teacher",
                newName: "IX_Teacher_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_University_Id",
                table: "Teacher",
                newName: "IX_Teacher_University_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Thread_Name",
                table: "ForumThreads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Teacher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Unit_Id",
                table: "Words",
                column: "Unit_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Accounts_User_Id",
                table: "Teacher",
                column: "User_Id",
                principalTable: "Accounts",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_University_University_Id",
                table: "Teacher",
                column: "University_Id",
                principalTable: "University",
                principalColumn: "University_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Teacher_Teacher_Id",
                table: "Units",
                column: "Teacher_Id",
                principalTable: "Teacher",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordUnits_Unit_Id",
                table: "Words",
                column: "Unit_Id",
                principalTable: "WordUnits",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
