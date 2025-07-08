// --- USINGS: Asegúrate de que todas estas líneas estén al principio del archivo ---
// Los 'using' que ya tenías y son correctos:
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration; // Si usas builder.Configuration

// Tus 'using' de extensiones de proyectos:
using FoodBook.Persistence.Extensions; // Ya la tienes
using FoodBook.Application.Extensions; // Ya la tienes
using FoodBook.Infrastructure.Extensions; // ¡Añade esta línea si no está!

// Asegúrate que este es el namespace de tu API si tu Program.cs no es un archivo de nivel superior
// Si tu Program.cs es un archivo de nivel superior (sin namespace globalmente), puedes omitir esto.
// Basado en image_19cf08.png, tienes un namespace FoodBookProAPI.
namespace FoodBookProAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // --- Agregando tus servicios de capas ---
            // Estos son los métodos de extensión que deberían estar definidos en tus proyectos respectivos
            builder.Services.AddPersistenceServices(builder.Configuration); // Correcto
            builder.Services.AddApplicationServices(); // Correcto
            builder.Services.AddInfrastructureServices(builder.Configuration); // ¡Esta es la línea clave que debe estar y ser correcta!

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection(); // Es buena práctica tenerlo si usas HTTPS

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}