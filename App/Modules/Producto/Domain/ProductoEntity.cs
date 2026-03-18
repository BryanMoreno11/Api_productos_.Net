namespace Backend.App.Modules.Producto.Domain
{
    public class ProductoEntity
{
    public Guid Id { get; private set; }
    public string Nombre { get;  private set; }= string.Empty;
    public int Stock {get;  private set; }
    public decimal Precio { get; private set; }
    private ProductoEntity() { }
    public ProductoEntity(Guid id, string nombre, int stock, decimal precio)
    {
        validarNombre(nombre);
        validarStock(stock);
        validarPrecio(precio);
        Id = id;
        Nombre = nombre;
        Stock = stock;
        Precio = precio;
    }

    public void validarStock(int stock)
        {
            if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }
        }

        public void validarPrecio(decimal precio)
        {
            if (precio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }
        }

        public void validarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        }
}
}


