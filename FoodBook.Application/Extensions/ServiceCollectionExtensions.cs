
using Microsoft.Extensions.DependencyInjection;
using FoodBook.Application.Contracts.Services; 
using FoodBook.Application.Services; 
using AutoMapper; 

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 


        services.AddTransient<IRecipeService, RecipeService>(); 
        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IReservationService, ReservationService>();
        

        return services;
    }
}