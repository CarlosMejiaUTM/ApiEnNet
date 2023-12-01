using System;
using System.Collections.Generic;

namespace FLOWFIT;

public partial class Instructor
{
    public int Id { get; set; }
   
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasenia { get; set; }

    public string? Especialidad { get; set; }

    public string? Experiencia { get; set; }

    public string? FotoPerfilUrl { get; set; }

    public DateTime? FechaInscripcion { get; set; }
}
