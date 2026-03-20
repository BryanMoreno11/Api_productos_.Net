using Backend.App.Modules.Bodega.Domain;
using Backend.App.Shared;
using Backend.App.Shared.Domain.Specifications;
using Backend.App.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.App.Modules.Bodega.Infrastructure.Adapters.Persistence
{
    public class BodegaRepository : IBodegaRepository
    {
        private readonly ApplicationDbContext _context;

        public BodegaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BodegaEntity>> GetAllAsync()
        {
            return await _context.Bodegas.AsNoTracking().OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<BodegaEntity?> GetByIdAsync(int id)
        {
            return await _context.Bodegas.FindAsync(id);
        }

        public async Task AddAsync(BodegaEntity bodega)
        {
            await _context.Bodegas.AddAsync(bodega);
        }

        public Task UpdateAsync(BodegaEntity bodega)
        {
            _context.Bodegas.Update(bodega);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(BodegaEntity bodega)
        {
            _context.Bodegas.Remove(bodega);
            return Task.CompletedTask;
        }

        public async Task<List<BodegaEntity>> GetWithSpecAsync(ISpecification<BodegaEntity> spec)
        {   
            return await SpecificationEvaluator<BodegaEntity>
                .GetQuery(_context.Bodegas.AsQueryable(), spec)
                .ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<BodegaEntity> spec)
        {
            return await _context.Bodegas.Where(spec.Criteria).CountAsync();    
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
