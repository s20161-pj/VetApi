using VetApp.Api.Dtos.Clinic;
using VetApp.Api.Models;

namespace VetApp.Api.Services.ClinicService
{
    public interface IClinicService
    {
        Task<ServiceResponse<List<GetClinicDto>>> GetAllClinics();
        Task<ServiceResponse<GetClinicDto>> GetClinicById(int id);
        Task<ServiceResponse<bool>> AddClinic(AddClinicDto newClinic);
        Task<ServiceResponse<bool>> DeleteClinic(int id);

    }
}
