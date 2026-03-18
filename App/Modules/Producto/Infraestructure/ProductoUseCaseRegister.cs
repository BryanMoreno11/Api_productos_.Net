using Backend.App.Modules.Producto.Application.UseCase;
using Backend.App.Modules.Producto.Domain;
using Backend.App.Modules.Producto.Infrastructure.Adapters.Persistence;

namespace Backend.App.Modules.Producto.Infrastructure
{
    public static class ProductoUseCaseRegister
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //Inyección de Dependencias
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<AgregarProducto>(); 
            services.AddScoped<ObtenerProductos>();
            services.AddScoped<ObtenerProducto>();
            services.AddScoped<ModificarProducto>();
            services.AddScoped<EliminarProducto>();
        }
    }
}