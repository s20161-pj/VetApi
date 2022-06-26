using Microsoft.AspNetCore.Mvc;
using VetApp.Model;
using VetApp.Model.Client;
using VetApp.Services.Interfaces;

namespace VetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("GetAllClients")]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> Get()
        {
            return Ok(await _clientService.GetAllClients());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClientDto>>> GetClientById(int id)
        {
            return Ok(await _clientService.GetClientById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetClientDto>>>> AddClinic(AddClientDto newClinic)
        {
            return Ok(await _clientService.AddClient(newClinic));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetClientDto>>>> Delete(int id)
        {
            var response = await _clientService.DeleteClient(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
