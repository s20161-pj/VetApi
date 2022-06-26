using VetApp.Model;
using VetApp.Model.Clinic;

namespace VetApp.Services.Interfaces
{
    public interface IClinicService
    {
        Task<ServiceResponse<List<GetClinicDto>>> GetAllClinics();
        Task<ServiceResponse<GetClinicDto>> GetClinicById(int id);
        Task<ServiceResponse<bool>> AddClinic(AddClinicDto newClinic);
        Task<ServiceResponse<bool>> DeleteClinic(int id);

    }
}
