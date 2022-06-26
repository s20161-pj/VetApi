using AutoMapper;
using VetApp.Api.Dtos.Vet;
using VetApp.DataAccess.Models;
using VetApp.Model.Clinic;
using VetApp.Model.Specialization;
using VetApp.Model.Vet;

namespace VetApp.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vet, GetVetDto>();
            CreateMap<AddVetDto, Vet>();
            CreateMap<Clinic, GetClinicDto>();
            CreateMap<AddClinicDto, Clinic>();
            CreateMap<AddSpecializationDto, Specialization>();
        }
    }
}
