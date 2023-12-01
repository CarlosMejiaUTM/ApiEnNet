using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FLOWFIT;
using flowfitapi.Infrastructure.Repositories;

namespace Flowfitapi.Services.Features.PagosMembresias
{
    public class PagoMembresiaService
    {
        private readonly PagoMembresiaRepository _pagoMembresiaRepository;

        public PagoMembresiaService(PagoMembresiaRepository pagoMembresiaRepository)
        {
            _pagoMembresiaRepository = pagoMembresiaRepository;
        }

        public async Task<IEnumerable<PagoMembresia>> GetAllAsync()
        {
            return await _pagoMembresiaRepository.GetAllAsync();
        }

        public async Task<PagoMembresia> GetByIdAsync(int id)
        {
            return await _pagoMembresiaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(PagoMembresia pagoMembresia)
        {
            await _pagoMembresiaRepository.AddAsync(pagoMembresia);
        }

        public async Task UpdateAsync(PagoMembresia pagoMembresiaToUpdate)
        {
            var pagoMembresia = await GetByIdAsync(pagoMembresiaToUpdate.id_pago_membresia);

            if (pagoMembresia.id_pago_membresia > 0)
                await _pagoMembresiaRepository.UpdateAsync(pagoMembresiaToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            var pagoMembresia = await GetByIdAsync(id);
            if (pagoMembresia != null)
            {
                await _pagoMembresiaRepository.DeleteAsync(id);
            }
        }
    }
}
