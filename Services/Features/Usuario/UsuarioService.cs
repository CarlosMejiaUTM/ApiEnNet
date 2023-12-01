using FLOWFIT;
using flowfitapi.Infrastructure.Repositories;

namespace Flowfitapi.Services.Features.Usuarios
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuarioToUpdate)
        {
            var usuario = await GetByIdAsync(usuarioToUpdate.Id);

            if (usuario.Id > 0)
                await _usuarioRepository.UpdateAsync(usuarioToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario.Id > 0)
                await _usuarioRepository.DeleteAsync(id);
        }
    }
}
