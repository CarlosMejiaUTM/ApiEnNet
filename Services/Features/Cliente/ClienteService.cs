using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories; // Asegúrate de tener la referencia correcta

namespace Flowfitapi.Services.Features.Clientes // Cambia el nombre del namespace
{
    public class ClienteService // Cambia el nombre de la clase
    {
        private readonly ClienteRepository _clienteRepository; // Cambia el nombre del repositorio

        public ClienteService(ClienteRepository clienteRepository) // Cambia el nombre del repositorio
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(int idCliente) // Cambia el nombre del parámetro
        {
            return await _clienteRepository.GetByIdAsync(idCliente);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task UpdateAsync(Cliente clienteToUpdate)
        {
            var cliente = await GetByIdAsync(clienteToUpdate.idCliente); // Cambia el nombre de la propiedad de identificación

            if (cliente.idCliente > 0) // Cambia el nombre de la propiedad de identificación si es diferente
                await _clienteRepository.UpdateAsync(clienteToUpdate);
        }

        public async Task DeleteAsync(int idCliente) // Cambia el nombre del parámetro
        {
            var cliente = await GetByIdAsync(idCliente);
            if (cliente != null)
            {
                await _clienteRepository.DeleteAsync(idCliente);
            }
        }
    }
}
