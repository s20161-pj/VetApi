using VetApp.Model.Clinic;

namespace VetApp.Repository.Interfaces
{
    public interface IClinicRepository
    {
        Task<List<GetClinicDto>> GetAllClinicsAsync();
        Task<GetClinicDto> GetClinicByIdAsync(int id);
        Task AddClinicAsync(AddClinicDto newClinic);
        Task DeleteClinicAsync(int id);
    }
}
