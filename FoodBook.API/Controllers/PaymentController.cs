using FoodBook.Application.Contracts.Services;
using FoodBook.Application.Dtos.Payment;
using FoodBook.Application.Dtos.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBookProAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<PaymentDto>>>> GetAll()
        {
            var result = await _paymentService.GetAllPaymentsAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<PaymentDto>>> GetById(int id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);
            if (result.IsSuccess)
            {
                if (result.Data == null) 
                {
                    return NotFound(ServiceResult<PaymentDto>.Failure($"Pago con ID {id} no encontrado."));
                }
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<PaymentDto>>> Create(CreatePaymentDto dto)
        {
            var result = await _paymentService.CreatePaymentAsync(dto);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<PaymentDto>>> Update(int id, UpdatePaymentDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(ServiceResult<PaymentDto>.Failure("El ID de la ruta no coincide con el ID del cuerpo de la solicitud."));
            }

            var result = await _paymentService.UpdatePaymentAsync(dto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult>> Cancel(int id)
        {
            var result = await _paymentService.CancelPaymentAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}