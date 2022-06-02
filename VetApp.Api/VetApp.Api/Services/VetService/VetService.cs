using AutoMapper;
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
    public async Task<ServiceResponse<List<GetVetDto>>> GetAllVets()
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        serviceResponse.Data = vets.Select(e=>_mapper.Map<GetVetDto>(e)).ToList();
        return serviceResponse;
    }

    private readonly IMapper _mapper;
    public VetService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetVetDto>> GetVetById(int id)
    {
        var serviceResponse = new ServiceResponse<GetVetDto>();
        serviceResponse.Data = _mapper.Map<GetVetDto>(vets.FirstOrDefault(v => v.Id == id));
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVetDto>>> AddVet(AddVetDto newVet)
    {
        var serviceResponse = new ServiceResponse<List<GetVetDto>>();
        Vet vet = _mapper.Map<Vet>(newVet);
        vet.Id = vets.Max(c => c.Id) + 1;
        vets.Add(vet);
        serviceResponse.Data = vets.Select(v=>_mapper.Map<GetVetDto>(v)).ToList();
        return serviceResponse;
    }
}