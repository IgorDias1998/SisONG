using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class PontoColetaProfile : Profile
    {
        public PontoColetaProfile()
        {
            CreateMap<PontoColeta, PontoColetaReadDto>();
            CreateMap<PontoColetaCreateDto, PontoColeta>();
            CreateMap<PontoColetaUpdateDto, PontoColeta>();
        }
    }
}
