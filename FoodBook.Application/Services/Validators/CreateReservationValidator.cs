using FluentValidation;       
using System;                 
using FoodBook.Application.Dtos.Reservation; 

namespace FoodBook.Application.Validators 
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.RestaurantId).GreaterThan(0);
            RuleFor(x => x.ReservationDate).GreaterThan(DateTime.Now);
            RuleFor(x => x.NumberOfGuests).GreaterThan(0).LessThanOrEqualTo(20);
        }
    }
}