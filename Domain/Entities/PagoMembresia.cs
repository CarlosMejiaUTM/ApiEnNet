using System;

namespace FLOWFIT
{
    public class PagoMembresia
    {
        public int id_pago_membresia { get; set; }
        public int id_membresia { get; set; }
        public int idCliente { get; set; }
        public DateTime? fecha { get; set; }
        public decimal monto { get; set; }

        // Relación con la tabla Membresias 
        public Membresia Membresia { get; set; }

        // Relación con la tabla Clientes
        public Cliente Cliente { get; set; }
    }
}
