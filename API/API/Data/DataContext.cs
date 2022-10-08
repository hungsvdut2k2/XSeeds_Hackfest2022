using API.Models;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Fluent Api methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // one to Many
            modelBuilder.Entity<Student>()
            .HasOne<University>(s => s.University)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.University_Id);

            modelBuilder.Entity<Teacher>()
           .HasOne<University>(s => s.University)
           .WithMany(g => g.Teachers)
           .HasForeignKey(s => s.University_Id);

            modelBuilder.Entity<Unit>()
           .HasOne<Course>(s => s.Course)
           .WithMany(g => g.Units)
           .HasForeignKey(s => s.Course_Id);

            modelBuilder.Entity<UnitComment>()
         .HasOne<Unit>(s => s.Unit)
         .WithMany(g => g.UnitComments)
         .HasForeignKey(s => s.Unit_Id);
            modelBuilder.Entity<ForumThread>()
                .HasOne<Account>(s => s.Account)
                .WithMany(g => g.ForumThreads)
                .HasForeignKey(s => s.Account_Id);
            modelBuilder.Entity<ForumThread>()
                .HasOne<Forum>(s => s.Forum)
                .WithMany(g => g.ForumThreads)
                .HasForeignKey(s => s.Forum_Id);

            //Many to many
            modelBuilder.Entity<StudentsCourses>().HasKey(sc => new { sc.Student_Id, sc.Course_Id });
            modelBuilder.Entity<StudentsCourses>().HasOne(p => p.Course).WithMany(p => p.StudentsCourses).HasForeignKey(p => p.Course_Id);
            modelBuilder.Entity<StudentsCourses>().HasOne(p => p.Student).WithMany(p => p.StudentsCourses).HasForeignKey(p => p.Student_Id);

            modelBuilder.Entity<StudentsUnits>().HasKey(su => new { su.New_Student_Id, su.New_Unit_id});
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }
        public DbSet<StudentsUnits> StudentsUnits { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitComment> UnitComments {get; set; }
        public DbSet<WordUnit> WordUnits { get; set; }
        public DbSet<VideoUnit> VideoUnits { get; set; }
        public DbSet<GrammarUnit> GrammarUnits { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Kanji> Kanjis { get; set; }
        public DbSet<Tango> Tangos { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}
