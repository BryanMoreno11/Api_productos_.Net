
using Backend.App.Modules.Producto.Domain;

namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class ProductoGetAll
    {
        private readonly IProductoRepository _repository;
        public ProductoGetAll(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductoDTO>> ExecuteAsync()
        {
            var entidades = await _repository.GetAllAsync();
            return entidades.Select(e => new ProductoDTO().FromEntity(e)).ToList();
        }
    }
}