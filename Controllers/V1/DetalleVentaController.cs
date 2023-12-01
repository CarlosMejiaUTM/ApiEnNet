using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.DetalleVentas;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalleVentaController : ControllerBase
    {
        private readonly DetalleVentaService _detalleVentaService;
        private readonly IMapper _mapper;

        public DetalleVentaController(DetalleVentaService detalleVentaService, IMapper mapper)
        {
            _detalleVentaService = detalleVentaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detallesVentas = await _detalleVentaService.GetAllAsync();
            var detalleVentaDtos = _mapper.Map<IEnumerable<DetalleVentaDto>>(detallesVentas);
            return Ok(detalleVentaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var detalleVenta = await _detalleVentaService.GetByIdAsync(id.Value);

            if (detalleVenta == null)
                return NotFound();

            var dto = _mapper.Map<DetalleVentaDto>(detalleVenta);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DetalleVentaCreateDto detalleVentaDto)
        {
            if (detalleVentaDto == null)
            {
                return BadRequest();
            }

            var detalleVenta = _mapper.Map<DetalleVenta>(detalleVentaDto);
            await _detalleVentaService.AddAsync(detalleVenta);

            var createdDetalleVentaDto = _mapper.Map<DetalleVentaDto>(detalleVenta);

            return CreatedAtAction(nameof(GetById), new { id = createdDetalleVentaDto.id_detalle }, createdDetalleVentaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetalleVenta detalleVenta)
        {
            var existingDetalleVenta = await _detalleVentaService.GetByIdAsync(id);

            if (existingDetalleVenta == null)
                return NotFound();

            if (id != detalleVenta.id_detalle)
                return BadRequest();

            await _detalleVentaService.UpdateAsync(detalleVenta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingDetalleVenta = await _detalleVentaService.GetByIdAsync(id.Value);

            if (existingDetalleVenta == null)
                return NotFound();

            await _detalleVentaService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
