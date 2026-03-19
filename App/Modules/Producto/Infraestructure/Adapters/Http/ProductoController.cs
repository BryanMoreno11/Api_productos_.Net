using Backend.App.Modules.Producto.Application.UseCase;
using Backend.App.Modules.Producto.Domain;
using Backend.App.Modules.Producto.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend.App.Modules.Producto.Infrastructure.Adapters.Http
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ObtenerProductos _obtenerTodosUseCase;
        private readonly ObtenerProducto _obtenerUnoUseCase;
        private readonly AgregarProducto _agregarUseCase;
        private readonly ModificarProducto _modificarUseCase;
        private readonly EliminarProducto _eliminarUseCase;
        private readonly ObtenerProductosPaginados _obtenerPaginadoUseCase;

        public ProductoController(
            ObtenerProductos obtenerTodosUseCase,
            ObtenerProducto obtenerUnoUseCase,
            AgregarProducto agregarUseCase,
            ModificarProducto modificarUseCase,
            EliminarProducto eliminarUseCase,
            ObtenerProductosPaginados obtenerPaginadoUseCase)
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _obtenerUnoUseCase.ExecuteAsync(id);
            return Ok(result);
        }

        [HttpGet("listar-paginado")]
        public async Task<IActionResult> GetPaginado([FromQuery] ProductoCriteriaDto criteria)
        {
            var result = await _obtenerPaginadoUseCase.ExecuteAsync(criteria);
            return Ok(result);
        }

        [HttpPost("crear-producto")]
        public async Task<IActionResult> Crear([FromBody] ProductoDto dto)
        {
            await _agregarUseCase.ExecuteAsync(dto);
            return Ok(new { mensaje = "Producto insertado con éxito" });
        }

        [HttpPut("modificar-producto/{id}")]
        public async Task<IActionResult> Modificar(Guid id, [FromBody] ProductoDto dto)
        {
            await _modificarUseCase.ExecuteAsync(id, dto.Nombre, dto.Stock, dto.Precio);
            return Ok(new { mensaje = "Producto modificado con éxito" });
        }

        [HttpDelete("eliminar-producto/{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            await _eliminarUseCase.ExecuteAsync(id);
            return Ok(new { mensaje = "Producto eliminado con éxito" });
        }
    }
}