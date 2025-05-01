using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class NotificacaoProfile : Profile
    {
        public NotificacaoProfile()
        {
            CreateMap<Notificacao, NotificacaoReadDto>();
            CreateMap<NotificacaoCreateDto, Notificacao>();
            CreateMap<NotificacaoUpdateDto, Notificacao>();
        }
    }
}
