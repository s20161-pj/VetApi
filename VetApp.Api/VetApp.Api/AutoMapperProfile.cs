using AutoMapper;
using VetApp.Api.Dtos.Vet;
using VetApp.Api.Models;

namespace VetApp.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vet, GetVetDto>();
            CreateMap<AddVetDto, Vet>();
        }
    }
}
