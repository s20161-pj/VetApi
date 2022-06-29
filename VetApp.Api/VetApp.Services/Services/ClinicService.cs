using AutoMapper;
using VetApp.Api.Context;
using VetApp.Model;
using VetApp.Model.Clinic;
using VetApp.Repository.Interfaces;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services
{
    public class ClinicService : IClinicService
    {
        public MainContext Context { get; private set; }

        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;
        public ClinicService(IMapper mapper, IClinicRepository clinicRepository)
        {
            _mapper = mapper;
            _clinicRepository = clinicRepository;
        }
        public async Task<ServiceResponse<bool>> AddClinic(AddClinicDto newClinic)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _clinicRepository.AddClinicAsync(newClinic);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteClinic(int id)
        {

            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _clinicRepository.DeleteClinicAsync(id);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetClinicDto>>> GetAllClinics()
        {
            var serviceResponse = new ServiceResponse<List<GetClinicDto>>();
            var dbClinics = await _clinicRepository.GetAllClinicsAsync();
            serviceResponse.Data = dbClinics;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClinicDto>> GetClinicById(int id)
        {
            var serviceResponse = new ServiceResponse<GetClinicDto>();
            var dbClinic = await _clinicRepository.GetClinicByIdAsync(id);
            if(dbClinic == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Brak podanej kliniki";
                return serviceResponse;
            }

            serviceResponse.Data = dbClinic;
            return serviceResponse;
        }
    }
}
