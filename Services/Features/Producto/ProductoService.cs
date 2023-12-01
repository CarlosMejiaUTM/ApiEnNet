using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Services.Features.Productos
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _productoRepository.GetAllAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Producto producto)
        {
            await _productoRepository.AddAsync(producto);
        }

        public async Task UpdateAsync(Producto productoToUpdate)
        {
            var producto = await GetByIdAsync(productoToUpdate.id_producto);

            if (producto.id_producto > 0)
                await _productoRepository.UpdateAsync(productoToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await GetByIdAsync(id);
            if (producto != null)
            {
                await _productoRepository.DeleteAsync(id);
            }
        }
    }
}
