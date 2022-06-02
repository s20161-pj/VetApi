using Microsoft.AspNetCore.Mvc;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;
using VetApp.Api.Services.VetService;

namespace VetApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VetController : ControllerBase
{
    private readonly IVetService _vetService;
    public VetController(IVetService vetService)
    {
        _vetService= vetService;
    }
    
    [HttpGet("GetAllVets")]
    public async Task<ActionResult<ServiceResponse<List<GetVetDto>>>> Get()
    {
        return Ok(await _vetService.GetAllVets());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetVetDto>>> GetVetById(int id)
    {
        return Ok(await _vetService.GetVetById(id));
    }
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetVetDto>>>> AddVet(AddVetDto newVet)
    {
        return Ok(await _vetService.AddVet(newVet));
    }
}