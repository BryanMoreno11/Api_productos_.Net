using Backend.App.Shared.Domain.Specifications;

namespace Backend.App.Modules.Producto.Domain.Specifications;

public class ProductoFilterSpec : BaseSpecification<ProductoEntity>
{
    public ProductoFilterSpec(string? nombre, int? stockMin, int page, int pageSize) 
        : base(x => 
            (string.IsNullOrEmpty(nombre) || x.Nombre.ToLower().Contains(nombre.ToLower())) &&
            (!stockMin.HasValue || x.Stock >= stockMin.Value)
        )
    {
        ApplyPaging((page - 1) * pageSize, pageSize);
    }
}