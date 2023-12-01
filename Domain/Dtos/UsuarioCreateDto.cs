namespace Flowfitapi.Library.Domain.Dtos;

public class UsuarioCreateDto
{   
    public string Nombre { get; set; }= null!;
    public string Apellido { get; set; }= null!;
    public string CorreoElectronico { get; set; }= null!;
    public string Contrasenia { get; set; }= null!;
    public string Altura { get; set; }= null!;
    public string Peso { get; set; }= null!;
    public string Objetivos { get; set; }= null!;
}

