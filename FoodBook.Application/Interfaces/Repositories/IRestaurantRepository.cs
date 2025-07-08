using FoodBook.Application.Contracts.Repositories;
using FoodBook.Domain.Entities;   
using System.Collections.Generic; 
using System.Threading.Tasks;     

namespace FoodBook.Application.Interfaces.Repositories 
{
    public interface IReservationRepository : IGenericRepository<Reservation> 
    {
        Task<Reservation> GetByIdAsync(int id);
        Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Reservation>> GetByRestaurantIdAsync(int restaurantId);
        Task<Reservation> AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
        Task DeleteAsync(int id);
    }
}