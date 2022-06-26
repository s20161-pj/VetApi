using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetApp.Api.Context;
using VetApp.DataAccess.Models;
using VetApp.Model.Clinic;
using VetApp.Repository.Interfaces;

namespace VetApp.Repository.Repository
{
    public class ClinicRepository : IClinicRepository
    {
        public MainContext Context { get; private set; }

        private readonly MainContext _mainContext;
        private readonly IMapper _mapper;
        public ClinicRepository(IMapper mapper, MainContext context)
        {
            _mainContext = context;
            _mapper = mapper;
        }
        public async Task AddClinicAsync(AddClinicDto newClinic)
        {
            Clinic clinic = _mapper.Map<Clinic>(newClinic);
            _mainContext.Clinics.Add(clinic);
            await _mainContext.SaveChangesAsync();
        }
        public async Task<List<GetClinicDto>> GetAllClinicsAsync()
        {
            var dbClinics = await _mainContext.Clinics.ToListAsync();
            return dbClinics.Select(e => _mapper.Map<GetClinicDto>(e)).ToList();
        }

        public async Task<GetClinicDto> GetClinicByIdAsync(int id)
        {

            var dbClinic = await _mainContext.Clinics.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GetClinicDto>(dbClinic);
        }
        public async Task DeleteClinicAsync(int id)
        {
            Clinic clinic = await _mainContext.Clinics.FirstAsync(c => c.Id == id);
            _mainContext.Clinics.Remove(clinic);
            await _mainContext.SaveChangesAsync();
        }
    }
}