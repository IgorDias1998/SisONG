using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }

    }
}
