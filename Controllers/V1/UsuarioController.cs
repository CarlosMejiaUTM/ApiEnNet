using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Flowfitapi.Library.Domain.Dtos; // Asegúrate de ajustar el espacio de nombres según tus DTOs
using Flowfitapi.Services.Features.Usuarios;
using Flowfitapi.Domain.Dtos;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            var usuarioDtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            return Ok(usuarioDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if (usuario == null)
                return NotFound();

            var dto = _mapper.Map<UsuarioDto>(usuario);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UsuarioCreateDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest();
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioService.AddAsync(usuario);

            var createdUsuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdUsuarioDto.Id }, createdUsuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Usuario usuario)
        {
            var existingUsuario = await _usuarioService.GetByIdAsync(id);

            if (existingUsuario == null)
                return NotFound();

            if (id != usuario.Id)
                return BadRequest();

            await _usuarioService.UpdateAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingUsuario = await _usuarioService.GetByIdAsync(id);

            if (existingUsuario == null)
                return NotFound();

            await _usuarioService.DeleteAsync(id);
            return NoContent();
        }
    }
}
