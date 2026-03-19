using Backend.App.Shared.Domain.Specifications;

namespace Backend.App.Modules.Producto.Domain
{
    public interface IProductoRepository
    {
        Task<List<ProductoEntity>> GetAllAsync();
        Task<ProductoEntity?> GetByIdAsync(int id);
        Task AddAsync(ProductoEntity producto);
         Task UpdateAsync(ProductoEntity producto);
        Task DeleteAsync(ProductoEntity producto);
        Task  SaveChangesAsync();
        Task<List<ProductoEntity>> GetWithSpecAsync(ISpecification<ProductoEntity> spec);
        Task<int> CountAsync(ISpecification<ProductoEntity> spec);
    }
}