
using VetApp.Model;
using VetApp.Model.Pet;

namespace VetApp.Services.Interfaces
{
   public interface IPetService
    {
        Task<ServiceResponse<List<GetPetDto>>> GetAllPets();
        Task<ServiceResponse<GetPetDto>> GetPetById(int id);
        Task<ServiceResponse<bool>> AddPet(AddPetDto newPet);
        Task<ServiceResponse<bool>> DeletePet(int id);
    }
}
