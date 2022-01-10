using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.IntegrationEvents.Model
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> IntegrationEvents { get; set; }

        public EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
               new Event(1, "Klik", DateTime.Now),
               new Event(2, "Klik", DateTime.Now)
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(GetDBConnectionString()).UseLazyLoadingProxies();
        }

        public string GetDBConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPort") ?? "5432";
            var user = Environment.GetEnvironmentVariable("DBUser") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DBPassword") ?? "123";
            var database = Environment.GetEnvironmentVariable("DB") ?? "event";
            //if (server == null) return ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString");
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }
    }
}
