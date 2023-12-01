using System.Collections.Generic;

namespace flowfitapi.Domain.Dtos
{
    public class RutinaCreateDto
    {

        public  string Nombre { get; set; }= null!;
        public  string Descripcion { get; set; }= null!;
        public  string Nivel { get; set; }= null!;
        public  string Duracion { get; set; }= null!;
        public  string Ejercicio { get; set; }= null!;
    }
}