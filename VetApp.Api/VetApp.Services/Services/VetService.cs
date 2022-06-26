using AutoMapper;
using VetApp.Api.Context;
using VetApp.Api.Dtos.Vet;
using VetApp.Model;
using VetApp.Model.Vet;
using VetApp.Repository.Interfaces;
using VetApp.Services.Interfaces;

namespace VetApp.Services.Services;

public class VetService : IVetService
{
    public MainContext Context { get; private set; }

    private readonly IVetRepository _vetRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IMapper _mapper;
    public VetService(IMapper mapper, IVetRepository vetRepository, IClinicRepository clinicRepository)
    {
        _mapper = mapper;
        _vetRepository = vetRepository;
        _clinicRepository = clinicRepository;
    }
    public async Task<ServiceResponse<List<GetVetDto>>> GetAllVets()
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        var dbVets = await _vetRepository.GetAllVetsAsync();
        serviceResponse.Data = dbVets;
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetVetDto>> GetVetById(int id)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        var dbVet = await _vetRepository.GetVetByIdAsync(id);
        serviceResponse.Data = dbVet;
        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> AddVet(AddVetDto newVet)
    {
        var serviceResponse = new ServiceResponse<bool>();
        var clinic = await _clinicRepository.GetClinicByIdAsync(newVet.ClinicId);

        if (clinic == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Podana klinika nie istnieje";

            return serviceResponse;
        }

        try
        {
            await _vetRepository.AddVetAsync(newVet);
            serviceResponse.Data = true;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVetDto>> UpdateVet(UpdateVetDto vetToUpdate)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        try
        {
            var updatedVet = await _vetRepository.UpdateVetAsync(vetToUpdate);

            serviceResponse.Data = updatedVet;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;

    }

    public async Task<ServiceResponse<bool>> DeleteVet(int id)
    {
        var serviceResponse = new ServiceResponse<bool>();
        try
        {
            await _vetRepository.DeleteVetAsync(id);
            serviceResponse.Data = true;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}