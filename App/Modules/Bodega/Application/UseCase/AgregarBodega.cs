using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Domain.DTO;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class AgregarBodega
    {
        private readonly IBodegaRepository _repository;
        public AgregarBodega(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(CrearBodegaDto bodegaDto)
        {
            BodegaEntity bodega = new BodegaEntity(bodegaDto.Nombre, bodegaDto.Descripcion);
            await _repository.AddAsync(bodega);
            await _repository.SaveChangesAsync();
        }
    }
}
