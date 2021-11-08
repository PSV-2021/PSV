using Microsoft.EntityFrameworkCore;


namespace Drugstore.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines
        {
            get; set;
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Brufen", Price = 250.00 },
                new Medicine { Id = 2, Name = "Olynth", Price = 180.00 },
                new Medicine { Id = 3, Name = "Polinol", Price = 670.00 }
            );
        }
    }
}
