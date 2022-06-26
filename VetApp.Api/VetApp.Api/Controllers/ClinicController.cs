using Microsoft.AspNetCore.Mvc;
using VetApp.Model;
using VetApp.Model.Clinic;
using VetApp.Services.Interfaces;

namespace VetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController : ControllerBase
    {

        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        [HttpGet("GetAllClinics")]
        public async Task<ActionResult<ServiceResponse<List<GetClinicDto>>>> Get()
        {
            return Ok(await _clinicService.GetAllClinics());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClinicDto>>> GetClinicById(int id)
        {
            return Ok(await _clinicService.GetClinicById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetClinicDto>>>> AddClinic(AddClinicDto newClinic)
        {
            return Ok(await _clinicService.AddClinic(newClinic));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetClinicDto>>>> Delete(int id)
        {
            var response = await _clinicService.DeleteClinic(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
