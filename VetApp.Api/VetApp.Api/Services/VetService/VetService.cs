using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;
namespace VetApp.Api.Services.VetService;

public class VetService : IVetService
{
    public MainContext Context { get; private set; }

    private readonly MainContext _context;
    private readonly IMapper _mapper;
    public VetService(IMapper mapper, MainContext context)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<List<GetVetDto>>> GetAllVets()
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        var dbVets = await _context.Vets.ToListAsync();
        serviceResponse.Data = dbVets.Select(e => _mapper.Map<GetVetDto>(e)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetVetDto>> GetVetById(int id)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        var dbVet = await _context.Vets.FirstOrDefaultAsync(v => v.Id == id);
        serviceResponse.Data = _mapper.Map<GetVetDto>(dbVet);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVetDto>>> AddVet(AddVetDto newVet)
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        Vet vet = _mapper.Map<Vet>(newVet);
        _context.Vets.Add(vet);
        await _context.SaveChangesAsync();
        serviceResponse.Data =await _context.Vets.Select(v => _mapper.Map<GetVetDto>(v)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVetDto>> UpdateVet(UpdateVetDto updatedVet)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        try
        {
            Vet vet = await _context.Vets.FirstAsync(v => v.Id == updatedVet.Id);

            vet.Name = updatedVet.Name;
            vet.Surname = updatedVet.Surname;
            vet.OccupationNumber = updatedVet.OccupationNumber;
            vet.ClinicId = updatedVet.ClinicId;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetVetDto>(vet);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;

    }

    public async Task<ServiceResponse<List<GetVetDto>>> DeleteVet(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        try
        {
            Vet vet = await _context.Vets.FirstAsync(c => c.Id == id);
            _context.Vets.Remove(vet);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Vets.Select(c => _mapper.Map<GetVetDto>(c)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}