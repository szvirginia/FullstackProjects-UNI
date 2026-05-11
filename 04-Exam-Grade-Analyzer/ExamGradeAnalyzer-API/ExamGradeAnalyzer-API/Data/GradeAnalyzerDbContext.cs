using ExamGradeAnalyzer_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamGradeAnalyzer_API.Data
{
    public class GradeAnalyzerDbContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; }

        public GradeAnalyzerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GradeAnalyzerDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                optionsBuilder.UseSqlServer(connString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasData(
        new Grade { Id = 1, Name = "Sophie Anne", Subject = "Math", GradeType = 5 },
        new Grade { Id = 2, Name = "Carmen Cooper", Subject = "PE", GradeType = 4 },
        new Grade { Id = 3, Name = "Haley Master", Subject = "History", GradeType = 2 }
    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
