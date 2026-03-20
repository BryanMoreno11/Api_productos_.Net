namespace Backend.App.Modules.Bodega.Domain
{
    public class BodegaEntity
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;

        private BodegaEntity() { }

        public BodegaEntity(string nombre, string descripcion)
        {
            validarNombre(nombre);
            validarDescripcion(descripcion);
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public void validarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        }

        public void validarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }
        }

        public void ActualizarBodega(string nombre, string descripcion)
        {
            validarNombre(nombre);
            validarDescripcion(descripcion);
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
