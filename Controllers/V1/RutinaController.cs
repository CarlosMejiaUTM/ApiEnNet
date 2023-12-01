using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.Rutinas;
using FLOWFIT;

namespace flowfitapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutinaController : ControllerBase
    {
        private readonly RutinaService _rutinaService;
        private readonly IMapper _mapper;

        public RutinaController(RutinaService rutinaService, IMapper mapper)
        {
            _rutinaService = rutinaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var rutinas = await _rutinaService.GetAllAsync();
            var rutinaDtos = _mapper.Map<IEnumerable<RutinaDto>>(rutinas);
            return Ok(rutinaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var rutina = await _rutinaService.GetByIdAsync(id);

            if (rutina == null)
                return NotFound();

            var dto = _mapper.Map<RutinaDto>(rutina);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RutinaCreateDto rutinaDto)
        {
            if (rutinaDto == null)
            {
                return BadRequest();
            }

            var rutina = _mapper.Map<Rutina>(rutinaDto);
            await _rutinaService.AddAsync(rutina);

            var createdRutinaDto = _mapper.Map<RutinaDto>(rutina);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdRutinaDto.Id }, createdRutinaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Rutina rutina)
        {
            var existingRutina = await _rutinaService.GetByIdAsync(id);

            if (existingRutina == null)
                return NotFound();

            if (id != rutina.Id)
                return BadRequest();

            await _rutinaService.UpdateAsync(rutina);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingRutina = await _rutinaService.GetByIdAsync(id);

            if (existingRutina == null)
                return NotFound();

            await _rutinaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
