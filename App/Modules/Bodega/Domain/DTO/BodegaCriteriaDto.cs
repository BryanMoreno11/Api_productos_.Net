namespace Backend.App.Modules.Bodega.Domain.DTO;

public class BodegaCriteriaDto
{
    public string? Nombre { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
