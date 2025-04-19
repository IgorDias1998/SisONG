using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class AdministradorProfile : Profile
    {
        public AdministradorProfile()
        {
            CreateMap<Administrador, AdministradorReadDto>();
            CreateMap<AdministradorCreateDto, Administrador>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "Administrador"));
            CreateMap<AdministradorUpdateDto, Administrador>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
