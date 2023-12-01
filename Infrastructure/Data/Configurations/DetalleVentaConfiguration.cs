using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("detalle_ventas"); // Asegúrate de que coincida con el nombre de tu tabla.

            // Configuraciones de las propiedades de DetalleVenta
            builder.HasKey(e => e.id_detalle).HasName("PK__detalle_ventas__id_detalle");

            builder.Property(e => e.id_detalle).ValueGeneratedOnAdd();

            builder.Property(e => e.id_venta).IsRequired();

            builder.Property(e => e.id_producto).IsRequired();

            builder.Property(e => e.cantidad).IsRequired();

            builder.Property(e => e.precio_unitario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.total)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            // Define las relaciones con las tablas de ventas y productos (claves foráneas)
            builder.HasOne(e => e.Venta)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.id_venta)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.

            builder.HasOne(e => e.Producto)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.id_producto)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.
        }
    }
}
