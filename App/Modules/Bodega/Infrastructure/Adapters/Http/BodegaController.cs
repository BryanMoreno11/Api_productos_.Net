using Backend.App.Modules.Bodega.Application.UseCase;
using Backend.App.Modules.Bodega.Domain;
using Backend.App.Modules.Bodega.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.App.Modules.Bodega.Infrastructure.Adapters.Http
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        private readonly ObtenerBodegas _obtenerTodosUseCase;
        private readonly ObtenerBodega _obtenerUnoUseCase;
        private readonly AgregarBodega _agregarUseCase;
        private readonly ModificarBodega _modificarUseCase;
        private readonly EliminarBodega _eliminarUseCase;
        private readonly ObtenerBodegasPaginados _obtenerPaginadoUseCase;

        public BodegaController(
            ObtenerBodegas obtenerTodosUseCase,
            ObtenerBodega obtenerUnoUseCase,
            AgregarBodega agregarUseCase,
            ModificarBodega modificarUseCase,
            EliminarBodega eliminarUseCase,
            ObtenerBodegasPaginados obtenerPaginadoUseCase)
        {
            _obtenerTodosUseCase = obtenerTodosUseCase;
            _obtenerUnoUseCase = obtenerUnoUseCase;
            _agregarUseCase = agregarUseCase;
            _modificarUseCase = modificarUseCase;
            _eliminarUseCase = eliminarUseCase;
            _obtenerPaginadoUseCase= obtenerPaginadoUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _obtenerTodosUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _obtenerUnoUseCase.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpGet("listar-paginado")]
        public async Task<IActionResult> GetPaginado([FromQuery] BodegaCriteriaDto criteria)
        {
            var result = await _obtenerPaginadoUseCase.ExecuteAsync(criteria);
            return Ok(result);
        }

        [HttpPost("crear-bodega")]
        public async Task<IActionResult> Crear([FromBody] CrearBodegaDto dto)
        {
            await _agregarUseCase.ExecuteAsync(dto);
            return Ok(new { mensaje = "Bodega insertada con éxito" });
        }

        [HttpPut("modificar-bodega/{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] ModificarBodegaDto dto)
        {
            await _modificarUseCase.ExecuteAsync(id, dto.Nombre, dto.Descripcion);
            return Ok(new { mensaje = "Bodega modificada con éxito" });
        }

        [HttpDelete("eliminar-bodega/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _eliminarUseCase.ExecuteAsync(id);
            return Ok(new { mensaje = "Bodega eliminada con éxito" });
        }
    }
}
