using FLOWFIT; // Asegúrate de tener la referencia correcta
using flowfitapi.Infrastructure.Repositories;

namespace Flowfitapi.Services.Features.Instructores
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorService(InstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            return await _instructorRepository.GetAllAsync();
        }

        public async Task<Instructor> GetByIdAsync(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _instructorRepository.AddAsync(instructor);
        }

        public async Task UpdateAsync(Instructor instructorToUpdate)
        {
            var instructor = await GetByIdAsync(instructorToUpdate.Id);

            if (instructor.Id > 0)
                await _instructorRepository.UpdateAsync(instructorToUpdate);          
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await GetByIdAsync(id);
            if (instructor != null)
            {
                await _instructorRepository.DeleteAsync(id);
            }
        }
    }
}
