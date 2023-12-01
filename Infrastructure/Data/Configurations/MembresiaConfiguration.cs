using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class MembresiaConfiguration : IEntityTypeConfiguration<Membresia>
    {
        public void Configure(EntityTypeBuilder<Membresia> builder)
        {
            builder.ToTable("membresias"); // Asegúrate de que coincida con el nombre de tu tabla.

            builder.HasKey(e => e.id_membresia).HasName("PK__Membresias__id_membresia");

            builder.Property(e => e.id_membresia).ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Fecha_Inicio)
                .IsRequired();

            builder.Property(e => e.Fecha_Fin)
                .IsRequired();
        }
    }
}
