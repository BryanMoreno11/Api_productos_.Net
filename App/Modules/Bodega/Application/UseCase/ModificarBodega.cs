using Backend.App.Modules.Bodega.Domain;

namespace Backend.App.Modules.Bodega.Application.UseCase
{
    public class ModificarBodega
    {
        private readonly IBodegaRepository _repository;

        public ModificarBodega(IBodegaRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id, string nombre, string descripcion)
        {
            var bodega = await _repository.GetByIdAsync(id);
            if (bodega == null)
            {
                throw new KeyNotFoundException("Bodega no encontrada");
            }

            bodega.ActualizarBodega(nombre, descripcion);
            await _repository.UpdateAsync(bodega);
            await _repository.SaveChangesAsync();
        }
    }
}
