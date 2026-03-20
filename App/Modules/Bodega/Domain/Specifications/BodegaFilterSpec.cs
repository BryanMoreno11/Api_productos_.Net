using Backend.App.Shared.Domain.Specifications;

namespace Backend.App.Modules.Bodega.Domain.Specifications;

public class BodegaFilterSpec : BaseSpecification<BodegaEntity>
{
    public BodegaFilterSpec(string? nombre, int page, int pageSize) 
        : base(x => 
            (string.IsNullOrEmpty(nombre) || x.Nombre.ToLower().Contains(nombre.ToLower()))
        )
    {
        ApplyPaging((page - 1) * pageSize, pageSize);
    }
}
