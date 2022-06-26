using Microsoft.AspNetCore.Mvc;
using VetApp.Model;
using VetApp.Model.VeterinaryVisit;
using VetApp.Services.Interfaces;
using VetApp.Services.Services;

namespace VetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeterinaryVisitController : ControllerBase
    {
        private readonly IVeterinaryVisitService _veterinaryVisitService;
        public VeterinaryVisitController(IVeterinaryVisitService veterinaryVisitService)
        {
            _veterinaryVisitService = veterinaryVisitService;
        }

        [HttpGet("GetAllVeterinaryVisits")]
        public async Task<ActionResult<ServiceResponse<List<GetVeterinaryVisitDto>>>> Get()
        {
            return Ok(await _veterinaryVisitService.GetAllVeterinaryVisits());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVeterinaryVisitDto>>> GetVeterinaryisitById(int id)
        {
            return Ok(await _veterinaryVisitService.GetVeterinaryVisitById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVeterinaryVisitDto>>>> AddVeterinaryVist(AddVeterinaryVisitDto newVeterinaryVisit)
        {
            return Ok(await _veterinaryVisitService.AddVeterinaryVisit(newVeterinaryVisit));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVeterinaryVisitDto>>> UpdateVeterinaryVisit(UpdateVeterinaryVisitDto updatedVeterinaryVisit)
        {
            var response = await _veterinaryVisitService.UpdateVeterinaryVisit(updatedVeterinaryVisit);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetVeterinaryVisitDto>>>> Delete(int id)
        {
            var response = await _veterinaryVisitService.DeleteVeterinaryVisit(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
