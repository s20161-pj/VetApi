using AutoMapper;
using VetApp.Api.Context;
using VetApp.Model;
using VetApp.Model.Specialization;
using VetApp.Repository.Interfaces;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services
{
    public class SpecializationService : ISpecializationService
    {
        public MainContext Context { get; private set; }

        private readonly ISpecializationRepository _specializationRepository;
        private readonly IMapper _mapper;
        public SpecializationService(IMapper mapper, ISpecializationRepository specializationRepository)
        {
            _mapper = mapper;
            _specializationRepository = specializationRepository;
        }
        public async Task<ServiceResponse<bool>> AddSpecialization(AddSpecializationDto newSpecialization)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _specializationRepository.AddSpecializationAsync(newSpecialization);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteSpecialization(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                await _specializationRepository.DeleteSpecializationAsync(id);
                serviceResponse.Data = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSpecializationDto>>> GetAllSpecializations()
        {
            var serviceResponse = new ServiceResponse<List<GetSpecializationDto>>();
            var dbSpecializations = await _specializationRepository.GetAllSpecializationsAsync();
            serviceResponse.Data = dbSpecializations;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSpecializationDto>> GetSpecializationById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSpecializationDto>();
            var dbSpecialization = await _specializationRepository.GetSpecializationByIdAsync(id);
            serviceResponse.Data = dbSpecialization;
            return serviceResponse;
        }
    }
}
