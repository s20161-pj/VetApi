using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;

namespace VetApp.Api.Repository
{
    public class VetRepository : IVetRepository
    {
        public MainContext Context { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;
        public VetRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task<List<GetVetDto>> GetAllVetsAsync()
        {
            var dbVets = await _mainContext.Vets.ToListAsync();
            return dbVets.Select(e => _mapper.Map<GetVetDto>(e)).ToList();
        }
        public async Task<GetVetDto> GetVetByIdAsync(int id)
        {

            var dbVet = await _mainContext.Vets.FirstOrDefaultAsync(v => v.Id == id);
            return _mapper.Map<GetVetDto>(dbVet);
        }
        public async Task AddVetAsync(AddVetDto newVet)
        {
            Vet vet = _mapper.Map<Vet>(newVet);
            _mainContext.Vets.Add(vet);
            await _mainContext.SaveChangesAsync();
        }
        public async Task<GetVetDto> UpdateVetAsync(UpdateVetDto updatedVet)
        {

            Vet vet = await _mainContext.Vets.FirstAsync(v => v.Id == updatedVet.Id);

            vet.Name = updatedVet.Name;
            vet.Surname = updatedVet.Surname;
            vet.OccupationNumber = updatedVet.OccupationNumber;
            vet.ClinicId = updatedVet.ClinicId;

            await _mainContext.SaveChangesAsync();
            return _mapper.Map<GetVetDto>(vet);

        }
        public async Task DeleteVetAsync(int id)
        {
            Vet vet = await _mainContext.Vets.FirstAsync(c => c.Id == id);
            _mainContext.Vets.Remove(vet);
            await _mainContext.SaveChangesAsync();
        }
    }
}