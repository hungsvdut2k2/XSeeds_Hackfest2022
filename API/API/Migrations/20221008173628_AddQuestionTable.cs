using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddQuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Units_Unit_Id",
                table: "Exam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "AnswerA",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "AnswerB",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "AnswerC",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "AnswerD",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Exam_Name",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Sudent_Id",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_Exam_Unit_Id",
                table: "Exams",
                newName: "IX_Exams_Unit_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Exam_Id");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Question_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Examp_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Question_Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_Examp_Id",
                        column: x => x.Examp_Id,
                        principalTable: "Exams",
                        principalColumn: "Exam_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Examp_Id",
                table: "Questions",
                column: "Examp_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Units_Unit_Id",
                table: "Exams",
                column: "Unit_Id",
                principalTable: "Units",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Units_Unit_Id",
                table: "Exams");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_Unit_Id",
                table: "Exam",
                newName: "IX_Exam_Unit_Id");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerA",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerB",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerC",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerD",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Exam_Name",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Exam",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Sudent_Id",
                table: "Exam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Exam_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Units_Unit_Id",
                table: "Exam",
                column: "Unit_Id",
                principalTable: "Units",
                principalColumn: "Unit_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
