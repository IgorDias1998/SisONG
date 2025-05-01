using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<Relatorio, RelatorioReadDto>();
            CreateMap<RelatorioCreateDto, Relatorio>();
            CreateMap<RelatorioUpdateDto, Relatorio>();

            // Novo mapeamento: RelatorioRequestDto para Relatorio
            CreateMap<RelatorioRequestDto, Relatorio>()
                .ForMember(dest => dest.DataGeracao, opt => opt.Ignore()) // Ignorar porque é gerado no momento
                .ForMember(dest => dest.Conteudo, opt => opt.Ignore())    // Conteúdo será preenchido dinamicamente
                .ForMember(dest => dest.Id, opt => opt.Ignore());         // ID gerado pelo banco
        }
    }
}
