using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;
using VetApp.Api.Repository;

namespace VetApp.Api.Services.VetService;

public class VetService : IVetService
{
    public MainContext Context { get; private set; }

    private readonly IVetRepository _vetRepository;
    private readonly IMapper _mapper;
    public VetService(IMapper mapper, IVetRepository vetRepository)
    {
        _mapper = mapper;
        _vetRepository = vetRepository;
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

    public async Task<ServiceResponse<List<GetVetDto>>> AddVet(AddVetDto newVet)
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        var addedVet = await _vetRepository.AddVetAsync(newVet);
        serviceResponse.Data = addedVet;
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