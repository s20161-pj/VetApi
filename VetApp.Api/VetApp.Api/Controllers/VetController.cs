using Microsoft.AspNetCore.Mvc;
using VetApp.Api.Models;
using VetApp.Api.Services.VetService;

namespace VetApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VetController : ControllerBase
{
    private static List<Vet> vets = new List<Vet>
    {
        new Vet(),
        new Vet {Id=1, Name = "Mateusz" }
    };

    private readonly IVetService _vetService;
    public VetController(IVetService vetService)
    {
        _vetService= vetService;
    }
    
    [HttpGet("GetAllVets")]
    public async Task<ActionResult<ServiceResponse<List<Vet>>>> Get()
    {
        return Ok(await _vetService.GetAllVets());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Vet>>> GetVetById(int id)
    {
        return Ok(await _vetService.GetVetById(id));
    }
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Vet>>>> AddVet(Vet newVet)
    {
        return Ok(await _vetService.AddVet(newVet));
    }
}