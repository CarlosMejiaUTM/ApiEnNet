using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class MembresiaRepository
    {
        private readonly flowfitapiDbContext _context;

        public MembresiaRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Membresia>> GetAllAsync()
        {
            return await _context.Membresias.ToListAsync();
        }

        public async Task<Membresia> GetByIdAsync(int id)
        {
            return await _context.Membresias.FirstOrDefaultAsync(membresia => membresia.id_membresia == id)
                ?? new Membresia
                {
                    id_membresia = -1,
                    Nombre = string.Empty,
                    Fecha_Inicio = DateTime.MinValue,
                    Fecha_Fin = DateTime.MinValue
                };
        }

        public async Task AddAsync(Membresia membresia)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Membresias.Add(membresia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Membresia updatedMembresia)
        {
            var existingMembresia = await _context.Membresias.FirstOrDefaultAsync(membresia => membresia.id_membresia == updatedMembresia.id_membresia);

            if (existingMembresia != null)
            {
                existingMembresia.Nombre = updatedMembresia.Nombre;
                existingMembresia.Fecha_Inicio = updatedMembresia.Fecha_Inicio;
                existingMembresia.Fecha_Fin = updatedMembresia.Fecha_Fin;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var membresiaToDelete = await _context.Membresias.FirstOrDefaultAsync(membresia => membresia.id_membresia == id);

            if (membresiaToDelete != null)
            {
                _context.Membresias.Remove(membresiaToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
