
using AutoMapper;
using FoodBook.Application.Dtos.Reservation;
using FoodBook.Domain.Entities; 

namespace FoodBook.Application.MappingProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
           
            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

           
            CreateMap<Reservation, ReservationDto>();
        }
    }
}