using FoodBook.Application.Contracts.Repositories;
using FoodBook.Application.Contracts.Services;
using FoodBook.Application.Dtos.Reservation;
using FoodBook.Application.Dtos.Common;
using FoodBook.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System; 

namespace FoodBook.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ReservationDto>>> GetAllReservationsAsync()
        {
            try
            {
                var reservations = await _reservationRepository.GetAllAsync();
                var reservationDtos = _mapper.Map<List<ReservationDto>>(reservations);
                return ServiceResult<List<ReservationDto>>.Success(reservationDtos);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<ReservationDto>>.Failure($"Error al obtener reservas: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ReservationDto>> GetReservationByIdAsync(int id)
        {
            try
            {
                var reservation = await _reservationRepository.GetByIdAsync(id);
                if (reservation == null)
                {
                    return ServiceResult<ReservationDto>.Failure($"Reserva con ID {id} no encontrada.");
                }
                var reservationDto = _mapper.Map<ReservationDto>(reservation);
                return ServiceResult<ReservationDto>.Success(reservationDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<ReservationDto>.Failure($"Error al obtener reserva: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ReservationDto>> CreateReservationAsync(CreateReservationDto createReservationDto)
        {
            try
            {
                var reservation = _mapper.Map<Reservation>(createReservationDto);
                reservation.Status = "Pendiente";
                reservation.CreatedDate = DateTime.Now;

                var createdReservation = await _reservationRepository.AddAsync(reservation);
                var reservationDto = _mapper.Map<ReservationDto>(createdReservation);
                return ServiceResult<ReservationDto>.Success(reservationDto, "Reserva creada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ReservationDto>.Failure($"Error al crear reserva: {ex.Message}");
            }
        }

        public async Task<ServiceResult<ReservationDto>> UpdateReservationAsync(UpdateReservationDto updateReservationDto)
        {
            try
            {
                var existingReservation = await _reservationRepository.GetByIdAsync(updateReservationDto.Id);
                if (existingReservation == null)
                {
                    return ServiceResult<ReservationDto>.Failure($"Reserva con ID {updateReservationDto.Id} no encontrada para actualizar.");
                }

                _mapper.Map(updateReservationDto, existingReservation);

                await _reservationRepository.UpdateAsync(existingReservation);
                var reservationDto = _mapper.Map<ReservationDto>(existingReservation);
                return ServiceResult<ReservationDto>.Success(reservationDto, "Reserva actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult<ReservationDto>.Failure($"Error al actualizar reserva: {ex.Message}");
            }
        }

        public async Task<ServiceResult> CancelReservationAsync(int id)
        {
            try
            {
                var reservationToCancel = await _reservationRepository.GetByIdAsync(id);
                if (reservationToCancel == null)
                {
                    return ServiceResult.Failure($"Reserva con ID {id} no encontrada para cancelar.");
                }

                reservationToCancel.Status = "Cancelada";
                await _reservationRepository.UpdateAsync(reservationToCancel);

                return ServiceResult.Success("Reserva cancelada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al cancelar reserva: {ex.Message}");
            }
        }
    }
}