// PaymentRepository.cs
using Microsoft.EntityFrameworkCore;
using FoodBook.Application.Interfaces.Repositories;
using FoodBook.Domain.Entities;
using FoodBook.Persistence.Context;

namespace FoodBook.Persistence.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FoodBookDbContext _context;

        public PaymentRepository(FoodBookDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Reservation)
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Payment> GetByReservationIdAsync(int reservationId)
        {
            return await _context.Payments
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.ReservationId == reservationId);
        }

        public async Task<Payment> AddAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}