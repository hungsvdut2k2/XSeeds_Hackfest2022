using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addLearningPathTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Learning_Path_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LearningPath",
                columns: table => new
                {
                    Path_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningPath", x => x.Path_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Learning_Path_Id",
                table: "Courses",
                column: "Learning_Path_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_LearningPath_Learning_Path_Id",
                table: "Courses",
                column: "Learning_Path_Id",
                principalTable: "LearningPath",
                principalColumn: "Path_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_LearningPath_Learning_Path_Id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "LearningPath");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Learning_Path_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Learning_Path_Id",
                table: "Courses");
        }
    }
}
