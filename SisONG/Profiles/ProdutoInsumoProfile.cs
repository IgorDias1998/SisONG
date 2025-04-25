using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class ProdutoInsumoProfile : Profile
    {
        public ProdutoInsumoProfile()
        {
            CreateMap<ProdutoInsumo, ProdutoInsumoReadDto>();
            CreateMap<ProdutoInsumoCreateDto, ProdutoInsumo>();
            CreateMap<ProdutoInsumoUpdateDto, ProdutoInsumo>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
