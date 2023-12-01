using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using flowfitapi.Domain.Dtos;
using Flowfitapi.Services.Features.Instructores;
using FLOWFIT;

namespace Flowfitapi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorController(InstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var instructores = await _instructorService.GetAllAsync();
            var instructorDtos = _mapper.Map<IEnumerable<InstructorDto>>(instructores);
            return Ok(instructorDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var instructor = await _instructorService.GetByIdAsync(id.Value);

            if (instructor == null)
                return NotFound();

            var dto = _mapper.Map<InstructorDto>(instructor);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(InstructorCreateDto instructorDto)
        {
            if (instructorDto == null)
            {
                return BadRequest();
            }

            var instructor = _mapper.Map<Instructor>(instructorDto);
            await _instructorService.AddAsync(instructor);

            var createdInstructorDto = _mapper.Map<InstructorDto>(instructor);

            return CreatedAtAction(nameof(GetById), new { id = createdInstructorDto.Id }, createdInstructorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Instructor instructor)
        {

            var existingInstructor = await _instructorService.GetByIdAsync(id);

            if (existingInstructor == null)
                return NotFound();

            if (id != instructor.Id)
                return BadRequest();

            await _instructorService.UpdateAsync(instructor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var existingInstructor = await _instructorService.GetByIdAsync(id.Value);

            if (existingInstructor == null)
                return NotFound();

            await _instructorService.DeleteAsync(id.Value);
            return NoContent();
        }
    }
}
