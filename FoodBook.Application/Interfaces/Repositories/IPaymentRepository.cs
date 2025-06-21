// IPaymentRepository.cs
public interface IPaymentRepository
{
    Task<Payment> GetByIdAsync(int id);
    Task<Payment> GetByReservationIdAsync(int reservationId);
    Task<Payment> AddAsync(Payment payment);
    Task UpdateAsync(Payment payment);
}