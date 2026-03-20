namespace Backend.App.Modules.Producto.Domain
{
    public class ProductoDto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int BodegaId { get; set; }
        public string BodegaNombre { get; set; } = string.Empty;

        public ProductoEntity GetEntity()
        {
            return new ProductoEntity(
                this.Nombre,
                this.Stock,
                this.Precio,
                this.FechaIngreso,
                this.BodegaId
            );
        }
        public ProductoDto FromEntity(ProductoEntity entity)
        {
            return new ProductoDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Precio = entity.Precio,
                Stock = entity.Stock,
                FechaIngreso = entity.FechaIngreso,
                BodegaId = entity.BodegaId,
                BodegaNombre = entity.Bodega?.Nombre ?? string.Empty
            };
        }
    }
}