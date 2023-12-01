using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class PagoMembresiaConfiguration : IEntityTypeConfiguration<PagoMembresia>
    {
        public void Configure(EntityTypeBuilder<PagoMembresia> builder)
        {
            builder.ToTable("pagos_membresias"); // Asegúrate de que coincida con el nombre de tu tabla.

            // Configuraciones de las propiedades de PagoMembresia
            builder.HasKey(e => e.id_pago_membresia).HasName("PK__pagos_membresias__id_pago_membresia");

            builder.Property(e => e.id_pago_membresia).ValueGeneratedOnAdd();

            builder.Property(e => e.id_membresia)
                .IsRequired();

            builder.Property(e => e.idCliente)
                .IsRequired();

            builder.Property(e => e.fecha)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.monto)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            // Define la relación con la tabla de membresias (clave foránea)
            builder.HasOne(e => e.Membresia)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.id_membresia)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.

            // Define la relación con la tabla de clientes (clave foránea)
            builder.HasOne(e => e.Cliente)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.idCliente)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.
        }
    }
}
