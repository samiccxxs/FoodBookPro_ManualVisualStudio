using System;

namespace FoodBook.Application.Dtos.Reservation
{
    public class UpdateReservationDto
    {
        public int Id { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string Status { get; set; } 
        public string Notes { get; set; }
    }
}