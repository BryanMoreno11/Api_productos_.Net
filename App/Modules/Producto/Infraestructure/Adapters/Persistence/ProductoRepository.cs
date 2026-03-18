using Backend.App.Modules.Producto.Domain;
using Backend.App.Modules.Producto.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Modules.Producto.Infrastructure.Adapters.Persistence
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductoDbContext _context;

        public ProductoRepository(ProductoDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoEntity>> GetAllAsync()
        {
            return await _context.Productos.AsNoTracking().ToListAsync();
        }
    }
}