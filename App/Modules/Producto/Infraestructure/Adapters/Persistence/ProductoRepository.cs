using Backend.App.Modules.Producto.Domain;
using Backend.App.Shared;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Modules.Producto.Infrastructure.Adapters.Persistence
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoEntity>> GetAllAsync()
        {
            return await _context.Productos.AsNoTracking().ToListAsync();
        }

        public async Task<ProductoEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task AddAsync(ProductoEntity producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public Task UpdateAsync(ProductoEntity producto)
        {
            _context.Productos.Update(producto);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(ProductoEntity producto)
        {
            _context.Productos.Remove(producto);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}