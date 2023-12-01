using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FLOWFIT;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.Ventas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _ventaService;
        private readonly IMapper _mapper;

        public VentaController(VentaService ventaService, IMapper mapper)
        {
            _ventaService = ventaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ventas = await _ventaService.GetAllAsync();
            var ventaDtos = _mapper.Map<IEnumerable<VentaDto>>(ventas);
            return Ok(ventaDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var venta = await _ventaService.GetByIdAsync(id.Value);

            if (venta == null)
                return NotFound();

            var dto = _mapper.Map<VentaDto>(venta);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(VentaCreateDto ventaDto)
        {
            if (ventaDto == null)
            {
                return BadRequest();
            }

            var venta = _mapper.Map<Venta>(ventaDto);
            await _ventaService.AddAsync(venta);

            var createdVentaDto = _mapper.Map<VentaDto>(venta);

            return CreatedAtAction(nameof(GetById), new { id = createdVentaDto.id_venta }, createdVentaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Venta venta)
        {
            var existingVenta = await _ventaService.GetByIdAsync(id);

            if (existingVenta == null)
                return NotFound();

            if (id != venta.id_venta)
                return BadRequest();

            await _ventaService.UpdateAsync(venta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingVenta = await _ventaService.GetByIdAsync(id.Value);

            if (existingVenta == null)
                return NotFound();

            await _ventaService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
