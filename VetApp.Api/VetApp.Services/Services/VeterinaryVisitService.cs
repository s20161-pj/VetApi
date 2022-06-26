using AutoMapper;
using VetApp.Api.Context;
using VetApp.Model;
using VetApp.Model.VeterinaryVisit;
using VetApp.Repository.Interfaces;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services
{

    public class VeterinaryVisitService : IVeterinaryVisitService
    {
        public MainContext Context { get; private set; }

        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IVetRepository _vetRepository;
        private readonly IVeterinaryVisitRepository _veterinaryVisitRepository;
        public VeterinaryVisitService(IMapper mapper, IClientRepository clientRepository, IVetRepository vetRepository, IVeterinaryVisitRepository veterinaryVisitRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _vetRepository = vetRepository;
            _veterinaryVisitRepository = veterinaryVisitRepository;
        }
        public async Task<ServiceResponse<bool>> AddVeterinaryVisit(AddVeterinaryVisitDto newVeterinaryVisit)
        {
            var serviceResponse = new ServiceResponse<bool>();
            var client = await _clientRepository.GetClientByIdAsync(newVeterinaryVisit.ClientId);
            var vet = await _vetRepository.GetVetByIdAsync(newVeterinaryVisit.VetId);
            if (client == null || vet == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Nie można dodać wizyty dla nieistniejącego klienta lub weterynarza";

                return serviceResponse;
            }

            try
            {
                await _veterinaryVisitRepository.AddVeterinaryVisitAsync(newVeterinaryVisit);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<bool>> DeleteVeterinaryVisit(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _veterinaryVisitRepository.DeleteVeterinaryVisitAsync(id);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetVeterinaryVisitDto>>> GetAllVeterinaryVisits()
        {
            var serviceResponse = new ServiceResponse<List<GetVeterinaryVisitDto>>();
            var dbVeterinaryVisits = await _veterinaryVisitRepository.GetAllVeterinaryVisitsAsync();
            serviceResponse.Data = dbVeterinaryVisits;
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetVeterinaryVisitDto>> GetVeterinaryVisitById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVeterinaryVisitDto>();
            var dbVeterinaryVisit = await _veterinaryVisitRepository.GetVeterinaryVisitByIdAsync(id);
            serviceResponse.Data = dbVeterinaryVisit;
            return serviceResponse;
        }
      
        public async Task<ServiceResponse<GetVeterinaryVisitDto>> UpdateVeterinaryVisit(UpdateVeterinaryVisitDto veterinaryVisitToUpdate)
        {
            var serviceResponse = new ServiceResponse<GetVeterinaryVisitDto>();
            try
            {
                var updatedVeterinaryVisit = await _veterinaryVisitRepository.UpdateVeterinaryVisitAsync(veterinaryVisitToUpdate);

                serviceResponse.Data = updatedVeterinaryVisit;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }


}

