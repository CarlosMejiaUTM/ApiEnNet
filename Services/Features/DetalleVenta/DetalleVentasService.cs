using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Services.Features.DetalleVentas
{
    public class DetalleVentaService
    {
        private readonly DetalleVentaRepository _detalleVentaRepository;

        public DetalleVentaService(DetalleVentaRepository detalleVentaRepository)
        {
            _detalleVentaRepository = detalleVentaRepository;
        }

        public async Task<IEnumerable<DetalleVenta>> GetAllAsync()
        {
            return await _detalleVentaRepository.GetAllAsync();
        }

        public async Task<DetalleVenta> GetByIdAsync(int id)
        {
            return await _detalleVentaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(DetalleVenta detalleVenta)
        {
            await _detalleVentaRepository.AddAsync(detalleVenta);
        }

        public async Task UpdateAsync(DetalleVenta detalleVentaToUpdate)
        {
            var detalleVenta = await GetByIdAsync(detalleVentaToUpdate.id_detalle);

            if (detalleVenta.id_detalle > 0)
                await _detalleVentaRepository.UpdateAsync(detalleVentaToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var detalleVenta = await GetByIdAsync(id);
            if (detalleVenta != null)
            {
                await _detalleVentaRepository.DeleteAsync(id);
            }
        }
    }
}
