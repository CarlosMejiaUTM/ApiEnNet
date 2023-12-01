using System;
using System.Collections.Generic;

namespace FLOWFIT;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasenia { get; set; }

    public string? Altura { get; set; }

    public string? Peso { get; set; }

    public string? Objetivos { get; set; }

    public DateTime? Fechainscripcion { get; set; }
}
