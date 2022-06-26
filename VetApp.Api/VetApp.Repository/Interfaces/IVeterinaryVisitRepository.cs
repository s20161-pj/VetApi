
using VetApp.Model.VeterinaryVisit;

namespace VetApp.Repository.Interfaces
{
    public interface IVeterinaryVisitRepository
    {
        Task<List<GetVeterinaryVisitDto>> GetAllVeterinaryVisitsAsync();
        Task<GetVeterinaryVisitDto> GetVeterinaryVisitByIdAsync(int id);
        Task AddVeterinaryVisitAsync(AddVeterinaryVisitDto newVeterinaryVisit);
        Task<GetVeterinaryVisitDto> UpdateVeterinaryVisitAsync(UpdateVeterinaryVisitDto updatedVeterinaryVisit);
        Task DeleteVeterinaryVisitAsync(int id);
    }
}
