using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class removeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_LearningPath_Learning_Path_Id",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Learning_Path_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Learning_Path_Id",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "LearningPathPath_Id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LearningPathPath_Id",
                table: "Courses",
                column: "LearningPathPath_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_LearningPath_LearningPathPath_Id",
                table: "Courses",
                column: "LearningPathPath_Id",
                principalTable: "LearningPath",
                principalColumn: "Path_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_LearningPath_LearningPathPath_Id",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LearningPathPath_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LearningPathPath_Id",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Learning_Path_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
