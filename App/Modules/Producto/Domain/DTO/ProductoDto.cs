namespace Backend.App.Modules.Producto.Domain
{
    public class ProductoDto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public ProductoEntity GetEntity()
        {
            return new ProductoEntity(
                this.Nombre,
                this.Stock,
                this.Precio
            );
        }
        public ProductoDto FromEntity(ProductoEntity entity)
        {
            return new ProductoDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Precio = entity.Precio,
                Stock = entity.Stock
            };
        }
    }
}