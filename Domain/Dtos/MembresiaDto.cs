namespace Flowfitapi.Domain.Dtos
{
    public class MembresiaDto
    {
        public int id_membresia { get; set; } = -1;
        public string Nombre { get; set; } = string.Empty;
        public DateTime? Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
    }
}
