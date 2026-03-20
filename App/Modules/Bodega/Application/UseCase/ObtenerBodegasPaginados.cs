using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Domain.DTO;
using Backend.App.Modules.Bodega.Domain.Specifications;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class ObtenerBodegasPaginados
    {
        private readonly IBodegaRepository _repository;

        public ObtenerBodegasPaginados(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> ExecuteAsync(BodegaCriteriaDto criteria)
        {
            var spec = new BodegaFilterSpec(criteria.Nombre, criteria.Page, criteria.PageSize);
            
            var bodegas = await _repository.GetWithSpecAsync(spec);
            var totalItems = await _repository.CountAsync(spec);
            
            return new
            {
                items = bodegas.Select(b => BodegaDto.FromEntity(b)).ToList(),
                totalItems = totalItems,
                page = criteria.Page,
                pageSize = criteria.PageSize
            };
        }
    }
}
