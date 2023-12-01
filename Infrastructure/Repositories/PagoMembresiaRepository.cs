using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class PagoMembresiaRepository
    {
        private readonly flowfitapiDbContext _context;

        public PagoMembresiaRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PagoMembresia>> GetAllAsync()
        {
            return await _context.PagoMembresias.ToListAsync();
        }

        public async Task<PagoMembresia> GetByIdAsync(int id)
        {
            return await _context.PagoMembresias.FirstOrDefaultAsync(pago => pago.id_pago_membresia == id)
                ?? new PagoMembresia
                {
                    id_pago_membresia = -1,
                    id_membresia = 0, // Ajusta esto según tus necesidades.
                    idCliente = 0,  // Ajusta esto según tus necesidades.
                    fecha = DateTime.MinValue, // Ajusta esto según tus necesidades.
                    monto = 0.0m, // Ajusta esto según tus necesidades.
                };
        }

        public async Task AddAsync(PagoMembresia pagoMembresia)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.PagoMembresias.Add(pagoMembresia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PagoMembresia updatedPagoMembresia)
        {
            var existingPagoMembresia = await _context.PagoMembresias.FirstOrDefaultAsync(pago => pago.id_pago_membresia == updatedPagoMembresia.id_pago_membresia);

            if (existingPagoMembresia != null)
            {
                existingPagoMembresia.id_membresia = updatedPagoMembresia.id_membresia;
                existingPagoMembresia.idCliente = updatedPagoMembresia.idCliente;
                existingPagoMembresia.fecha = updatedPagoMembresia.fecha;
                existingPagoMembresia.monto = updatedPagoMembresia.monto;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var pagoMembresiaToDelete = await _context.PagoMembresias.FirstOrDefaultAsync(pago => pago.id_pago_membresia == id);

            if (pagoMembresiaToDelete != null)
            {
                _context.PagoMembresias.Remove(pagoMembresiaToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
