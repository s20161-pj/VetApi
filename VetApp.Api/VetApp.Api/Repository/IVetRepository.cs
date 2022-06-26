using VetApp.Api.Dtos.Vet;

namespace VetApp.Api.Repository
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
