namespace Backend.App.Modules.Producto.Domain.DTO;

public class ProductoCriteriaDto
{
    public string? Nombre { get; set; }
    public int? StockMinimo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}