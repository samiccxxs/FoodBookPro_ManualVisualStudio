
using Microsoft.EntityFrameworkCore;
using FoodBook.Domain.Entities; 

namespace FoodBook.Persistence.Context
{
    public class FoodBookDbContext : DbContext
    {
        public FoodBookDbContext(DbContextOptions<FoodBookDbContext> options) : base(options)
        {
        }


        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Transaction> Transactions { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

              modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation) 
                .WithMany() 
                .HasForeignKey(p => p.ReservationId); 
        }
    }
}