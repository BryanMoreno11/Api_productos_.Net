namespace Backend.App.Modules.Bodega.Domain.DTO
{
    public class BodegaDto
    {
        public int? Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public BodegaEntity GetEntity()
        {
            return new BodegaEntity(
                this.Nombre,
                this.Descripcion
            );
        }

        public static BodegaDto FromEntity(BodegaEntity entity)
        {
            return new BodegaDto
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion
            };
        }
    }
}
