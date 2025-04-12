using SisONG.DTOs;
using SisONG.Models;
using AutoMapper;

namespace SisONG.Profiles
{
    public class VoluntarioProfile : Profile
    {
        public VoluntarioProfile()
        {
            CreateMap<Voluntario, VoluntarioReadDto>();
            CreateMap<VoluntarioCreateDto, Voluntario>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "Voluntario"));
            CreateMap<VoluntarioUpdateDto, Voluntario>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
