using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Model.Client;

namespace VetApp.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<GetClientDto>> GetAllClientsAsync();
        Task<GetClientDto> GetClientByIdAsync(int id);
        Task AddClientAsync(AddClientDto newClient);
        Task DeleteClientAsync(int id);
    }
}
