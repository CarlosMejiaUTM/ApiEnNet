using FLOWFIT;
using flowfitapi.Infrastructure.Repositories;

namespace Flowfitapi.Services.Features.Rutinas
{
    public class RutinaService
    {
        private readonly RutinaRepository _rutinaRepository;

        public RutinaService(RutinaRepository rutinaRepository)
        {
            _rutinaRepository = rutinaRepository;
        }

        public async Task<IEnumerable<Rutina>> GetAllAsync()
        {
            return await _rutinaRepository.GetAllAsync();
        }

        public async Task<Rutina> GetByIdAsync(int id)
        {
            return await _rutinaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Rutina rutina)
        {
            await _rutinaRepository.AddAsync(rutina);
        }

        public async Task UpdateAsync(Rutina rutinaToUpdate)
        {
            var rutina = await GetByIdAsync(rutinaToUpdate.Id);

            if (rutina.Id > 0)
                await _rutinaRepository.UpdateAsync(rutinaToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var rutina = await GetByIdAsync(id);
            if (rutina.Id > 0)
                await _rutinaRepository.DeleteAsync(id);
        }
    }
}
