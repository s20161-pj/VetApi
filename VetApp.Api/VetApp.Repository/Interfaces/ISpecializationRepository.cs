using VetApp.Model.Specialization;

namespace VetApp.Repository.Interfaces
{
    public interface ISpecializationRepository
    {
        Task<List<GetSpecializationDto>> GetAllSpecializationsAsync();
        Task<GetSpecializationDto> GetSpecializationByIdAsync(int id);
        Task AddSpecializationAsync(AddSpecializationDto newSpecialization);
        Task DeleteSpecializationAsync(int id);
    }
}
