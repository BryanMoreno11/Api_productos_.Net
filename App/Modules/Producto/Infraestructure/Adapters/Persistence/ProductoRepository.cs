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
        public async Task AddAsync(ProductoEntity producto)
        {
            await _context.Productos.AddAsync(producto);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}