public interface IReservationRepository
{
    Task<Reservation> GetByIdAsync(int id);
    Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
    Task<IEnumerable<Reservation>> GetByRestaurantIdAsync(int restaurantId);
    Task<Reservation> AddAsync(Reservation reservation);
    Task UpdateAsync(Reservation reservation);
    Task DeleteAsync(int id);
}