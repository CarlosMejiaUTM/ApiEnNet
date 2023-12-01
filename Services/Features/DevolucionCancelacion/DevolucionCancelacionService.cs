using FLOWFIT;
using flowfitapi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Services.Features.DevolucionesCancelaciones
{
    public class DevolucionCancelacionService
    {
        private readonly DevolucionCancelacionRepository _devolucionCancelacionRepository;

        public DevolucionCancelacionService(DevolucionCancelacionRepository devolucionCancelacionRepository)
        {
            _devolucionCancelacionRepository = devolucionCancelacionRepository;
        }

        public async Task<IEnumerable<DevolucionCancelacion>> GetAllAsync()
        {
            return await _devolucionCancelacionRepository.GetAllAsync();
        }

        public async Task<DevolucionCancelacion> GetByIdAsync(int id)
        {
            return await _devolucionCancelacionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(DevolucionCancelacion devolucionCancelacion)
        {
            await _devolucionCancelacionRepository.AddAsync(devolucionCancelacion);
        }

        public async Task UpdateAsync(DevolucionCancelacion devolucionCancelacionToUpdate)
        {
            var devolucionCancelacion = await GetByIdAsync(devolucionCancelacionToUpdate.id_devolucion);

            if (devolucionCancelacion.id_devolucion > 0)
                await _devolucionCancelacionRepository.UpdateAsync(devolucionCancelacionToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var devolucionCancelacion = await GetByIdAsync(id);
            if (devolucionCancelacion != null)
            {
                await _devolucionCancelacionRepository.DeleteAsync(id);
            }
        }
    }
}
