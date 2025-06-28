
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodBook.Application.Interfaces.Repositories;
using FoodBook.Persistence.Context;
using FoodBook.Persistence.Repositories;

namespace FoodBook.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<FoodBookDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}