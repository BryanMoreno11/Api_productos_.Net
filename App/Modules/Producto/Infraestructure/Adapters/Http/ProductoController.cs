using Backend.App.Modules.Producto.Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Backend.App.Modules.Producto.Infrastructure.Adapters.Http
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoGetAll _useCase;

        public ProductoController(ProductoGetAll useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _useCase.ExecuteAsync();
            return Ok(result);
        }
    }
}