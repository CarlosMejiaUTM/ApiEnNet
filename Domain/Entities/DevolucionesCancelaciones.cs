using System;

namespace FLOWFIT
{
    public class DevolucionCancelacion
    {
        public int id_devolucion { get; set; }
        public DateTime? fecha { get; set; }
        public int id_venta { get; set; }
        public string? motivo { get; set; }
        public bool es_devolucion { get; set; }

        // Relación con la tabla Ventas
        public Venta Venta { get; set; }
    }
}
