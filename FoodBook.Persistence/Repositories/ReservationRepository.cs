
using FoodBook.Application.Contracts.Repositories;
using FoodBook.Domain.Entities;
using FoodBook.Persistence.Context;
using System.Collections.Generic; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 

namespace FoodBook.Persistence.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {

        private readonly FoodBookDbContext _context;

        public ReservationRepository(FoodBookDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(int userId)
        {
            return await _context.Reservations
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
        }

    }
}