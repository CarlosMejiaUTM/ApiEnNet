using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flowfitapi.Infrastructure.Data
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos"); // Asegúrate de que coincida con el nombre de tu tabla.

            // Configuraciones de las propiedades de Producto
            builder.HasKey(e => e.id_producto).HasName("PK__Productos__id_producto");

            builder.Property(e => e.id_producto).ValueGeneratedOnAdd();

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Precio)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.id_proveedor)
                .IsRequired();

            // Define la relación con la tabla de proveedores (clave foránea)
            builder.HasOne(e => e.Proveedor)
                .WithMany() // Ajusta esto según tu modelo de datos.
                .HasForeignKey(e => e.id_proveedor)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta la acción de eliminación según tus necesidades.
        }
    }
}
