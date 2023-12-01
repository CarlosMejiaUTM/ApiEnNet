using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FLOWFIT;
using Flowfitapi.Services.Features.Proveedores;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase // Cambiar el nombre del controlador
    {
        private readonly ProveedorService _proveedorService; // Cambiar el nombre del servicio si es diferente
        private readonly IMapper _mapper;

        public ProveedorController(ProveedorService proveedorService, IMapper mapper) // Cambiar el nombre del servicio si es diferente
        {
            _proveedorService = proveedorService; // Cambiar el nombre del servicio si es diferente
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.GetAllAsync(); // Cambiar el nombre del servicio si es diferente
            var proveedorDtos = _mapper.Map<IEnumerable<ProveedorDto>>(proveedores);
            return Ok(proveedorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var proveedor = await _proveedorService.GetByIdAsync(id.Value); // Cambiar el nombre del servicio si es diferente

            if (proveedor == null)
                return NotFound();

            var dto = _mapper.Map<ProveedorDto>(proveedor);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProveedorCreateDto proveedorDto)
        {
            if (proveedorDto == null)
            {
                return BadRequest();
            }

            var proveedor = _mapper.Map<Proveedor>(proveedorDto);
            await _proveedorService.AddAsync(proveedor); // Cambiar el nombre del servicio si es diferente

            var createdProveedorDto = _mapper.Map<ProveedorDto>(proveedor);

            return CreatedAtAction(nameof(GetById), new { id = createdProveedorDto.id_proveedor }, createdProveedorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Proveedor proveedor)
        {

            var existingProveedor = await _proveedorService.GetByIdAsync(id); // Cambiar el nombre del servicio si es diferente

            if (existingProveedor == null)
                return NotFound();

            if (id != proveedor.id_proveedor) // Cambiar el nombre de la propiedad de identificación si es diferente
                return BadRequest();

            await _proveedorService.UpdateAsync(proveedor); // Cambiar el nombre del servicio si es diferente
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingProveedor = await _proveedorService.GetByIdAsync(id.Value); // Cambiar el nombre del servicio si es diferente

            if (existingProveedor == null)
                return NotFound();

            await _proveedorService.DeleteAsync(id.Value); // Cambiar el nombre del servicio si es diferente
            return NoContent();
        }
    }
}
