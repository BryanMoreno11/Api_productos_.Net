
using Backend.App.Modules.Producto.Domain;

namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class AgregarProducto
    {
        private readonly IProductoRepository _repository;
        public AgregarProducto(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(ProductoDto productoDto)
        {
            ProductoEntity producto= new ProductoEntity(productoDto.Id, productoDto.Nombre, productoDto.Stock,  productoDto.Precio);
            await _repository.AddAsync(producto);
            await _repository.SaveChangesAsync();
        }
    }
}