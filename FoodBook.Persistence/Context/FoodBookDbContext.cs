// FoodBookDbContext.cs
using Microsoft.EntityFrameworkCore;
using FoodBook.Domain.Entities;

namespace FoodBook.Persistence.Context
{
    public class FoodBookDbContext : DbContext
    {
        public FoodBookDbContext(DbContextOptions<FoodBookDbContext> options) : base(options)
        {
        }

        // DbSets para todas las entidades
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar todas las configuraciones
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodBookDbContext).Assembly);
        }
    }
}