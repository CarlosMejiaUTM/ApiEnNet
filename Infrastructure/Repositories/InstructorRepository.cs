using Microsoft.EntityFrameworkCore;
using flowfitapi.Infrastructure.Data;
using FLOWFIT;

namespace flowfitapi.Infrastructure.Repositories
{
    public class InstructorRepository
    {
        private readonly flowfitapiDbContext _context;

        public InstructorRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _context.Instructores.ToListAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _context.Instructores.FirstOrDefaultAsync(instructor => instructor.Id == id)
                ?? new Instructor
                {
                    Id = -1,
                    Nombre = string.Empty,
                    Apellido = string.Empty,
                    CorreoElectronico = string.Empty,
                    Contrasenia = string.Empty,
                    Especialidad = string.Empty,
                    Experiencia = string.Empty,
                    FotoPerfilUrl = string.Empty
                };
        }

        public async Task AddAsync(Instructor instructor)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Instructores.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor updatedInstructor)
        {
            var existingInstructor = await _context.Instructores.FirstOrDefaultAsync(instructor => instructor.Id == updatedInstructor.Id);

            if (existingInstructor != null)
            {
                existingInstructor.Nombre = updatedInstructor.Nombre;
                existingInstructor.Apellido = updatedInstructor.Apellido;
                existingInstructor.CorreoElectronico = updatedInstructor.CorreoElectronico;
                existingInstructor.Contrasenia = updatedInstructor.Contrasenia;
                existingInstructor.Especialidad = updatedInstructor.Especialidad;
                existingInstructor.Experiencia = updatedInstructor.Experiencia;
                existingInstructor.FotoPerfilUrl = updatedInstructor.FotoPerfilUrl;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var instructorToDelete = await _context.Instructores.FirstOrDefaultAsync(instructor => instructor.Id == id);

            if (instructorToDelete != null)
            {
                _context.Instructores.Remove(instructorToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
