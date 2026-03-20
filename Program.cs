using Backend.App.Modules.Producto.Infrastructure;
using Backend.App.Shared;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//Base de Datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
//Cors
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngular", policy => {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//Servicios de .NET
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Servicios del módulo Producto
ProductoUseCaseRegister.Register(builder.Services, builder.Configuration);
// Servicios del módulo Bodega
Backend.App.Modules.Bodega.Infrastructure.BodegaUseCaseRegister.Register(builder.Services, builder.Configuration);
var app = builder.Build();
//Middleware global para manejo de excepciones
app.UseMiddleware<ExceptionMiddleware>();
//PIPELINE DE EJECUCIÓN ---
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAngular");
// Mapeamos los controladores que viven en Infraestructura/Adapters/Http
app.MapControllers(); 
app.Run();