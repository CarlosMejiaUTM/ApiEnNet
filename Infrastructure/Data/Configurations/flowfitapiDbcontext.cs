using FLOWFIT;
using Microsoft.EntityFrameworkCore;

namespace flowfitapi.Infrastructure.Data
{
    public partial class flowfitapiDbContext : DbContext
    {
        public flowfitapiDbContext()
        {
        }

        public flowfitapiDbContext(DbContextOptions<flowfitapiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instructor> Instructores { get; set; }
        public virtual DbSet<Rutina> Rutinas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }
        public virtual DbSet<DevolucionCancelacion> DevolucionesCancelaciones { get; set; }
        public virtual DbSet<Membresia> Membresias { get; set; }
        public virtual DbSet<PagoMembresia> PagoMembresias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new RutinaConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new ProveedorConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new VentaConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleVentaConfiguration());
            modelBuilder.ApplyConfiguration(new DevolucionCancelacionConfiguration());
            modelBuilder.ApplyConfiguration(new MembresiaConfiguration());
            modelBuilder.ApplyConfiguration(new PagoMembresiaConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
