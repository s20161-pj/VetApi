
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.DataAccess.Models;
using VetApp.Model.Pet;
using VetApp.Repository.Interfaces;

namespace VetApp.Repository.Repository
{
    public class PetRepository : IPetRepository
    {
        public MainContext Context { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;
        public PetRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task AddPetAsync(AddPetDto newPet)
        {
            Pet pet = _mapper.Map<Pet>(newPet);
            _mainContext.Pets.Add(pet);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeletePetAsync(int id)
        {
            Pet pet = await _mainContext.Pets.FirstAsync(p => p.Id == id);
            _mainContext.Pets.Remove(pet);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<GetPetDto>> GetAllPetsAsync()
        {
            var dbPets= await _mainContext.Pets.ToListAsync();
            return dbPets.Select(e => _mapper.Map<GetPetDto>(e)).ToList();
        }

        public async Task<GetPetDto> GetPetByIdAsync(int id)
        {
            var dbPet = await _mainContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<GetPetDto>(dbPet);
        }
    }
}
