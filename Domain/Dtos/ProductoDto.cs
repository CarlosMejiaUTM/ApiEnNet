namespace Flowfitapi.Domain.Dtos
{
    public class ProductoDto
    {
        public int id_producto { get; set; } = -1;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public int id_proveedor { get; set; }
    }
}
