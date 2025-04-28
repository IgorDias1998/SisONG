using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Profiles
{
    public class TransacaoFinanceiraProfile : Profile
    {
        public TransacaoFinanceiraProfile()
        {
            CreateMap<TransacaoFinanceiraCreateDto, TransacaoFinanceira>();
            CreateMap<TransacaoFinanceiraUpdateDto, TransacaoFinanceira>();
            CreateMap<TransacaoFinanceira, TransacaoFinanceiraReadDto>();
        }
    }
}
