
public interface INotificationService
{
    Task SendReservationConfirmationAsync(int reservationId);
    Task SendPaymentConfirmationAsync(int paymentId);
    Task SendReservationReminderAsync(int reservationId);
    Task SendCancellationNotificationAsync(int reservationId);
}