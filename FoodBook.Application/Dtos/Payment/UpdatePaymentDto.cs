using System;

namespace FoodBook.Application.Dtos.Payment
{
    public class UpdatePaymentDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}