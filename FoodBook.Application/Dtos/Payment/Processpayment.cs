
using System.ComponentModel.DataAnnotations;

public class ProcessPaymentDto
{
    [Required(ErrorMessage = "ReservationId is required.")]
    public int ReservationId { get; set; }
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage = "Payment method is required.")]
    public string PaymentMethod { get; set; } 
    public string CardNumber { get; set; }
}


public class PaymentDto
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string Status { get; set; } 
    public string PaymentMethod { get; set; }
    
}