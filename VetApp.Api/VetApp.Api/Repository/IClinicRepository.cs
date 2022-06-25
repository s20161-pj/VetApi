
using VetApp.Api.Dtos.Clinic;

namespace VetApp.Api.Repository
{
    public interface IClinicRepository
    {
        Task<List<GetClinicDto>> GetAllClinicsAsync();
        Task<GetClinicDto> GetClinicByIdAsync(int id);
        Task AddClinicAsync(AddClinicDto newClinic);
        Task DeleteClinicAsync(int id);
    }
}
