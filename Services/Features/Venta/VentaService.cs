using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Services.Features.Ventas
{
    public class VentaService
    {
        private readonly VentaRepository _ventaRepository;

        public VentaService(VentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await _ventaRepository.GetAllAsync();
        }

        public async Task<Venta> GetByIdAsync(int id)
        {
            return await _ventaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Venta venta)
        {
            await _ventaRepository.AddAsync(venta);
        }

        public async Task UpdateAsync(Venta ventaToUpdate)
        {
            var venta = await GetByIdAsync(ventaToUpdate.id_venta);

            if (venta.id_venta > 0)
                await _ventaRepository.UpdateAsync(ventaToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var venta = await GetByIdAsync(id);
            if (venta != null)
            {
                await _ventaRepository.DeleteAsync(id);
            }
        }
    }
}
