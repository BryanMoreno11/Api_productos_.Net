using Backend.App.Modules.Producto.Domain;
namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class ModificarProducto
{
    private readonly IProductoRepository _repository;
    public ModificarProducto(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id, string nombre, int stock, decimal precio)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null)
        {
            throw new Exception("Producto no encontrado.");
        }
        producto.ActualizarProducto(nombre, stock, precio);
        await _repository.UpdateAsync(producto);
        await _repository.SaveChangesAsync();
    }
}
}

