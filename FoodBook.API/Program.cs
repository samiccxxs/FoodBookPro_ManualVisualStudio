using FoodBook.Persistence.Extensions; 
using FoodBook.Application.Extensions; 
using FoodBook.Infrastructure.Extensions; 

namespace FoodBookProAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers(); 
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen(); 

            
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddApplicationServices();

            builder.Services.AddInfrastructureServices(builder.Configuration); 

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 
                app.UseSwaggerUI(); 
            }


            app.UseAuthorization(); 

            app.MapControllers(); 

            app.Run();
        }
    }
}