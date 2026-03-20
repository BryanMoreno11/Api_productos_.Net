using Backend.App.Modules.Bodega.Application.UseCase;
using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Infrastructure.Adapters.Persistence;

namespace Backend.App.Modules.Bodega.Infrastructure
{
    public static class BodegaUseCaseRegister
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //Inyección de Dependencias
            services.AddScoped<IBodegaRepository, BodegaRepository>();
            services.AddScoped<AgregarBodega>(); 
            services.AddScoped<ObtenerBodegas>();
            services.AddScoped<ObtenerBodega>();
            services.AddScoped<ModificarBodega>();
            services.AddScoped<EliminarBodega>();
            services.AddScoped<ObtenerBodegasPaginados>();
        }
    }
}
