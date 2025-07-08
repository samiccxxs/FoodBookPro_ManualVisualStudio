
using AutoMapper;
using FoodBook.Application.Dtos.Payment;
using FoodBook.Domain.Entities; 

namespace FoodBook.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
         
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>(); 
            CreateMap<UpdatePaymentDto, Payment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Payment, PaymentDto>();
        }
    }
}