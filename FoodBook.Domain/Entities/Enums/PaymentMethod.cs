using System;

namespace FoodBook.Domain
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } 
        public decimal Amount { get; set; }
        public string PaymentMethodType { get; set; } 
        public DateTime PaymentDate { get; set; }
        public Transaction Transaction { get; set; } 
    }
}