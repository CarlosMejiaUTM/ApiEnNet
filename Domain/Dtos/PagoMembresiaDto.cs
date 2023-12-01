namespace Flowfitapi.Domain.Dtos
{
    public class PagoMembresiaDto
    {
        public int id_pago_membresia { get; set; } = -1;
        public int id_membresia { get; set; }
        public int idCliente { get; set; }
        public int fechamembresia { get; set; }
        public decimal monto { get; set; }
    }
}
