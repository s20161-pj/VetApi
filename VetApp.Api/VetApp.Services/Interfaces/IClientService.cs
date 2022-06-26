using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Model;
using VetApp.Model.Client;

namespace VetApp.Services.Interfaces
{
    public interface IClientService
    {
        Task<ServiceResponse<List<GetClientDto>>> GetAllClients();
        Task<ServiceResponse<GetClientDto>> GetClientById(int id);
        Task<ServiceResponse<bool>> AddClient(AddClientDto newClient);
        Task<ServiceResponse<bool>> DeleteClient(int id);
    }
}
