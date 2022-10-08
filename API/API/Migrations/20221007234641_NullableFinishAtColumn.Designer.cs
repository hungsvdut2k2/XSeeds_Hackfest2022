﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221007234641_NullableFinishAtColumn")]
    partial class NullableFinishAtColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("User_Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Admin", b =>
                {
                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Course", b =>
                {
                    b.Property<int>("Course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_Id"), 1L, 1);

                    b.Property<string>("Course_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstimateDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("Max_Bonus_Star")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Course_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Forum", b =>
                {
                    b.Property<int>("Forum_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Forum_Id"), 1L, 1);

                    b.Property<string>("Forum_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Forum_Id");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("API.Models.ModelDBs.ForumThread", b =>
                {
                    b.Property<int>("Thread_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Thread_Id"), 1L, 1);

                    b.Property<int>("Account_Id")
                        .HasColumnType("int");

                    b.Property<int>("Forum_Id")
                        .HasColumnType("int");

                    b.Property<int>("Thread_Name")
                        .HasColumnType("int");

                    b.HasKey("Thread_Id");

                    b.HasIndex("Account_Id");

                    b.HasIndex("Forum_Id");

                    b.ToTable("ForumThreads");
                });

            modelBuilder.Entity("API.Models.ModelDBs.GrammarUnit", b =>
                {
                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Unit_Id");

                    b.ToTable("GrammarUnits");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Kanji", b =>
                {
                    b.Property<int>("Word_Id")
                        .HasColumnType("int");

                    b.Property<string>("HanViet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kunyomi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Onyomi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Word_Kanji")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Word_Id");

                    b.ToTable("Kanjis");
                });

            modelBuilder.Entity("API.Models.ModelDBs.StudentsCourses", b =>
                {
                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Finish_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Star_Get_From_Course")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Student_Id", "Course_Id");

                    b.HasIndex("Course_Id");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("API.Models.ModelDBs.StudentsUnits", b =>
                {
                    b.Property<int>("New_Student_Id")
                        .HasColumnType("int");

                    b.Property<int>("New_Unit_id")
                        .HasColumnType("int");

                    b.Property<bool>("Is_Done")
                        .HasColumnType("bit");

                    b.Property<int?>("Unit_Id")
                        .HasColumnType("int");

                    b.HasKey("New_Student_Id", "New_Unit_id");

                    b.HasIndex("Unit_Id");

                    b.ToTable("StudentsUnits");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Tango", b =>
                {
                    b.Property<int>("Word_Id")
                        .HasColumnType("int");

                    b.Property<string>("Pronounce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vietnamese_mean")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Word_Id");

                    b.ToTable("Tangos");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Teacher", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Teacher_Id"), 1L, 1);

                    b.Property<string>("Katakana_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("University_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Teacher_Id");

                    b.HasIndex("University_Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Unit", b =>
                {
                    b.Property<int>("Unit_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Unit_Id"), 1L, 1);

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.HasKey("Unit_Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("Teacher_Id")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("API.Models.ModelDBs.UnitComment", b =>
                {
                    b.Property<int>("Comment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Comment_Id"), 1L, 1);

                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Comment_Id");

                    b.HasIndex("Unit_Id");

                    b.ToTable("UnitComments");
                });

            modelBuilder.Entity("API.Models.ModelDBs.University", b =>
                {
                    b.Property<int>("University_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("University_Id"), 1L, 1);

                    b.Property<string>("University_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("University_Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("API.Models.ModelDBs.VideoUnit", b =>
                {
                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Unit_Id");

                    b.ToTable("VideoUnits");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Word", b =>
                {
                    b.Property<int>("Word_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Word_Id"), 1L, 1);

                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<int>("WordUnitUnit_Id")
                        .HasColumnType("int");

                    b.HasKey("Word_Id");

                    b.HasIndex("WordUnitUnit_Id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("API.Models.ModelDBs.WordUnit", b =>
                {
                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<string>("Unit_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Unit_Id");

                    b.ToTable("WordUnits");
                });

            modelBuilder.Entity("API.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_Id"), 1L, 1);

                    b.Property<string>("KatakanaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("University_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<string>("VietnameseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_Id");

                    b.HasIndex("University_Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Admin", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Admin")
                        .HasForeignKey("API.Models.ModelDBs.Admin", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("API.Models.ModelDBs.ForumThread", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("ForumThreads")
                        .HasForeignKey("Account_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.ModelDBs.Forum", "Forum")
                        .WithMany("ForumThreads")
                        .HasForeignKey("Forum_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Forum");
                });

            modelBuilder.Entity("API.Models.ModelDBs.GrammarUnit", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Unit", "Unit")
                        .WithMany("GrammarUnits")
                        .HasForeignKey("Unit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Kanji", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Word", "Word")
                        .WithMany()
                        .HasForeignKey("Word_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("API.Models.ModelDBs.StudentsCourses", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Course", "Course")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Student", "Student")
                        .WithMany("StudentsCourses")
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("API.Models.ModelDBs.StudentsUnits", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Unit", null)
                        .WithMany("StudentsUnits")
                        .HasForeignKey("Unit_Id");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Tango", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Word", "Word")
                        .WithMany()
                        .HasForeignKey("Word_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Teacher", b =>
                {
                    b.HasOne("API.Models.ModelDBs.University", "University")
                        .WithMany("Teachers")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Teacher")
                        .HasForeignKey("API.Models.ModelDBs.Teacher", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("University");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Unit", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Course", "Course")
                        .WithMany("Units")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.ModelDBs.Teacher", "Teacher")
                        .WithOne("Unit")
                        .HasForeignKey("API.Models.ModelDBs.Unit", "Teacher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("API.Models.ModelDBs.UnitComment", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Unit", "Unit")
                        .WithMany("UnitComments")
                        .HasForeignKey("Unit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Models.ModelDBs.VideoUnit", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Unit", "Unit")
                        .WithMany("VideoUnits")
                        .HasForeignKey("Unit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Word", b =>
                {
                    b.HasOne("API.Models.ModelDBs.WordUnit", "WordUnit")
                        .WithMany("Word")
                        .HasForeignKey("WordUnitUnit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WordUnit");
                });

            modelBuilder.Entity("API.Models.ModelDBs.WordUnit", b =>
                {
                    b.HasOne("API.Models.ModelDBs.Unit", "Unit")
                        .WithMany("WordUnits")
                        .HasForeignKey("Unit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Models.Student", b =>
                {
                    b.HasOne("API.Models.ModelDBs.University", "University")
                        .WithMany("Students")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Account", "Account")
                        .WithOne("Student")
                        .HasForeignKey("API.Models.Student", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("University");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("ForumThreads");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Course", b =>
                {
                    b.Navigation("StudentsCourses");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Forum", b =>
                {
                    b.Navigation("ForumThreads");
                });

            modelBuilder.Entity("API.Models.ModelDBs.Teacher", b =>
                {
                    b.Navigation("Unit")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.ModelDBs.Unit", b =>
                {
                    b.Navigation("GrammarUnits");

                    b.Navigation("StudentsUnits");

                    b.Navigation("UnitComments");

                    b.Navigation("VideoUnits");

                    b.Navigation("WordUnits");
                });

            modelBuilder.Entity("API.Models.ModelDBs.University", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("API.Models.ModelDBs.WordUnit", b =>
                {
                    b.Navigation("Word");
                });

            modelBuilder.Entity("API.Models.Student", b =>
                {
                    b.Navigation("StudentsCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
