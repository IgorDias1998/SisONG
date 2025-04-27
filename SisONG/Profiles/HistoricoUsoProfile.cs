using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class HistoricoUsoProfile : Profile
    {
        public HistoricoUsoProfile()
        {
            CreateMap<HistoricoUso, HistoricoUsoDto>();
            CreateMap<HistoricoUsoCreateDto, HistoricoUso>();
        }
    }
}
