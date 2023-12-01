using System;

namespace FLOWFIT
{
    public class DetalleVenta
    {
        public int id_detalle { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public decimal total { get; set; }

        // Relación con la tabla Ventas 
        public Venta Venta { get; set; }

        // Relación con la tabla Productos
        public Producto Producto { get; set; }
    }
}
