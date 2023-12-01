using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.Productos;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(ProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAllAsync();
            var productoDtos = _mapper.Map<IEnumerable<ProductoDto>>(productos);
            return Ok(productoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var producto = await _productoService.GetByIdAsync(id.Value);

            if (producto == null)
                return NotFound();

            var dto = _mapper.Map<ProductoDto>(producto);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductoCreateDto productoDto)
        {
            if (productoDto == null)
            {
                return BadRequest();
            }

            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.AddAsync(producto);

            var createdProductoDto = _mapper.Map<ProductoDto>(producto);

            return CreatedAtAction(nameof(GetById), new { id = createdProductoDto.id_producto }, createdProductoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            var existingProducto = await _productoService.GetByIdAsync(id);

            if (existingProducto == null)
                return NotFound();

            if (id != producto.id_producto)
                return BadRequest();

            await _productoService.UpdateAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingProducto = await _productoService.GetByIdAsync(id.Value);

            if (existingProducto == null)
                return NotFound();

            await _productoService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
