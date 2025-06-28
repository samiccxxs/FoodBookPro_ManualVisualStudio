
using System.ComponentModel.DataAnnotations;

public class UpdatePaymentDto
{
    [Required(ErrorMessage = "El ID de pago es requerido para la actualización.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El monto es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "El estado del pago es requerido.")]
    [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres.")]
    public string Status { get; set; } 

    [StringLength(255, ErrorMessage = "La descripción no puede exceder 255 caracteres.")]
    public string Description { get; set; }
}