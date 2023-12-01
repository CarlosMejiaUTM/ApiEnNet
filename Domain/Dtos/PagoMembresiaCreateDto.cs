namespace Flowfitapi.Domain.Dtos
{
    public class PagoMembresiaCreateDto
    {
        public int id_membresia { get; set; }
        public int idCliente { get; set; }
        public decimal monto { get; set; }
    }
}
