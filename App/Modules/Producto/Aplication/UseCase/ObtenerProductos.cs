
using Backend.App.Modules.Producto.Domain;

namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class ObtenerProductos
    {
        private readonly IProductoRepository _repository;
        public ObtenerProductos(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoDto>> ExecuteAsync()
        {
            var entidades = await _repository.GetAllAsync();
            return entidades.Select(e => new ProductoDto().FromEntity(e)).ToList();
        }
    }
}