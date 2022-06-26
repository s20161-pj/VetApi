
using VetApp.Model;
using VetApp.Model.VeterinaryVisit;

namespace VetApp.Services.Interfaces
{
    public interface IVeterinaryVisitService
    {
        Task<ServiceResponse<List<GetVeterinaryVisitDto>>> GetAllVeterinaryVisits();
        Task<ServiceResponse<GetVeterinaryVisitDto>> GetVeterinaryVisitById(int id);
        Task<ServiceResponse<bool>> AddVeterinaryVisit(AddVeterinaryVisitDto newVeterinaryVisit);
        Task<ServiceResponse<GetVeterinaryVisitDto>> UpdateVeterinaryVisit(UpdateVeterinaryVisitDto updatedVeterinaryVisit);
        Task<ServiceResponse<bool>> DeleteVeterinaryVisit(int id);
    }
}
