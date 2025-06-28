using FoodBook.Application.Contracts.Repositories; 
using FoodBook.Application.Contracts.Services;
using FoodBook.Application.Dtos.Payment;
using FoodBook.Application.Dtos.Common;
using FoodBook.Domain.Entities; 
using AutoMapper;

namespace FoodBook.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper; 

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<PaymentDto>>> GetAllPaymentsAsync()
        {
            try
            {
                var payments = await _paymentRepository.GetAllAsync(); 
                var paymentDtos = _mapper.Map<List<PaymentDto>>(payments);
                return ServiceResult<List<PaymentDto>>.Success(paymentDtos);
            }
            catch (Exception ex)
            {
                
                return ServiceResult<List<PaymentDto>>.Failure($"Error al obtener pagos: {ex.Message}");
            }
        }

        public async Task<ServiceResult<PaymentDto>> GetPaymentByIdAsync(int id)
        {
            try
            {
                var payment = await _paymentRepository.GetByIdAsync(id); 
                if (payment == null)
                {
                    return ServiceResult<PaymentDto>.Failure($"Pago con ID {id} no encontrado.");
                }
                var paymentDto = _mapper.Map<PaymentDto>(payment);
                return ServiceResult<PaymentDto>.Success(paymentDto);
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentDto>.Failure($"Error al obtener pago: {ex.Message}");
            }
        }

        public async Task<ServiceResult<PaymentDto>> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            try
            {
                var payment = _mapper.Map<Payment>(createPaymentDto); 
                payment.PaymentDate = DateTime.Now; 
                payment.Status = "Pendiente"; 

                var createdPayment = await _paymentRepository.AddAsync(payment);
                var paymentDto = _mapper.Map<PaymentDto>(createdPayment);
                return ServiceResult<PaymentDto>.Success(paymentDto, "Pago creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentDto>.Failure($"Error al crear pago: {ex.Message}");
            }
        }

        public async Task<ServiceResult<PaymentDto>> UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto)
        {
            try
            {
                var existingPayment = await _paymentRepository.GetByIdAsync(updatePaymentDto.Id);
                if (existingPayment == null)
                {
                    return ServiceResult<PaymentDto>.Failure($"Pago con ID {updatePaymentDto.Id} no encontrado para actualizar.");
                }

                _mapper.Map(updatePaymentDto, existingPayment); 
                
                await _paymentRepository.UpdateAsync(existingPayment); 
                var paymentDto = _mapper.Map<PaymentDto>(existingPayment);
                return ServiceResult<PaymentDto>.Success(paymentDto, "Pago actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaymentDto>.Failure($"Error al actualizar pago: {ex.Message}");
            }
        }

        public async Task<ServiceResult> CancelPaymentAsync(int id)
        {
            try
            {
                var paymentToCancel = await _paymentRepository.GetByIdAsync(id);
                if (paymentToCancel == null)
                {
                    return ServiceResult.Failure($"Pago con ID {id} no encontrado para cancelar.");
                }


                 paymentToCancel.Status = "Cancelado";
                await _paymentRepository.UpdateAsync(paymentToCancel);

                return ServiceResult.Success("Pago cancelado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al cancelar pago: {ex.Message}");
            }
        }
    }
}