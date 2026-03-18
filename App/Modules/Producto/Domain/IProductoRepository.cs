namespace Backend.App.Modules.Producto.Domain
{
    public interface IProductoRepository
    {
        Task<List<ProductoEntity>> GetAllAsync();
    }
}