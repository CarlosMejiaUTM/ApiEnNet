using FLOWFIT;
using Microsoft.EntityFrameworkCore;
using flowfitapi.Infrastructure.Data;

namespace flowfitapi.Infrastructure.Repositories
{
    public class ProveedorRepository
    {
        private readonly flowfitapiDbContext _context;

        public ProveedorRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(proveedor => proveedor.id_proveedor == id)
                ?? new Proveedor
                {
                    id_proveedor = -1,
                    Nombre = string.Empty,
                    Contacto = string.Empty,
                    Direccion = string.Empty
                };
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Proveedor updatedProveedor)
        {
            var existingProveedor = await _context.Proveedores.FirstOrDefaultAsync(proveedor => proveedor.id_proveedor == updatedProveedor.id_proveedor);

            if (existingProveedor != null)
            {
                existingProveedor.Nombre = updatedProveedor.Nombre;
                existingProveedor.Contacto = updatedProveedor.Contacto;
                existingProveedor.Direccion = updatedProveedor.Direccion;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var proveedorToDelete = await _context.Proveedores.FirstOrDefaultAsync(proveedor => proveedor.id_proveedor == id);

            if (proveedorToDelete != null)
            {
                _context.Proveedores.Remove(proveedorToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
