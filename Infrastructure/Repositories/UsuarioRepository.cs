using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace flowfitapi.Infrastructure.Repositories
{
    public class UsuarioRepository
    {
        private readonly flowfitapiDbContext _context;

        public UsuarioRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id)
                ?? new Usuario
                {
                    Id = -1,
                    Nombre = string.Empty,
                    Apellido = string.Empty,
                    CorreoElectronico = string.Empty,
                    Contrasenia = string.Empty,
                    Altura = string.Empty,
                    Peso = string.Empty,
                    Objetivos = string.Empty
                };
        }

        public async Task AddAsync(Usuario usuario)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario updatedUsuario)
        {
            var existingUsuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == updatedUsuario.Id);

            if (existingUsuario != null)
            {
                existingUsuario.Nombre = updatedUsuario.Nombre;
                existingUsuario.Apellido = updatedUsuario.Apellido;
                existingUsuario.CorreoElectronico = updatedUsuario.CorreoElectronico;
                existingUsuario.Contrasenia = updatedUsuario.Contrasenia;
                existingUsuario.Altura = updatedUsuario.Altura;
                existingUsuario.Peso = updatedUsuario.Peso;
                existingUsuario.Objetivos = updatedUsuario.Objetivos;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var usuarioToDelete = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);

            if (usuarioToDelete != null)
            {
                _context.Usuarios.Remove(usuarioToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
