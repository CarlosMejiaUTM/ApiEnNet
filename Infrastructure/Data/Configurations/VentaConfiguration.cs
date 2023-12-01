using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Ventas"); // Asegúrate de que coincida con el nombre de tu tabla.

            // Configuraciones de las propiedades de Venta
            builder.HasKey(e => e.id_venta).HasName("PK__Ventas__id_venta");

            builder.Property(e => e.id_venta).ValueGeneratedOnAdd();

            builder.Property(e => e.fecha_venta)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.idCliente)
                .IsRequired();

            // Define la relación con la tabla de clientes (clave foránea)
            builder.HasOne(e => e.Cliente)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.idCliente)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.
        }
    }
}
