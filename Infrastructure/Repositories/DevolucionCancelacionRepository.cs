using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class DevolucionCancelacionRepository
    {
        private readonly flowfitapiDbContext _context;

        public DevolucionCancelacionRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DevolucionCancelacion>> GetAllAsync()
        {
            return await _context.DevolucionesCancelaciones.ToListAsync();
        }

        public async Task<DevolucionCancelacion> GetByIdAsync(int id)
        {
            return await _context.DevolucionesCancelaciones.FirstOrDefaultAsync(dc => dc.id_devolucion == id)
                ?? new DevolucionCancelacion
                {
                    id_devolucion = -1,
                    fecha = DateTime.MinValue,
                    id_venta = 0,
                    motivo = string.Empty,
                    es_devolucion = false
                };
        }

        public async Task AddAsync(DevolucionCancelacion devolucionCancelacion)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.DevolucionesCancelaciones.Add(devolucionCancelacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DevolucionCancelacion updatedDevolucionCancelacion)
        {
            var existingDevolucionCancelacion = await _context.DevolucionesCancelaciones.FirstOrDefaultAsync(dc => dc.id_devolucion == updatedDevolucionCancelacion.id_devolucion);

            if (existingDevolucionCancelacion != null)
            {
                existingDevolucionCancelacion.fecha = updatedDevolucionCancelacion.fecha;
                existingDevolucionCancelacion.id_venta = updatedDevolucionCancelacion.id_venta;
                existingDevolucionCancelacion.motivo = updatedDevolucionCancelacion.motivo;
                existingDevolucionCancelacion.es_devolucion = updatedDevolucionCancelacion.es_devolucion;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var devolucionCancelacionToDelete = await _context.DevolucionesCancelaciones.FirstOrDefaultAsync(dc => dc.id_devolucion == id);

            if (devolucionCancelacionToDelete != null)
            {
                _context.DevolucionesCancelaciones.Remove(devolucionCancelacionToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
