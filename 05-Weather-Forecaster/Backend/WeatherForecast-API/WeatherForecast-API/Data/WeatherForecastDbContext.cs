using Microsoft.EntityFrameworkCore;
using WeatherForecast_API.Models;

namespace WeatherForecast_API.Data
{
    public class WeatherForecastDbContext :DbContext
    {
        public DbSet<Forecast> Forecasts { get; set; }

        public WeatherForecastDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeatherForecastDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
                optionsBuilder.UseSqlServer(connString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forecast>().HasData(
                new Forecast
                {
                    Id = 1,
                    Date = new DateTime(2026,5,1),
                    Degree = 27,
                    Wind = 4,
                    WeatherType = WeatherType.Sunny
                },
                new Forecast
                {
                    Id = 2,
                    Date = new DateTime(2026, 5, 3),
                    Degree = 26,
                    Wind = 8,
                    WeatherType = WeatherType.Dry
                },
                new Forecast
                {
                    Id = 3,
                    Date = new DateTime(2026, 5, 12),
                    Degree = 21,
                    Wind = 16,
                    WeatherType = WeatherType.Rainy
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
