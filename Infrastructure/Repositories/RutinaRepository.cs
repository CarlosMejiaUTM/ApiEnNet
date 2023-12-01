using Microsoft.EntityFrameworkCore;
using flowfitapi.Infrastructure.Data;
using FLOWFIT;

namespace flowfitapi.Infrastructure.Repositories
{
    public class RutinaRepository
    {
        private readonly flowfitapiDbContext _context;

        public RutinaRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rutina>> GetAllAsync()
        {
            return await _context.Rutinas.ToListAsync();
        }

        public async Task<Rutina> GetByIdAsync(int id)
        {
            return await _context.Rutinas.FirstOrDefaultAsync(rutina => rutina.Id == id)
                ?? new Rutina
                {
                    Id = -1,
                    Nombre = string.Empty,
                    Descripcion= string.Empty,
                    Nivel = string.Empty,
                    Duracion = string.Empty,
                    Ejercicio = string.Empty

                    
                };
        }

        public async Task AddAsync(Rutina rutina)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Rutinas.Add(rutina);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rutina updatedrutina)
        {
            var existingrutina = await _context.Rutinas.FirstOrDefaultAsync(rutina => rutina.Id == updatedrutina.Id);

            if (existingrutina != null)
            {
                existingrutina.Nombre = updatedrutina.Nombre;
                existingrutina.Descripcion = updatedrutina.Descripcion;
                existingrutina.Nivel = updatedrutina.Nivel;
                existingrutina.Duracion = updatedrutina.Duracion;
                existingrutina.Ejercicio = updatedrutina.Ejercicio;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var rutinaToDelete = await _context.Rutinas.FirstOrDefaultAsync(rutina => rutina.Id == id);

            if (rutinaToDelete != null)
            {
                _context.Rutinas.Remove(rutinaToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
