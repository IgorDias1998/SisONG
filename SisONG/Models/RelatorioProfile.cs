using AutoMapper;
using SisONG.DTOs;

namespace SisONG.Models
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<Relatorio, RelatorioReadDto>();
            CreateMap<RelatorioCreateDto, Relatorio>();
            CreateMap<RelatorioUpdateDto, Relatorio>();
        }
    }
}
