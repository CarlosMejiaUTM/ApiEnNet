using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructores"); // Reemplaza "NombreDeTuTabla" con el nombre de la tabla que deseas.

            // Configuraciones de las propiedades de Instructor
             builder.HasKey(e => e.Id).HasName("PK__Instructores__3214EC07D7862D8C");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Contrasenia)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Experiencia)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.FechaInscripcion).HasColumnType("date");

            builder.Property(e => e.FotoPerfilUrl)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
