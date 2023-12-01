using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class VentaRepository
    {
        private readonly flowfitapiDbContext _context;

        public VentaRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _context.Ventas.ToListAsync();
        }

        public async Task<Venta> GetByIdAsync(int id)
        {
            return await _context.Ventas.FirstOrDefaultAsync(venta => venta.id_venta == id)
                ?? new Venta
                {
                    id_venta = -1,
                    fecha_venta = default, // Ajusta esto según tus necesidades.
                    idCliente = 0 // Cambia esto según tus necesidades.
                };
        }

        public async Task AddAsync(Venta venta)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Venta updatedVenta)
        {
            var existingVenta = await _context.Ventas.FirstOrDefaultAsync(venta => venta.id_venta == updatedVenta.id_venta);

            if (existingVenta != null)
            {
                existingVenta.fecha_venta = updatedVenta.fecha_venta;
                existingVenta.idCliente = updatedVenta.idCliente; // Ajusta esto según tu modelo de datos.

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var ventaToDelete = await _context.Ventas.FirstOrDefaultAsync(venta => venta.id_venta == id);

            if (ventaToDelete != null)
            {
                _context.Ventas.Remove(ventaToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
