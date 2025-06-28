
using System.ComponentModel.DataAnnotations;

public class CreatePaymentDto
{
    [Required(ErrorMessage = "El ID de reserva es requerido.")]
    public int ReservationId { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "El método de pago es requerido.")]
    [StringLength(50, ErrorMessage = "El método de pago no puede exceder 50 caracteres.")]
    public string PaymentMethod { get; set; }

    [StringLength(255, ErrorMessage = "La descripción no puede exceder 255 caracteres.")]
    public string Description { get; set; }
}