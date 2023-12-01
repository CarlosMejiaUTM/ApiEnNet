using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories; // Asegúrate de tener la referencia correcta

namespace Flowfitapi.Services.Features.Proveedores // Cambia el nombre del namespace
{
    public class ProveedorService // Cambia el nombre de la clase
    {
        private readonly ProveedorRepository _proveedorRepository; // Cambia el nombre del repositorio

        public ProveedorService(ProveedorRepository proveedorRepository) // Cambia el nombre del repositorio
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _proveedorRepository.GetAllAsync();
        }

        public async Task<Proveedor> GetByIdAsync(int id)
        {
            return await _proveedorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await _proveedorRepository.AddAsync(proveedor);
        }

        public async Task UpdateAsync(Proveedor proveedorToUpdate)
        {
            var proveedor = await GetByIdAsync(proveedorToUpdate.id_proveedor);

            if (proveedor.id_proveedor > 0) // Cambia el nombre de la propiedad de identificación si es diferente
                await _proveedorRepository.UpdateAsync(proveedorToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var proveedor = await GetByIdAsync(id);
            if (proveedor != null)
            {
                await _proveedorRepository.DeleteAsync(id);
            }
        }
    }
}
