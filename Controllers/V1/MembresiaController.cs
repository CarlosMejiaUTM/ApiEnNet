using AutoMapper;
using FLOWFIT;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.Membresias; // Asegúrate de tener la referencia correcta
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembresiaController : ControllerBase
    {
        private readonly MembresiaService _membresiaService;
        private readonly IMapper _mapper;

        public MembresiaController(MembresiaService membresiaService, IMapper mapper)
        {
            _membresiaService = membresiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var membresias = await _membresiaService.GetAllAsync();
            var membresiaDtos = _mapper.Map<IEnumerable<MembresiaDto>>(membresias);
            return Ok(membresiaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var membresia = await _membresiaService.GetByIdAsync(id.Value);

            if (membresia == null)
                return NotFound();

            var dto = _mapper.Map<MembresiaDto>(membresia);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(MembresiaCreateDto membresiaDto)
        {
            if (membresiaDto == null)
            {
                return BadRequest();
            }

            var membresia = _mapper.Map<Membresia>(membresiaDto);
            await _membresiaService.AddAsync(membresia);

            var createdMembresiaDto = _mapper.Map<MembresiaDto>(membresia);

            return CreatedAtAction(nameof(GetById), new { id = createdMembresiaDto.id_membresia }, createdMembresiaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Membresia membresia)
        {
            var existingMembresia = await _membresiaService.GetByIdAsync(id);

            if (existingMembresia == null)
                return NotFound();

            if (id != membresia.id_membresia)
                return BadRequest();

            await _membresiaService.UpdateAsync(membresia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingMembresia = await _membresiaService.GetByIdAsync(id.Value);

            if (existingMembresia == null)
                return NotFound();

            await _membresiaService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
