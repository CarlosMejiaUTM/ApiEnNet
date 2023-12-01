namespace Flowfitapi.Domain.Dtos;
public class UsuarioDto
{
        public long Id { get; set; } = -1;
        public string Nombre { get; set; }= null!;
        public string Apellido { get; set; }= null!;
        public string CorreoElectronico { get; set; }= null!;
        public string Contrasenia { get; set; }= null!;
        public string Altura { get; set; }= null!;
        public string Peso { get; set; }= null!;
        public string Objetivos { get; set; }= null!;
        public int inscripcion { get; set; }

}
