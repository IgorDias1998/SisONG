using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class DoacaoProfile : Profile
    {
        public DoacaoProfile()
        {
            CreateMap<Doacao, DoacaoReadDto>();
            CreateMap<DoacaoCreateDto, Doacao>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data ?? DateTime.Now));
            CreateMap<DoacaoUpdateDto, Doacao>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
