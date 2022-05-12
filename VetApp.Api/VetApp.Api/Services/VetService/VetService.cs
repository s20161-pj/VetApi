using VetApp.Api.Models;
namespace VetApp.Api.Services.VetService;

public class VetService : IVetService
{
    private static List<Vet> vets = new List<Vet>
    {
        new Vet(),
        new Vet {Id=1, Name = "Mateusz" }
    };
    public async Task<ServiceResponse<List<Vet>>> GetAllVets()
    {
        var serviceResponse = new ServiceResponse<List<Vet>>();
        serviceResponse.Data = vets;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Vet>> GetVetById(int id)
    {
        var serviceResponse = new ServiceResponse<Vet>();
        serviceResponse.Data = vets.FirstOrDefault(v => v.Id == id);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Vet>>> AddVet(Vet newVet)
    {
        var serviceResponse = new ServiceResponse<List<Vet>>();
        vets.Add(newVet);
        serviceResponse.Data = vets;
        return serviceResponse;
    }
}