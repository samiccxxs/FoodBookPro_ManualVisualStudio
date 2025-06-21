// Program.cs
using FoodBook.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de persistencia
builder.Services.AddPersistenceServices(builder.Configuration);

// ... otros servicios

var app = builder.Build();

// ... configuración del pipeline