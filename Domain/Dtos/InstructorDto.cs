namespace flowfitapi.Domain.Dtos;

    public class InstructorDto
    {
        public int Id { get; set; } = -1;
        public string Nombre { get; set; }= null!;
        public string Apellido { get; set; }= null!;
        public string CorreoElectronico { get; set; }= null!;
        public string Contrasenia { get; set; }= null!;
        public string Especialidad { get; set; }= null!;
        public string Experiencia { get; set; }= null!;
        public string FotoPerfilUrl { get; set; } = null!;

        public int añocontratado { get; set; }
    }

