namespace Backend.App.Modules.Producto.Domain
{
    public interface IProductoRepository
    {
        Task<List<ProductoEntity>> GetAllAsync();
        Task<ProductoEntity?> GetByIdAsync(Guid id);
        Task AddAsync(ProductoEntity producto);
         Task UpdateAsync(ProductoEntity producto);
        Task DeleteAsync(ProductoEntity producto);
        Task  SaveChangesAsync();
    }
}