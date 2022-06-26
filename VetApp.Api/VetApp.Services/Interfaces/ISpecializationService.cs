using VetApp.Model;
using VetApp.Model.Specialization;

namespace VetApp.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<ServiceResponse<List<GetSpecializationDto>>> GetAllSpecializations();
        Task<ServiceResponse<GetSpecializationDto>> GetSpecializationById(int id);
        Task<ServiceResponse<bool>> AddSpecialization(AddSpecializationDto newSpecialization);
        Task<ServiceResponse<bool>> DeleteSpecialization(int id);

    }
}
