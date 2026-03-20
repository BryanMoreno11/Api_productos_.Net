using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Domain.DTO;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class ObtenerBodegas
    {
        private readonly IBodegaRepository _repository;

        public ObtenerBodegas(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BodegaDto>> ExecuteAsync()
        {
            var bodegas = await _repository.GetAllAsync();
            return bodegas.Select(b => BodegaDto.FromEntity(b)).ToList();
        }
    }
}
