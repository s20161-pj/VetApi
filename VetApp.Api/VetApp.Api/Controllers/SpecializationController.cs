using Microsoft.AspNetCore.Mvc;
using VetApp.Model;
using VetApp.Model.Specialization;
using VetApp.Services.Interfaces;

namespace VetApp.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SpecializationController:ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }
        [HttpGet("GetAllSpecializations")]
        public async Task<ActionResult<ServiceResponse<List<GetSpecializationDto>>>> Get()
        {
            return Ok(await _specializationService.GetAllSpecializations());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSpecializationDto>>> GetSpecializationById(int id)
        {
            return Ok(await _specializationService.GetSpecializationById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSpecializationDto>>>> AddClinic(AddSpecializationDto newSpecialization)
        {
            return Ok(await _specializationService.AddSpecialization(newSpecialization));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetSpecializationDto>>>> Delete(int id)
        {
            var response = await _specializationService.DeleteSpecialization(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
