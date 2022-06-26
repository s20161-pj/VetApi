using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.DataAccess.Models;
using VetApp.Model.VeterinaryVisit;
using VetApp.Repository.Interfaces;

namespace VetApp.Repository.Repository
{
    public class VeterinaryVisitRepository : IVeterinaryVisitRepository
    {
        public MainContext Contex { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;

        public VeterinaryVisitRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task AddVeterinaryVisitAsync(AddVeterinaryVisitDto newVeterinaryVisit)
        {
            VeterinaryVisit veterinaryVisit = _mapper.Map<VeterinaryVisit>(newVeterinaryVisit);
            _mainContext.VeterinaryVisits.Add(veterinaryVisit);
            await _mainContext.SaveChangesAsync();
        }

        public async Task DeleteVeterinaryVisitAsync(int id)
        {
            VeterinaryVisit veterinaryVisit = await _mainContext.VeterinaryVisits.FirstOrDefaultAsync(veterinaryVisit => veterinaryVisit.Id == id);
            _mainContext.VeterinaryVisits.Remove(veterinaryVisit);
            await _mainContext.SaveChangesAsync();
        }

        public async Task<List<GetVeterinaryVisitDto>> GetAllVeterinaryVisitsAsync()
        {
            var dbVeterinaryVisits = await _mainContext.VeterinaryVisits.ToListAsync();
            return dbVeterinaryVisits.Select(e => _mapper.Map<GetVeterinaryVisitDto>(e)).ToList();
        }

        public async Task<GetVeterinaryVisitDto> GetVeterinaryVisitByIdAsync(int id)
        {
            
            var dbVeterinaryVisit = await _mainContext.VeterinaryVisits.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetVeterinaryVisitDto>(dbVeterinaryVisit);
        }

        public async Task<GetVeterinaryVisitDto> UpdateVeterinaryVisitAsync(UpdateVeterinaryVisitDto updatedVeterinaryVisit)
        {
            VeterinaryVisit veterinaryVist = await _mainContext.VeterinaryVisits.FirstAsync(v => v.Id == updatedVeterinaryVisit.Id);

            veterinaryVist.Class = updatedVeterinaryVisit.TypeOfVisit;
            veterinaryVist.DateOfVisit = updatedVeterinaryVisit.DateOfVisit;
            veterinaryVist.VetId = updatedVeterinaryVisit.VetId;
            veterinaryVist.ClientId = updatedVeterinaryVisit.ClientId;
     
            await _mainContext.SaveChangesAsync();
            return _mapper.Map<GetVeterinaryVisitDto>(veterinaryVist);
        }
    }
}
