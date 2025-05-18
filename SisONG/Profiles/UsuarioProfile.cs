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

            // Map base class
            CreateMap<Usuario, UsuarioCompletoReadDto>()
                .Include<Voluntario, UsuarioCompletoReadDto>()
                .Include<Doador, UsuarioCompletoReadDto>()
                .Include<Administrador, UsuarioCompletoReadDto>();

            // Subclass mappings
            CreateMap<Voluntario, UsuarioCompletoReadDto>();
            CreateMap<Doador, UsuarioCompletoReadDto>();
            CreateMap<Administrador, UsuarioCompletoReadDto>();
        }
    }
}
