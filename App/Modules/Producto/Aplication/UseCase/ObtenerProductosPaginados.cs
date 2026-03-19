using Backend.App.Modules.Producto.Domain;
using Backend.App.Modules.Producto.Domain.DTO;
using Backend.App.Modules.Producto.Domain.Specifications;

namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class ObtenerProductosPaginados{
        private readonly IProductoRepository _repository;
        public ObtenerProductosPaginados(IProductoRepository repository)
        {
            _repository = repository;
        }
        public async Task<object> ExecuteAsync(ProductoCriteriaDto criteria) {
            var spec = new ProductoFilterSpec(criteria.Nombre, criteria.StockMinimo, criteria.Page, criteria.PageSize);
            var productos = await _repository.GetWithSpecAsync(spec);
            var total = await _repository.CountAsync(spec);
            return new {
            items = productos.Select(p => new ProductoDto().FromEntity(p)).ToList(),
            totalItems = total,
            page = criteria.Page,
            pageSize = criteria.PageSize
            };
        }
    }












}




