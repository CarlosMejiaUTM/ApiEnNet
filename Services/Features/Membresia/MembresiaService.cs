using FLOWFIT;
using flowfitapi.Infrastructure.Repositories; // Asegúrate de tener la referencia correcta
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Services.Features.Membresias
{
    public class MembresiaService
    {
        private readonly MembresiaRepository _membresiaRepository;

        public MembresiaService(MembresiaRepository membresiaRepository)
        {
            _membresiaRepository = membresiaRepository;
        }

        public async Task<IEnumerable<Membresia>> GetAllAsync()
        {
            return await _membresiaRepository.GetAllAsync();
        }

        public async Task<Membresia> GetByIdAsync(int id)
        {
            return await _membresiaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Membresia membresia)
        {
            await _membresiaRepository.AddAsync(membresia);
        }

        public async Task UpdateAsync(Membresia membresiaToUpdate)
        {
            var membresia = await GetByIdAsync(membresiaToUpdate.id_membresia);

            if (membresia.id_membresia > 0)
                await _membresiaRepository.UpdateAsync(membresiaToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var membresia = await GetByIdAsync(id);
            if (membresia != null)
            {
                await _membresiaRepository.DeleteAsync(id);
            }
        }
    }
}
