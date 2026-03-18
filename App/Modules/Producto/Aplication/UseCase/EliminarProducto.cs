
using Backend.App.Modules.Producto.Domain;

namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class EliminarProducto
    {
        private readonly IProductoRepository _repository;
        public EliminarProducto(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null)
            {
                throw new Exception("Producto no encontrado.");
            }
            await _repository.DeleteAsync(producto);
            await _repository.SaveChangesAsync();
        }
    }
}