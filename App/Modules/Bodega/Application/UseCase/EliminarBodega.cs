using Backend.App.Modules.Bodega.Domain;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class EliminarBodega
    {
        private readonly IBodegaRepository _repository;

        public EliminarBodega(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            var bodega = await _repository.GetByIdAsync(id);
            if (bodega == null)
            {
                throw new KeyNotFoundException("Bodega no encontrada");
            }

            await _repository.DeleteAsync(bodega);
            await _repository.SaveChangesAsync();
        }
    }
}
