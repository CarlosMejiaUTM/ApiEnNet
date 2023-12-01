using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.DevolucionesCancelaciones;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevolucionCancelacionController : ControllerBase
    {
        private readonly DevolucionCancelacionService _devolucionCancelacionService;
        private readonly IMapper _mapper;

        public DevolucionCancelacionController(DevolucionCancelacionService devolucionCancelacionService, IMapper mapper)
        {
            _devolucionCancelacionService = devolucionCancelacionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var devolucionesCancelaciones = await _devolucionCancelacionService.GetAllAsync();
            var devolucionCancelacionDtos = _mapper.Map<IEnumerable<DevolucionCancelacionDto>>(devolucionesCancelaciones);
            return Ok(devolucionCancelacionDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var devolucionCancelacion = await _devolucionCancelacionService.GetByIdAsync(id.Value);

            if (devolucionCancelacion == null)
                return NotFound();

            var dto = _mapper.Map<DevolucionCancelacionDto>(devolucionCancelacion);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DevolucionCancelacionCreateDto devolucionCancelacionDto)
        {
            if (devolucionCancelacionDto == null)
            {
                return BadRequest();
            }

            var devolucionCancelacion = _mapper.Map<DevolucionCancelacion>(devolucionCancelacionDto);
            await _devolucionCancelacionService.AddAsync(devolucionCancelacion);

            var createdDevolucionCancelacionDto = _mapper.Map<DevolucionCancelacionDto>(devolucionCancelacion);

            return CreatedAtAction(nameof(GetById), new { id = createdDevolucionCancelacionDto.id_devolucion }, createdDevolucionCancelacionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DevolucionCancelacion devolucionCancelacion)
        {
            var existingDevolucionCancelacion = await _devolucionCancelacionService.GetByIdAsync(id);

            if (existingDevolucionCancelacion == null)
                return NotFound();

            if (id != devolucionCancelacion.id_devolucion)
                return BadRequest();

            await _devolucionCancelacionService.UpdateAsync(devolucionCancelacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingDevolucionCancelacion = await _devolucionCancelacionService.GetByIdAsync(id.Value);

            if (existingDevolucionCancelacion == null)
                return NotFound();

            await _devolucionCancelacionService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
