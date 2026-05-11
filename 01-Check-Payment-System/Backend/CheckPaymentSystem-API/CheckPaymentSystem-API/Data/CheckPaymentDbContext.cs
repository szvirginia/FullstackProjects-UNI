using CheckPaymentSystem_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckPaymentSystem_API.Data
{
    public class CheckPaymentDbContext : DbContext
    {
        public DbSet<CheckEntity> Checks { get; set; }

        public CheckPaymentDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CheckPaymentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckEntity>().HasData(
                new CheckEntity
                {
                    Id = 1,
                    Name = "Sophie Great",
                    Paid = 12000,
                    Date = new DateTime(2026, 5, 11),
                    PaymentType = PaymentType.Utilities,
                    IsProcessed = true
                },
                new CheckEntity
                {
                    Id = 2,
                    Name = "James Brones",
                    Paid = 37000,
                    Date = new DateTime(2026, 5, 11),
                    PaymentType = PaymentType.Penalty,
                    IsProcessed = false
                },
                new CheckEntity
                {
                    Id = 3,
                    Name = "Grace Cooper",
                    Paid = 700,
                    Date = new DateTime(2026, 5, 11),
                    PaymentType = PaymentType.Tax,
                    IsProcessed = true
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
