using Microsoft.EntityFrameworkCore;
using StudentRegiter.Models;
using StudentRegiter.Models;

namespace StudentRegiter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Student>().HasIndex(s => s.Email).IsUnique();
            b.Entity<Course>().HasIndex(c => c.Code).IsUnique();

            b.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            b.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            b.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
