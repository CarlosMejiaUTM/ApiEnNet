using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores"); // Reemplaza "NombreDeTuTabla" con el nombre de la tabla que deseas.

            // Configuraciones de las propiedades de Proveedor
            builder.HasKey(e => e.id_proveedor).HasName("PK__Proveedores__id_proveedor");

            builder.Property(e => e.id_proveedor).ValueGeneratedOnAdd();

            builder.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
