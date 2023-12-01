using System;
using System.ComponentModel.DataAnnotations;

namespace FLOWFIT
{
    public class Venta
    {
        public int id_venta { get; set; }

        [Required]
        public DateTime? fecha_venta { get; set; }

        public int idCliente { get; set; } 

        public Cliente Cliente { get; set; }
    }
}
