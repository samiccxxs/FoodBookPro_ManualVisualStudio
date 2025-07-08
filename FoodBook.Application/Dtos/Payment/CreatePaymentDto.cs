
using System;

namespace FoodBook.Application.Dtos.Payment
{
    public class CreatePaymentDto
    {
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }
    }
}