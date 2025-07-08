using Microsoft.EntityFrameworkCore;
using FoodBook.Application.Contracts.Repositories; 
using FoodBook.Domain.Entities;
using FoodBook.Persistence.Context; 

namespace FoodBook.Persistence.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly FoodBookDbContext _context; 

        public PaymentRepository(FoodBookDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<Payment> GetByReservationIdAsync(int reservationId)
        {
            return await _context.Payments
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.ReservationId == reservationId);
        }


        public override async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments
                .Include(p => p.Reservation)
                .Include(p => p.Transaction)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


    }
}