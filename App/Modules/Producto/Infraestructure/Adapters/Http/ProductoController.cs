using Backend.App.Modules.Producto.Application.UseCase;
using Backend.App.Modules.Producto.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Backend.App.Modules.Producto.Infrastructure.Adapters.Http
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ObtenerProductos _obtenerUseCase;
        private readonly AgregarProducto _agregarUseCase;

        public ProductoController(ObtenerProductos useCase, AgregarProducto agregarUseCase)
        {
            _obtenerUseCase = useCase;
            _agregarUseCase = agregarUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _obtenerUseCase.ExecuteAsync();
            return Ok(result);
        }

        [HttpPost("crear-producto")]
        public async Task<IActionResult> Crear([FromBody] ProductoDto dto)
        {
            await _agregarUseCase.ExecuteAsync(dto);
            return Ok(new { mensaje = "Producto insertado con éxito" });
        }
    }
}