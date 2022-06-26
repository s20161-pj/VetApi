using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Model.Pet;

namespace VetApp.Repository.Interfaces
{
    public interface IPetRepository
    {
        Task<List<GetPetDto>> GetAllPetsAsync();
        Task<GetPetDto> GetPetByIdAsync(int id);
        Task AddPetAsync(AddPetDto newPet);
        Task DeletePetAsync(int id);
    }
}
