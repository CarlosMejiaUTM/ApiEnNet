using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class RutinaConfiguration : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutinas"); // Reemplaza "NombreDeTuTabla" con el nombre de la tabla que deseas.

            // Configuraciones de las propiedades de Rutina
            builder.HasKey(e => e.Id).HasName("PK__Rutinas__3214EC071C8A1B78");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Descripcion).HasMaxLength(255);
            builder.Property(e => e.Duracion).HasMaxLength(255);
            builder.Property(e => e.Fechacreacioon).HasColumnType("datetime");
            builder.Property(e => e.Nivel).HasMaxLength(255);
            builder.Property(e => e.Nombre).HasMaxLength(255);
        }
    }
}
