using Microsoft.EntityFrameworkCore;
using StudentsAPI.Models;

namespace StudentsAPI.Data
{
    public class StudentsAPIContext : DbContext
    {
        public StudentsAPIContext(DbContextOptions<StudentsAPIContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
