using Backend.App.Modules.Producto.Application.UseCase;
using Backend.App.Modules.Producto.Domain;
using Backend.App.Modules.Producto.Infrastructure.Adapters.Persistence;
using Backend.App.Modules.Producto.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Modules.Producto.Infrastructure
{
    public static class ProductoUseCaseRegister
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            // 1. Conexión a la base de datos exclusiva del módulo (Modular Monolith)
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductoDbContext>(options =>
                options.UseNpgsql(connectionString));
            // 2. Registro de Inyección de Dependencias
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ProductoGetAll>(); // Registramos tu nuevo nombre
        }
    }
}