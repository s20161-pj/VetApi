
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.DataAccess.Models;
using VetApp.Model.Client;
using VetApp.Repository.Interfaces;

namespace VetApp.Repository.Repository
{
    public class ClientRepository : IClientRepository
    {
        public MainContext Context { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;
        public ClientRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task AddClientAsync(AddClientDto newClient)
        {
            Client client = _mapper.Map<Client>(newClient);
            _mainContext.Clients.Add(client);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(int id)
        {
            Client client = await _mainContext.Clients.FirstAsync(c => c.Id == id);
            _mainContext.Clients.Remove(client);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<GetClientDto>> GetAllClientsAsync()
        {
            var dbClients = await _mainContext.Clients.ToListAsync();
            return dbClients.Select(e => _mapper.Map<GetClientDto>(e)).ToList();
        }

        public async Task<GetClientDto> GetClientByIdAsync(int id)
        {
            var dbClient = await _mainContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetClientDto>(dbClient);
        }
        public async Task DeleteClinicAsync(int id)
        {
            Clinic clinic = await _mainContext.Clinics.FirstAsync(c => c.Id == id);
            _mainContext.Clinics.Remove(clinic);
            await _mainContext.SaveChangesAsync();
        }
    }
}

