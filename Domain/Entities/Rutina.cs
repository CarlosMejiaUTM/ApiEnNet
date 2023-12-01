using System;
using System.Collections.Generic;

namespace FLOWFIT;

public partial class Rutina
{
    public int Id { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Descripcion { get; set; } = null!;

    public string? Nivel { get; set; } = null!;

    public string? Duracion { get; set; } = null!;

    public string? Ejercicio { get; set; } = null!;

    public DateTime? Fechacreacioon { get; set; }
}
