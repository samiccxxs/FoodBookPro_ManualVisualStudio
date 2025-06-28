/using Microsoft.AspNetCore.Mvc;
using FoodBook.Application.Contracts.Services; 
using FoodBook.Application.Dtos.Payment; 
using Microsoft.Extensions.Logging; 
using FoodBook.Application.Dtos.Common; 

namespace FoodBookProAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }


        [HttpGet("GetAllPayments")]
        public async Task<IActionResult> GetAllPayments()
        {
            _logger.LogInformation("Attempting to retrieve all payments.");
            var result = await _paymentService.GetAllPaymentsAsync(); 

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error retrieving payments: {ErrorMessage}", result.Message);
                return BadRequest(result);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            _logger.LogInformation("Attempting to retrieve payment with ID: {Id}", id);
            var result = await _paymentService.GetPaymentByIdAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error retrieving payment {Id}: {ErrorMessage}", id, result.Message);
                return NotFound(result); 
            }
        }

        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentDto processPaymentDto)
        {
            _logger.LogInformation("Attempting to process a new payment for reservation: {ReservationId}", processPaymentDto.ReservationId);
            var result = await _paymentService.ProcessPaymentAsync(processPaymentDto); 

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                _logger.LogError("Error processing payment: {ErrorMessage}", result.Message);
                return BadRequest(result);
            }
        }

    }
}