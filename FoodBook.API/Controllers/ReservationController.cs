using FoodBook.Application.Contracts.Services;
using FoodBook.Application.Dtos.Reservation;
using FoodBook.Application.Dtos.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBookProAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ReservationDto>>>> GetAll()
        {
            var result = await _reservationService.GetAllReservationsAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> GetById(int id)
        {
            var result = await _reservationService.GetReservationByIdAsync(id);
            if (result.IsSuccess)
            {
                if (result.Data == null)
                {
                    return NotFound(ServiceResult<ReservationDto>.Failure($"Reserva con ID {id} no encontrada."));
                }
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> Create(CreateReservationDto dto)
        {
            var result = await _reservationService.CreateReservationAsync(dto);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<ReservationDto>>> Update(int id, UpdateReservationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(ServiceResult<ReservationDto>.Failure("El ID de la ruta no coincide con el ID del cuerpo de la solicitud."));
            }

            var result = await _reservationService.UpdateReservationAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult>> Cancel(int id)
        {
            var result = await _reservationService.CancelReservationAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}