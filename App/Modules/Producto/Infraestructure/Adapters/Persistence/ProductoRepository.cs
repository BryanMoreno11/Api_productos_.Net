using Backend.App.Modules.Producto.Domain;
using Backend.App.Shared;
using Backend.App.Shared.Domain.Specifications;
using Backend.App.Shared.Infrastructure.Persistence;
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
            return await _context.Productos.AsNoTracking().OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<ProductoEntity?> GetByIdAsync(int id)
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

        public async Task<List<ProductoEntity>> GetWithSpecAsync(ISpecification<ProductoEntity> spec)
        {   
            return await SpecificationEvaluator<ProductoEntity>
                .GetQuery(_context.Productos.AsQueryable(), spec)
                .ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<ProductoEntity> spec)
        {
            return await _context.Productos.Where(spec.Criteria).CountAsync();    
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}