using VetApp.Api.Dtos.Vet;
using VetApp.Model.Vet;

namespace VetApp.Repository.Interfaces
{
    public interface IVetRepository
    {
        Task<List<GetVetDto>> GetAllVetsAsync();
        Task<GetVetDto> GetVetByIdAsync(int id);
        Task AddVetAsync(AddVetDto newVet);
        Task<GetVetDto> UpdateVetAsync(UpdateVetDto updatedVet);
        Task DeleteVetAsync(int id);
    }
}
