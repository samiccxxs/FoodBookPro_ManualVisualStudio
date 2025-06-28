using FoodBook.Application.Dtos.Reservation;
using FoodBook.Application.Dtos.Common; 

namespace FoodBook.Application.Contracts.Services
{
    public interface IReservationService
    {
        Task<ServiceResult<List<ReservationDto>>> GetAllReservationsAsync();
        Task<ServiceResult<ReservationDto>> GetReservationByIdAsync(int id);
        Task<ServiceResult<ReservationDto>> CreateReservationAsync(CreateReservationDto createReservationDto);
        Task<ServiceResult<ReservationDto>> UpdateReservationAsync(UpdateReservationDto updateReservationDto);
        Task<ServiceResult> CancelReservationAsync(int id);
    }
}