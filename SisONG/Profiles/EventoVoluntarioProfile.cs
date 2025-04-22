using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class EventoVoluntarioProfile : Profile
    {
        public EventoVoluntarioProfile()
        {
            CreateMap<EventoVoluntarioCreateDto, EventoVoluntario>();
            CreateMap<EventoVoluntario, EventoVoluntarioReadDto>()
                .ForMember(dest => dest.EventoTitulo, opt => opt.MapFrom(src => src.Evento.Titulo))
                .ForMember(dest => dest.VoluntarioNome, opt => opt.MapFrom(src => src.Voluntario.Nome));
        }
    }
}
