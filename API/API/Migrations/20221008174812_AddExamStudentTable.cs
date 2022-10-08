using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddExamStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamStudents",
                columns: table => new
                {
                    ExemStudent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Examp_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamStudents", x => x.ExemStudent_Id);
                    table.ForeignKey(
                        name: "FK_ExamStudents_Exams_Examp_Id",
                        column: x => x.Examp_Id,
                        principalTable: "Exams",
                        principalColumn: "Exam_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudents_Examp_Id",
                table: "ExamStudents",
                column: "Examp_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamStudents");
        }
    }
}
