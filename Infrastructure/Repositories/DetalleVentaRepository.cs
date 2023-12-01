using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class DetalleVentaRepository
    {
        private readonly flowfitapiDbContext _context;

        public DetalleVentaRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleVenta>> GetAllAsync()
        {
            return await _context.DetalleVentas.ToListAsync();
        }

        public async Task<DetalleVenta> GetByIdAsync(int id)
        {
            return await _context.DetalleVentas.FirstOrDefaultAsync(detalleVenta => detalleVenta.id_detalle == id)
                ?? new DetalleVenta
                {
                    id_detalle = -1,
                    id_venta = 0, // Cambia esto según tus necesidades.
                    id_producto = 0, // Cambia esto según tus necesidades.
                    cantidad = 0,
                    precio_unitario = 0.0m,
                    total = 0.0m
                };
        }

        public async Task AddAsync(DetalleVenta detalleVenta)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.DetalleVentas.Add(detalleVenta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DetalleVenta updatedDetalleVenta)
        {
            var existingDetalleVenta = await _context.DetalleVentas.FirstOrDefaultAsync(detalleVenta => detalleVenta.id_detalle == updatedDetalleVenta.id_detalle);

            if (existingDetalleVenta != null)
            {
                existingDetalleVenta.id_venta = updatedDetalleVenta.id_venta;
                existingDetalleVenta.id_producto = updatedDetalleVenta.id_producto;
                existingDetalleVenta.cantidad = updatedDetalleVenta.cantidad;
                existingDetalleVenta.precio_unitario = updatedDetalleVenta.precio_unitario;
                existingDetalleVenta.total = updatedDetalleVenta.total;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var detalleVentaToDelete = await _context.DetalleVentas.FirstOrDefaultAsync(detalleVenta => detalleVenta.id_detalle == id);

            if (detalleVentaToDelete != null)
            {
                _context.DetalleVentas.Remove(detalleVentaToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
