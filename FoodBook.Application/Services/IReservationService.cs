
// IReservationService.cs
public interface IReservationService
{
    Task<ReservationDto> CreateReservationAsync(CreateReservationDto createReservationDto);
    Task<ReservationDto> GetReservationByIdAsync(int id);
    Task<IEnumerable<ReservationDto>> GetUserReservationsAsync(int userId);
    Task<IEnumerable<ReservationDto>> GetRestaurantReservationsAsync(int restaurantId);
    Task UpdateReservationStatusAsync(int id, ReservationStatus status);
    Task CancelReservationAsync(int id);
}