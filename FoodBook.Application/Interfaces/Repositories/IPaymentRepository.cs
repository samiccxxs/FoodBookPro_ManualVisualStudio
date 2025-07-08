using System.Threading.Tasks;
using System.Collections.Generic;
using FoodBook.Domain.Entities;
using FoodBook.Application.Contracts.Repositories; 

namespace FoodBook.Application.Interfaces.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> GetByReservationIdAsync(int reservationId);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
    }
}