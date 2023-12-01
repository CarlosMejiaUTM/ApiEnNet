using Microsoft.EntityFrameworkCore;
using flowfitapi.Infrastructure.Data;
using FLOWFIT;

namespace flowfitapi.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly flowfitapiDbContext _context;

        public ClienteRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int idCliente)
        {
            return await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.idCliente == idCliente)
                ?? new Cliente
                {
                    idCliente = -1,
                    Nombre = string.Empty,
                    Apellido = string.Empty,
                    Email = string.Empty,
                    Telefono = string.Empty,
                    Direccion = string.Empty
                };
        }

        public async Task AddAsync(Cliente cliente)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente updatedCliente)
        {
            var existingCliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.idCliente == updatedCliente.idCliente);

            if (existingCliente != null)
            {
                existingCliente.Nombre = updatedCliente.Nombre;
                existingCliente.Apellido = updatedCliente.Apellido;
                existingCliente.Email = updatedCliente.Email;
                existingCliente.Telefono = updatedCliente.Telefono;
                existingCliente.Direccion = updatedCliente.Direccion;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var clienteToDelete = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.idCliente == id);

            if (clienteToDelete != null)
            {
                _context.Clientes.Remove(clienteToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
