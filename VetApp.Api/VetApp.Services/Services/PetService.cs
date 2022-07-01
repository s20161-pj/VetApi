using AutoMapper;
using VetApp.Api.Context;
using VetApp.Model;
using VetApp.Model.Clinic;
using VetApp.Model.Pet;
using VetApp.Repository.Interfaces;
using VetApp.Repository.Repository;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services
{
    public class PetService : IPetService
    {
        public MainContext Context { get; private set; }

        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        public PetService(IMapper mapper, IPetRepository petRepository, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
            _clientRepository = clientRepository;
        }
        public async Task<ServiceResponse<bool>> AddPet(AddPetDto newPet)
        {
            var serviceResponse = new ServiceResponse<bool>();
            var client = await _clientRepository.GetClientByIdAsync(newPet.ClientId);
            if (client == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message="Nie ma takiego klienta, nie można dodać zwierzaka do listy";
                return serviceResponse;
            }
            try
            {
                await _petRepository.AddPetAsync(newPet);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeletePet(int id)
        {

            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _petRepository.DeletePetAsync(id);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetPetDto>> GetPetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPetDto>();
            var dbPet = await _petRepository.GetPetByIdAsync(id);
            serviceResponse.Data = dbPet;
            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetPetDto>>> GetAllPets()
        {
            throw new NotImplementedException();
        }

    }
}
