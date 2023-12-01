namespace Flowfitapi.Domain.Dtos
{
    public class DetalleVentaCreateDto
    {
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal total { get; set; }
    }
}
