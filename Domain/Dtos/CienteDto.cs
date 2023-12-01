namespace FLOWFIT
{
    public class ClienteDto
    {
        public int idCliente { get; set; } = -1; // Cambiado de "id_proveedor" a "ClaveElector"
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
