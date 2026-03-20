using Backend.App.Shared.Domain.Specifications;

namespace Backend.App.Modules.Bodega.Domain
{
    public interface IBodegaRepository
    {
        Task<List<BodegaEntity>> GetAllAsync();
        Task<BodegaEntity?> GetByIdAsync(int id);
        Task AddAsync(BodegaEntity bodega);
        Task UpdateAsync(BodegaEntity bodega);
        Task DeleteAsync(BodegaEntity bodega);
        Task SaveChangesAsync();
        Task<List<BodegaEntity>> GetWithSpecAsync(ISpecification<BodegaEntity> spec);
        Task<int> CountAsync(ISpecification<BodegaEntity> spec);
    }
}
