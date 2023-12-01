using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.PagosMembresias;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoMembresiaController : ControllerBase
    {
        private readonly PagoMembresiaService _pagoMembresiaService;
        private readonly IMapper _mapper;

        public PagoMembresiaController(PagoMembresiaService pagoMembresiaService, IMapper mapper)
        {
            _pagoMembresiaService = pagoMembresiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagosMembresias = await _pagoMembresiaService.GetAllAsync();
            var pagoMembresiaDtos = _mapper.Map<IEnumerable<PagoMembresiaDto>>(pagosMembresias);
            return Ok(pagoMembresiaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var pagoMembresia = await _pagoMembresiaService.GetByIdAsync(id.Value);

            if (pagoMembresia == null)
                return NotFound();

            var dto = _mapper.Map<PagoMembresiaDto>(pagoMembresia);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PagoMembresiaCreateDto pagoMembresiaDto)
        {
            if (pagoMembresiaDto == null)
            {
                return BadRequest();
            }

            var pagoMembresia = _mapper.Map<PagoMembresia>(pagoMembresiaDto);
            await _pagoMembresiaService.AddAsync(pagoMembresia);

            var createdPagoMembresiaDto = _mapper.Map<PagoMembresiaDto>(pagoMembresia);

            return CreatedAtAction(nameof(GetById), new { id = createdPagoMembresiaDto.id_pago_membresia }, createdPagoMembresiaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PagoMembresia pagoMembresia)
        {
            var existingPagoMembresia = await _pagoMembresiaService.GetByIdAsync(id);

            if (existingPagoMembresia == null)
                return NotFound();

            if (id != pagoMembresia.id_pago_membresia)
                return BadRequest();

            await _pagoMembresiaService.UpdateAsync(pagoMembresia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingPagoMembresia = await _pagoMembresiaService.GetByIdAsync(id.Value);

            if (existingPagoMembresia == null)
                return NotFound();

            await _pagoMembresiaService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
