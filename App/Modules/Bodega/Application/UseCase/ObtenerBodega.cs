using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Domain.DTO;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class ObtenerBodega
    {
        private readonly IBodegaRepository _repository;

        public ObtenerBodega(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task<BodegaDto> ExecuteAsync(int id)
        {
            var bodega = await _repository.GetByIdAsync(id);
            if (bodega == null)
            {
                throw new KeyNotFoundException("Bodega no encontrada");
            }

            return BodegaDto.FromEntity(bodega);
        }
    }
}
