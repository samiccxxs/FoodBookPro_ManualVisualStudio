using System;

namespace FoodBook.Application.Dtos.Reservation
{
    public class CreateReservationDto
    {
        public int UserId { get; set; }
        public int FoodItemId { get; set; } 
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Notes { get; set; }
    }
}