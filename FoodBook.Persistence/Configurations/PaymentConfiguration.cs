// PaymentConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodBook.Domain.Entities;

namespace FoodBook.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ReservationId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Method)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.PaymentDate)
                .IsRequired();

            // Relación con Reservation
            builder.HasOne(x => x.Reservation)
                .WithMany()
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación uno a uno con Transaction
            builder.HasOne(x => x.Transaction)
                .WithOne(x => x.Payment)
                .HasForeignKey<Transaction>(x => x.PaymentId);
        }
    }
}