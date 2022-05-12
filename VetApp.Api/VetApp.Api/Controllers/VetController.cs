using Microsoft.AspNetCore.Mvc;
using VetApp.Api.Models;
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
    [HttpGet("GetAll")]
    public ActionResult<List<Vet>> Get()
    {
        return Ok(vets);
    }
    [HttpGet("{id}")]
    public ActionResult<Vet> GetSingle(int id)
    {
        return Ok(vets.FirstOrDefault(v=>v.Id==id));
    }
}