using ActivityManager_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ActivityManager_API.Data
{
    public class ActivityManagerDbContext :DbContext
    {
        public DbSet<Activity> Activities { get; set; }

        public ActivityManagerDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActivityManagerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                optionsBuilder.UseSqlServer(connString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    Id = 1,
                    TaskName = "Cleaning",
                    Duration = 124,
                    Priority = Priority.Medium,
                    IsFinished = true
                },
                new Activity
                {
                    Id = 2,
                    TaskName = "Study",
                    Duration = 45,
                    Priority = Priority.High,
                    IsFinished = false
                },
                new Activity
                {
                    Id = 3,
                    TaskName = "Shopping",
                    Duration = 12,
                    Priority = Priority.Low,
                    IsFinished = true
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
