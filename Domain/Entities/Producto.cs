using System;

namespace FLOWFIT
{
    public class Producto
    {
        public int id_producto { get; set; }
        
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public string? Imagen { get; set; }

        public int id_proveedor { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}
