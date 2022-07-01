using AutoMapper;
using VetApp.Api.Context;
using VetApp.Model;
using VetApp.Model.Client;
using VetApp.Repository.Interfaces;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services
{
   public class ClientService : IClientService
    {
        public MainContext Context { get; private set; }

        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<ServiceResponse<bool>> AddClient(AddClientDto newClient)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _clientRepository.AddClientAsync(newClient);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteClient(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _clientRepository.DeleteClientAsync(id);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClientDto>>> GetAllClients()
        {
            var serviceResponse = new ServiceResponse<List<GetClientDto>>();
            var dbClients = await _clientRepository.GetAllClientsAsync();
            serviceResponse.Data = dbClients;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDto>> GetClientById(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();
            var dbClient = await _clientRepository.GetClientByIdAsync(id);
            serviceResponse.Data = dbClient;
            return serviceResponse;
        }
    }
}
