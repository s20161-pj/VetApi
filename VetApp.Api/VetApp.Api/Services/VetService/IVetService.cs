using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;

namespace VetApp.Api.Services.VetService;

public interface IVetService
    {
        Task<ServiceResponse<List<GetVetDto>>> GetAllVets();
        Task<ServiceResponse<GetVetDto>> GetVetById(int id);
        Task<ServiceResponse<List<GetVetDto>>> AddVet(AddVetDto newVet);
        Task<ServiceResponse<GetVetDto>> UpdateVet(UpdateVetDto updatedVet);
         Task<ServiceResponse<List<GetVetDto>>> DeleteVet(int id);
}