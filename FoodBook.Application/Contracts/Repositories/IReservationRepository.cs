using FoodBook.Domain.Entities;

namespace FoodBook.Application.Contracts.Repositories
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(int userId); // Ejemplo de m�todo espec�fico
    }
}