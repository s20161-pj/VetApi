using VetApp.Api.Dtos.Vet;
using VetApp.Model;
using VetApp.Model.Vet;

namespace VetApp.Services.Interfaces;

public interface IVetService
{
    Task<ServiceResponse<List<GetVetDto>>> GetAllVets();
    Task<ServiceResponse<GetVetDto>> GetVetById(int id);
    Task<ServiceResponse<bool>> AddVet(AddVetDto newVet);
    Task<ServiceResponse<GetVetDto>> UpdateVet(UpdateVetDto updatedVet);
    Task<ServiceResponse<bool>> DeleteVet(int id);
}