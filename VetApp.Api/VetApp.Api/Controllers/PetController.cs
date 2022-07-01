using Microsoft.AspNetCore.Mvc;
using VetApp.Model;
using VetApp.Model.Pet;
using VetApp.Services.Interfaces;

namespace VetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController: ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        [HttpGet("GetAllPets")]
        public async Task<ActionResult<ServiceResponse<List<GetPetDto>>>> Get()
        {
            return Ok(await _petService.GetAllPets());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetPetDto>>> GetPetById(int id)
        {
            return Ok(await _petService.GetPetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPetDto>>>> AddPet(AddPetDto newPet)
        {
            return Ok(await _petService.AddPet(newPet));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetPetDto>>>> Delete(int id)
        {
            var response = await _petService.DeletePet(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
