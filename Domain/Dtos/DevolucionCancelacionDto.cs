namespace Flowfitapi.Domain.Dtos
{
    public class DevolucionCancelacionDto
    {
        public int id_devolucion { get; set; } = -1;
        public int Fechadev { get; set; }
        public int id_venta { get; set; }
        public string Motivo { get; set; }= string.Empty;
        public bool es_devolucion { get; set; }
    }
}
