using FoodBook.Application.Dtos.Payment;
using FoodBook.Application.Dtos.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBook.Application.Contracts.Services
{
    public interface IPaymentService
    {
        Task<ServiceResult<List<PaymentDto>>> GetAllPaymentsAsync();
        Task<ServiceResult<PaymentDto>> GetPaymentByIdAsync(int id);
        Task<ServiceResult<PaymentDto>> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
        Task<ServiceResult<PaymentDto>> UpdatePaymentAsync(UpdatePaymentDto updatePaymentDto);
        Task<ServiceResult> CancelPaymentAsync(int id);
    }
}