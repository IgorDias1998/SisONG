using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class DoadorProfile : Profile
    {
        public DoadorProfile()
        {
            CreateMap<Doador, DoadorReadDto>();
            CreateMap<DoadorCreateDto, Doador>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => "Doador"));
            CreateMap<DoadorUpdateDto, Doador>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
