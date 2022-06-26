
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.DataAccess.Models;
using VetApp.Model.Specialization;
using VetApp.Repository.Interfaces;

namespace VetApp.Repository.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public MainContext Context { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;
        public SpecializationRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task AddSpecializationAsync(AddSpecializationDto newSpecialization)
        {
            Specialization specialization = _mapper.Map<Specialization>(newSpecialization);
            _mainContext.Specializations.Add(specialization);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteSpecializationAsync(int id)
        {
            Specialization specialization = await _mainContext.Specializations.FirstAsync(s => s.Id == id);
            _mainContext.Specializations.Remove(specialization);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<GetSpecializationDto>> GetAllSpecializationsAsync()
        {
            var dbSpecializations = await _mainContext.Specializations.ToListAsync();
            return dbSpecializations.Select(e => _mapper.Map<GetSpecializationDto>(e)).ToList();
        }
        public async Task<GetSpecializationDto> GetSpecializationByIdAsync(int id)
        {
            var dbSpecialization = await _mainContext.Specializations.FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<GetSpecializationDto>(dbSpecialization);
        }
    }
}
