using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FLOWFIT;
using Flowfitapi.Services.Features.Clientes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(ClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            var clienteDtos = _mapper.Map<IEnumerable<ClienteDto>>(clientes);
            return Ok(clienteDtos);
        }

        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetById(int? idCliente)
        {
            if (!idCliente.HasValue)
                return BadRequest();

            var cliente = await _clienteService.GetByIdAsync(idCliente.Value);

            if (cliente == null)
                return NotFound();

            var dto = _mapper.Map<ClienteDto>(cliente);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ClienteCreateDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest();
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _clienteService.AddAsync(cliente);

            var createdClienteDto = _mapper.Map<ClienteDto>(cliente);

            return CreatedAtAction(nameof(GetById), new { idCliente = createdClienteDto.idCliente }, createdClienteDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            var existingCliente = await _clienteService.GetByIdAsync(id);

            if (existingCliente == null)
                return NotFound();

            if (id != cliente.idCliente)
                return BadRequest();

            await _clienteService.UpdateAsync(cliente);

            return NoContent();
        }

        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete(int? idCliente)
        {
            if (!idCliente.HasValue)
                return BadRequest();

            var existingCliente = await _clienteService.GetByIdAsync(idCliente.Value);

            if (existingCliente == null)
                return NotFound();

            await _clienteService.DeleteAsync(idCliente.Value);
            return NoContent();
        }
    }
}
