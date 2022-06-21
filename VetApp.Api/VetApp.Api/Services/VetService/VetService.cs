using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;
namespace VetApp.Api.Services.VetService;

public class VetService : IVetService
{
    private static List<Vet> vets = new List<Vet>
    {
        new Vet(),
        new Vet {Id=1, Name = "Joanna" }
    };
  
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
        var dbVets = await _context.Vet.ToListAsync();
        serviceResponse.Data = dbVets.Select(e => _mapper.Map<GetVetDto>(e)).ToList();
        return serviceResponse;
    }
    public async Task<ServiceResponse<GetVetDto>> GetVetById(int id)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        var dbVet = await _context.Vet.FirstOrDefaultAsync(v => v.Id == id);
        serviceResponse.Data = _mapper.Map<GetVetDto>(dbVet);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVetDto>>> AddVet(AddVetDto newVet)
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        Vet vet = _mapper.Map<Vet>(newVet);
        _context.Vet.Add(vet);
        await _context.SaveChangesAsync();
        serviceResponse.Data =await _context.Vet.Select(v => _mapper.Map<GetVetDto>(v)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVetDto>> UpdateVet(UpdateVetDto updatedVet)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        try
        {
            Vet vet = vets.FirstOrDefault(c => c.Id == updatedVet.Id);
            vet.Name = updatedVet.Name;
            vet.Surname = updatedVet.Surname;
            vet.OccupationNumber = updatedVet.OccupationNumber;
            vet.ClinicId = updatedVet.ClinicId;

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
            Vet vet = vets.First(c => c.Id == id);
            vets.Remove(vet);

            serviceResponse.Data = vets.Select(c => _mapper.Map<GetVetDto>(c)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}