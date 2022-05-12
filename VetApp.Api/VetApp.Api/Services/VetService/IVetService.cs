using VetApp.Api.Models;

namespace VetApp.Api.Services.VetService;

public interface IVetService
    {
        Task<ServiceResponse<List<Vet>>> GetAllVets();
        Task<ServiceResponse<Vet>> GetVetById(int id);
        Task<ServiceResponse<List<Vet>>> AddVet(Vet newVet);
        
}