namespace Flowfitapi.Domain.Dtos
{
    public class DevolucionCancelacionCreateDto
    {
        public int id_venta { get; set; }
        public string Motivo { get; set; }  = string.Empty;
        public bool es_devolucion { get; set; }
    }
}
