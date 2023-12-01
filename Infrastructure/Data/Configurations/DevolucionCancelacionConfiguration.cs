using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class DevolucionCancelacionConfiguration : IEntityTypeConfiguration<DevolucionCancelacion>
    {
        public void Configure(EntityTypeBuilder<DevolucionCancelacion> builder)
        {
            builder.ToTable("devoluciones_y_cancelaciones"); // Asegúrate de que coincida con el nombre de tu tabla.

            // Configuraciones de las propiedades de DevolucionCancelacion
            builder.HasKey(e => e.id_devolucion).HasName("PK__DevolucionesCancelaciones__id_devolucion");

            builder.Property(e => e.id_devolucion).ValueGeneratedOnAdd();

            builder.Property(e => e.fecha)
                .IsRequired();

            builder.Property(e => e.id_venta)
                .IsRequired();

            builder.Property(e => e.motivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.es_devolucion)
                .IsRequired();

            // Define la relación con la tabla de ventas (clave foránea)
            builder.HasOne(e => e.Venta)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.id_venta)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.
        }
    }
}
