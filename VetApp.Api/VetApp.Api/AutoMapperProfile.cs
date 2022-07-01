using AutoMapper;
using VetApp.Api.Dtos.Vet;
using VetApp.DataAccess.Models;
using VetApp.Model.Client;
using VetApp.Model.Clinic;
using VetApp.Model.Pet;
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
            CreateMap<Client, GetClientDto>();
            CreateMap<AddClinicDto, Clinic>();
            CreateMap<AddClientDto, Client>();
            CreateMap<AddSpecializationDto, Specialization>();
            CreateMap<GetSpecializationDto, Specialization>();
            CreateMap<AddPetDto, Pet>();
            CreateMap<GetPetDto, Pet>();

        }
    }
}
