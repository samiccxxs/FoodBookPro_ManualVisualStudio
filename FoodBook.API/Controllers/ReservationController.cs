
using Microsoft.AspNetCore.Mvc;
using FoodBook.Application.Contracts.Services; 
using FoodBook.Application.Dtos.Reservation;  
using Microsoft.Extensions.Logging;
using FoodBook.Application.Dtos.Common;      

namespace FoodBookProAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }

        
        [HttpGet] 
        public async Task<IActionResult> GetAllReservations()
        {
            _logger.LogInformation("Intentando obtener todas las reservas.");
            var result = await _reservationService.GetAllReservationsAsync();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error al obtener reservas: {ErrorMessage}", result.Message);
                return BadRequest(result);
            }
        }

        
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetReservationById(int id)
        {
            _logger.LogInformation("Intentando obtener reserva con ID: {Id}", id);
            var result = await _reservationService.GetReservationByIdAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error al obtener reserva {Id}: {ErrorMessage}", id, result.Message);
                return NotFound(result);
            }
        }

        
        [HttpPost] 
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            _logger.LogInformation("Intentando crear una nueva reserva para el usuario: {UserId}", createReservationDto.UserId);
            var result = await _reservationService.CreateReservationAsync(createReservationDto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error al crear reserva: {ErrorMessage}", result.Message);
                return BadRequest(result);
            }
        }

        
        [HttpPut] 
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationDto updateReservationDto)
        {
            _logger.LogInformation("Intentando actualizar reserva con ID: {Id}", updateReservationDto.Id);
            var result = await _reservationService.UpdateReservationAsync(updateReservationDto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error al actualizar reserva {Id}: {ErrorMessage}", updateReservationDto.Id, result.Message);
                return BadRequest(result);
            }
        }

        
        [HttpDelete("{id}")] 
        public async Task<IActionResult> CancelReservation(int id)
        {
            _logger.LogInformation("Intentando cancelar reserva con ID: {Id}", id);
            var result = await _reservationService.CancelReservationAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error al cancelar reserva {Id}: {ErrorMessage}", id, result.Message);
                return BadRequest(result);
            }
        }
    }
}