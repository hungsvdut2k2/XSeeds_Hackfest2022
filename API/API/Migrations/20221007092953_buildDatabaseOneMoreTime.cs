using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class buildDatabaseOneMoreTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Max_Bonus_Star = table.Column<int>(type: "int", nullable: false),
                    EstimateDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_Id);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    University_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.University_Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_Admin_Accounts_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Accounts",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    University_Id = table.Column<int>(type: "int", nullable: false),
                    VietnameseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatakanaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_Id);
                    table.ForeignKey(
                        name: "FK_Students_Accounts_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Accounts",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_University_University_Id",
                        column: x => x.University_Id,
                        principalTable: "University",
                        principalColumn: "University_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    University_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacher_Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Accounts_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Accounts",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_University_University_Id",
                        column: x => x.University_Id,
                        principalTable: "University",
                        principalColumn: "University_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Star_Get_From_Course = table.Column<int>(type: "int", nullable: false),
                    Start_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.Student_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Unit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Unit_Id);
                    table.ForeignKey(
                        name: "FK_Units_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Units_Teacher_Teacher_Id",
                        column: x => x.Teacher_Id,
                        principalTable: "Teacher",
                        principalColumn: "Teacher_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrammarUnits",
                columns: table => new
                {
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Unit_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarUnits", x => x.Unit_Id);
                    table.ForeignKey(
                        name: "FK_GrammarUnits_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Unit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsUnits",
                columns: table => new
                {
                    New_Unit_id = table.Column<int>(type: "int", nullable: false),
                    New_Student_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Done = table.Column<bool>(type: "bit", nullable: false),
                    Unit_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsUnits", x => new { x.New_Student_Id, x.New_Unit_id });
                    table.ForeignKey(
                        name: "FK_StudentsUnits_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Unit_Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitComments",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitComments", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_UnitComments_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Unit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoUnits",
                columns: table => new
                {
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoUnits", x => x.Unit_Id);
                    table.ForeignKey(
                        name: "FK_VideoUnits_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Unit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordUnits",
                columns: table => new
                {
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Unit_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordUnits", x => x.Unit_Id);
                    table.ForeignKey(
                        name: "FK_WordUnits_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Unit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Word_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Word_Id);
                    table.ForeignKey(
                        name: "FK_Words_WordUnits_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "WordUnits",
                        principalColumn: "Unit_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kanjis",
                columns: table => new
                {
                    Word_Id = table.Column<int>(type: "int", nullable: false),
                    Word_Kanji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kunyomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Onyomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HanViet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanjis", x => x.Word_Id);
                    table.ForeignKey(
                        name: "FK_Kanjis_Words_Word_Id",
                        column: x => x.Word_Id,
                        principalTable: "Words",
                        principalColumn: "Word_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tangos",
                columns: table => new
                {
                    Word_Id = table.Column<int>(type: "int", nullable: false),
                    Pronounce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vietnamese_mean = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tangos", x => x.Word_Id);
                    table.ForeignKey(
                        name: "FK_Tangos_Words_Word_Id",
                        column: x => x.Word_Id,
                        principalTable: "Words",
                        principalColumn: "Word_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_University_Id",
                table: "Students",
                column: "University_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_User_Id",
                table: "Students",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_Course_Id",
                table: "StudentsCourses",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsUnits_Unit_Id",
                table: "StudentsUnits",
                column: "Unit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_University_Id",
                table: "Teacher",
                column: "University_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_User_Id",
                table: "Teacher",
                column: "User_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitComments_Unit_Id",
                table: "UnitComments",
                column: "Unit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Course_Id",
                table: "Units",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Teacher_Id",
                table: "Units",
                column: "Teacher_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_Unit_Id",
                table: "Words",
                column: "Unit_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "GrammarUnits");

            migrationBuilder.DropTable(
                name: "Kanjis");

            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "StudentsUnits");

            migrationBuilder.DropTable(
                name: "Tangos");

            migrationBuilder.DropTable(
                name: "UnitComments");

            migrationBuilder.DropTable(
                name: "VideoUnits");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordUnits");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
