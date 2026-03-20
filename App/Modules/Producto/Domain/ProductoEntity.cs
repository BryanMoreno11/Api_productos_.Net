using Backend.App.Modules.Bodega.Domain;

namespace Backend.App.Modules.Producto.Domain
{
    public class ProductoEntity
{
    public int Id { get; private set; }
    public string Nombre { get;  private set; }= string.Empty;
    public int Stock {get;  private set; }
    public decimal Precio { get; private set; }
    public DateTime FechaIngreso { get; private set; }
    public int BodegaId { get; private set; }
    public virtual BodegaEntity Bodega { get; private set; } = null!;

    private ProductoEntity() { }

    public ProductoEntity(string nombre, int stock, decimal precio, DateTime fechaIngreso, int bodegaId)
    {
        validarNombre(nombre);
        validarStock(stock);
        validarPrecio(precio);
        Nombre = nombre;
        Stock = stock;
        Precio = precio;
        FechaIngreso = fechaIngreso;
        BodegaId = bodegaId;
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

        public void ActualizarProducto(string nombre, int stock, decimal precio, DateTime fechaIngreso, int bodegaId)
        {
            validarNombre(nombre);
            validarStock(stock);
            validarPrecio(precio);
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
            FechaIngreso = fechaIngreso;
            BodegaId = bodegaId;
        }
}
}


