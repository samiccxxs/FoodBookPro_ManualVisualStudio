
public interface IPaymentService
{
    Task<PaymentDto> ProcessPaymentAsync(ProcessPaymentDto processPaymentDto);
    Task<PaymentDto> GetPaymentByIdAsync(int id);
    Task<PaymentDto> GetPaymentByReservationIdAsync(int reservationId);
    Task RefundPaymentAsync(int paymentId);
}