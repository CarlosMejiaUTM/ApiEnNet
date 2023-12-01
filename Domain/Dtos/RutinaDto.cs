using System.Collections.Generic;

namespace flowfitapi.Domain.Dtos
{
    public class RutinaDto
    {
        public int Id { get; set; } = -1;
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required string Nivel { get; set; }
        public required string Duracion { get; set; }
        public required string Ejercicio { get; set; }

        public int creacion { get; set; }


    }
}