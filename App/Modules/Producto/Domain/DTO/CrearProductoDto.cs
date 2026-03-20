namespace Backend.App.Modules.Producto.Domain.DTO
{
    public class CrearProductoDto
    {
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int BodegaId { get; set; }
    }
}
