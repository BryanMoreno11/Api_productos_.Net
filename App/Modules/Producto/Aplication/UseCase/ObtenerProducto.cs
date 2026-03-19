using Backend.App.Modules.Producto.Domain;


namespace Backend.App.Modules.Producto.Application.UseCase
{
    public class ObtenerProducto
{
    private readonly IProductoRepository _repository;
    public ObtenerProducto(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductoDto> ExecuteAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        if (producto == null)
        {
            throw new Exception("Producto no encontrado.");
        }
        return new ProductoDto().FromEntity(producto);
    }


}
}



