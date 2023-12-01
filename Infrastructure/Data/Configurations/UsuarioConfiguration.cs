using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios"); // Reemplaza "NombreDeTuTabla" con el nombre de la tabla que deseas.

            // Configuraciones de las propiedades de Usuario
            builder.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07D7862D8C");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Altura)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Fechainscripcion).HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Objetivos)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Peso)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
