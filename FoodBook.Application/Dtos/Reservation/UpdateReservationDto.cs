using System.ComponentModel.DataAnnotations;

public class UpdateReservationDto
{
    [Required(ErrorMessage = "El ID de reserva es requerido para la actualización.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "El ID de usuario es requerido.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "El ID del restaurante/comida es requerido.")]
    public int FoodItemId { get; set; }

    [Required(ErrorMessage = "La fecha y hora de la reserva es requerida.")]
    public DateTime ReservationDateTime { get; set; }

    [Required(ErrorMessage = "El número de personas es requerido.")]
    [Range(1, 20, ErrorMessage = "El número de personas debe estar entre 1 y 20.")]
    public int NumberOfPeople { get; set; }

    [Required(ErrorMessage = "El estado de la reserva es requerido.")]
    [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres.")]
    public string Status { get; set; } 

    [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres.")]
    public string Notes { get; set; }
}